using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;

namespace Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;   
        }
        public IActionResult Index()
        {
            var data = _db.productTypes.ToList();
            return View(data);
        }
        //GEt action
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.productTypes.Add(productTypes);
                await _db.SaveChangesAsync();
               return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }


        //GEt action
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var productType = _db.productTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Update(productTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }


        //Details action
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productType = _db.productTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult  Details(ProductTypes productTypes)
        {
                return RedirectToAction(nameof(Index));
        }


        //Delete action
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productType = _db.productTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int? id, ProductTypes productTypes)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != productTypes.Id)
            {
                return NotFound();
            }

            var productType = _db.productTypes.Find(id);
            if(productType == null)
            {
                return NotFound();
            }



            if (ModelState.IsValid)
            {
                _db.Remove(productType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }




    }
}
