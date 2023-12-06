using System;
using System.Reactive;
using ReactiveUI;
using Tg_bot_GUI.Controllers;
using Chat = Tg_bot_GUI.Models.Chat;

namespace Tg_bot_GUI.ViewModels;

public class ChatViewModel: ReactiveObject, IRoutableViewModel
{
    public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }

    private readonly RoutingState _router;
    private TelegramBotController _bot; 
    
    public ReactiveCommand<Unit, IRoutableViewModel> GoBack => _router.NavigateBack;
    
    private string? _chatId;

    private long _botId;

    public string? Text
    {
        get => _chatId;
        set => this.RaiseAndSetIfChanged(ref _chatId, value);
    }

    private string _watermark;

    public string Watermark
    {
        get => _watermark;
        set => this.RaiseAndSetIfChanged(ref _watermark, value);
    }
    public DatabaseController SourceDatabaseController { get; }

    public ChatViewModel(IScreen hostScreen, RoutingState router, TelegramBotController bot)
    {
        _botId = bot.Id;
        _bot = bot;
        Text = string.Empty;
        Watermark = string.Empty;
        HostScreen = hostScreen;
        _router = router;

        SourceDatabaseController = new DatabaseController(bot.Id);
        
        GoNext = ReactiveCommand.CreateFromObservable(
            () =>
            {
                var screen = new MessageViewModel(hostScreen, SourceDatabaseController);
                return _router.Navigate.Execute(screen);
            });
    }

    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
    public IScreen HostScreen { get; }

    public void AddNewChat()
    {
        if (string.IsNullOrEmpty(_chatId))
        {
            Watermark = "Empty chat id";
            return;
        }
        try
        {
            var chatName = _bot.GetChatName(_chatId);
            if (chatName == null) return;
            SourceDatabaseController.Add(new Chat(chatName, _chatId), _botId);
            Text = "";
            Watermark = "";
        }
        catch (Exception e)
        {
            Text = "";
            Watermark = e.Message;
        }
    }

    public void RemoveSelectedChats(Chat parameter)
    {
        SourceDatabaseController.Remove(parameter, _botId);
    }
    
}