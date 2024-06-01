using BulkyWebRazorApp.Data;
using BulkyWebRazorApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazorApp.Pages.Categories
{
    [BindProperties(SupportsGet = true)]
    public class DeleteModel : PageModel
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Category = _db.Categories.Find(Id);
        }

        public IActionResult OnPost() {
            Category obj = _db.Categories.Find(Id);
            if (obj != null)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
