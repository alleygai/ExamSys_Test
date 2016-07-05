using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamSys.Controllers
{
    public class BaseController : Controller
    {
        private DicHelper mDicHelper;
        public DicHelper DicHelper
        {
            get
            {
                if (mDicHelper == null)
                {
                    mDicHelper = new DicHelper();
                }
                return mDicHelper;
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}