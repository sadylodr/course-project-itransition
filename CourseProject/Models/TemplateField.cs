using System;
using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models
{
    public class TemplateField
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; }  // Вопрос

        public string Description { get; set; }  // Доп. описание вопроса

        [Required]
        public string FieldType { get; set; }  // Text, Integer, Checkbox

        public bool ShowInResults { get; set; } = false;  // Показывать в таблице результатов?

        public int Position { get; set; }  // Для Drag'n'Drop сортировки

        // Связь с шаблоном
        public Guid TemplateId { get; set; }
        public Template Template { get; set; }
    }
}