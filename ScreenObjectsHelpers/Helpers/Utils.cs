using System;
using System.IO;
using System.Threading;

namespace ScreenObjectsHelpers.Helpers
{
    public class Utils
    {
        public static void ThreadWait(int timeInMilliseconds)
        {
            try
            {
                Thread.Sleep(timeInMilliseconds);
            }
            catch (ThreadInterruptedException)
            {
                Thread.CurrentThread.Interrupt();
            }
        }

        public static void RemoveFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void RemoveDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path, true);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static bool IsFolderGit(string path)
        {
            string pathToDotGitFolder = Path.Combine(path, ConstantsList.dotGitFolder);
            return Directory.Exists(pathToDotGitFolder);
        }

        public static bool IsFolderMercurial(string path)
        {
            string pathToDotGitFolder = Path.Combine(path, ConstantsList.dotHgFolder);
            return Directory.Exists(pathToDotGitFolder);
        }
    }
}