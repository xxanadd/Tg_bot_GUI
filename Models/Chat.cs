using System;

namespace Tg_bot_GUI.Models;

public class Chat
{
    public bool isChecked = true;
    public String ChatName { get; set; }
    public String chatId;

    public Chat(String chatName)
    {
        ChatName = chatName;
    }
    
    // Переопределение Equals и GetHashCode
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Chat otherChat = (Chat)obj;
        return this.ChatName == otherChat.ChatName;
    }

    public override int GetHashCode()
    {
        return ChatName.GetHashCode();
    }
}