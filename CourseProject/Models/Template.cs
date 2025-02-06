using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.Models
{
    public class Template
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        public string MarkdownDescription { get; set; }

        [Required]
        public string Topic { get; set; }  // Education, Quiz, Other

        public string ImageUrl { get; set; } // Ссылка на картинку

        public bool IsPublic { get; set; } = false;  // Публичный шаблон?

        public string AuthorId { get; set; }  // Автор шаблона
        public ApplicationUser Author { get; set; }

        // Теги в виде массива строк
        [Column(TypeName = "text[]")]
        public List<string> Tags { get; set; } = new();

        // Поля шаблона (вопросы)
        public List<TemplateField> Fields { get; set; } = new();

        // Заполненные формы
        public List<Form> Forms { get; set; } = new();

        // Комментарии
        public List<Comment> Comments { get; set; } = new();

        // Лайки
        public List<Like> Likes { get; set; } = new();
        
        [Column(TypeName = "tsvector")]
        public string SearchVector { get; set; }
    }
}