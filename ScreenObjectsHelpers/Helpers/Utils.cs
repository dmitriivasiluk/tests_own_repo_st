using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;


namespace ScreenObjectsHelpers.Helpers
{
    public class Utils
    {

        public static Window FindNewWindow(string nameOfWindow, int testCount = 30)
        {
            Window window = Desktop.Instance.Windows().FirstOrDefault(x => x.Name == nameOfWindow);
            int count = 0;
            while (window == null && count < testCount)
            {
                try
                {
                    window = Desktop.Instance.Windows().FirstOrDefault(x => x.Name == nameOfWindow);
                }
                catch (ElementNotAvailableException e)
                {
                    window = null;
                }
                catch (NullReferenceException e)
                {
                    window = null;
                }
                Thread.Sleep(1000);
                count++;
            }
            return window;
        }

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
