using System.Collections;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
namespace Курсовая
{
    //Объявления делегата для отправки сообщений и меню
    public delegate Task SendMessageDelegate(ITelegramBotClient botClient, long chatId, string text, IReplyMarkup replyMarkup);
    public class Program
    {
        //Запоминание последней команды
        private class UserState
        {
            public string LastCommand { get; set; }
        }

        //Создание словаря для многопользовательского интерфейса
        private static readonly Dictionary<long, UserState> userStates = new Dictionary<long, UserState>();

        //Метод для делегата
        private async static Task SendMessage(ITelegramBotClient botClient, long chatId, string text, IReplyMarkup replyMarkup)
        {
            await botClient.SendTextMessageAsync(chatId, text, replyMarkup: replyMarkup);
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            SendMessageDelegate sendMessage = SendMessage;
            var message = update.Message;
            if (message.Text != null)
            {
                var chatId = message.Chat.Id;

                if (!userStates.ContainsKey(chatId))
                {
                    userStates[chatId] = new UserState();
                }

                var userState = userStates[chatId];

                switch (message.Text)
                {
                    case "/start":
                    case "Вернуться к выбору типа активности":
                        {
                            await sendMessage(botClient, chatId, "Выберите тип активности:", GetButtonsType());
                            userState.LastCommand = message.Text;
                            return;
                        }
                    case "Вернуться к выбору времени суток":
                        {
                            await sendMessage(botClient, chatId, "Выберите время суток:", GetButtonsTime());
                            userState.LastCommand = message.Text;
                            return;
                        }
                    case "Активность":
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите время суток:", replyMarkup: GetButtonsTime());
                            userState.LastCommand = message.Text;
                            return;
                        }
                    case "Прогулки":
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите время суток:", replyMarkup: GetButtonsTime());
                            userState.LastCommand = message.Text;
                            return;
                        }
                    case "Экскурсии":
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите время суток:", replyMarkup: GetButtonsTime());
                            userState.LastCommand = message.Text;
                            return;
                        }
                    case "Выезд за пределы города":
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите время суток:", replyMarkup: GetButtonsTime());
                            userState.LastCommand = message.Text;
                            return;
                        }
                    case "Досуг с детьми":
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите время суток:", replyMarkup: GetButtonsTime());
                            userState.LastCommand = message.Text;
                            return;
                        }
                    case "Помощь":
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id, "ЖЁСТКО ПОМОГАЕМ", replyMarkup: GetHelpButtons());
                            userState.LastCommand = message.Text;
                            return;
                        }
                    case "Утро или день":
                        {
                            if (userState.LastCommand == "Активность")
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Вы выбрали Активность - Утро или день", replyMarkup: GetButtonsReturn());
                            }
                            if (userState.LastCommand == "Прогулки")
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Вы выбрали Прогулки - Утро или день", replyMarkup: GetButtonsReturn());
                            }
                            if (userState.LastCommand == "Экскурсии")
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Вы выбрали Экскурсии - Утро или день", replyMarkup: GetButtonsReturn());
                            }
                            if (userState.LastCommand == "Выезд за пределы города")
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Вы выбрали Выезд за пределы города - Утро или день", replyMarkup: GetButtonsReturn());
                            }
                            if (userState.LastCommand == "Досуг с детьми")
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Вы выбрали Досуг с детьми - Утро или день", replyMarkup: GetButtonsReturn());
                            }
                            return;
                        }
                    case "Вечер":
                        {
                            if (userState.LastCommand == "Активность")
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Вы выбрали Активность - Вечер", replyMarkup: GetButtonsReturn());
                            }
                            if (userState.LastCommand == "Прогулки")
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Вы выбрали Прогулки - Вечер", replyMarkup: GetButtonsReturn());
                            }
                            if (userState.LastCommand == "Экскурсии")
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Вы выбрали Экскурсии - Вечер", replyMarkup: GetButtonsReturn());
                            }
                            if (userState.LastCommand == "Выезд за пределы города")
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Вы выбрали Выезд за пределы города - Вечер", replyMarkup: GetButtonsReturn());
                            }
                            if (userState.LastCommand == "Досуг с детьми")
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Вы выбрали Досуг с детьми - Вечер", replyMarkup: GetButtonsReturn());
                            }
                            return;
                        }
                    case "Весь день":
                        {
                            if (userState.LastCommand == "Активность")
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Вы выбрали Активность - Весь день", replyMarkup: GetButtonsReturn());
                            }
                            if (userState.LastCommand == "Прогулки")
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Вы выбрали Прогулки - Весь день", replyMarkup: GetButtonsReturn());
                            }
                            if (userState.LastCommand == "Экскурсии")
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Вы выбрали Экскурсии - Весь день", replyMarkup: GetButtonsReturn());
                            }
                            if (userState.LastCommand == "Выезд за пределы города")
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Вы выбрали Выезд за пределы города - Весь день", replyMarkup: GetButtonsReturn());
                            }
                            if (userState.LastCommand == "Досуг с детьми")
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Вы выбрали Досуг с детьми - Весь день", replyMarkup: GetButtonsReturn());
                            }
                            return;
                        }
                    default:
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Данной команды не существует, вы возвращены в меню выбора типа активности", replyMarkup: GetButtonsType());
                            userState.LastCommand = message.Text;
                            return;
                        }
                }
            }
        }

        private static IReplyMarkup GetButtonsReturn()
        {
            var keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton ("Вернуться к выбору времени суток") },
                    new List<KeyboardButton> { new KeyboardButton ("Вернуться к выбору типа активности") },
                    new List<KeyboardButton> { new KeyboardButton ("Помощь") }

                };
            return new ReplyKeyboardMarkup(keyboard);
        }


        private static IReplyMarkup GetHelpButtons()
        {
            var keyboard = new List<List<KeyboardButton>>
    {
        new List<KeyboardButton> { new KeyboardButton ("Кнопка 1"), new KeyboardButton ("Кнопка 2") },
        new List<KeyboardButton> { new KeyboardButton ("Кнопка 3") }
    };

            return new ReplyKeyboardMarkup(keyboard);
        }

        private static IReplyMarkup GetButtonsTime()
        {
            var keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton ("Утро или день"), new KeyboardButton ("Вечер"), new KeyboardButton ("Весь день") },
                    new List<KeyboardButton> { new KeyboardButton ("Вернуться к выбору типа активности") },
                      new List<KeyboardButton> { new KeyboardButton ("Помощь") }
                };
            return new ReplyKeyboardMarkup(keyboard);
        }

        private static IReplyMarkup GetButtonsType()
        {

            var keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton ("Активность"), new KeyboardButton ("Прогулки") },
                    new List<KeyboardButton> { new KeyboardButton ("Экскурсии"), new KeyboardButton ("Выезд за пределы города"), new KeyboardButton ("Досуг с детьми") },
                    new List<KeyboardButton> { new KeyboardButton ("Помощь") }
                };
            return new ReplyKeyboardMarkup(keyboard);
        }
        private static async Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            Console.WriteLine($"Ошибка: {exception.Message}");
        }
        static void Main(string[] args)
        {
            var client = new TelegramBotClient("7085153126:AAFEVPuuMKbIubl60qBuIISP3Ogo6vkQpUw");
            client.StartReceiving(Update, Error, null);
            Console.ReadLine();





            //Активности
            ArrayList arrActivities = new ArrayList(48);
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
            //47
            arrActivities.Add(new Activity("Экскурсия Пермь мистическая", "ссылка1", "вечер", "экскурсия", "информация1", 6));


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
//GPT - многопользовательская поддержка - как учесть предыдущую кнопку
// правки: добавить делегаты и linq запросы