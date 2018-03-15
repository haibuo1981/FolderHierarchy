using FolderHierarchy.Core.DataContexts;
using FolderHierarchy.Core.Entities;
using FolderHierarchy.Core.Services.Abstract;
using FolderHierarchy.Core.Services.Concrete;
using FolderHierarchy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FolderHierarchy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFolderService _service;
        public HomeController()
        {
            _service = new FolderService(new AppDbContext());
        }

        [HttpGet]
        public ActionResult Index()
        {
            var paramStr = RouteData.Values["catchall"] as string;
            var folder = _service.GetFolder(paramStr);
            if (folder == null)
            {
                ViewData["Error"] = "Такой папки не существует";
                return View();
            }
            if (string.IsNullOrEmpty(paramStr))
            {
                return Redirect(Request.Url.AbsolutePath + folder.Name);
            }
            var model = new FolderViewModel()
            {
                Name = folder.Name,
                ChildFolderUrls = folder.FolderChilds != null ? GenerateUrls(folder.FolderChilds, Request.Url.AbsolutePath) : new List<FolderUrl>()
            };

            return View(model);
        }

        private List<FolderUrl> GenerateUrls(ICollection<Folder> folders, string baseUrl)
        {
            var result = new List<FolderUrl>(folders.Count);
            foreach (var folder in folders)
            {
                result.Add(new FolderUrl
                {
                    Name = folder.Name,
                    Url = baseUrl + "/" + folder.Name
                });
            }
            return result;
        }
    }
}