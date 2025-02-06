using System;
using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models
{
    public class Like
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public Guid TemplateId { get; set; }
        public Template Template { get; set; }
    }
}