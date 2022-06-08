using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using _02u19106832_HW03.Models;

namespace _02u19106832_HW03.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            //building file paths
            // Fetching all the files in the Folder (Directory).
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/Files/"));
            //copying file names to model collection and returning it to the list
            List<FileModel> files = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel {FileName = Path.GetFileName(filePath)});
            }
            return View(files);
           
        }
        //Download the file
        public FileResult Download(string DownloadFile)
        {
            string Filepath = Server.MapPath("~/App_Data/Files/") + DownloadFile;
            byte[] bytes = System.IO.File.ReadAllBytes(Filepath);
            return File(bytes, "application/octet-stream", DownloadFile);
        }
        //deleting the file 
        public ActionResult Delete(string DeleteFile)
        {
            //deleting the files require reading the files first and then allocated a file path
            // The file is deleted based on the file path 
            string Path = Server.MapPath("~/App_Data/Files/" + DeleteFile);
            byte[] bytes = System.IO.File.ReadAllBytes(Path);
            System.IO.File.Delete(Path);
            
            return RedirectToAction("Index");
        }
    }
}