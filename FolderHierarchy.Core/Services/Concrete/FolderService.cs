using FolderHierarchy.Core.DataContexts;
using FolderHierarchy.Core.Entities;
using FolderHierarchy.Core.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FolderHierarchy.Core.Services.Concrete
{
    public class FolderService : IFolderService
    {
        private readonly AppDbContext _context;
        public FolderService(AppDbContext context)
        {
            _context = context;
        }

        public Folder GetFolder(string path)
        {
            Folder result = null;
            if (path != null && path.Length > 0)
            {
                var segments = path.Split('/');
                if (segments.Length > 0)
                {
                    string fname = segments[0];
                    var folder = _context.Folders.Where(x => x.ParentId == null && x.Name == fname).Single();
                    for (int i = 1; i < segments.Length; i++)
                    {
                        fname = segments[i];
                        folder = folder.FolderChilds.Where(x => x.Name == fname).FirstOrDefault();
                    }
                    result = folder;
                }
            }
            else
            {
                Folder root = _context.Folders.Where(x => x.ParentId == null).Single();
                result = root;
            }
            return result;
        }
    }
}
