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
            
        }

        public Window MainWindow { get; private set; }

        public void ClickOnButton(Button Button)
        {
            Button.Click();
        }

        public void ClickOnButtonAfterElementVisible(Button Button)
        {
            WaitWhileElementAvaliable(Button).Click();
        }

        public bool IsElementAvaliable(UIItem item)
        {
            return item.Visible;
        }
        public  UIItem WaitWhileElementAvaliable(UIItem item)
        {
            var ifItemVisible = item.Visible;
            int secondPassed = 0;
            while (true)
            {
                var isItemVisible = item.Visible;
                if (secondPassed > 60)
                {
                    throw new TimeoutException($"Element {item.ToString()} is not Visible after {secondPassed} second");
                }
                if (!isItemVisible)
                {
                    int secondToWait = 5;
                    secondPassed += secondToWait;
                    ThreadWait(secondToWait);
                    continue;
                }
                return item;
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

        public void ScrollHorizontalLeft(Window window)
        {
            var isWindowScrolable = window.ScrollBars.Horizontal.IsScrollable;
            if (isWindowScrolable == true)
            {
                window.ScrollBars.Horizontal.ScrollLeftLarge();
            }

        }
        public void ScrollHorizontalRigh(Window window)
        {
            var isWindowScrolable = window.ScrollBars.Horizontal.IsScrollable;
            if (isWindowScrolable)
            {
                window.ScrollBars.Horizontal.ScrollRightLarge();
            }

        }
        public void ScrollVerticalDown(Window window)
        {
            var isWindowScrolable = window.ScrollBars.Vertical.IsScrollable;
            if (isWindowScrolable)
            {
                window.ScrollBars.Vertical.ScrollDown();
            }
        }
        public void ScrollVerticalUp(Window window)
        {
            var isWindowScrolable = window.ScrollBars.Vertical.IsScrollable;
            if (isWindowScrolable)
            {
                window.ScrollBars.Vertical.ScrollUp();
            }

        }


    }

}

