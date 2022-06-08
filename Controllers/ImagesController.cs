using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using _02u19106832_HW03.Models;

namespace _02u19106832_HW03.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Images
        public ActionResult Index()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/Images/"));

            List<FileModel> files = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);

        }
        public FileResult Download(string DownloadImg)
        {
            string Filepath = Server.MapPath("~/App_Data/Images/") + DownloadImg;
            byte[] bytes = System.IO.File.ReadAllBytes(Filepath);
            return File(bytes, "application/octet-stream", DownloadImg);
        }

        public ActionResult Delete(string DeleteImg)
        {
            string Path = Server.MapPath("~/App_Data/Images/" + DeleteImg);
            byte[] bytes = System.IO.File.ReadAllBytes(Path);
            System.IO.File.Delete(Path);

            return RedirectToAction("Index");
        }



    }
}