using BulkyDataAccess.Repository.IRepository;
using BulkyModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _catRepo;
        public CategoryController(ICategoryRepository catRepo)
        {
            _catRepo = catRepo;
        }
        public IActionResult Index()
        {
            List<Category> list = _catRepo.GetAll().ToList();
            return View(list);
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == "test")
            {
                ModelState.AddModelError("name", "Invalid Name.");
            }
            if(ModelState.IsValid)
            {
                _catRepo.Add(obj);
                _catRepo.Save();
                TempData["success"] = "Category Created Successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id) {
            if (id == null || id == 0)
                return NotFound();

            Category cat = _catRepo.GetFirstOrDefault(x => x.Id == id);

            if (cat == null)
                return NotFound();

            return View(cat);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _catRepo.Update(obj);
                _catRepo.Save();

                TempData["success"] = "Category Updated Successfully.";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Category cat = _catRepo.GetFirstOrDefault(x => x.Id == id);

            if (cat == null)
                return NotFound();
            else
                _catRepo.Remove(cat);

                _catRepo.Save();

        TempData["success"] = "Category Deleted Successfully.";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Category cat = _catRepo.GetFirstOrDefault(x => x.Id == id);

            if (cat == null)
                return NotFound();

            return View(cat);
        }
    }
}
