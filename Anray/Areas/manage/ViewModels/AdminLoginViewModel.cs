using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Anray.Areas.manage.ViewModels
{
    public class AdminLoginViewModel
    {
        [StringLength(maximumLength: 50)]
        public string UserName { get; set;}
        [DataType(DataType.Password)]
        [StringLength(maximumLength:20,MinimumLength =8)]
        public string Password { get; set;}
    }
}
