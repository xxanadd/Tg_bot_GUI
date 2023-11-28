using System;

namespace Tg_bot_GUI.Models;

public class Chat
{
    public String ChatName { get; set; }
    public String chatId;
    public Boolean isChecked { get; set; }

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
        return ChatName == otherChat.ChatName;
    }

    public override int GetHashCode()
    {
        return ChatName.GetHashCode();
    }
}