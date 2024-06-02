using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModels.Models;
using BulkyBookModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> list = _unitOfWork.productRepository.GetAll().ToList();           
            return View(list);
        }

        public IActionResult Create()
        {
            //ViewBag.CategoryList = CategoryList;
            //ViewData["CategoryList"] = CategoryList;
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.categoryRepository.GetAll().Select(u => new SelectListItem()
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };

            return View(productVM);
        }
        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.productRepository.Add(productVM.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product Created Successfully.";
                return RedirectToAction("Index");
            }
            else {
                productVM.CategoryList = _unitOfWork.categoryRepository.GetAll().Select(u => new SelectListItem()
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(productVM);
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Product cat = _unitOfWork.productRepository.GetFirstOrDefault(x => x.Id == id);

            if (cat == null)
                return NotFound();

            return View(cat);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.productRepository.Update(obj);
                _unitOfWork.Save();

                TempData["success"] = "Product Updated Successfully.";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Product cat = _unitOfWork.productRepository.GetFirstOrDefault(x => x.Id == id);

            if (cat == null)
                return NotFound();
            else
                _unitOfWork.productRepository.Remove(cat);

            _unitOfWork.Save();

            TempData["success"] = "Product Deleted Successfully.";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Product cat = _unitOfWork.productRepository.GetFirstOrDefault(x => x.Id == id);

            if (cat == null)
                return NotFound();

            return View(cat);
        }
    }
}
