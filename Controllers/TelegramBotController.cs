using System;
using System.Threading.Tasks;
using Tg_bot_GUI.Models;

namespace Tg_bot_GUI.Controllers;
using Telegram.Bot;

public class TelegramBotController
{
    private TelegramBotClient bot;

    public TelegramBotController(string botToken)
    {
        if (botToken == null) throw new ArgumentNullException(nameof(botToken));
        bot = new TelegramBotClient(botToken);;
    }

    public string? GetChatName(string chatId)
    {
        return bot.GetChatAsync(chatId).Result.Title;
    }
}