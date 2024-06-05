using System.Collections;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Курсовая
{
    public class Program
    {
        private class UserState
        {
            public string? LastCommand { get; set; }
            public Activity? RndAct { get; set; }
            public Cafe? RndCafe { get; set; }
            public List<Activity> acts { get; set; } = new List<Activity>();
            public List<Cafe> cafes { get; set; } = new List<Cafe> { };
        }

        //Создание словаря для многопользовательского интерфейса
        private static readonly Dictionary<long, UserState> userStates = new Dictionary<long, UserState>();

        //фильтрация активностей
        public static List<Activity> FilteredActivities(string time, string type)
        {
            List<Activity> act = new List<Activity>();
            for (int i = 0; i < ActivityArray.allActs.Count; i++)
            {
                Activity activity = ActivityArray.allActs[i];
                if (activity.time.Contains(time) && activity.type.Contains(type))
                {
                    act.Add(activity);
                }
            }
            return act;
        }

        //Фильтрация кафе
        public static List<Cafe> FilteredCafes(string time, string type)
        {
            List<Cafe> cafes = new List<Cafe>();
            for (int i = 0; i < CafeArray.allCafes.Count; i++)
            {
                Cafe cafe = CafeArray.allCafes[i];
                if (cafe.time.Contains(time) && cafe.type.Contains(type))
                {
                    cafes.Add(cafe);
                }
            }
            return cafes;
        }

        //Отправка скомбинированной текст + фото активности
        async static Task SendActivityWithPhotoAsync(ITelegramBotClient botClient, long chatId, Activity activity)
        {
            if (activity == null)
            {
                await botClient.SendTextMessageAsync(chatId, "Рекомендации не найдены, перезапустите бота командой /start");
                return;
            }

            string messageText = activity.ToString();
            if (!string.IsNullOrEmpty(messageText))
            {

                await botClient.SendTextMessageAsync(chatId, messageText);

                await botClient.SendPhotoAsync(
                    chatId: chatId,
                    photo: InputFile.FromUri(activity.picture));
            }
        }

        //Отправка скомбинированной текст + фото активности
        async static Task SendCafeWithPhotoAsync(ITelegramBotClient botClient, long chatId, Cafe cafe)
        {
            if (cafe == null)
            {
                await botClient.SendTextMessageAsync(chatId, "Рекомендации не найдены, перезапустите бота командой /start");
                return;
            }

            string messageText = cafe.ToString();

            if (!string.IsNullOrEmpty(messageText))
            {
                await botClient.SendTextMessageAsync(chatId, messageText);

                await botClient.SendPhotoAsync(
                    chatId: chatId,
                    photo: InputFile.FromUri(cafe.picture));
            }
        }

        //Отправка сообщений пользователю
        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            Random random = new Random();
            int sum = 0;

            

            Message message = update.Message;
            if (message.Text != null)
            {
                long chatId = message.Chat.Id;

                if (!userStates.ContainsKey(chatId))
                {
                    userStates[chatId] = new UserState();
                }

                UserState userState = userStates[chatId];

                //Кнопки
                switch (message.Text)
                {
                    case "/start":
                    case "Вернуться к выбору типа активности":
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите тип активности:", replyMarkup: GetButtonsType());
                            return;
                        }
                    case "Другой вариант":
                        {
                            if (userState.acts.Count > 0 && userState.cafes.Count > 0)
                            {
                                userState.RndAct = userState.acts[random.Next(userState.acts.Count)];
                                userState.RndCafe = userState.cafes[random.Next(userState.cafes.Count)];
                                if (userState.RndAct != null && userState.RndCafe != null)
                                {
                                    sum = userState.RndAct.cost + userState.RndCafe.cost;
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                            }

                            await SendActivityWithPhotoAsync(botClient, message.Chat.Id, userState.RndAct);
                            await SendCafeWithPhotoAsync(botClient, message.Chat.Id, userState.RndCafe);

                            string combinedMessage = $"Итоговая сумма: {sum}";
                            await botClient.SendTextMessageAsync(message.Chat.Id, combinedMessage, replyMarkup: GetButtonsVariants());
                            return;
                        }
                    case "Другой вариант поездки":
                        {
                            if (userState.acts.Count > 0)
                            {
                                userState.RndAct = userState.acts[random.Next(userState.acts.Count)];
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                            }
                            await SendActivityWithPhotoAsync(botClient, message.Chat.Id, userState.RndAct);

                            string combinedMessage = $"Итоговая сумма: {userState.RndAct.cost}";
                            await botClient.SendTextMessageAsync(message.Chat.Id, combinedMessage, replyMarkup: GetButtonsReturn());
                            return;
                        }
                    case "Сменить активность":
                        {
                            if (userState.acts.Count > 0)
                            {
                                userState.RndAct = userState.acts[random.Next(userState.acts.Count)];

                                if (userState.RndAct != null && userState.RndCafe != null)
                                {
                                    sum = userState.RndAct.cost + userState.RndCafe.cost;
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                            }

                            await SendActivityWithPhotoAsync(botClient, message.Chat.Id, userState.RndAct);
                            await SendCafeWithPhotoAsync(botClient, message.Chat.Id, userState.RndCafe);

                            string combinedMessage = $"Итоговая сумма: {sum}";
                            await botClient.SendTextMessageAsync(message.Chat.Id, combinedMessage, replyMarkup: GetButtonsVariants());
                            return;
                        }
                    case "Сменить кафе":
                        {
                            if (userState.cafes.Count > 0)
                            {
                                userState.RndCafe = userState.cafes[random.Next(userState.cafes.Count)];

                                if (userState.RndAct != null && userState.RndCafe != null)
                                {
                                    sum = userState.RndAct.cost + userState.RndCafe.cost;
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены. Рекомендации не найдены, перезапустите бота командой /start\"");
                            }

                            await SendActivityWithPhotoAsync(botClient, message.Chat.Id, userState.RndAct);
                            await SendCafeWithPhotoAsync(botClient, message.Chat.Id, userState.RndCafe);

                            string combinedMessage = $"Итоговая сумма: {sum}";
                            await botClient.SendTextMessageAsync(message.Chat.Id, combinedMessage, replyMarkup: GetButtonsVariants());
                            return;
                        }
                    case "Вернуться к выбору времени суток":
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите время суток:", replyMarkup: GetButtonsTime());
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
                            userState.acts = FilteredActivities("весь день", "выезд");

                            if (userState.acts.Count > 0)
                            {
                                userState.RndAct = userState.acts[random.Next(userState.acts.Count)];
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                            }

                            await SendActivityWithPhotoAsync(botClient, message.Chat.Id, userState.RndAct);

                            string combinedMessage = $"Итоговая сумма: {userState.RndAct.cost}";
                            await botClient.SendTextMessageAsync(message.Chat.Id, combinedMessage, replyMarkup: GetButtonsReturn());
                            return;
                        }
                    case "Досуг с детьми":
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите время суток:", replyMarkup: GetButtonsTime());
                            userState.LastCommand = message.Text;
                            return;
                        }
                    case "Помощь":
                    case "/help":
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Здравствуйте!\n\n\nСпасибо за обращение в нашу службу " +
                              "поддержки.\n\n\nЕсли у вас возникла проблема или вам нужна помощь, пожалуйста, напишите нам на наш э" +
                              "лектронный адрес mamurzina@edu.hse.ru Опишите свою проблему как можно более подробно, чтобы мы могли быстрее " +
                              "и точнее вам помочь.\n\n\nНе забудьте указать следующую информацию:\r\n- Ваше имя в Telegram\r\n- Подробное " +
                              "описание проблемы\r\n- Любые сообщения об ошибках, которые вы видите\r\n- Шаги, которые вы предприняли перед" +
                              " возникновением проблемы\r\n\r\nМы стремимся ответить на все запросы в течение 24 часов. Спасибо за ваше " +
                              "терпение и понимание.\r\n\r\nС уважением,\r\nКоманда поддержки", replyMarkup: GetButtonsHelp());
                            return;
                        }
                    case "Утро или день":
                        {
                            if (userState.LastCommand == "Активность")
                            {
                                userState.acts = FilteredActivities("утро/день", "активности");
                                userState.cafes = FilteredCafes("утро/день", "активности");

                                if (userState.acts.Count > 0 && userState.cafes.Count > 0)
                                {
                                    userState.RndAct = userState.acts[random.Next(userState.acts.Count)];
                                    userState.RndCafe = userState.cafes[random.Next(userState.cafes.Count)];

                                    if (userState.RndAct != null && userState.RndCafe != null)
                                    {
                                        sum = userState.RndAct.cost + userState.RndCafe.cost;
                                    }
                                    else
                                    {
                                        await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                    }
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                }

                                await SendActivityWithPhotoAsync(botClient, message.Chat.Id, userState.RndAct);
                                await SendCafeWithPhotoAsync(botClient, message.Chat.Id, userState.RndCafe);

                                string combinedMessage = $"Итоговая сумма: {sum}";
                                await botClient.SendTextMessageAsync(message.Chat.Id, combinedMessage, replyMarkup: GetButtonsVariants());
                            }

                            if (userState.LastCommand == "Прогулки")
                            {
                                userState.acts = FilteredActivities("утро/день", "прогулка");
                                userState.cafes = FilteredCafes("утро/день", "прогулка");

                                if (userState.acts.Count > 0 && userState.cafes.Count > 0)
                                {
                                    userState.RndAct = userState.acts[random.Next(userState.acts.Count)];
                                    userState.RndCafe = userState.cafes[random.Next(userState.cafes.Count)];

                                    if (userState.RndAct != null && userState.RndCafe != null)
                                    {
                                        sum = userState.RndAct.cost + userState.RndCafe.cost;
                                    }
                                    else
                                    {
                                        await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                    }
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                }

                                await SendActivityWithPhotoAsync(botClient, message.Chat.Id, userState.RndAct);
                                await SendCafeWithPhotoAsync(botClient, message.Chat.Id, userState.RndCafe);

                                string combinedMessage = $"Итоговая сумма: {sum}";
                                await botClient.SendTextMessageAsync(message.Chat.Id, combinedMessage, replyMarkup: GetButtonsVariants());
                            }

                            if (userState.LastCommand == "Экскурсии")
                            {
                                userState.acts = FilteredActivities("утро/день", "экскурсии");
                                userState.cafes = FilteredCafes("утро/день", "экскурсии");

                                if (userState.acts.Count > 0 && userState.cafes.Count > 0)
                                {
                                    userState.RndAct = userState.acts[random.Next(userState.acts.Count)];
                                    userState.RndCafe = userState.cafes[random.Next(userState.cafes.Count)];

                                    if (userState.RndAct != null && userState.RndCafe != null)
                                    {
                                        sum = userState.RndAct.cost + userState.RndCafe.cost;
                                    }
                                    else
                                    {
                                        await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                    }
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                }

                                await SendActivityWithPhotoAsync(botClient, message.Chat.Id, userState.RndAct);
                                await SendCafeWithPhotoAsync(botClient, message.Chat.Id, userState.RndCafe);

                                string combinedMessage = $"Итоговая сумма: {sum}";
                                await botClient.SendTextMessageAsync(message.Chat.Id, combinedMessage, replyMarkup: GetButtonsVariants());
                            }

                            if (userState.LastCommand == "Досуг с детьми")
                            {
                                userState.acts = FilteredActivities("утро/день", "досуг с детьми");
                                userState.cafes = FilteredCafes("утро/день", "досуг с детьми");

                                if (userState.acts.Count > 0 && userState.cafes.Count > 0)
                                {
                                    userState.RndAct = userState.acts[random.Next(userState.acts.Count)];
                                    userState.RndCafe = userState.cafes[random.Next(userState.cafes.Count)];

                                    if (userState.RndAct != null && userState.RndCafe != null)
                                    {
                                        sum = userState.RndAct.cost + userState.RndCafe.cost;
                                    }
                                    else
                                    {
                                        await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                    }
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                }

                                await SendActivityWithPhotoAsync(botClient, message.Chat.Id, userState.RndAct);
                                await SendCafeWithPhotoAsync(botClient, message.Chat.Id, userState.RndCafe);

                                string combinedMessage = $"Итоговая сумма: {sum}";
                                await botClient.SendTextMessageAsync(message.Chat.Id, combinedMessage, replyMarkup: GetButtonsVariants());
                            }
                            return;
                        }
                    case "Вечер":
                        {
                            if (userState.LastCommand == "Активность")
                            {
                                userState.acts = FilteredActivities("вечер", "активности");
                                userState.cafes = FilteredCafes("вечер", "активности");

                                if (userState.acts.Count > 0 && userState.cafes.Count > 0)
                                {
                                    userState.RndAct = userState.acts[random.Next(userState.acts.Count)];
                                    userState.RndCafe = userState.cafes[random.Next(userState.cafes.Count)];

                                    if (userState.RndAct != null && userState.RndCafe != null)
                                    {
                                        sum = userState.RndAct.cost + userState.RndCafe.cost;
                                    }
                                    else
                                    {
                                        await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                    }
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                }

                                await SendActivityWithPhotoAsync(botClient, message.Chat.Id, userState.RndAct);
                                await SendCafeWithPhotoAsync(botClient, message.Chat.Id, userState.RndCafe);

                                string combinedMessage = $"Итоговая сумма: {sum}";
                                await botClient.SendTextMessageAsync(message.Chat.Id, combinedMessage, replyMarkup: GetButtonsVariants());
                            }

                            if (userState.LastCommand == "Прогулки")
                            {
                                userState.acts = FilteredActivities("вечер", "прогулка");
                                userState.cafes = FilteredCafes("вечер", "прогулка");

                                if (userState.acts.Count > 0 && userState.cafes.Count > 0)
                                {
                                    userState.RndAct = userState.acts[random.Next(userState.acts.Count)];
                                    userState.RndCafe = userState.cafes[random.Next(userState.cafes.Count)];

                                    if (userState.RndAct != null && userState.RndCafe != null)
                                    {
                                        sum = userState.RndAct.cost + userState.RndCafe.cost;
                                    }
                                    else
                                    {
                                        await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                    }
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                }

                                string combinedMessage = $"{userState.RndAct} {userState.RndCafe}\n\n Итоговая сумма: {sum}";
                                await botClient.SendTextMessageAsync(message.Chat.Id, combinedMessage, replyMarkup: GetButtonsVariants());
                            }

                            if (userState.LastCommand == "Экскурсии")
                            {
                                userState.acts = FilteredActivities("вечер", "экскурсии");
                                userState.cafes = FilteredCafes("вечер", "экскурсии");

                                if (userState.acts.Count > 0 && userState.cafes.Count > 0)
                                {
                                    userState.RndAct = userState.acts[random.Next(userState.acts.Count)];
                                    userState.RndCafe = userState.cafes[random.Next(userState.cafes.Count)];

                                    if (userState.RndAct != null && userState.RndCafe != null)
                                    {
                                        sum = userState.RndAct.cost + userState.RndCafe.cost;
                                    }
                                    else
                                    {
                                        await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                    }
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                }

                                await SendActivityWithPhotoAsync(botClient, message.Chat.Id, userState.RndAct);
                                await SendCafeWithPhotoAsync(botClient, message.Chat.Id, userState.RndCafe);

                                string combinedMessage = $"Итоговая сумма: {sum}";
                                await botClient.SendTextMessageAsync(message.Chat.Id, combinedMessage, replyMarkup: GetButtonsVariants());
                            }

                            if (userState.LastCommand == "Досуг с детьми")
                            {
                                userState.acts = FilteredActivities("вечер", "досуг с детьми");
                                userState.cafes = FilteredCafes("вечер", "досуг с детьми");

                                if (userState.acts.Count > 0 && userState.cafes.Count > 0)
                                {
                                    userState.RndAct = userState.acts[random.Next(userState.acts.Count)];
                                    userState.RndCafe = userState.cafes[random.Next(userState.cafes.Count)];

                                    if (userState.RndAct != null && userState.RndCafe != null)
                                    {
                                        sum = userState.RndAct.cost + userState.RndCafe.cost;
                                    }
                                    else
                                    {
                                        await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                    }
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                }

                                await SendActivityWithPhotoAsync(botClient, message.Chat.Id, userState.RndAct);
                                await SendCafeWithPhotoAsync(botClient, message.Chat.Id, userState.RndCafe);

                                string combinedMessage = $"Итоговая сумма: {sum}";
                                await botClient.SendTextMessageAsync(message.Chat.Id, combinedMessage, replyMarkup: GetButtonsVariants());
                            }
                            return;
                        }
                    case "Весь день":
                        {
                            if (userState.LastCommand == "Активность")
                            {
                                userState.acts = FilteredActivities("весь день", "активности");
                                userState.cafes = FilteredCafes("весь день", "активности");

                                if (userState.acts.Count > 0 && userState.cafes.Count > 0)
                                {
                                    userState.RndAct = userState.acts[random.Next(userState.acts.Count)];
                                    userState.RndCafe = userState.cafes[random.Next(userState.cafes.Count)];

                                    if (userState.RndAct != null && userState.RndCafe != null)
                                    {
                                        sum = userState.RndAct.cost + userState.RndCafe.cost;
                                    }
                                    else
                                    {
                                        await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                    }
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                }

                                await SendActivityWithPhotoAsync(botClient, message.Chat.Id, userState.RndAct);
                                await SendCafeWithPhotoAsync(botClient, message.Chat.Id, userState.RndCafe);

                                string combinedMessage = $"Итоговая сумма: {sum}";
                                await botClient.SendTextMessageAsync(message.Chat.Id, combinedMessage, replyMarkup: GetButtonsVariants());
                            }

                            if (userState.LastCommand == "Прогулки")
                            {
                                userState.acts = FilteredActivities("весь день", "прогулка");
                                userState.cafes = FilteredCafes("весь день", "прогулка");

                                if (userState.acts.Count > 0 && userState.cafes.Count > 0)
                                {
                                    userState.RndAct = userState.acts[random.Next(userState.acts.Count)];
                                    userState.RndCafe = userState.cafes[random.Next(userState.cafes.Count)];

                                    if (userState.RndAct != null && userState.RndCafe != null)
                                    {
                                        sum = userState.RndAct.cost + userState.RndCafe.cost;
                                    }
                                    else
                                    {
                                        await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                    }
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                }

                                await SendActivityWithPhotoAsync(botClient, message.Chat.Id, userState.RndAct);
                                await SendCafeWithPhotoAsync(botClient, message.Chat.Id, userState.RndCafe);

                                string combinedMessage = $"Итоговая сумма: {sum}";
                                await botClient.SendTextMessageAsync(message.Chat.Id, combinedMessage, replyMarkup: GetButtonsVariants());
                            }

                            if (userState.LastCommand == "Экскурсии")
                            {
                                userState.acts = FilteredActivities("весь день", "экскурсии");
                                userState.cafes = FilteredCafes("весь день", "экскурсии");

                                if (userState.acts.Count > 0 && userState.cafes.Count > 0)
                                {
                                    userState.RndAct = userState.acts[random.Next(userState.acts.Count)];
                                    userState.RndCafe = userState.cafes[random.Next(userState.cafes.Count)];

                                    if (userState.RndAct != null && userState.RndCafe != null)
                                    {
                                        sum = userState.RndAct.cost + userState.RndCafe.cost;
                                    }
                                    else
                                    {
                                        await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                    }
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                }

                                await SendActivityWithPhotoAsync(botClient, message.Chat.Id, userState.RndAct);
                                await SendCafeWithPhotoAsync(botClient, message.Chat.Id, userState.RndCafe);

                                string combinedMessage = $"Итоговая сумма: {sum}";
                                await botClient.SendTextMessageAsync(message.Chat.Id, combinedMessage, replyMarkup: GetButtonsVariants());
                            }

                            if (userState.LastCommand == "Досуг с детьми")
                            {
                                userState.acts = FilteredActivities("весь день", "досуг с детьми");
                                userState.cafes = FilteredCafes("весь день", "досуг с детьми");

                                if (userState.acts.Count > 0 && userState.cafes.Count > 0)
                                {
                                    userState.RndAct = userState.acts[random.Next(userState.acts.Count)];
                                    userState.RndCafe = userState.cafes[random.Next(userState.cafes.Count)];

                                    if (userState.RndAct != null && userState.RndCafe != null)
                                    {
                                        sum = userState.RndAct.cost + userState.RndCafe.cost;
                                    }
                                    else
                                    {
                                        await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                    }
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(message.Chat.Id, "Рекомендации не найдены, перезапустите бота командой /start");
                                }

                                await SendActivityWithPhotoAsync(botClient, message.Chat.Id, userState.RndAct);
                                await SendCafeWithPhotoAsync(botClient, message.Chat.Id, userState.RndCafe);

                                string combinedMessage = $"Итоговая сумма: {sum}";
                                await botClient.SendTextMessageAsync(message.Chat.Id, combinedMessage, replyMarkup: GetButtonsVariants());
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

        //меню выезда
        private static IReplyMarkup GetButtonsVariants()
        {
            var keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton ("Другой вариант") },
                    new List<KeyboardButton> { new KeyboardButton ("Сменить активность"), new KeyboardButton("Сменить кафе") },
                    new List<KeyboardButton> { new KeyboardButton ("Помощь"), new KeyboardButton("Вернуться к выбору времени суток"), new KeyboardButton("Вернуться к выбору типа активности") }

                };
            return new ReplyKeyboardMarkup(keyboard);
        }

        //Меню итоговых вариантов
        private static IReplyMarkup GetButtonsReturn()
        {
            var keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton ("Другой вариант поездки") },
                    new List<KeyboardButton> { new KeyboardButton ("Помощь"), new KeyboardButton("Вернуться к выбору времени суток"), new KeyboardButton("Вернуться к выбору типа активности") }

                };
            return new ReplyKeyboardMarkup(keyboard);
        }

        //ПОМОЩЬ
        private static IReplyMarkup GetButtonsHelp()
        {
            var keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton ("Вернуться к выбору типа активности") },

                };
            return new ReplyKeyboardMarkup(keyboard);
        }

        //Меню выбора времени суток
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

        //Меню выбора активности
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

        //Обработка ошибок
        private static async Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            Console.WriteLine($"Ошибка: {exception.Message}");
        }

        static void Main(string[] args)
        {
            var client = new TelegramBotClient("7085153126:AAFEVPuuMKbIubl60qBuIISP3Ogo6vkQpUw");
            client.StartReceiving(Update, Error, null);
            Console.ReadLine();
        }       
    }
}


//GPT - многопользовательская поддержка - как учесть предыдущую кнопку