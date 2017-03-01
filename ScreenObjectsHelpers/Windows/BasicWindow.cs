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
    /// <summary>
    /// This is the base page from which all other pages inherit.
    /// It contains base methods that are used in all window like click on button, waits, get text etc.
    /// Also it has an abstract method that enforce all window verify that it is opened.
    /// </summary>
    public abstract class BasicWindow
    {

        public BasicWindow(Window mainWindow)
        {
            this.MainWindow = mainWindow;
            ValidateWindow();
        }

        public Window MainWindow { get; private set; }

        public abstract void ValidateWindow();

        public void ClickOnButton(Button Button)
        {
            // WaitWhileElementAvaliable(Button).Click() uncomment it when implement WaitWhileElementAvaliable() method
            Button.Click();
        }

        public void WaitWhileElementAvaliable() {
            throw new NotImplementedException();
        }

        protected void ThreadWait(int time)
        {
            try
            {
                //1000 milliseconds is on  e second.
                Thread.Sleep(time);
            }
            catch (ThreadInterruptedException ex)
            {
                Thread.CurrentThread.Interrupt();
            }
        }

    }

  }

