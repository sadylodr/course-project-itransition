using System;
using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models
{
    public class Comment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public Guid TemplateId { get; set; }
        public Template Template { get; set; }
    }
}