using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows.ToolbarTabs
{
    public class RemoteTab : NewTabWindow
    {
        public RemoteTab(TestStack.White.UIItems.WindowItems.Window mainWindow) : base(mainWindow)
        {
        }

        public override UIItem ToolbarTabButton => MainWindow.Get<UIItem>(SearchCriteria.ByText("Remote"));
    }
}
