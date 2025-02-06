using CourseProject.Data;
using CourseProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CourseProject.Controllers
{
    [Authorize] // Только аутентифицированные пользователи могут управлять шаблонами
    public class TemplateController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TemplateController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // 🟢 [GET] /Template/Index
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var templates = await _context.Templates
                .Where(t => t.AuthorId == userId)
                .ToListAsync();
            return View(templates);
        }

        // 🟢 [GET] /Template/Create
        public IActionResult Create()
        {
            return View();
        }

        // 🟢 [POST] /Template/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Template template)
        {
            if (!ModelState.IsValid)
            {
                return View(template);
            }

            template.AuthorId = _userManager.GetUserId(User);
            _context.Templates.Add(template);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // 🟢 [GET] /Template/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var template = await _context.Templates.FindAsync(id);
            if (template == null || template.AuthorId != _userManager.GetUserId(User))
            {
                return NotFound();
            }
            return View(template);
        }

        // 🟢 [POST] /Template/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Template template)
        {
            if (!ModelState.IsValid)
            {
                return View(template);
            }

            var existingTemplate = await _context.Templates.FindAsync(template.Id);
            if (existingTemplate == null || existingTemplate.AuthorId != _userManager.GetUserId(User))
            {
                return NotFound();
            }

            existingTemplate.Title = template.Title;
            existingTemplate.Description = template.Description;
            existingTemplate.Topic = template.Topic;
            existingTemplate.IsPublic = template.IsPublic;

            _context.Templates.Update(existingTemplate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // 🟢 [POST] /Template/Delete/{id}
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var template = await _context.Templates.FindAsync(id);
            if (template == null || template.AuthorId != _userManager.GetUserId(User))
            {
                return NotFound();
            }

            _context.Templates.Remove(template);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
