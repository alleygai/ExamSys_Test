using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamSys.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            List<SelectListItem> employeeTypeItems = new List<SelectListItem>();
            employeeTypeItems.Add(new SelectListItem { Text = "请选择工种", Value = "0", Selected = true });

            foreach (var item in base.DicHelper.EmployeeType)
            {
                employeeTypeItems.Add(new SelectListItem { Text = item.Name, Value = item.ID.ToString() });
            }
            ViewBag.EmployeeType = employeeTypeItems;

            List<SelectListItem> subjectTypeItems = new List<SelectListItem>();
            subjectTypeItems.Add(new SelectListItem { Text = "请选择题型", Value = "0", Selected = true });

            foreach (var item in base.DicHelper.SubjectType)
            {
                subjectTypeItems.Add(new SelectListItem { Text = item.Name, Value = item.ID.ToString() });
            }
            ViewBag.SubjectType = subjectTypeItems;

            return View();
        }
    }
}