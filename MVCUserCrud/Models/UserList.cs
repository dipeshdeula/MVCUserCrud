using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCUserCrud.Models;

public partial class UserList
{
    public int UserId { get; set; }

    [Display(Name = "Name")]
    [Required(ErrorMessage = "Name is required")]

    public string UserName { get; set; } = null!;


    public string UserPassword { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string UserProfile { get; set; } = null!;

    public string UserAddress { get; set; } = null!;

    public string UserRole { get; set; } = null!;

    public bool UserStatus { get; set; }
}
