﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая
{
    public class ActivityArray
    {
        public static List<Activity> allActs = new List<Activity>
    {
        //Активности
            //0
            new Activity("Пермский цирк", "https://www.circus-perm.ru/", "утро/день", "досуг с детьми", "Цирк - это захватывающее зрелище, где искусные артисты исполняют" +
                " удивительные трюки, поражающие воображение зрителей. Каждое представление - это яркий праздник, полный смеха, удивления и " +
                "восторга.", 3000, "https://schools11kiz.ru/images/p146_kp41rl5tixc.jpg"),
            //1
            new Activity("Парк Горького", "https://www.parkperm.ru/", "утро/день и вечер", "досуг с детьми и активности", "Пермский парк Горького" +
                " - это зеленый оазис в центре Перми, идеальное место для отдыха и развлечений. Здесь можно прогуляться по живописным аллеям, насладиться аттракционами " +
                "и посетить разнообразные культурные мероприятия. Стоимость рассчитана на 2-х человек примерно на 4-5 аттракционов.", 4000, "https://sun9-25.userapi.com/impg/W-5K" +
               "1q7Nz1_YM5LukhxrmC4w4ndFILx5DdugoA/FS7i2G88Eh4.jpg?size=1080x719&quality=95&sign=e3a2e11d70aba1b7db0f7671e6868687&c_uniq_tag=3fJKN41NNqO9_csuTew_Ihsgr6lQ9NZONIYRa8XZRU0&type=album"),
            //2
            new Activity("Зоопарк", "http://zoo.perm.ru/", "утро/день", "досуг с детьми", "Пермский зоопарк - это увлекательное место, где можно увидеть разнообразие" +
                " животных со всего мира. Здесь созданы комфортные условия для обитателей, а также проводятся образовательные программы и мероприятия для посетителей всех " +
                "возрастов.", 600, "https://flud.perm.ru/forum/uploads/monthly_2023_03/04032023.jpg.b21e7f8d6605e055a9176dce7c401f94.jpg"),
            //3
            new Activity("Perm Stand-Up", "https://vk.com/standupperm", "вечер", "активности", "Стендап - это жанр комедийного искусства, где " +
                "комик выступает перед аудиторией с остроумными и часто провокационными монологами. Каждое выступление - это живое общение, наполненное юмором " +
                "и актуальными шутками, отражающими современные реалии и личный опыт комика.", 300, "https://avatars.dzeninfra.ru/get-zen_doc/1581919/pub_5e2afa533d5f6900ad428d8" +
                "3_5e2afe7eb477bf00b1cc3291/scale_1200"),
            //4
            new Activity("Прогулка на лодочке", "https://vk.com/river_tram", "утро/день и вечер и весь день", "прогулка", "Прогулка на лодочке - это спокойное" +
                " и романтичное времяпрепровождение, когда можно наслаждаться красотой природы и тихим плеском воды. Этот вид отдыха позволяет расслабиться, отдохнуть" +
                " от городской суеты и насладиться моментами умиротворения и гармонии.", 1000, "https://img.tourister.ru/files/2/8/1/7/0/7/5/6/original.jpg"),
            //5
            new Activity("Пермский планетарий", "https://www.planetarium.perm.ru/", "утро/день", "досуг с детьми", "Пермский планетарий - это захватывающее место, где " +
                "можно погрузиться в тайны Вселенной и насладиться красотой звездного неба. Здесь проводятся интересные лекции и шоу, которые позволяют узнать больше" +
                " о космосе и астрономии, делая науку увлекательной и доступной для всех возрастов.", 600, "https://шатковская-библиотека.рф/images/2021/obsluzh/long/37.jpg"),
            //6
            new Activity("Парк науки", "https://parknauki.bitrix24site.ru/", "утро/день", "досуг с детьми и активности", "Парк науки в Перми - это " +
                "интерактивное пространство, где наука становится доступной и увлекательной. Посетители могут участвовать в разнообразных экспериментах, изучать научные " +
                "экспонаты и открывать для себя мир технологий и инноваций в увлекательной форме.", 700, "https://gto59.ru/wp-content/uploads/2020/01/1-1.jpg"),
            //7
            new Activity("Экскурсия на шоколадную фабрику", "https://candyfactoryperm.com/jekskursii/", "утро/день и вечер", "экскурсии",
                "Экскурсия на «Кондитерскую фабрику «Пермская» — это не только увлекательнейшее знакомство с историей предприятия, но и посещение кондитерского" +
                " производства — приключение, которое никого не оставит равнодушным. Посетители своими глазами увидят, как на свет появляются любимые всеми конфеты, " +
                "пекутся вафли и производятся фруктовые пастилки.", 4000, "http://otdyh59.ru/wp-content/uploads/2018/10/Ekskursiya-na-konditerskuyu-fabriku-4.jpg"),
            //8
            new Activity("Караоке с отдельными комнатами", "https://clubperm.ru/karaoke", "вечер", "активности", "Караоке - это веселое и захватывающее" +
                " развлечение, где каждый может почувствовать себя звездой сцены, исполняя любимые песни перед друзьями или незнакомыми. Это отличный способ развлечься, " +
                "поднять настроение и создать незабываемые воспоминания, вне зависимости от того, как хорошо поется.", 2000, "https://avatars.mds.yandex.net/get-altay/11396712/2" +
                "a0000018bfbdd2be1c9e19bc456aa2a216b/XXL_height"),
            //9
            new Activity("Мегалэнд", "https://megalandpark.ru/perm", "утро/день", "досуг с детьми", "Мегалэнд - это увлекательный парк развлечений, где каждый найдет что-то " +
                "по своему вкусу. С аттракционами для детей и взрослых, игровыми зонами, кинотеатром и кафе, Мегалэнд предлагает яркие и запоминающиеся моменты для всей семь" +
                "и или компании друзей.", 1400, "https://sun9-70.userapi.com/impg/xHNYrqX-I_Cgbid_prGCi6lYMqHGC9HBDcccBw/j6DGpv1WDH4.jpg?size=1280x851&quality=96&sign=37c93696ce" +
                "55cc97a733e1ba4f64f10c&c_uniq_tag=JLBkr4c-yiVEWc-xyuygriPqBnsE6deU2mctLSc4YIQ&type=album"),
            //10
            new Activity("Боулинг", "https://vk.com/wall-3551694_45737121", "утро/день и вечер", "активности", "Боулинг - это забавное времяпрепровождение, подходяще" +
                "е для всей семьи или друзей. Боулинг объединяет веселье и соревновательный дух, создавая атмосферу, где можно отдохнуть, расслабиться и насладиться временем в приятной " +
                "компании.", 2000, "https://sun3-20.userapi.com/impg/_rqZF-poaNYAQ8ulyOcN4jKGy9cjvm_PJLycsg/aDWqiEyyqxY.jpg?size=1500x1500&quality=95&sign=f39051b60b5a4d5bec5cf78f260aede6&" +
                "type=album"),
            //11
            new Activity("Кино + PlayDay", "https://play-day.ru/", "утро/день и вечер", "досуг с детьми и активности", "Play Day - это забавное мероприятие, наполненное" +
                " играми, развлечениями и творческими активностями. Здесь каждый может найти что-то интересное и провести время с удовольствием.", 2600, "https://i9.photo.2gis.com/images/b" +
                "ranch/0/30258560049791968_9693.jpg"),
            //12
            new Activity("Гейм-клуб", "https://darugame.ru/", "утро/день и вечер", "активности", "Daru Game - это компьютерный клуб, где геймеры могут наслаждаться " +
                "широким выбором игр, соревноваться с друзьями и участвовать в турнирах. Здесь создана атмосфера, способствующая обмену опытом, общению и веселому времяпрепровождению " +
                "в мире виртуальных приключений.", 500, "https://langame.ru/storage/clubs/2022/May/31/1654012412629639fcad8ce.webp"),
            //13
            new Activity("Антикафе", "https://vk.com/paradoxperm", "утро/день", "активности", "Антикафе - это место, где посетители платят за время, проведенное в его" +
                " стенах, а не за заказанные напитки или закуски. Здесь вы можете насладиться общением с друзьями, игрой в настольные или компьютерные игры, читать книги, работать или " +
                "заниматься любимым делом, находясь в уютной и дружелюбной обстановке.", 1000, "https://sun9-34.userapi.com/impg/YAQxB1Cfukl4Dw-7UGYcD3cGxxaqc2CanHvCDA/TxGqk2RI6CE.jpg?size=" +
                "2560x1701&quality=95&sign=adcf182ba821c98a9fb5d40af16b28b7&type=album"),
            //14
            new Activity("Нетипичный тир", "https://perm.moremotions.ru/catalog/item/Kreativnaya-komnata-tir-i-kartina-emociy?utm_source=yandex%7Csearch&utm_medium" +
                "=cpc&utm_campaign=cid%7C98094058%7CMK_Obshhaya_Perm&utm_content=gid%7C5306862209%7Caid%7C15718877658%7C7_7%7Cc%3A98094058%7Cg%3A5306862209%7Cb%3A15718877658%7Ck%3A7" +
                "%7Cst%3Asearch%7Ca%3Ano%7Cs%3Anone%7Ct%3Apremium%7Cp%3A3%7Cr%3A7%7Cdev%3Adesktop&utm_term=&roistat=direct10_search_15718877658_filter&roistat_referrer=none&roistat_pos" +
                "=premium_3&cm_id=98094058_5306862209_15718877658_7_7_none_search_type1_no_desktop_premium_11108&yclid=6859792276545601535", "утро/день", "активности", "На работе не поймут, в" +
                " семье будут задавать кучу вопросов, на улице как-то не то… Гость проходит в специальную комнату, в которой его ждет нетипичный тир, в котором можно использовать посуду" +
                " и манекены и битва красок, позволяющая выплеснуть все свои эмоций.", 5000, "https://i2.photo.2gis.com/images/branch/4/562949986324160_a54f.jpg"),
            //15
            new Activity("Урок стрельбы из лука", "https://perm.moremotions.ru/catalog/item/Urok-strelyby-iz-lukaW", "утро/день", "активности", "Стрельба из лука помогает " +
                "исправить осанку, укрепить мышцы спины и развить вестибулярный аппарат. А еще это интересно! ", 1000, "https://www.fixflo.com/hubfs/Fixflo_2020%20Theme/img/2020%20Bl" +
                "og/Featured_Conceptual%20Target_01.jpg"),
            //16
            new Activity("Гончарный мастер-класс", "https://perm.moremotions.ru/catalog/item/Master-klass-po-goncharnomu-masterstvu-v-gruppe", "утро / день", "активности", "Работа" +
                " с глиной вызывают кардинально разные ощущения, впечатляя сменой состояний и переживаний во время творческого процесса.", 2400, "https://perm.moremotions.ru/storage/p" +
                "erm/items/2763/MTY5OTMzNjAzNzQ5NzY4MQ==.webp"),
            //17
            new Activity("Мастер-класс по кофе", "https://perm.moremotions.ru/catalog/item/Individualniy-master-klass-po-prigotovlenyu-cofe-v-domashnih-usloviyah", "утро/день",
                "активности", "Уметь приготовить вкуснейший кофе, чтобы порадовать себя и близкого человека — ценный навык, заслуживающий восхищения. ", 4400, "https://moslenta.r" +
                "u/imgs/2024/04/05/11/6423007/140d34682484c141d4117eead9900597938e7115.jpg"),
            //18
            new Activity("Прогулка на каяках", "https://perm.moremotions.ru/catalog/item/Semeynaya-progulka-na-kayakah", "весь день", "активности", "Каяки - это узкие гребные " +
                "лодки с острыми носом и кормой, обладающие высокой маневренностью. Гостей ждёт увлекательная водная прогулка по реке Кама! Это интересная возможность провести время и получить " +
                "новые впечатления с семьей.", 3500, "https://extraguide.ru/images/t/8379c948063de8811dbd675bbaf43ba90305a36e.jpeg"),
            //19
            new Activity("Катание на сап-борде в Хохловке", "https://perm.moremotions.ru/catalog/item/Progulka-na-SAP-borde-po-Hohlovke", "весь день", "активности", "Катание " +
                "на SUP-борде по Каме - новая, но уже очень популярная услуга! Гость учится стоять на доске и плыть в почти медитативном состоянии. SUP, так модный в Европе, весьма условно можно" +
                " назвать экстремальным видом спорта. ", 3800, "https://perm.moremotions.ru/storage/perm/items/MTY2OTg4OTYyNDk4ODQ4MA==.webp"),
            //20
            new Activity("Краш-комната для компании", "https://perm.moremotions.ru/catalog/item/Svidanye-krash-komnata-dlya-snyanya-stressa", "утро/день и вечер", "активности", "Все " +
                "устают, выгорают, злятся. И так хочется освободить свое тело и мысли от негатива и агрессии, выплеснуть все это. ", 15000, "https://static.tildacdn.com/tild3763-6537-4536-a230" +
                "-616333323335/IMG_5372.jpeg"),
            //21
            new Activity("Экскурсия на производство роботов Промобот", "https://promo-bot.ru/tour/", "утро/день", "экскурсии", "В Пермском периоде истории России была организована" +
                " первая в стране экскурсия на производство человекоподобных роботов. Это событие стало важным шагом в развитии технологий и вызвало оживленный интерес к перспективам использования " +
                "робототехники.", 5000, "https://cdn.iportal.ru/news/99/preview/094d33a72f9f8e00197286a53c90cf5e00f85e08_1601_1067_c.jpg"),
            //22
            new Activity("Хохловка - музей под открытым небом", "https://museumperm.ru/branch/khokhlovka", "весь день", "выезд", "Первый на Урале музей деревянного зодчества" +
                " под открытым небом расположен на живописном берегу Камы в 43 км. от Перми. В «Хохловку» перевезено много уникальных памятников деревянной архитектуры Прикамья, но удивляет она " +
                "не только этим.", 700, "http://s4.fotokto.ru/photo/full/167/1675060.jpg"),
            //23
            new Activity("Музей пермских древностей", "https://museumperm.ru/branch/mpd", "утро/день", "экскурсии", "В недрах Пермского края скрыта удивительная летопись, " +
                "которая дала название уникальному этапу развития жизни на Земле продолжительностью 50 000 000 лет — «пермский период», «пермь». В то время все материки слились в единый " +
                "суперконтинет Пангея, а в глубинах планеты формировались золото и алмазы. Древнее пермское море, отступив в конце пермского периода, оставило богатейшие залежи солей," +
                " гипсов, селенита.", 600, "https://sun9-87.userapi.com/impg/eXIoZzJgQ2VrFqyta1aKazj-G8EQ7tO_Q5KBbg/AbYcPP292nU.jpg?size=1280x920&quality=95&sign=1ecb32755fa4131bfdddd026b23c" +
                "dd3f&c_uniq_tag=wY6BJYRJyJ2srkwS9SHmPdTL4RnS3FjqeqlGsbVEBGg&type=album"),
            //24
            new Activity("Экскурсия в ботанический сад ПГНИУ", "https://vk.com/botsad_perm", "утро/день", "экскурсии", "В настоящее время Ботанический сад имени " +
                "профессора А.Г. Генкеля входит в состав регионального Совета ботанических садов Урала и Поволжья, имеет статус научного учреждения и особо охраняемой природной " +
                "территории. Основными научными направлениями работы являются: интродукция и акклиматизация растений, выведение и отбор новых форм и сортов, наиболее стойких и " +
                "продуктивных в местных условиях.", 600, "https://mykaleidoscope.ru/x/uploads/posts/2022-09/1663333168_1-mykaleidoscope-ru-p-permskii-botanicheskii-sad-pinterest-1.jpg"),
            //25
            new Activity("Берег реки Мулянка", "https://vk.com/wall-3551694_3253589", "утро/день и весь день", "прогулка", "Место, надо сказать, довольно миловидное. " +
                "Туда и позагорать можно прийти - мест достаточно, и покупаться всей семьей, ибо неглубоко, и даже, при случае, посмотреть на уточек.", 0, "https://sun1-56.userapi.com/i" +
                "mpg/azlgglje6aqCi0N0l9VH62mRA5MBGWF4LA9CWA/POwwsLsWWNI.jpg?size=604x346&quality=95&sign=501b9240c08c8766d9d6d9a75b5e6de5&c_uniq_tag=LnzGy2D6hC573lXTrRFnKzPu_7k5Tkq590H5J_k" +
                "dx-k&type=album"),
            //26
            new Activity("Сад соловьёв", "https://vk.com/uinka", "утро/день", "прогулка", "Парк Соловьёва в Перми - это место, где природа раскрывает" +
                " всю свою красоту и спокойствие. Здесь можно прогуляться по зеленым аллеям, насладиться свежим воздухом и отдохнуть от городской суеты.", 0, "https://avatars.dzeninfra.ru/ge" +
                "t-zen_doc/4491962/pub_609c0993f7956a1ab2aa421f_609c09e0c6446324a3974844/scale_1200"),
            //27
            new Activity("Мост тысяча ступеней", "https://vk.com/wall-3551694_3359465", "утро/день", "прогулка", "Мост Тысячи Ступеней в Перми -" +
                " это захватывающая архитектурная конструкция, ведущая через живописную долину реки Кама. Его уникальность заключается в том, что он состоит из тысячи" +
                " ступеней, ведущих к вершине холма, откуда открывается великолепный вид на окрестности и реку. ", 0, "https://cdn.iportal.ru/preview/news/articles/33680a844cfec1b8" +
                "8d65c8472bc2e0c2155fda4d3_1920.jpg"),
            //28
            new Activity("Старокирпичный переулок", "https://vk.com/oldtownperm", "утро/день и вечер и весь день", "активности и прогулка", "Это атмосферное лофт-пространство в историческом" +
                " центре Перми, сводчатый кирпичный тоннель которого ведет в уютный дворик с качелями, кофейнями и дизайнерскими магазинчиками. А еще здесь можно заказать" +
                " настоящую итальянскую пиццу из дровяной печи.", 0, "https://cdn.iportal.ru/news/2021/99/preview/9580ddf0423f8cb81188ea263e9b158b08939873_1920_1080_c.jpg"),
            //29
            new Activity("Парк камней", "https://www.tourister.ru/world/europe/russia/city/perm/parks/28069", "утро/день и вечер", "прогулка", "Парк активно " +
                "насаждается молодыми саженцами самых разных деревьев: яблонь, вязов, лиственниц, кленов, лип и прочих, также он украшен клумбами с цветами. Здесь много скамеек " +
                "и фонарей, есть несколько красивых композиций из растений в самом центре сада и пара бассейнов, оформленных под фонтаны.", 0, "https://img-fotki.yandex.ru/get/19802" +
                "6/125107421.34/0_1c3717_be5d44e8_XXXL.jpg"),
            //30
            new Activity("Арт-пространство завод Шпагина", "https://zav-shpag.com/", "утро /день и весь день", "прогулка и активности", "Арт-пространство завод Шпагина - " +
                "это уникальное место, где современное искусство оживает в промышленной атмосфере старого завода. Здесь собираются творческие люди, чтобы воплощать свои идеи в" +
                " различных формах искусства, создавая вдохновляющие произведения и проводя интересные мероприятия.", 0, "https://gubernator.permkrai.ru/upload/iblock/730/2019_0817" +
                "_18494900.jpg"),
            //31
            new Activity("Балатоский парк", "http://www.archive.perm.ru/projects/weeklyphoto/balatovsky-park-/", "утро/день и вечер", "прогулка", "Балатовский парк" +
                " - это уединенный оазис в сердце города, где каждый найдет умиротворение в объятиях природы. С его извилистыми тропинками, живописными прудами и " +
                "уютными скамейками, парк приглашает на прогулки, отдых и моменты спокойствия вдали от городской суеты.", 0, "https://vsegda-pomnim.com/uploads/posts/2022-" +
                "04/1648946042_18-vsegda-pomnim-com-p-chernyaevskii-les-perm-foto-19.jpg"),
            //32
            new Activity("Парк Райский сад", "https://dzen.ru/a/ZBMqwO_yMCDSuL2E", "утро/день и вечер", "прогулка", "Парк райский сад - это удивительное " +
                "место, где встречаются великолепие природы и человеческого творчества. С его красочными цветниками, извилистыми дорожками и ухоженными " +
                "скверами, это идеальное пространство для отдыха и наслаждения красотой в любое время года.", 0, "https://turvopros.com/wp-content/uploads/2023" +
                "/10/raiskii-sad-nochiu.jpg"),
            //33
            new Activity("Кунгурская пещера", "https://kungurcave.ru/", "весь день", "выезд", "Кунгурская пещера - это уникальное природное явление," +
                " скрывающее в своих недрах загадки древних времен. Ее извилистые ходы, кристально чистые озера и захватывающие подземные пейзажи " +
                "привлекают тысячи любителей природы и исследователей каждый год. Это место наполнено магией и таинственностью, предлагая незабываемые " +
                "впечатления всем, кто осмелится погрузиться в ее таинственные глубины.", 1000, "https://avatars.dzeninfra.ru/get-zen_doc/1657335/pub_64f867" +
                "46e6afc35163a1173a_64f86eadd643ae46b70c8a86/scale_1200"),
            //34
            new Activity("Сквер уральских добровольцев", "http://www.archive.perm.ru/projects/weeklyphoto/park-them-ural-volunteers/", "утро/день и вечер",
                "прогулка", "Сквер Уральских добровольцев - прекрасное место для прогулок в центре города с семьей, с детьми, с любимыми и друзьями. " +
                "Сквер находится на пересечении главных улиц города, а за 5 минут от парка можно дойти до Эспланады.", 0, "https://i1.photo.2gis.com/images/" +
                "geo/16/2251799846740839_5e9b.jpg"),
            //35
            new Activity("Пермская набережная", "https://www.tourister.ru/world/europe/russia/city/perm/placeofinterest/28224", "утро/день и вечер", "прогулка",
                "Набережная реки Камы — один из основных пунктов в туристическом маршруте по Перми. Она является популярным прогулочным местом горожан и хранит в" +
                " себе многолетнюю историю, начинающуюся с конца XIX века.", 0, "https://i6.photo.2gis.com/images/geo/0/30258560069262176_2e54.jpg"),
            //36
            new Activity("Пермская эспланада", "https://www.tourister.ru/world/europe/russia/city/perm/squares/28088", "утро/день и вечер", "прогулка",
                "Эспланада — это одно из самых популярных общественных пространств в городе. Круглый год здесь проводятся фестивали, праздники и другие " +
                "мероприятия; молодожены устраивают фотосессии, дети резвятся на детских площадках, а взрослые прогуливаются по променаду и отдыхают в кафе.", 0, "https://ic.pics.livejournal.com/zdorovs/16627846/2086822/2086822_original.jpg"),
            //37
            new Activity("Театральный сад", "https://visitperm.ru/sightseeing/history/teatralnyy-skver-i-skver-im-dyagileva/", "утро/день и вечер", "прогулка",
                "Театральный сквер — одно из самых интересных мест для прогулок в Перми. В саду посадили липы, клёны, ели и создали неповторимую атмосферу " +
                "театрального парка, которая не покидает это место уже больше века.", 0, "https://perm-300.ru/assets/images/2079480_original.jpg"),
            //38
            new Activity("Активити парк Sky Trip", "https://skytrip.pro/", "утро/день", "досуг с детьми и активности", "«Активити парки Sky Trip» как" +
                " уникальный и совершенно новый формат активного досуга и отдыха впервые открылись в России в 2018г. компанией ООО «Активити парк». " +
                "Наши парки созданы в рамках единой тематической концепции, рассчитаны на широкую аудиторию, оснащенные качественным и инновационным" +
                " игровым оборудованием, отвечающим всем требованиям безопасности, соответствующим высоким запросам потребителей.", 2000, "https://i5." +
                "photo.2gis.com/images/branch/16/2251799847904662_ef85.jpg"),
            //39
            new Activity("Отель Побег из города", "https://tvoi-pobeg.ru/perm", "весь день", "выезд", "Бетон и стекло, пробки и шум, работа и" +
                " встречи. Хочется поставить быстрый ритм жизни на паузу. Устройте побег из города! Мы разбили небольшую деревеньку со " +
                "скандинавскими домиками, чтобы вы прислушались к тишине соснового леса, разожгли костер и побыли наедине с собой.", 8000, "https://mezen" +
                "skoye.nochi.com/data/Photos/OriginalPhoto/11466/1146606/1146606973/Pobeg-Iz-Goroda-Mezenskoye-Exterior.JPEG"),
            //40
            new Activity("Сосновый бор - экотропа", "https://bskportal.ru/news/oficialno/verhnjaja-kurja-i-bolshoj-sosnovyj", "утро/день и вечер", "прогулка",
                "Сейчас мы гуляем по земле, по которой более двух тысяч лет назад ходили наши предки. Обнаружили это при строительстве Камской ГЭС в " +
                "1930 году. Археологи нашли место стоянки первых поселений человека на улице 1-я линия. Активно территория Верхней Курьи " +
                "стала заселяться в конце XVII века. Работали в основном на шахтах: «Первые рудники», «Вторые рудники», которые находились на " +
                "границе Верхней Курьи и Гайвы.", 0, "https://storage.myseldon.com/news-pict-b7/B71CCF9F28678C2994E226FA2C22EDBF"),
            //41
            new Activity("Андроновский лес", "https://dzen.ru/a/X14DpExAMCQ4beLU", "утро/день и вечер", "прогулка", "Андроновский " +
                "лес является частью городских лесов Перми. Его рельеф представляет собой всхолмленную равнину, включающую в себя " +
                "пойму реки Мулянки, аллювиальные террасы и склоны. Среди почв присутствуют дерново-карбонатные и темногумусовые," +
                " редкие для Перми и рекомендованные для включения в Красную книгу почв РФ.", 0, "https://vsegda-pomnim.com/uploads/posts/2022-04/1648920706_9-v" +
                "segda-pomnim-com-p-andronovskii-les-perm-foto-10.jpg"),
            //42
            new Activity("Экскурсия в Каменный город", "https://vk.com/kameniy_gorod_usvinskie_stolbi", "весь день", "выезд", "Каменный город расположен в 200 " +
                "км от Перми. Это необычные скальные останцы на вершине хребта Уральских гор. В фильме «Последний богатырь» это место изображало Страну мертвых, " +
                "где был заточен Кощей. Еще здесь снимали сцены из фильма «Сердце Пармы» и сериал «Территория».", 10000, "https://avatars.dzeninfra.ru/get-zen_doc/153" +
                "3968/pub_624aea931f08181b5a0557b5_624af167e9f628770134c851/scale_1200"),
            //43
            new Activity("Экскурсия на Верхнечусовские горки", "https://zolotoy-kompas.ru/aktiv/pvd/etnopark_i_selo_uspenka", "весь день", "выезд", "Этнографический " +
                "парк реки Чусовой появился еще в 1981 году, благодаря Постникову Леонарду Дмитриевичу и группе энтузиастов, решивших спасти заброшенные деревенские " +
                "дома, некоторые из которых были построены еще в середине 19 века. Первоначально парк служил местом отдыха и просвещения спортсменов спортивной" +
                " школы олимпийского резерва «Огонек», расположенной поблизости. Но со временем коллекция росла и расширялась, теперь сюда возят " +
                "полноценные туристические группы.", 7000, "https://static.tildacdn.com/tild3364-3632-4230-a662-306265386364/Kazanskaya_zhenskaya.jpg"),
            //44
            new Activity("Камень Ермака и арт-музей кинетических фигур", "https://dmarshrut.ru/tury/tury-po-uralu/kamen-ermak-i-art-muzey-kinetiches" +
                "kikh-figur-semeynyy-vyezd/", "весь день", "выезд", "Приглашаем родителей с детьми любых возрастов! И для малыша, и для подростка наши " +
                "гиды-аниматоры найдут занятие по душе. А родители смогут насладиться великолепной панорамой реки Сылва с высоты птичьего полёта.",
                10000, "https://avatars.dzeninfra.ru/get-zen_doc/5163173/pub_616beab0ffdef07a4aff6d8b_616c6ff72ca39e5cccde388a/scale_1200"),
            //45
            new Activity("Картинг KartON", "https://kart-on.ru/", "утро/день и вечер", "активности", "Единственный крытый картинг-центр в Перми; Только современные," +
                " безопасные и карты: бензиновые и электрокарты; Комфортная зона отдыха; Школа картинга; Подарочные сертификаты Проведения корпоративов в стиле" +
                " «Формула 1».", 3000, "https://static.tildacdn.com/tild3733-3761-4932-a137-393663393239/2.png"),
            //46
            new Activity("Пермские термы", "https://permterms.ru/", "весь день", "выезд", "Самое время прийти в Пермские Термы и насладиться " +
                "теплыми лучами солнца на открытой террасе, поплавать в термальном бассейне и расслабиться.", 6000, "https://avatars.mds.yandex.net/g" +
                "et-altay/9719535/2a00000189fa25f05b9378b5b11cb14cfdb3/orig"),
            //47
            new Activity("Экскурсия Пермь мистическая", "https://vk.com/mysticalperm", "вечер", "экскурсия", "В 300-летней истории Перми накопилось на удивление " +
                "много таинственных сюжетов, и самые интересные вы раскроете на прогулке. Узнаете, какие секреты хранят особняки 19 века и где наблюдаются" +
                " леденящие кровь феномены, как отыскать «Дом с кикиморой» и чем пугает горожан старинный некрополь. А актеры и анимационные эффекты обеспечат " +
                "максимальное погружение в мистику.", 2000, "https://cdn.tripster.ru/thumbs2/e2d8b7be-de41-11ea-ab2f-021fc8f58862.800x600.jpg"),
            //48
            new Activity("Хвойная хижина", "https://pineshack.ru/", "весь день", "выезд", "Хвойная Хижина — это треугольный дом с невероятным сочетанием хвойного " +
                "леса и современного стиля, ĸоторый расположен всего в 20 ĸм от Перми.\r\nВ треугольном доме ĸаждый найдет, ĸаĸ провести время по душе: устроить" +
                " романтичесĸие выходные, организовать фотосессию или оĸунуться в ĸупель.", 10000, "https://altaitop.ru/wp-content/uploads/2022/02/ef0af85469c6ee86ec" +
                "a0ce5915da8839.jpg"),
    };
    }
}
