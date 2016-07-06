using ExamSys.Data;
using ExamSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamSys
{
    public class DicHelper
    {
        private IList<EmployeeTypeModel> mEmployeeType;
        public IList<EmployeeTypeModel> EmployeeType
        {
            get
            {
                if (mEmployeeType == null)
                {
                    using (ExamSysEntities entity = new ExamSysEntities())
                    {
                        mEmployeeType = (from m in entity.EmployeeType
                                         select new EmployeeTypeModel
                                         {
                                             ID = m.ID,
                                             Type = m.EType,
                                             Name = m.ETypeName
                                         }).ToList();
                    }
                    if (mEmployeeType == null)
                    {
                        mEmployeeType = new List<EmployeeTypeModel>();
                    }
                }
                return mEmployeeType;
            }
        }

        private IList<SubjectTypeModel> mSubjectType;
        public IList<SubjectTypeModel> SubjectType
        {
            get
            {
                if (mSubjectType == null)
                {
                    using (ExamSysEntities entity = new ExamSysEntities())
                    {
                        mSubjectType = (from m in entity.SubjectType
                                        select new SubjectTypeModel
                                        {
                                            ID = m.ID,
                                            Type = m.SType,
                                            Name = m.STypeName
                                        }).ToList();
                    }
                    if (mSubjectType == null)
                    {
                        mSubjectType = new List<SubjectTypeModel>();
                    }
                }
                return mSubjectType;
            }
        }
    }
}