using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToysApplication.Commands;
using ToysApplication.DTO;
using ToysApplication.Exceptions;
using ToysApplication.Searches;
using ToysEfDataAccess;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToysMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ToysContext _context;
        private readonly ICreateCategoryCommand _createCategory;
        private readonly IGetCategoryCommand _getCategory;
        private readonly IEditCategoryCommand _editCategory;
        private readonly IGetOneCategoryCommand _getOneCategory;

        public CategoryController(ToysContext context, ICreateCategoryCommand createCategory, IGetCategoryCommand getCategory, IEditCategoryCommand editCategory)
        {
            _context = context;
            _createCategory = createCategory;
            _getCategory = getCategory;
            _editCategory = editCategory;
        }

        // GET: /<controller>/
        public IActionResult Index(CategorySearches searches)
        {
            var result = _getCategory.Execute(searches);
            return View(result);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var dto = _getOneCategory.Execute(id);
                return View(dto);
            }
            catch (Exception)
            {
                return View();
            }
        }


        // GET: Category/Create
        public ActionResult Create()
        {
          
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["greska"] = "Doslo je do greske pri unosu";
                RedirectToAction("create");
            }

            try
            {
                _createCategory.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException ex)
            {
                TempData["greska"] = ex.Message;

            }
            catch (Exception e)
            {
                TempData["greska"] = "Doslo je do greske.";
            }
            return View();
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
        
            try
            {
                var dto = _getOneCategory.Execute(id);
                return View(dto);
            }
            catch (Exception)
            {

                return RedirectToAction("index");
            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateCategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                _editCategory.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException)
            {
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException)
            {
                TempData["error"] = "Proizvod sa istim imenom vec postoji.";
                return View(dto);
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
