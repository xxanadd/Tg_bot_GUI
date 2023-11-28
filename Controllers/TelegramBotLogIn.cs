namespace Tg_bot_GUI.Controllers;
using Telegram.Bot;

public class TelegramBotLogIn
{
    public TelegramBotClient Bot (string botToken)
    {
        return new TelegramBotClient(botToken);
    }
}