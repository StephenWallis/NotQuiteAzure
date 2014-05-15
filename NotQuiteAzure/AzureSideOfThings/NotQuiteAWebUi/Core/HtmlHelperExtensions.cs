using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using NotQuiteAWebUi.Controllers;
using NotQuiteAWebUi.Models;

namespace NotQuiteAWebUi.Core
{
    public static class HtmlHelperExtensions
    {
        public static string GetVersionNumber(this HtmlHelper htmlHelper)
        {
            Type controllerType = typeof (HomeController);
            return controllerType.Assembly.GetName().Version.ToString(3);
        }

        public static MvcHtmlString MainMenu(this HtmlHelper htmlHelper, string currentUrl = null)
        {
            return htmlHelper.Partial(MVC.Shared.Views._Menu, new MenuModel
            {
                CurrentUrl = currentUrl
            });
        }
    }
}