using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenObjectsHelpers.Helpers
{
    public class WindowsFilesHelper
    {
        public static void CreateFolderByPath(string path)
        {
            DirectoryInfo di = Directory.CreateDirectory(path);
        }

        public static void RemoveFolderRecursivelyByPath(string path)
        {
            try
            {
                Directory.Delete(path, true);
            }
            catch (DirectoryNotFoundException)
            {
                // Empty
            }

        }

        public static bool IsGitRepositoryByPath(string path)
        {
            const string defaultGitFolder = ".git";
            string pathToDefaultGitFolderInRepository = path + "\\" + defaultGitFolder;
            return Directory.Exists(pathToDefaultGitFolderInRepository);
        }
    }
}
