using Microsoft.AspNetCore.Identity;

namespace CourseProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
        
        public List<Template> Templates { get; set; } = new();
    }
}