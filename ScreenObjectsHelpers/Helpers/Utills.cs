using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Helpers
{
    public class Utills
    {

        public static Window FindNewWindow(string nameOfWindow)
        {
            Window window = Desktop.Instance.Windows().FirstOrDefault(x => x.Name == nameOfWindow);
            int testCount = 0;
            while (window == null && testCount < 30)
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
                testCount++;
            }
            return window;
        }
    }
}
