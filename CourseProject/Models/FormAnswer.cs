using System;

namespace CourseProject.Models
{
    public class FormAnswer
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string AnswerText { get; set; }  // Ответ (для текстовых полей)
        public int? AnswerInt { get; set; }  // Ответ (для числовых полей)
        public bool? AnswerCheckbox { get; set; }  // Ответ (для чекбоксов)

        public Guid FieldId { get; set; }
        public TemplateField Field { get; set; }

        public Guid FormId { get; set; }
        public Form Form { get; set; }
    }
}