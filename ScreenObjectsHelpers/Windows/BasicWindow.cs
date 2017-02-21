using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows
{
    public class BasicWindow
    {

        public Window MainWindow;

        public BasicWindow(Window mainWindow)
        {
            this.MainWindow = mainWindow;
        }

        public void ClickOnButton(Button ButtonName)
        {
            ButtonName.Click();
        }

        public void WaitWhileElementAvaliable() {


        }

        protected void threadWait(int time)
        {
            try
            {
                //1000 milliseconds is on   e second.
                Thread.Sleep(time);
            }
            catch (ThreadInterruptedException ex)
            {
                Thread.CurrentThread.Interrupt();
            }
        }

    }

  }

