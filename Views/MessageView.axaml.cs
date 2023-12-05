using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Tg_bot_GUI.ViewModels;

namespace Tg_bot_GUI.Views;

public partial class MessageView : ReactiveUserControl<MessageViewModel>
{
    public MessageView()
    {
        this.WhenActivated(disposables => { });
        InitializeComponent();
    }
}