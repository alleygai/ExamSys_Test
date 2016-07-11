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
        public FileResult Download(string subjectType, string employeeType)
        {
            var filepath = GenerateExamFile(subjectType, employeeType);
            return File(filepath, MimeMapping.GetMimeMapping(filepath), "试卷.doc");
        }

        private string GenerateExamFile(string subjectType, string employeeType)
        {
            string filePath = @"C:\Work\Words\" + Guid.NewGuid().ToString() + ".doc";

            var doc = DocX.Create(filePath);
            doc.InsertParagraph("This is my first paragraph");
            doc.Save();

            return filePath;
        }
    }
}