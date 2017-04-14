using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White.UIItems;

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
            try
            {
                File.Delete(path);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);                
            }

        }

        public static void RemoveDirectory(string path)
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
}
