// ResultView.axaml.cs
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Tg_bot_GUI
{
    public partial class ResultView : UserControl
    {
        private TextBlock _resultTextBlock;
        private MainView _mainView; // Используйте MainView, если у вас есть такая ссылка

        public ResultView(MainView mainView)
        {
            _mainView = mainView;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            _resultTextBlock = this.FindControl<TextBlock>("ResultTextBlock");
        }

        public void SetResultText(string text)
        {
            _resultTextBlock.Text = text;
        }

        private void OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            // Возвращаемся к MainView
            Content = new MainView();
        }
    }
}