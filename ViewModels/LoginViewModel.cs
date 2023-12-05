using System;
using System.Reactive;
using ReactiveUI;
using Tg_bot_GUI.Controllers;

namespace Tg_bot_GUI.ViewModels;

public class LoginViewModel: ReactiveObject, IRoutableViewModel
{
    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
    private string _token;
    public string Token
    {
        get => _token;
        set => this.RaiseAndSetIfChanged(ref _token, value);
    }
    public IScreen HostScreen { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }

    public LoginViewModel(RoutingState router, IScreen hostScreen)
    {
        HostScreen = hostScreen;
        GoNext = ReactiveCommand.CreateFromObservable(
            () => router.Navigate.Execute(new ChatViewModel(HostScreen, router, new TelegramBotController(_token)))
        );
    }
}