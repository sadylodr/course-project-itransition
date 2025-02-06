using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CourseProject.Models;

namespace CourseProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Template> Templates { get; set; }
        public DbSet<TemplateField> TemplateFields { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormAnswer> FormAnswers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Уникальный лайк (один пользователь – один лайк на один шаблон)
            builder.Entity<Like>()
                .HasIndex(l => new { l.UserId, l.TemplateId })
                .IsUnique();

            // Полнотекстовый поиск в PostgreSQL
            builder.Entity<Template>()
                .Ignore(t => t.SearchVector); // Убираем ошибку "Cannot resolve symbol 'SearchVector'"
        }
    }
}