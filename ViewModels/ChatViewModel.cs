using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using DynamicData.Binding;
using ReactiveUI;
using Tg_bot_GUI.Models;

namespace Tg_bot_GUI.ViewModels;

public class ChatViewModel: ReactiveObject, IRoutableViewModel
{
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
    
    private ReactiveCommand<Unit, Unit> _removeSelectedChatsCommand;
    public ReactiveCommand<Unit, Unit> RemoveSelectedChatsCommand => _removeSelectedChatsCommand ??= ReactiveCommand.Create(RemoveSelectedChats);

    private void RemoveSelectedChats()
    {
        var selectedItems = listBox.SelectedItems.Cast<Chat>().ToList();
        foreach (var selectedItem in selectedItems)
        {
            Chats.Remove(selectedItem);
        }
    }
}