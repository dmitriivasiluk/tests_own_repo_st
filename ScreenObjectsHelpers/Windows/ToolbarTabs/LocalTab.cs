using System;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using ScreenObjectsHelpers.Helpers;

namespace ScreenObjectsHelpers.Windows.ToolbarTabs
{
    public class LocalTab : NewTabWindow
    {
        public LocalTab(Window mainWindow) : base(mainWindow)
        {
        }

        public override UIItem ToolbarTabButton
        {
            get
            {
                try
                {
                    return MainWindow.Get<UIItem>(SearchCriteria.ByText("Local"));
                }
                catch (AutomationException)
                {
                    return null;
                }
            }
        }

        public override void ValidateWindow()
        {
            // Need verify opened tab in this method, need implementation! If validation is fail, throw exception!
            Console.WriteLine("WAIT FOR OPENING TAB");
        }        

        public UIItem TestGitRepoBookmark
        { 
            get
            {
                try
                {
                    //AutomationID_required
                    return MainWindow.Get<UIItem>(SearchCriteria.ByText(ConstantsList.testGitRepoBookmarkName));
                }
                catch (AutomationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public UIItem TestHgRepoBookmark
        {
            get
            {
                try
                {
                    //AutomationID_required
                    return MainWindow.Get<UIItem>(SearchCriteria.ByText(ConstantsList.testHgRepoBookmarkName));
                }
                catch (AutomationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public bool IsTestGitRepoBookmarkAdded()
        {
            if (TestGitRepoBookmark != null)
            {
                return true;
            }

            return false;
        }

        public bool IsTestHgRepoBookmarkAdded()
        {
            if (TestHgRepoBookmark != null)
            {
                return true;
            }

            return false;
        }
    }
}