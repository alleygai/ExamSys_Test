using ExamSys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamSys.Controllers
{
    public class QuestionsController : BaseController
    {
        [HttpPost]
        public void AddQ()
        {
            var title = Request.Form["title"].ToString();
            var content = Request.Form["content"].ToString();
            var answer = Request.Form["answer"].ToString();
            var subjectType = Convert.ToInt32(Request.Form["subjectType"].ToString());
            var employeeType = Convert.ToInt32(Request.Form["employeeType"].ToString());

            Questions q = new Questions();
            q.ID = Guid.NewGuid();
            q.Title = title;
            q.Content = content;
            q.Answer = answer;
            q.SubjectTypeID = subjectType;
            q.EmployeeTypeID = employeeType;
            q.IsDelete = false;
            q.CreateTime = DateTime.Now;
            q.LastUpdateTime = DateTime.Now;


            using (ExamSysEntities entity = new ExamSysEntities())
            {

                entity.Questions.Add(q);
                entity.SaveChanges();
            }
        }

        public JsonResult GetQuestions(int pagesize, int pagenum, int subjecttypeid, int employeetypeid)
        {
            ExamSysEntities entity = new ExamSysEntities();
            var totalResult = from item in entity.Questions
                              where item.SubjectTypeID == subjecttypeid &&
                                    item.EmployeeTypeID == employeetypeid
                              select new
                              {
                                  ID = item.ID,
                                  Answer = item.Answer,
                                  Content = item.Content,
                                  Title = item.Title
                              };
            var totalCount = totalResult.Count();
            var questions = totalResult.OrderBy(re => re.ID).Skip(pagesize * pagenum).Take(pagesize);
            var result = new
            {
                TotalRows = questions,
                Rows = questions
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}