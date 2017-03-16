using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows.MenuFolder
{
    public class EditMenu : MenuBar
    {
        public EditMenu(Window mainWindow) : base(mainWindow)
        {
        }

        public override Menu UIElementMenu { get { return MainWindow.Get<Menu>(SearchCriteria.ByText("Edit")); } }

        public void ClickOperations(OperationsEdit operation)
        {
            UIElementMenu.SubMenu(operation.Value).Click();
        }

    }

    public struct OperationsEdit
    {
        private OperationsEdit(string value) { Value = value; }
        public string Value { get; set; }
        public static OperationsEdit Undo { get { return new OperationsEdit("Undo"); } }
        public static OperationsEdit Redo { get { return new OperationsEdit("Redo"); } }
        public static OperationsEdit Cut { get { return new OperationsEdit("Cut"); } }
        public static OperationsEdit Copy { get { return new OperationsEdit("Copy"); } }
        public static OperationsEdit Paste { get { return new OperationsEdit("Paste"); } }
        public static OperationsEdit SelectAll { get { return new OperationsEdit("Select All"); } }
    }
}
