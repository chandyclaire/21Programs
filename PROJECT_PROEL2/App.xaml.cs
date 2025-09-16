namespace PROJECT_PROEL2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = new Window(new AppShell());
            window.Height = 800; window.Width = 550;
            return window;
        }
    }
}