// MainWindow.axaml.cs
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Tg_bot_GUI.ViewModels;
using Tg_bot_GUI.Views;

namespace Tg_bot_GUI
{
    public partial class MainWindow :  ReactiveWindow<MainWindowViewModel>
    {
        private ContentControl _mainContent;

        public MainWindow()
        {
            this.WhenActivated(disposables => { });
            InitializeComponent();
        }
        
    }
}