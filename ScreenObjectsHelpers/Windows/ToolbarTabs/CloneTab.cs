using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows.ToolbarTabs
{
    public class CloneTab : NewTabWindow
    {
        public CloneTab(TestStack.White.UIItems.WindowItems.Window mainWindow) : base(mainWindow)
        {
        }

        #region UIElements
        public override UIItem ToolbarTabButton => MainWindow.Get<UIItem>(SearchCriteria.ByText("Clone"));
        public Label RemoteAccountLabel => MainWindow.Get<Label>(SearchCriteria.ByAutomationId("remote account"));
        public TextBox SourcePathTextBox => MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("SourceTextBox"));
        public ComboBox LocalFolderComboBox => MainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("CloneBookmarksFolderList"));
        public Button CloneButton => MainWindow.Get<Button>(SearchCriteria.ByText("Clone"));
        public Button AdvancedOptionsButton => MainWindow.Get<Button>(SearchCriteria.ByAutomationId("HeaderSite"));
        public CheckBox RecurseSubmodulesCheckBox => MainWindow.Get<CheckBox>(SearchCriteria.ByText("Recurse submodules"));
        public CheckBox NoHardlinksCheckBox => MainWindow.Get<CheckBox>(SearchCriteria.ByText("No hardlinks"));

        //AutomationID required
        /*
        public TextBox DestinationPathTextBox => MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId(""));

        public TextBox DestinationPathTextBox => MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId(""));

        public Button SourcePathButton => MainWindow.Get<Button>(SearchCriteria.ByAutomationId(""));

        public Button DestinationPathButton => MainWindow.Get<Button>(SearchCriteria.ByAutomationId(""));

        public ComboBox CheckoutBranchComboBox => MainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId(""));

        public TextBox CloneDepthTextBox => MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId(""));
        */
        #endregion

        #region Methods
        //TODO
        //Expand / Collapse method for advanced options group
        #endregion
    }
}
