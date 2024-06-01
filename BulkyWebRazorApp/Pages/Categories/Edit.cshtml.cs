using BulkyBookWebRazorApp.Data;
using BulkyBookWebRazorApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyBookWebRazorApp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        public Category Category { get; set; }

        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public void OnGet(int? id)
        {
            if(id != null)
                Category = _db.Categories.Find(id);
        }

        public IActionResult OnPost()
        {
            if (Category != null && ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}
