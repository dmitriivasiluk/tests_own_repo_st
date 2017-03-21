using System;
using System.Threading;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
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

        public void ClickOnButton(Button button)
        {
            WaitWhileElementAvaliable(button);
            if (button.Enabled)
            {
                button.Click();
            }
            else
            {
                throw new TimeoutException("Element is not enabled, can not perform action on element.");
            }
        }

        public void ClickOnButtonAfterElementVisible(Button Button)
        {
            WaitWhileElementAvaliable(Button).Click();
        }

        public UIItemContainer WaitMdiChildAppears(SearchCriteria searchCriteria, int secondsForWait)
        {
            int secondsPass = 0;
            UIItemContainer container = MainWindow.MdiChild(searchCriteria);
            while (container == null)
            {
                ThreadWait(1000);
                secondsPass++;
                container = MainWindow.MdiChild(searchCriteria);
                if (secondsPass > secondsForWait)
                {
                    throw new TimeoutException();
                }
            }
            return container;
        }

        public bool IsElementAvaliable(UIItem item)
        {
            return item.Visible;
        }

        public UIItem WaitWhileElementAvaliable(UIItem item, int maximumTimeToWait = 60)
        {
            int secondPassed = 0;
            const int secondToWaitEachLoop = 5;
            while (true)
            {
                var isItemVisible = item.Visible;
                if (secondPassed > maximumTimeToWait)
                {
                    throw new TimeoutException($"Element {item.ToString()} is not Visible after {secondPassed} second");
                }
                if (isItemVisible) return item;
                secondPassed += secondToWaitEachLoop;
                ThreadWait(secondToWaitEachLoop * 5000); // convert in milliseconds 
            }
        }

        protected void ThreadWait(int timeInMilliseconds)
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

        public void ScrollHorizontalLeft(Window window)
        {
            var isWindowScrolable = window.ScrollBars.Horizontal.IsScrollable;
            if (isWindowScrolable)
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

