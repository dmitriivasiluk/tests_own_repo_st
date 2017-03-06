using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
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
