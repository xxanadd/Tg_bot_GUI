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
using Tg_bot_GUI.Models;

namespace Tg_bot_GUI.ViewModels;

public class ChatViewModel: ReactiveObject, IRoutableViewModel, INotifyPropertyChanged
{
    public ReactiveCommand<Unit, IRoutableViewModel> GoBack { get; }
    
    private string _text;

    public string Text
    {
        get
        {
            return _text;
        }
        set
        {
            this.RaiseAndSetIfChanged(ref _text, value);
            //AddNewChat(value);
        }
    }
    public ObservableCollectionExtended<Chat> Source { get; } 

    public ChatViewModel(IScreen hostScreen, MainWindowViewModel vm)
    {
        HostScreen = hostScreen;

        Source = new ObservableCollectionExtended<Chat>();
        
        GoBack = ReactiveCommand.CreateFromObservable(() =>
        {
            hostScreen.Router.NavigateBack.Execute().Subscribe();
            return Observable.Return(this as IRoutableViewModel);
        });
    }

    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
    public IScreen HostScreen { get; }

    public void AddNewChat()
    { 
        if(_text == "") return;
        Source.Add(new Chat(_text));
        _text = "";
        this.RaisePropertyChanged(nameof(Text));
    }

    public void RemoveSelectedChats(Chat parameter)
    {
        Source.Remove(parameter);
    }
    
}