using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> list = _unitOfWork.categoryRepository.GetAll().ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == "test")
            {
                ModelState.AddModelError("name", "Invalid Name.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.categoryRepository.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Created Successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Category cat = _unitOfWork.categoryRepository.GetFirstOrDefault(x => x.Id == id);

            if (cat == null)
                return NotFound();

            return View(cat);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.categoryRepository.Update(obj);
                _unitOfWork.Save();

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

            Category cat = _unitOfWork.categoryRepository.GetFirstOrDefault(x => x.Id == id);

            if (cat == null)
                return NotFound();
            else
                _unitOfWork.categoryRepository.Remove(cat);

            _unitOfWork.Save();

            TempData["success"] = "Category Deleted Successfully.";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Category cat = _unitOfWork.categoryRepository.GetFirstOrDefault(x => x.Id == id);

            if (cat == null)
                return NotFound();

            return View(cat);
        }
    }
}
