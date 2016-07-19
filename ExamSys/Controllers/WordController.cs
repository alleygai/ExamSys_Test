using ExamSys.Data;
using Novacode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamSys.Controllers
{
    public class WordController : BaseController
    {
        public FileResult Download(string employeeType)
        {
            var filepath = GenerateExamFile(employeeType);
            return File(filepath, MimeMapping.GetMimeMapping(filepath), "试卷.doc");
        }

        /// <summary>
        /// 生成试卷 
        /// 选择题 10 2分
        /// 判断题 20 1分
        /// 填空题 20 1分
        /// 简答题 4  5分
        /// 计算题 4  5分
        /// </summary>
        /// <param name="subjectType"></param>
        /// <param name="employeeType"></param>
        /// <returns></returns>
        private string GenerateExamFile(string employeeType)
        {
            string filePath = @"C:\Work\Words\" + Guid.NewGuid().ToString() + ".doc";

            var doc = DocX.Create(filePath);
            doc.InsertParagraph("内部试卷").Bold().FontSize(18);

            using (ExamSysEntities entity = new ExamSysEntities())
            {
                #region 选择题
                doc.InsertParagraph();
                doc.InsertParagraph("一 选择题").Bold().FontSize(14);
                var all1 = (from item in entity.Questions
                            where item.EmployeeTypeID.ToString() == employeeType
                            && item.SubjectType.STypeName == "选择题"
                            select new
                            {
                                ID = item.ID,
                                Title = item.Title,
                                Content = item.Content,
                                Score = item.Score
                            }).ToList();
                List<Questions> chooseItems = new List<Questions>();
                while (chooseItems.Count < 10)
                {
                    var temp = all1.ElementAt(new Random().Next(all1.Count));
                    if (chooseItems.FirstOrDefault(i => i.ID == temp.ID) == null)
                    {
                        chooseItems.Add(new Questions
                        {
                            ID = temp.ID,
                            Title = temp.Title,
                            Content = temp.Content,
                            Score = temp.Score
                        });
                    }
                }
                foreach (Questions q in chooseItems)
                {
                    doc.InsertParagraph(q.Title);
                    doc.InsertParagraph(q.Content);
                }

                #endregion

                #region 判断题
                doc.InsertParagraph();
                doc.InsertParagraph("二 判断题").Bold().FontSize(14);
                var all2 = (from item in entity.Questions
                            where item.EmployeeTypeID.ToString() == employeeType
                            && item.SubjectType.STypeName == "判断题"
                            select new
                            {
                                ID = item.ID,
                                Title = item.Title,
                                Content = item.Content,
                                Score = item.Score
                            }).ToList();
                List<Questions> judgeItems = new List<Questions>();
                while (judgeItems.Count < 20)
                {
                    var temp = all1.ElementAt(new Random().Next(all2.Count));
                    if (judgeItems.FirstOrDefault(i => i.ID == temp.ID) == null)
                    {
                        judgeItems.Add(new Questions
                        {
                            ID = temp.ID,
                            Title = temp.Title,
                            Content = temp.Content,
                            Score = temp.Score
                        });
                    }
                }
                foreach (Questions q in judgeItems)
                {
                    doc.InsertParagraph(q.Title);
                    doc.InsertParagraph(q.Content);
                }
                #endregion

                #region 填空题
                doc.InsertParagraph();
                doc.InsertParagraph("三 填空题").Bold().FontSize(14);
                var all3 = (from item in entity.Questions
                            where item.EmployeeTypeID.ToString() == employeeType
                            && item.SubjectType.STypeName == "填空题"
                            select new
                            {
                                ID = item.ID,
                                Title = item.Title,
                                Content = item.Content,
                                Score = item.Score
                            }).ToList();
                List<Questions> blankItems = new List<Questions>();
                while (blankItems.Count < 10)
                {
                    var temp = all1.ElementAt(new Random().Next(all3.Count));
                    if (blankItems.FirstOrDefault(i => i.ID == temp.ID) == null)
                    {
                        blankItems.Add(new Questions
                        {
                            ID = temp.ID,
                            Title = temp.Title,
                            Content = temp.Content,
                            Score = temp.Score
                        });
                    }
                }
                foreach (Questions q in blankItems)
                {
                    doc.InsertParagraph(q.Title);
                    doc.InsertParagraph(q.Content);
                }

                #endregion

                #region 计算题
                doc.InsertParagraph();
                doc.InsertParagraph("四 计算题").Bold().FontSize(14);
                var all4 = (from item in entity.Questions
                            where item.EmployeeTypeID.ToString() == employeeType
                            && item.SubjectType.STypeName == "计算题"
                            select new
                            {
                                ID = item.ID,
                                Title = item.Title,
                                Content = item.Content,
                                Score = item.Score
                            }).ToList();
                List<Questions> computeItems = new List<Questions>();
                while (computeItems.Count < 5)
                {
                    var temp = all1.ElementAt(new Random().Next(all4.Count));
                    if (computeItems.FirstOrDefault(i => i.ID == temp.ID) == null)
                    {
                        computeItems.Add(new Questions
                        {
                            ID = temp.ID,
                            Title = temp.Title,
                            Content = temp.Content,
                            Score = temp.Score
                        });
                    }
                }
                foreach (Questions q in computeItems)
                {
                    doc.InsertParagraph(q.Title);
                    doc.InsertParagraph(q.Content);
                }

                #endregion

                #region 简答题
                doc.InsertParagraph();
                doc.InsertParagraph("五 简答题").Bold().FontSize(14);
                var all5 = (from item in entity.Questions
                            where item.EmployeeTypeID.ToString() == employeeType
                            && item.SubjectType.STypeName == "简答题"
                            select new
                            {
                                ID = item.ID,
                                Title = item.Title,
                                Content = item.Content,
                                Score = item.Score
                            }).ToList();
                List<Questions> answerItems = new List<Questions>();
                while (answerItems.Count < 5)
                {
                    var temp = all1.ElementAt(new Random().Next(all4.Count));
                    if (answerItems.FirstOrDefault(i => i.ID == temp.ID) == null)
                    {
                        answerItems.Add(new Questions
                        {
                            ID = temp.ID,
                            Title = temp.Title,
                            Content = temp.Content,
                            Score = temp.Score
                        });
                    }
                }
                foreach (Questions q in answerItems)
                {
                    doc.InsertParagraph(q.Title);
                    doc.InsertParagraph(q.Content);
                }

                #endregion
            }

            doc.Save();

            return filePath;
        }
    }
}