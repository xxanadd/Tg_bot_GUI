using System;
using ReactiveUI;
using Tg_bot_GUI.ViewModels;
using Tg_bot_GUI.Views;

namespace Tg_bot_GUI;

public class AppViewLocator : IViewLocator
{
    public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
    {
        ChatViewModel context => new ChatView() { DataContext = context },
        _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
    };
}