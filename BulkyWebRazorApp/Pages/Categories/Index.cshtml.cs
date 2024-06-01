using BulkyWebRazorApp.Data;
using BulkyWebRazorApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazorApp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        public List<Category> CategoryList { get; set; }
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
