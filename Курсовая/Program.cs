using System.Collections;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using System.Threading;
using Telegram.Bot.Types.ReplyMarkups;

namespace Курсовая
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            var botClient = new TelegramBotClient("7085153126:AAFEVPuuMKbIubl60qBuIISP3Ogo6vkQpUw");

            Message message = await botClient.SendTextMessageAsync(
     chatId: chatId,
     text: "Trying *all the parameters* of `sendMessage` method",
     parseMode: ParseMode.MarkdownV2,
     disableNotification: true,
     replyToMessageId: update.Message.MessageId,
     replyMarkup: new InlineKeyboardMarkup(
         InlineKeyboardButton.WithUrl(
             text: "Check sendMessage method",
             url: "https://core.telegram.org/bots/api#sendmessage")),
     cancellationToken: cancellationToken);

            //var me = await botClient.GetMeAsync();
            //Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");


            //var client = new TelegramBotClient("7085153126:AAFEVPuuMKbIubl60qBuIISP3Ogo6vkQpUw");

            //client.OnMessage += async (sender, e) =>
            //{
            //    if (e.Message.Text == "/start")
            //    {
            //        // Create keyboard buttons
            //        var keyboardButtons = new List<KeyboardButton[]>()
            //        {
            //            new KeyboardButton[] { "утро/день" },
            //            new KeyboardButton[] { "вечер" },
            //            new KeyboardButton[] { "весь день" },
            //        };

            //        // Create reply keyboard markup
            //        var replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons)
            //        {
            //            ResizeKeyboard = true, // Allow keyboard to resize
            //            OneTimeKeyboard = true // Hide keyboard after user selects an option
            //        };

            //        // Send message with keyboard
            //        await client.SendTextMessageAsync(
            //            chatId: e.Message.Chat.Id,
            //            text: "Выберите время суток",
            //            replyMarkup: replyKeyboardMarkup
            //        );
            //    }
            //    else
            //    {
            //        // Handle user's button selection
            //        string selectedTime = e.Message.Text;
            //        // ... (process selected time)
            //    }
            //};

            //client.StartReceiving();
            //Console.ReadLine();
            //client.StopReceiving();

            //Активности
            ArrayList arrActivities = new ArrayList(47);
            //0
            arrActivities.Add(new Activity("Пермский цирк", "ссылка1", "утро/день", "досуг с детьми", "информация1", 6));
            //1
            arrActivities.Add(new Activity("Парк Горького", "ссылка1", "утро/день и вечер", "досуг с детьми и активности", "информация1", 6));
            //2
            arrActivities.Add(new Activity("Зоопарк", "ссылка1", "утро/день", "досуг с детьми", "информация1", 6));
            //3
            arrActivities.Add(new Activity("Perm Stand-Up", "ссылка1", "вечер", "активности", "информация1", 6));
            //4
            arrActivities.Add(new Activity("Прогулка на лодочке", "ссылка1", "утро/день и вечер", "прогулки", "информация1", 6));
            //5
            arrActivities.Add(new Activity("Пермский планетарий", "ссылка1", "утро/день", "досуг с детьми", "информация1", 6));
            //6
            arrActivities.Add(new Activity("Парк науки", "ссылка1", "утро/день", "досуг с детьми и активности", "информация1", 6));
            //7
            arrActivities.Add(new Activity("Экскурсия на шоколадную фабрику", "ссылка1", "утро/день и вечер", "экскурсии", "информация1", 6));
            //8
            arrActivities.Add(new Activity("Караоке с отдельными комнатами", "ссылка1", "вечер", "активности", "информация1", 6));
            //9
            arrActivities.Add(new Activity("Мегалэнд", "ссылка1", "утро/день", "досуг с детьми", "информация1", 6));
            //10
            arrActivities.Add(new Activity("Боулинг", "ссылка1", "утро/день и вечер", "активности", "информация1", 6));
            //11
            arrActivities.Add(new Activity("Кино + PlayDay", "ссылка1", "утро/день и вечер", "досуг с детьми и активности", "информация1", 6));
            //12
            arrActivities.Add(new Activity("Гейм-клуб", "ссылка1", "утро/день и вечер", "активности", "информация1", 6));
            //13
            arrActivities.Add(new Activity("Антикафе", "ссылка1", "утро/день", "активности", "информация1", 6));
            //14
            arrActivities.Add(new Activity("Нетипичный тир", "ссылка1", "утро/день", "активности", "информация1", 6));
            //15
            arrActivities.Add(new Activity("Урок стрельбы из лука", "ссылка1", "утро/день", "активности", "информация1", 6));
            //16
            arrActivities.Add(new Activity("Гончарный мастер-класс", "ссылка1", "утро / день", "активности", "информация1", 6));
            //17
            arrActivities.Add(new Activity("Мастер-класс по кофе", "ссылка1", "утро/день", "активности", "информация1", 6));
            //18
            arrActivities.Add(new Activity("Прогулка на каяках", "ссылка1", "весь день", "активности", "информация1", 6));
            //19
            arrActivities.Add(new Activity("Катание на сап-борде в Хохловке", "ссылка1", "весь день", "активности", "информация1", 6));
            //20
            arrActivities.Add(new Activity("Краш-комната для компании", "ссылка1", "утро/день и вечер", "активности", "информация1", 6));
            //21
            arrActivities.Add(new Activity("Экскурсия на производство роботов Промобот", "ссылка1", "утро/день", "экскурсии", "информация1", 6));
            //22
            arrActivities.Add(new Activity("Хохловка - музей под открытым небом", "ссылка1", "весь день", "выезд", "информация1", 6));
            //23
            arrActivities.Add(new Activity("Музей пермских древностей", "ссылка1", "утро/день", "экскурсии", "информация1", 6));
            //24
            arrActivities.Add(new Activity("Экскурсия в ботанический сад ПГНИУ", "ссылка1", "утро/день", "экскурсии", "информация1", 6));
            //25
            arrActivities.Add(new Activity("Берег реки Мулянка", "ссылка1", "утро/день", "прогулка", "информация1", 6));
            //26
            arrActivities.Add(new Activity("Сад соловьёв", "ссылка1", "утро/день", "прогулка", "информация1", 6));
            //27
            arrActivities.Add(new Activity("Мост тысяча ступеней", "ссылка1", "утро/день", "прогулка", "информация1", 6));
            //28
            arrActivities.Add(new Activity("Старокирпичный переулок", "ссылка1", "утро/день и вечер", "активности", "информация1", 6));
            //29
            arrActivities.Add(new Activity("Парк камней", "ссылка1", "утро/день и вечер", "прогулка", "информация1", 6));
            //30
            arrActivities.Add(new Activity("Арт-пространство завод Шпагина", "утро/день", "прогулка и активности", "тип1", "информация1", 6));
            //31
            arrActivities.Add(new Activity("Балатоский парк", "ссылка1", "утро/день и вечер", "прогулка", "информация1", 6));
            //32
            arrActivities.Add(new Activity("Парк Райский сад", "ссылка1", "утро/день и вечер", "прогулка", "информация1", 6));
            //33
            arrActivities.Add(new Activity("Кунгурская пещера", "ссылка1", "весь день", "выезд", "информация1", 6));
            //34
            arrActivities.Add(new Activity("Сквер уральских добровольцев", "ссылка1", "утро/день и вечер", "прогулка", "информация1", 6));
            //35
            arrActivities.Add(new Activity("Пермская набережная", "ссылка1", "утро/день и вечер", "прогулка", "информация1", 6));
            //36
            arrActivities.Add(new Activity("Пермская эспланада", "ссылка1", "утро/день и вечер", "прогулка", "информация1", 6));
            //37
            arrActivities.Add(new Activity("Театральный сад", "ссылка1", "утро/день и вечер", "прогулка", "информация1", 6));
            //38
            arrActivities.Add(new Activity("Активити парк Sky Trip", "ссылка1", "утро/день", "досуг с детьми и активности", "информация1", 6));
            //39
            arrActivities.Add(new Activity("Отель Побег из города", "ссылка1", "весь день", "выезд", "информация1", 6));
            //40
            arrActivities.Add(new Activity("Сосновый бор", "ссылка1", "утро/день и вечер", "прогулка", "информация1", 6));
            //41
            arrActivities.Add(new Activity("Андроновский лес", "ссылка1", "утро/день и вечер", "прогулка", "информация1", 6));
            //42
            arrActivities.Add(new Activity("Экскурсия в Каменный город", "ссылка1", "весь день", "выезд", "информация1", 6));
            //43
            arrActivities.Add(new Activity("Экскурсия на Верхнечусовские горки", "ссылка1", "весь день", "выезд", "информация1", 6));
            //44
            arrActivities.Add(new Activity("Камень Ермака и арт-музей кинетических фигур", "ссылка1", "весь день", "выезд", "информация1", 6));
            //45
            arrActivities.Add(new Activity("Картинг KartON", "ссылка1", "утро/день и вечер", "активности", "информация1", 6));
            //46
            arrActivities.Add(new Activity("Пермские термы", "ссылка1", "весь день", "выезд", "информация1", 6));


            //Кафе
            ArrayList arrCafes = new ArrayList(6);
            //0
            arrCafes.Add(new Cafe("Баскин Роббинс", "ссылка1", "утро/день", "с детьми", "информация1", 6));
            //1
            arrCafes.Add(new Cafe("Пахлава", "ссылка1", "утро/день и вечер", "с детьми и без детей", "информация1", 6));
            //2
            arrCafes.Add(new Cafe("ШашлыкOFF", "ссылка1", "утро/день и вечер", "с детьми и без детей", "информация1", 6));
            //3
            arrCafes.Add(new Cafe("Smoky Dog", "ссылка1", "вечер", "без детей", "информация1", 6));
            //4
            arrCafes.Add(new Cafe("Трамвай-кафе", "ссылка1", "утро/день и вечер", "с детьми и без детей", "информация1", 6));
            //5
            arrCafes.Add(new Cafe("Котокафе", "ссылка1", "утро/день и вечер", "с детьми и без детей", "информация1", 6));
        }
    }
}