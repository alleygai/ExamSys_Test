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

            List<SelectListItem> scoreTypeItems = new List<SelectListItem>();
            scoreTypeItems.Add(new SelectListItem { Text = "请选择分数", Value = "0", Selected = true });
            scoreTypeItems.Add(new SelectListItem { Text = "1", Value = "1" });
            scoreTypeItems.Add(new SelectListItem { Text = "2", Value = "2" });
            scoreTypeItems.Add(new SelectListItem { Text = "3", Value = "3" });
            scoreTypeItems.Add(new SelectListItem { Text = "4", Value = "4" });
            scoreTypeItems.Add(new SelectListItem { Text = "5", Value = "5" });
            ViewBag.ScoreType = scoreTypeItems;

            return View();
        }
    }
}