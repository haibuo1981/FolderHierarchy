using FolderHierarchy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderHierarchy.Core.Services.Abstract
{
    public interface IFolderService
    {
        Folder GetFolder(string path);
    }
}
