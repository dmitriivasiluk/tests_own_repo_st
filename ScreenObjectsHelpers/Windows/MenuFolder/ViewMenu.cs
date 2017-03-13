using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows.MenuFolder
{
    public class ViewMenu : MenuBar
    {
        public ViewMenu(Window mainWindow) : base(mainWindow)
        {
        }

        public override Menu UIElementMenu { get { return MainWindow.Get<Menu>(SearchCriteria.ByText("View")); } }

        public void ClickOperations(OperationsView operation)
        {
            UIElementMenu.SubMenu(operation.Value).Click();
        }

    }

    public struct OperationsView
    {
        private OperationsView(string value) { Value = value; }
        public string Value { get; set; }
        public static OperationsView Refresh { get { return new OperationsView("Refresh"); } }
        public static OperationsView NextTab { get { return new OperationsView("Next Tab"); } }
        public static OperationsView PreviuosTab { get { return new OperationsView("Previuos Tab"); } }
        public static OperationsView FileStatusView { get { return new OperationsView("File Status View"); } }
        public static OperationsView LogView { get { return new OperationsView("Log View"); } }
        public static OperationsView SearchView { get { return new OperationsView("Search View"); } }
    }
}
