using System;
using System.ComponentModel;
using System.Reactive;
using DynamicData.Binding;
using ReactiveUI;
using Tg_bot_GUI.Models;

namespace Tg_bot_GUI.ViewModels;

public class MessageViewModel: ReactiveObject, IRoutableViewModel
{
    public ReactiveCommand<Unit, IRoutableViewModel> GoBack { get; }

    private ObservableCollectionExtended<Chat> _source;
    public MessageViewModel(IScreen hostScreen, ObservableCollectionExtended<Chat> source)
    {
        HostScreen = hostScreen;
        _source = source;
    }

    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
    public IScreen HostScreen { get; }
}