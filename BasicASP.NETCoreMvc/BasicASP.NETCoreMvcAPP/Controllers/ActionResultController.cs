
using BasicASP.NETMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicASP.NETMvc.Controllers
{
    [AllowAnonymous]
    public class ActionResultController : Controller
    {
        // GET: ActionResult
        public ActionResult Index()
        {
            //basic points 1 change "null" to correct value.
            //return null;
            return View();
        }

        public ActionResult Baidu()
        {
            //basic points 2 change "" to Redirect to www.baidu.com
            var result = new RedirectResult("http://www.baidu.com");
            //return null;
            return result;
        }

        public ActionResult Page()
        {
            //basic points 3 change "" to correct value.
            //string str = "";
            string str = "this is content";
            return Content(str);
        }

        public ActionResult EmptyAction()
        {
            //basic points 4 change "null" to correct value.
            //eturn null;
            return new EmptyResult();
        }

        public ActionResult Redirect2Action()
        {
            //basic points 5 change null : Redirect to Baidu Action
            //return null;
            return RedirectToRoute("http://www.baidu.com");
        }

        public ActionResult Redirect2Route()
        {
            //basic points 6 change null : Redirect to Page Route
            //return null;
            return RedirectToRoute("");
        }

        public ActionResult JsonResult()
        {
            var result = new JsonObject("ActionResultController", "JsonResult");
            //basic points 7  change null to return a json obj
            //return Json(null);
            return Json(result);
        }

        public ActionResult ScriptResult()
        {
            var returnData=new ContentResult();
            var result = "<script><alert>hi,welcome to .net</alert></script>";
            returnData.Content = result;
            //basic points 8 change null to return a script code
            //return null;
            return returnData;
        }

        public ActionResult HttpUnauthorizedResult()
        {
            //basic points 9 change "null" to correct value.
            //return null;
            return new UnauthorizedResult();
        }

        public ActionResult HttpNotFoundResult()
        {
            //basic points 10 change "null" to correct value.
            //return null;
            return new NotFoundResult();
        }

        public ActionResult HttpStatusCodeResult()
        {
            //basic points 11 change "null" to correct value.
            //return null;
            return new StatusCodeResult(400);
        }

    }
}