using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Tg_bot_GUI
{
    public partial class MainView : UserControl
    {
        private TextBox _inputTextBox;

        public MainView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            _inputTextBox = this.FindControl<TextBox>("InputTextBox");
        }

        private void OnConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            var enteredText = _inputTextBox?.Text;

            // Создаем экземпляр ResultView
            var resultView = new ResultView(this);

            // Устанавливаем текст в ResultView
            resultView.SetResultText($"Введенный текст: {enteredText}");

            // Заменяем текущий UserControl на ResultView
            this.Content = resultView;
        }
    }
}