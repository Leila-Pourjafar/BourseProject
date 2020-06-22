using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bourse.DAL;
using Bourse.Models;

namespace Bourse.Controllers
{
    public class ProductsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public JsonResult GetAllProducts()
        {
            return Json(unitOfWork.ProductRepository.Get(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddProduct(Product item)
        {
            unitOfWork.ProductRepository.Insert(item);
            unitOfWork.Save();
            return Json(item, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyID(int ID)
        {
            var ProductR = unitOfWork.ProductRepository.GetByID(ID);
            return Json(ProductR, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditProduct(int id, Product product)
        {
            product.Id = id;
            //if (repository.Update(product))
            //{
            //    return Json(repository.GetAll(), JsonRequestBehavior.AllowGet);
            //}

            //return Json(null);
            unitOfWork.ProductRepository.Update(product);
            unitOfWork.Save();
            return Json(unitOfWork.ProductRepository.Get(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteProduct(int id)
        {

            //if (repository.Delete(id))
            //{
            //    return Json(new { Status = true }, JsonRequestBehavior.AllowGet);
            //}

            //return Json(new { Status = false }, JsonRequestBehavior.AllowGet);

            try
            {
                unitOfWork.ProductRepository.Delete(id);
                unitOfWork.Save();

                return Json(new { Status = true }, JsonRequestBehavior.AllowGet);

            }

            catch (Exception ex)
            {

                return Json(new { Status = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddJoinedHologram()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
