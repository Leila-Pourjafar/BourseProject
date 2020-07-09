using Bourse.DAL;
using Bourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bourse.Controllers
{

    public class EmployeesController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private BLL.IUserBusiness userService;
        private LogManeger.ILog loger;
        // GET: Home
        public EmployeesController()
        {
            this.userService = new BLL.UserBusiness();
            this.loger = new LogManeger.Utility();
        }
        public ActionResult Employees()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        [ActionFilters.Log]
        public ActionResult ShowData()
        {
            return View();
        }

        [ActionFilters.Log]
        public JsonResult ListData()
        {
            try
            {
                var data = userService.GetInfo(1);
                loger.Log(LogManeger.LogLevel.Info, this.GetType(), "test");
                return Json(data, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                loger.Log(LogManeger.LogLevel.Error, this.GetType(), ex.Message);
                throw;
            }
        }
        public JsonResult List()
        {
            return Json(unitOfWork.EmployeeRepository.Get(), JsonRequestBehavior.AllowGet);
        }
        //[ValidateAntiForgeryToken]
        public JsonResult Add(Employee emp)
        {
            unitOfWork.EmployeeRepository.Insert(emp);
            unitOfWork.Save();
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Employee = unitOfWork.EmployeeRepository.GetByID(ID);
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Employee emp)
        {
            unitOfWork.EmployeeRepository.Update(emp);
            unitOfWork.Save();
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            unitOfWork.EmployeeRepository.Delete(ID);
            unitOfWork.Save();
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}