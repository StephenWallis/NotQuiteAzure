using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotQuiteAWebUi.Controllers
{
    public partial class HomeController : Controller
    {
        //
        // GET: /Home/

        public virtual ViewResult Index()
        {
            return View();
        }

    }
}
