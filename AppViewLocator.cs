using System;
using ReactiveUI;
using Tg_bot_GUI.ViewModels;
using Tg_bot_GUI.Views;

namespace Tg_bot_GUI;

public class AppViewLocator : IViewLocator
{
    public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
    {
        LoginViewModel loginViewModel => new LoginView() { DataContext = loginViewModel},
        ChatViewModel chatViewModel => new ChatView() { DataContext = chatViewModel },
        MessageViewModel messageViewModel => new MessageView() {DataContext = messageViewModel},
        _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
    };
    
}