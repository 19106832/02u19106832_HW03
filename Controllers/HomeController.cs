using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace _02u19106832_HW03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //multiple file upload 

      [HttpPost]
        public ActionResult Index(HttpPostedFileBase files,string radButton)
        {
          //selecting the document radiobutton and fetching a file
            if(radButton == "Document")
            {
                // Extracted the filename and stored the file into a path and then redirected the action to the index
                var fileName = Path.GetFileName(files.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/Files/"), fileName);
                files.SaveAs(path);
            }
            // selecting an image radiobutton and fetching an image 
             else if (radButton == "Image")
            {
                var fileName = Path.GetFileName(files.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/Images/"), fileName);
                files.SaveAs(path);
            }
            //selecting the video radiobutton and fetching a video
             else if (radButton == "Video")
            {
                var fileName = Path.GetFileName(files.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/Videos/"), fileName);
                files.SaveAs(path);
            }
            return RedirectToAction("Index");
        }
    }
}