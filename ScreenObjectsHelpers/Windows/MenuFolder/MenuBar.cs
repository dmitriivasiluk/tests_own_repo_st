using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows.MenuFolder
{
    public abstract class MenuBar : BasicWindow
    {
        public MenuBar(Window mainWindow) : base(mainWindow)
        {
        }

        public abstract Menu UIElementMenu
        {
            get;
        }

    }
}
