using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FolderHierarchy.Models
{
    public class FolderViewModel
    {
        public string Name { get; set; }
        public List<FolderUrl> ChildFolderUrls { get; set; }
    }
}