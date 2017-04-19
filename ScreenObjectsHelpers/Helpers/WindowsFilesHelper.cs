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
            Directory.CreateDirectory(path);
        }

        public static void RemoveFolderRecursivelyByPath(string target_dir)
        {
            if (!Directory.Exists(target_dir))
            {
                return;
            }
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                RemoveFolderRecursivelyByPath(dir);
            }

            Directory.Delete(target_dir, false);
        }

        public static bool IsGitRepositoryByPath(string path)
        {
            const string defaultGitFolder = ".git";
            string pathToNewFolder = Path.Combine(path, defaultGitFolder);
            return Directory.Exists(pathToNewFolder);
        }
    }
}
