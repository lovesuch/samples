using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required] public string Name { get; set; }

        [Required] public string Mobile { get; set; }

        [Required] public string Password { get; set; }
    }
}