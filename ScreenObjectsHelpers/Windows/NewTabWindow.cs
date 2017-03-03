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
    /// <summary>
    /// This is main Window with opened New tab.
    /// This class inherit Menu from General class and this first main real window object which not abstract.
    /// </summary>
    public class NewTabWindow : GeneralWindow
    {
        public NewTabWindow(Window mainWindow) : base(mainWindow)
        {
        }

        public override void ValidateWindow()
        {
            // I guess this method should close all opened tab and open new one. Then validate that is all right. 
            // If validation is fail, throw exception!
            Console.WriteLine("WAIT FOR OPENING TAB");
        }
    }
}
