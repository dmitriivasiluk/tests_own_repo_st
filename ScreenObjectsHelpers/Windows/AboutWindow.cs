using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows
{
    public class AboutWindow : GeneralWindow
    {
        public AboutWindow(Window mainWindow, UIItemContainer aboutWindow) : base(mainWindow)
        {
            AboutWindowContainer = aboutWindow;
        }

        public UIItemContainer AboutWindowContainer { get; }
        public override void ValidateWindow()
        {
            // Need verify opened tab in this method, need implementation! If validation is fail, throw exception!
            Console.WriteLine("WAIT FOR OPENING _ABOUT_ WINDOW");
        }
    }
}
