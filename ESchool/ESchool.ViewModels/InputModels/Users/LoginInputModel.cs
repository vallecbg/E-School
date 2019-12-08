using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ESchool.ViewModels.Constants;

namespace ESchool.ViewModels.InputModels.Users
{
    public class LoginInputModel
    {
        [Required]
        [StringLength(ViewModelsConstants.UserModelNameMaxLength, MinimumLength = ViewModelsConstants.UserModelNameMinLength)]
        [RegularExpression(ViewModelsConstants.RegexValidateUsername, ErrorMessage = ViewModelsConstants.ErrorMessageUsernameRegisterModel)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
