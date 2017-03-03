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
    public class HelpMenu : MenuBar
    {
		private const string About = "About SourceTree";
		
        public HelpMenu(Window mainWindow) : base(mainWindow)
        {
        }

        public override Menu UIElementMenu { get {  return MainWindow.Get<Menu>(SearchCriteria.ByText("Help")); } }

        public void ClickOperations(OperationsHelp operation)
        {
            UIElementMenu.SubMenu(operation.Value).Click();
        }
		
		public AboutWindow OpenAbout()
        {
            UIElementMenu.SubMenu(About).Click();
            var aboutWindow = MainWindow.MdiChild(SearchCriteria.ByText(About));
            return new AboutWindow(MainWindow, aboutWindow);
        }        
    }

    public struct OperationsHelp
    {
        private OperationsHelp(string value) { Value = value; }
        public string Value { get; set; }        
        public static OperationsHelp GetStarted { get { return new OperationsHelp("Get Started With SourceTree"); } }
        public static OperationsHelp SupportWebsite { get { return new OperationsHelp("SourceTree Support Website"); } }        
        public static OperationsHelp SourceTreeWebsite { get { return new OperationsHelp("SourceTree Website"); } }
        public static OperationsHelp ReleaseNotes { get { return new OperationsHelp("Release Notes"); } }
        public static OperationsHelp GetGitRight { get { return new OperationsHelp("Get Git Right"); } }
        
    }
}
