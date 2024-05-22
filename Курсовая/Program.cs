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

        //Отправка сообщений пользователю
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
                    case "Другой вариант": //не реализовано
                        {
                            await sendMessage(botClient, chatId, "Выберите тип активности:", GetButtonsType());
                            userState.LastCommand = message.Text;
                            return;
                        }
                    case "Сменить активность": //не реализовано
                        {
                            await sendMessage(botClient, chatId, "Выберите тип активности:", GetButtonsType());
                            userState.LastCommand = message.Text;
                            return;
                        }
                    case "Сменить кафе": //не реализовано
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
                    case "Выезд за пределы города": //не реализовано
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Сам вариант", replyMarkup: GetButtonsVariants());
                            userState.LastCommand = message.Text;
                            return;
                        }
                    case "Досуг с детьми":
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите время суток:", replyMarkup: GetButtonsTime());
                            userState.LastCommand = message.Text;
                            return;
                        }
                    case "Помощь"://не реализовано
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

        //меню выезда
        private static IReplyMarkup? GetButtonsVariants()
        {
            var keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton ("Другой вариант") },
                    new List<KeyboardButton> { new KeyboardButton ("Помощь"), new KeyboardButton("Вернуться к выбору времени суток"), new KeyboardButton("Вернуться к выбору типа активности") }

                };
            return new ReplyKeyboardMarkup(keyboard);
        }

        //Меню итоговых вариантов
        private static IReplyMarkup GetButtonsReturn()
        {
            var keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton ("Другой вариант") },
                    new List<KeyboardButton> { new KeyboardButton ("Сменить активность"), new KeyboardButton("Сменить кафе") },
                    new List<KeyboardButton> { new KeyboardButton ("Помощь"), new KeyboardButton("Вернуться к выбору времени суток"), new KeyboardButton("Вернуться к выбору типа активности") }

                };
            return new ReplyKeyboardMarkup(keyboard);
        }

        //ПОМОЩЬ
        private static IReplyMarkup GetHelpButtons()// не реализовано
        {
            var keyboard = new List<List<KeyboardButton>>
            {
                   new List<KeyboardButton> { new KeyboardButton ("Кнопка 1"), new KeyboardButton ("Кнопка 2") },
                   new List<KeyboardButton> { new KeyboardButton ("Кнопка 3") }
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

            //Активности
            ArrayList arrActivities = new ArrayList(49);
            //0
            arrActivities.Add(new Activity("Пермский цирк", "https://www.circus-perm.ru/", "утро/день", "досуг с детьми", "Цирк - это захватывающее зрелище, где искусные артисты исполняют" +
                " удивительные трюки, поражающие воображение зрителей. Каждое представление - это яркий праздник, полный смеха, удивления и " +
                "восторга.", 3000));
            //1
            arrActivities.Add(new Activity("Парк Горького", "https://www.parkperm.ru/", "утро/день и вечер", "досуг с детьми и активности", "Пермский парк Горького" +
                " - это зеленый оазис в центре Перми, идеальное место для отдыха и развлечений. Здесь можно прогуляться по живописным аллеям, насладиться аттракционами " +
                "и посетить разнообразные культурные мероприятия. Стоимость рассчитана на 2-х человек примерно на 4-5 аттракционов.", 4000));
            //2
            arrActivities.Add(new Activity("Зоопарк", "http://zoo.perm.ru/", "утро/день", "досуг с детьми", "Пермский зоопарк - это увлекательное место, где можно увидеть разнообразие" +
                " животных со всего мира. Здесь созданы комфортные условия для обитателей, а также проводятся образовательные программы и мероприятия для посетителей всех " +
                "возрастов.", 600));
            //3
            arrActivities.Add(new Activity("Perm Stand-Up", "https://vk.com/standupperm", "вечер", "активности", "Стендап - это жанр комедийного искусства, где " +
                "комик выступает перед аудиторией с остроумными и часто провокационными монологами. Каждое выступление - это живое общение, наполненное юмором " +
                "и актуальными шутками, отражающими современные реалии и личный опыт комика.", 300));
            //4
            arrActivities.Add(new Activity("Прогулка на лодочке", "https://vk.com/river_tram", "утро/день и вечер", "прогулки", "Прогулка на лодочке - это спокойное" +
                " и романтичное времяпрепровождение, когда можно наслаждаться красотой природы и тихим плеском воды. Этот вид отдыха позволяет расслабиться, отдохнуть" +
                " от городской суеты и насладиться моментами умиротворения и гармонии.", 1000));
            //5
            arrActivities.Add(new Activity("Пермский планетарий", "https://www.planetarium.perm.ru/", "утро/день", "досуг с детьми", "Пермский планетарий - это захватывающее место, где " +
                "можно погрузиться в тайны Вселенной и насладиться красотой звездного неба. Здесь проводятся интересные лекции и шоу, которые позволяют узнать больше" +
                " о космосе и астрономии, делая науку увлекательной и доступной для всех возрастов.", 600));
            //6
            arrActivities.Add(new Activity("Парк науки", "https://parknauki.bitrix24site.ru/", "утро/день", "досуг с детьми и активности", "Парк науки в Перми - это " +
                "интерактивное пространство, где наука становится доступной и увлекательной. Посетители могут участвовать в разнообразных экспериментах, изучать научные " +
                "экспонаты и открывать для себя мир технологий и инноваций в увлекательной форме.", 700));
            //7
            arrActivities.Add(new Activity("Экскурсия на шоколадную фабрику", "https://candyfactoryperm.com/jekskursii/", "утро/день и вечер", "экскурсии",
                "Экскурсия на «Кондитерскую фабрику «Пермская» — это не только увлекательнейшее знакомство с историей предприятия, но и посещение кондитерского" +
                " производства — приключение, которое никого не оставит равнодушным. Посетители своими глазами увидят, как на свет появляются любимые всеми конфеты, " +
                "пекутся вафли и производятся фруктовые пастилки.", 4000));
            //8
            arrActivities.Add(new Activity("Караоке с отдельными комнатами", "https://clubperm.ru/karaoke", "вечер", "активности", "Караоке - это веселое и захватывающее" +
                " развлечение, где каждый может почувствовать себя звездой сцены, исполняя любимые песни перед друзьями или незнакомыми. Это отличный способ развлечься, " +
                "поднять настроение и создать незабываемые воспоминания, вне зависимости от того, как хорошо поется.", 2000));
            //9
            arrActivities.Add(new Activity("Мегалэнд", "https://megalandpark.ru/perm", "утро/день", "досуг с детьми", "Мегалэнд - это увлекательный парк развлечений, где каждый найдет что-то " +
                "по своему вкусу. С аттракционами для детей и взрослых, игровыми зонами, кинотеатром и кафе, Мегалэнд предлагает яркие и запоминающиеся моменты для всей семь" +
                "и или компании друзей.", 1400));
            //10
            arrActivities.Add(new Activity("Боулинг", "https://vk.com/wall-3551694_45737121", "утро/день и вечер", "активности", "Боулинг - это забавное времяпрепровождение, подходяще" +
                "е для всей семьи или друзей. Боулинг объединяет веселье и соревновательный дух, создавая атмосферу, где можно отдохнуть, расслабиться и насладиться временем в приятной " +
                "компании.", 2000));
            //11
            arrActivities.Add(new Activity("Кино + PlayDay", "https://play-day.ru/", "утро/день и вечер", "досуг с детьми и активности", "Play Day - это забавное мероприятие, наполненное" +
                " играми, развлечениями и творческими активностями. Здесь каждый может найти что-то интересное и провести время с удовольствием.", 2600));
            //12
            arrActivities.Add(new Activity("Гейм-клуб", "https://darugame.ru/", "утро/день и вечер", "активности", "Daru Game - это компьютерный клуб, где геймеры могут наслаждаться " +
                "широким выбором игр, соревноваться с друзьями и участвовать в турнирах. Здесь создана атмосфера, способствующая обмену опытом, общению и веселому времяпрепровождению " +
                "в мире виртуальных приключений.", 500));
            //13
            arrActivities.Add(new Activity("Антикафе", "https://vk.com/paradoxperm", "утро/день", "активности", "Антикафе - это место, где посетители платят за время, проведенное в его" +
                " стенах, а не за заказанные напитки или закуски. Здесь вы можете насладиться общением с друзьями, игрой в настольные или компьютерные игры, читать книги, работать или " +
                "заниматься любимым делом, находясь в уютной и дружелюбной обстановке.", 1000));
            //14
            arrActivities.Add(new Activity("Нетипичный тир", "https://perm.moremotions.ru/catalog/item/Kreativnaya-komnata-tir-i-kartina-emociy?utm_source=yandex%7Csearch&utm_medium" +
                "=cpc&utm_campaign=cid%7C98094058%7CMK_Obshhaya_Perm&utm_content=gid%7C5306862209%7Caid%7C15718877658%7C7_7%7Cc%3A98094058%7Cg%3A5306862209%7Cb%3A15718877658%7Ck%3A7" +
                "%7Cst%3Asearch%7Ca%3Ano%7Cs%3Anone%7Ct%3Apremium%7Cp%3A3%7Cr%3A7%7Cdev%3Adesktop&utm_term=&roistat=direct10_search_15718877658_filter&roistat_referrer=none&roistat_pos" +
                "=premium_3&cm_id=98094058_5306862209_15718877658_7_7_none_search_type1_no_desktop_premium_11108&yclid=6859792276545601535", "утро/день", "активности", "На работе не поймут, в" +
                " семье будут задавать кучу вопросов, на улице как-то не то… Гость проходит в специальную комнату, в которой его ждет нетипичный тир, в котором можно использовать посуду" +
                " и манекены и битва красок, позволяющая выплеснуть все свои эмоций.", 5000));
            //15
            arrActivities.Add(new Activity("Урок стрельбы из лука", "https://perm.moremotions.ru/catalog/item/Urok-strelyby-iz-lukaW", "утро/день", "активности", "Стрельба из лука помогает " +
                "исправить осанку, укрепить мышцы спины и развить вестибулярный аппарат. А еще это интересно! ", 1000));
            //16
            arrActivities.Add(new Activity("Гончарный мастер-класс", "https://perm.moremotions.ru/catalog/item/Master-klass-po-goncharnomu-masterstvu-v-gruppe", "утро / день", "активности", "Работа" +
                " с глиной вызывают кардинально разные ощущения, впечатляя сменой состояний и переживаний во время творческого процесса.", 2400));
            //17
            arrActivities.Add(new Activity("Мастер-класс по кофе", "https://perm.moremotions.ru/catalog/item/Individualniy-master-klass-po-prigotovlenyu-cofe-v-domashnih-usloviyah", "утро/день",
                "активности", "Уметь приготовить вкуснейший кофе, чтобы порадовать себя и близкого человека — ценный навык, заслуживающий восхищения. ", 4400));
            //18
            arrActivities.Add(new Activity("Прогулка на каяках", "https://perm.moremotions.ru/catalog/item/Semeynaya-progulka-na-kayakah", "весь день", "активности", "Каяки - это узкие гребные " +
                "лодки с острыми носом и кормой, обладающие высокой маневренностью. Гостей ждёт увлекательная водная прогулка по реке Кама! Это интересная возможность провести время и получить " +
                "новые впечатления с семьей.", 3500));
            //19
            arrActivities.Add(new Activity("Катание на сап-борде в Хохловке", "https://perm.moremotions.ru/catalog/item/Progulka-na-SAP-borde-po-Hohlovke", "весь день", "активности", "Катание " +
                "на SUP-борде по Каме - новая, но уже очень популярная услуга! Гость учится стоять на доске и плыть в почти медитативном состоянии. SUP, так модный в Европе, весьма условно можно" +
                " назвать экстремальным видом спорта. ", 3800));
            //20
            arrActivities.Add(new Activity("Краш-комната для компании", "https://perm.moremotions.ru/catalog/item/Svidanye-krash-komnata-dlya-snyanya-stressa", "утро/день и вечер", "активности", "Все " +
                "устают, выгорают, злятся. И так хочется освободить свое тело и мысли от негатива и агрессии, выплеснуть все это. ", 15000));
            //21
            arrActivities.Add(new Activity("Экскурсия на производство роботов Промобот", "https://promo-bot.ru/tour/", "утро/день", "экскурсии", "В Пермском периоде истории России была организована" +
                " первая в стране экскурсия на производство человекоподобных роботов. Это событие стало важным шагом в развитии технологий и вызвало оживленный интерес к перспективам использования " +
                "робототехники.", 5000));
            //22
            arrActivities.Add(new Activity("Хохловка - музей под открытым небом", "https://museumperm.ru/branch/khokhlovka", "весь день", "выезд", "Первый на Урале музей деревянного зодчества" +
                " под открытым небом расположен на живописном берегу Камы в 43 км. от Перми. В «Хохловку» перевезено много уникальных памятников деревянной архитектуры Прикамья, но удивляет она " +
                "не только этим.", 700));
            //23
            arrActivities.Add(new Activity("Музей пермских древностей", "https://museumperm.ru/branch/mpd", "утро/день", "экскурсии", "В недрах Пермского края скрыта удивительная летопись, " +
                "которая дала название уникальному этапу развития жизни на Земле продолжительностью 50 000 000 лет — «пермский период», «пермь». В то время все материки слились в единый " +
                "суперконтинет Пангея, а в глубинах планеты формировались золото и алмазы. Древнее пермское море, отступив в конце пермского периода, оставило богатейшие залежи солей," +
                " гипсов, селенита.", 600));
            //24
            arrActivities.Add(new Activity("Экскурсия в ботанический сад ПГНИУ", "https://vk.com/botsad_perm", "утро/день", "экскурсии", "В настоящее время Ботанический сад имени " +
                "профессора А.Г. Генкеля входит в состав регионального Совета ботанических садов Урала и Поволжья, имеет статус научного учреждения и особо охраняемой природной " +
                "территории. Основными научными направлениями работы являются: интродукция и акклиматизация растений, выведение и отбор новых форм и сортов, наиболее стойких и " +
                "продуктивных в местных условиях.", 600));
            //25
            arrActivities.Add(new Activity("Берег реки Мулянка", "https://vk.com/wall-3551694_3253589", "утро/день", "прогулка", "Место, надо сказать, довольно миловидное. " +
                "Туда и позагорать можно прийти - мест достаточно, и покупаться всей семьей, ибо неглубоко, и даже, при случае, посмотреть на уточек.", 0));
            //26
            arrActivities.Add(new Activity("Сад соловьёв", "https://vk.com/uinka", "утро/день", "прогулка", "Парк Соловьёва в Перми - это место, где природа раскрывает" +
                " всю свою красоту и спокойствие. Здесь можно прогуляться по зеленым аллеям, насладиться свежим воздухом и отдохнуть от городской суеты.", 0));
            //27
            arrActivities.Add(new Activity("Мост тысяча ступеней", "https://vk.com/wall-3551694_3359465", "утро/день", "прогулка", "Мост Тысячи Ступеней в Перми -" +
                " это захватывающая архитектурная конструкция, ведущая через живописную долину реки Кама. Его уникальность заключается в том, что он состоит из тысячи" +
                " ступеней, ведущих к вершине холма, откуда открывается великолепный вид на окрестности и реку. ", 0));
            //28
            arrActivities.Add(new Activity("Старокирпичный переулок", "https://vk.com/oldtownperm", "утро/день и вечер", "активности и прогулка", "Это атмосферное лофт-пространство в историческом" +
                " центре Перми, сводчатый кирпичный тоннель которого ведет в уютный дворик с качелями, кофейнями и дизайнерскими магазинчиками. А еще здесь можно заказать" +
                " настоящую итальянскую пиццу из дровяной печи.", 0));
            //29
            arrActivities.Add(new Activity("Парк камней", "https://www.tourister.ru/world/europe/russia/city/perm/parks/28069", "утро/день и вечер", "прогулка", "Парк активно " +
                "насаждается молодыми саженцами самых разных деревьев: яблонь, вязов, лиственниц, кленов, лип и прочих, также он украшен клумбами с цветами. Здесь много скамеек " +
                "и фонарей, есть несколько красивых композиций из растений в самом центре сада и пара бассейнов, оформленных под фонтаны.", 0));
            //30
            arrActivities.Add(new Activity("Арт-пространство завод Шпагина", "https://zav-shpag.com/", "утро /день", "прогулка и активности", "Арт-пространство завод Шпагина - " +
                "это уникальное место, где современное искусство оживает в промышленной атмосфере старого завода. Здесь собираются творческие люди, чтобы воплощать свои идеи в" +
                " различных формах искусства, создавая вдохновляющие произведения и проводя интересные мероприятия.", 0));
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
            //48
            arrActivities.Add(new Activity("Хвойная хижина", "ссылка1", "весь день", "выезд", "информация1", 6));


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

//В самой информации, написать, что стоимость активности расчитана на 2-х человек и что цены могут отличаться