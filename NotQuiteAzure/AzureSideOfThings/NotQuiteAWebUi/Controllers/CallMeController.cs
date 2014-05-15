using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotQuiteAWebUi.Controllers
{
    public partial class CallMeController : Controller
    {
        //
        // GET: /CallMe/

        public virtual ViewResult Index()
        {
            return View();
        }

    }
}
