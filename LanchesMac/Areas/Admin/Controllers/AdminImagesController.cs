﻿using LanchesMac.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IO;

namespace LanchesMac.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImagesController : Controller
    {
        private readonly ConfigurationImages _myConfig;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AdminImagesController(IWebHostEnvironment hostingEnvironment,
            IOptions<ConfigurationImages> myConfiguration)
        {
            _hostingEnvironment = hostingEnvironment;
            _myConfig = myConfiguration.Value;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if(files == null|| files.Count == 0)
            {
                ViewData["Error"] = "Error: File(s) not selected";
                return View(ViewData);
            }
            if(files.Count > 10)
            {
                ViewData["Error"] = "Error: Quantity of files overpast the limit";
                return View(ViewData);
            }
            long size = files.Sum(f => f.Length);

            var filePathsName = new List<string>();
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.ProductsImagesFolderName);

            foreach(var formFile in files)
            {
                if(formFile.FileName.Contains(".jpg") || formFile.FileName.Contains(".gif") || formFile.FileName.Contains(".png"))
                {
                    var fileNameWithPath = string.Concat(filePath, "\\", formFile.FileName);
                    filePathsName.Add(fileNameWithPath);

                    using(var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            ViewData["Result"] = $"{files.Count} files sent to server, " +
                $"with a total of {size} bytes";
            ViewBag.Files = filePathsName;

            return View(ViewData);
        }
        public IActionResult GetImages()
        {
            FileManagerModel model = new FileManagerModel();

            var userImagesPath = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.ProductsImagesFolderName);

            DirectoryInfo dir = new DirectoryInfo(userImagesPath);
            FileInfo[] files = dir.GetFiles();

            model.PathImagesProduct = _myConfig.ProductsImagesFolderName;

            if(files.Length == 0)
            {
                ViewData["Error"] = $"There is no file in {userImagesPath}";
            }
            model.Files = files;
            return View(model);
        }
        public IActionResult DeleteFile(string fName)
        {
            string _deleteImage = Path.Combine(_hostingEnvironment.WebRootPath,_myConfig.ProductsImagesFolderName + "\\", fName);

            if (System.IO.File.Exists(_deleteImage))
            {
                System.IO.File.Delete(_deleteImage);
                ViewData["Deleted"] = $"File(s) deleted: {_deleteImage}";
            }
            return View("Index");
        }
    }
}
