namespace AbsFacPattern
{
    public interface IButton
    {
        void Paint();
    }

    public interface ICheckbox
    {
        void Paint();
    }

    public class WinButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Rendering a Windows Button");
        }
    }

    public class MacButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Rendering a Mac Button");
        }
    }

    public class WinCheckbox : ICheckbox
    {
        public void Paint()
        {
            Console.WriteLine("Rendering a Windows Checkbox");
        }
    }

    public class MacCheckbox : ICheckbox
    {
        public void Paint()
        {
            Console.WriteLine("Rendering a Mac Checkbox");
        }
    }

    public interface IGUIFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }

    public class WinFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WinButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new WinCheckbox();
        }
    }

    public class MacFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new MacButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new MacCheckbox();
        }
    }

    public class Application
    {
        private IButton _button;
        private ICheckbox _checkbox;

        public Application(IGUIFactory factory)
        {
            _button = factory.CreateButton();
            _checkbox = factory.CreateCheckbox();
        }

        public void Render()
        {
            _button.Paint();
            _checkbox.Paint();
        }
    }
}