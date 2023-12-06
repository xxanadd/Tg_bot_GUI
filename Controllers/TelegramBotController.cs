using System;
using System.Threading.Tasks;
using Tg_bot_GUI.Models;

namespace Tg_bot_GUI.Controllers;
using Telegram.Bot;

public class TelegramBotController
{
    private TelegramBotClient _bot;

    public long Id;

    public TelegramBotController(string botToken)
    {
        if (string.IsNullOrEmpty(botToken)) throw new Exception("Empty bot token");
        _bot = new TelegramBotClient(botToken);
        try
        {
            Id = _bot.GetMeAsync().Result.Id;
        }
        catch
        {
            throw new Exception("Invalid bot token");
        }
    }

    public string? GetChatName(string? chatId)
    {
        try
        {
            return _bot.GetChatAsync(chatId).Result.Title;
        }
        catch
        {
            throw new Exception("Invalid chat id");
        }
    }
}