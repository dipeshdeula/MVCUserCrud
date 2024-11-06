using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MVCUserCrud.Models;
using MVCUserCrud.Security;
using MVCUserCrud.Services;

namespace MVCUserCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IDataProtector _protector;
        private readonly MvcuserCrudContext _appContext;
        //for file handling
        private readonly IWebHostEnvironment _env;

        public HomeController(IUserService userService, DataSecurityProvider datakey,
            IDataProtectionProvider provider, MvcuserCrudContext appContext,IWebHostEnvironment env)
        {
            _userService = userService;
            _protector = provider.CreateProtector(datakey.DataSecurityKey);
            _appContext = appContext;
            _env = env;
        }

        public IActionResult Index()
        {
            var users = _userService.GetUsers();
            var userData = users.Select(e => new UserListEdit
            {
                UserId = e.UserId,
                UserName = e.UserName,
                EmailAddress = e.EmailAddress,
                UserAddress = e.UserAddress,
                UserPassword = e.UserPassword,
                UserProfile = e.UserProfile,
                EncId = _protector.Protect(Convert.ToString(e.UserId)),
                UserRole = e.UserRole

            }).ToList();
            return View(userData);
        }

        public IActionResult Details(string id)
        {
            int userEncId = Convert.ToInt32(_protector.Unprotect(id));
            UserList userById = _userService.GetUsersById(userEncId);
            //return Json(userById);
            return View(userById);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserListEdit edit)
        {
            int maxId;
            if (_userService.GetUsers().Any())
            {
                maxId = _userService.GetUsers().Max(x => x.UserId) + 1;

            }
            else
            {
                maxId = 1;
            }
            edit.UserId = maxId;

            //file Handling
            if (edit.UserFile != null)
            { 
                string filename = maxId.ToString()+ Guid.NewGuid() + Path.GetExtension(edit.UserFile.FileName);
                string filePath = Path.Combine(_env.WebRootPath, "UserProfile", filename);
                using (FileStream str = new FileStream(filePath, FileMode.Create))
                {
                    edit.UserFile.CopyTo(str);
                }
                edit.UserProfile = filename;
            }
            //mapping
            UserList u = new()
            { 
                UserId = edit.UserId,
                EmailAddress = edit.EmailAddress,
                UserAddress = edit.UserAddress,
                UserName = edit.UserName,
                UserPassword = edit.UserPassword,
                UserProfile = edit.UserProfile,
                UserRole = edit.UserRole,
                UserStatus = true
            };
            if (u != null)
            {
                _userService.AddUser(u);
                // return Json("Success");
                return Content("success");

            }
            else {

               // return Json("fail");
                return Content("fail");
            }
           
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            int uid = Convert.ToInt32(_protector.Unprotect(id));
            var u = _appContext.UserLists.Where(x=>x.UserId == uid).FirstOrDefault();

            UserListEdit e = new()
            {
                UserId = u.UserId,
                UserName = u.UserName,
                UserPassword = u.UserPassword,
                EmailAddress = u.EmailAddress,
                UserAddress = u.UserAddress,
                UserProfile = u.UserProfile,
                UserRole = u.UserRole,
                UserStatus = u.UserStatus,

               

            };
            ViewData["psw"] = u.UserPassword;
            return View(e);
        
        }

        [HttpPost]
        public IActionResult Edit(UserListEdit edit)
        {
            //file Handling for updation
            if (edit.UserFile != null)
            {
                string filename = "UpdatedImage" + Guid.NewGuid() + Path.GetExtension(edit.UserFile.FileName);
                string filePath = Path.Combine(_env.WebRootPath, "UserProfile", filename);
                using (FileStream str = new FileStream(filePath, FileMode.Create))
                {
                    edit.UserFile.CopyTo(str);
                }
                edit.UserProfile = filename;
            }
            //mapping
            UserList u = new()
            {
                UserId = edit.UserId,
                EmailAddress = edit.EmailAddress,
                UserAddress = edit.UserAddress,
                UserName = edit.UserName,
                UserPassword = edit.UserPassword,
                UserProfile = edit.UserProfile,
                UserRole = edit.UserRole,
                UserStatus = true
            };
            _userService.UpdateUser(u);
            return Json(edit);

        }
    }
}
