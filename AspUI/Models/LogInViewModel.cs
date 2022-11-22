using Microsoft.Build.Framework;

namespace AspUI.Models
{
    public class LogInViewModel
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
    }
}
