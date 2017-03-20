using System;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows.MenuFolder
{
    public class FileMenu : MenuBar
    {
        private const string cloneNew = "Clone / New...";
        private const string open = "Open...";
        private const string exitSourceTree = "Exit SourceTree";

        public FileMenu(Window mainWindow) : base(mainWindow)
        {
        }

        public override Menu UIElementMenu
        {
            get
            {
                return MainWindow.Get<Menu>(SearchCriteria.ByText("File"));
            }
        }

        public NewTabWindow OpenCloneNew()
        {
            UIElementMenu.SubMenu(cloneNew).Click();
            NewTabWindow newTab = new NewTabWindow(MainWindow);
            return newTab;
        }

        public object OpenRepository()
        {
            UIElementMenu.SubMenu(open).Click();
            throw new NotImplementedException("No corresponding class");
        }

        public void ExitSourceTree()
        {
            UIElementMenu.SubMenu(exitSourceTree).Click();
        }


    }
}
