﻿using ExamSys.Data;
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
            var scoreType = Convert.ToInt32(Request.Form["scoreType"].ToString());

            using (ExamSysEntities entity = new ExamSysEntities())
            {
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
                q.Score = scoreType;

                entity.Questions.Add(q);
                entity.SaveChanges();
            }
        }

        [HttpPost]
        public string UpdateQ()
        {
            try
            {
                var ID = new Guid(Request.Form["ID"].ToString());
                var title = Request.Form["title"].ToString();
                var content = Request.Form["content"].ToString();
                var answer = Request.Form["answer"].ToString();

                using (ExamSysEntities entity = new ExamSysEntities())
                {
                    var question = entity.Questions.FirstOrDefault(q => q.ID == ID);
                    if (question != null)
                    {
                        entity.SaveChanges();
                        return "Y";
                    }
                    else
                        return "N";
                }
            }
            catch (Exception ex)
            {
                return "N";
            }
        }

        public JsonResult GetQuestions(int subjecttypeid, int employeetypeid)
        {
            int pagesize = Convert.ToInt32(Request.QueryString["pagesize"]);
            int pagenum = Convert.ToInt32(Request.QueryString["pagenum"]);
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
            var questions = totalResult.ToList();
            //var questions = totalResult.OrderBy(re => re.ID).Skip(pagesize * pagenum).Take(pagesize).ToList();
            var result = new
            {
                TotalRows = totalCount,
                Rows = questions
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}