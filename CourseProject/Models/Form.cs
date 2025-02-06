using System;
using System.Collections.Generic;

namespace CourseProject.Models
{
    public class Form
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }  // Кто заполнил форму
        public ApplicationUser User { get; set; }

        public Guid TemplateId { get; set; }
        public Template Template { get; set; }

        // Ответы на вопросы
        public List<FormAnswer> Answers { get; set; } = new();
    }
}