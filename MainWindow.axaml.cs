// MainWindow.axaml.cs
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Tg_bot_GUI
{
    public partial class MainWindow : Window
    {
        private ContentControl _mainContent;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            _mainContent = this.FindControl<ContentControl>("MainContent");

            // При запуске приложения отображаем MainView
            ShowMainView();
        }

        public void ShowMainView()
        {
            var mainView = new MainView();

            // Устанавливаем MainView как содержимое MainWindow
            _mainContent.Content = mainView;
        }
    }
}