using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using Avalonia.Controls;
using DynamicData.Binding;
using ReactiveUI;
using Telegram.Bot;
using Tg_bot_GUI.Controllers;
using Tg_bot_GUI.Models;

namespace Tg_bot_GUI.ViewModels;

public class ChatViewModel: ReactiveObject, IRoutableViewModel
{
    public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }

    private readonly RoutingState _router;
    private TelegramBotController _bot; 
    
    public ReactiveCommand<Unit, IRoutableViewModel> GoBack => _router.NavigateBack;
    
    private string _chatId;

    public string Text
    {
        get => _chatId;
        set => this.RaiseAndSetIfChanged(ref _chatId, value);
    }
    public ObservableCollectionExtended<Chat> Source { get; }

    public ChatViewModel(IScreen hostScreen, RoutingState router, TelegramBotController bot)
    {
        _bot = bot;
        _chatId = string.Empty;
        HostScreen = hostScreen;
        _router = router;

        Source = new ObservableCollectionExtended<Chat>();
        
        GoNext = ReactiveCommand.CreateFromObservable(
            () =>
            {
                var screen = new MessageViewModel(hostScreen, Source);
                return _router.Navigate.Execute(screen);
            });
    }

    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
    public IScreen HostScreen { get; }

    public void AddNewChat()
    { 
        if(_chatId == "") return;
        var chatName = _bot.GetChatName(_chatId);
        if (chatName == null) return;
        Source.Add(new Chat(chatName, _chatId));
        _chatId = "";
        this.RaisePropertyChanged(nameof(Text));
    }

    public void RemoveSelectedChats(Chat parameter)
    {
        Source.Remove(parameter);
    }
    
}