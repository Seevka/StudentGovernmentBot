using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace StudentGovernment
{
    public abstract class Faculty
    {
        public abstract string Name { get; }
        public abstract ReplyKeyboardMarkup ReplyKeyboardMarkup { get; }
        public abstract Dictionary<string, string> QuestionAnswer { get; }
        public int Admin = 312042781;
        public ReplyKeyboardMarkup Faculties => new(new[]
{
                new KeyboardButton[] { "Факультет прикладної математики та інформатики"},
                new KeyboardButton[] {"Факультет культури та мистецтв"},
                new KeyboardButton[] { "Адміністрування"},
})
        {
            ResizeKeyboard = true
        };
        public ReplyKeyboardMarkup AdminKeyboard => new(new[]
{
                new KeyboardButton[] {"Побачити усі питання"},
                new KeyboardButton[] {"Побачити лише питання, на які не було надано відповідь"},
                new KeyboardButton[] {"Побачити лише питання, на які було надано відповідь"},
                new KeyboardButton[] {"Побачити питання студентів ФПМІ"},
                new KeyboardButton[] {"Побачити питання студентів ФКІМ"},
                new KeyboardButton[] {"Відповісти на питання"},
                new KeyboardButton[] {"Отримати айді користувача"},
                new KeyboardButton[] {"/restart"},
})
        {
            ResizeKeyboard = true
        };

    }

    class AMI : Faculty
    {
        private static Dictionary<string, string> AmiAnswers = new Dictionary<string, string>()
        {
            {"Я абітурієнт 👨‍💻", "Вітаємо тебе в стінах Франкового університету 😍\r\nЩоб отримати усю інформацію про вступ на факультет прикладної математики та інформатики, переходь за посиланням 😉\r\nhttps://ami.lnu.edu.ua/admission/specializations"},
            {"Чат студентської підтримки 👨‍💻", "https://t.me/studentshelplnuchat" },
            {"Розклад 👨‍💻", "https://ami.lnu.edu.ua/students/rozklad-zanyat"},
            {"Відновлення паролю від корпоративної пошти 👨‍💻", "Щоб відновити пароль до корпоративної пошти напиши ось сюди 👉 studhelpoffice365@lnu.edu.ua" },
            {"Я вперше отримуватиму стипендію! 👨‍💻", "Круто, тішимось за вас і нагадуємо, що вам потрібно якнайскорше надіслати реквізити на електронну пошту бухгалтерії: \r\nRekvizytylnu@gmail.com \r\nПотрібно надіслати:\r\n~копію паспорта\r\n~ідентифікаційний код\r\n~довідку за реквізитами \r\nЗауважте, що підходить лише картка для виплат." },
            {"Психологічна допомога 👨‍💻", "Усю необхідну інформацію можна дізнатися ось тут https://instagram.com/lnu_psysluzhba?igshid=YmMyMTA2M2Y=" },
            {"Moodle 👨‍💻", "Відкривати за допомогою корпоративної пошти https://e-learning.lnu.edu.ua/login/index.php" },
            {"Журнал успішності студента 👨‍💻", "https://dekanat.lnu.edu.ua/cgi-bin/classman.cgi?n=999" },
            {"Сайт факультету 👨‍💻", "Необхідно більше інформації? Переходь на сайт факультету 🤩 https://ami.lnu.edu.ua/" },
            {"Соціальні мережі 👨‍💻", "Знайти нас можна ось тут:\r\nInstagram: https://www.instagram.com/lnu.prykladna/ 🐥\r\nTelegram: https://t.me/darkside_ami 🐶\r\nTikTok: @ami.lnu \U0001f986" },
            {"Вернутися на початок 👨‍💻", "Натисни сюди: /restart" },
            {"Задати питання адміністратору ФПМІ", "Напиши своє питання нижче та натисни готово, а ми обов'язково зв'яжемося з тобою!" },
        };
        public override string Name => "Факультет прикладної математики та інформатики";
        public override ReplyKeyboardMarkup ReplyKeyboardMarkup => new(new[]
{
                new KeyboardButton[] { "Я абітурієнт 👨‍💻", "Чат студентської підтримки 👨‍💻"},
                new KeyboardButton[] { "Розклад 👨‍💻",  "Відновлення паролю від корпоративної пошти 👨‍💻"},
                new KeyboardButton[] { "Я вперше отримуватиму стипендію! 👨‍💻", "Психологічна допомога 👨‍💻"},
                new KeyboardButton[] { "Moodle 👨‍💻", "Журнал успішності студента 👨‍💻"},
                new KeyboardButton[] { "Сайт факультету 👨‍💻", "Соціальні мережі 👨‍💻"},
                new KeyboardButton[] { "Задати питання адміністратору ФПМІ", "Вернутися на початок 👨‍💻"},
                new KeyboardButton[] { "Адміністрування"},
})
        {
            ResizeKeyboard = true
        };
        public override Dictionary<string, string> QuestionAnswer
        {
            get { return AmiAnswers; }
        }
    }

    class CultArt : Faculty
    {
        private Dictionary<string, string> CultArtAnswers = new Dictionary<string, string>()
        {
            {"Я абітурієнт 🎨", "Вітаємо тебе в стінах Франкового університету 😍\r\nЩоб отримати усю інформацію про вступ на факультет прикладної математики та інформатики, переходь за посиланням 😉\r\nhttps://kultart.lnu.edu.ua/admission/specializations"},
            {"Замовлення довідок 🎨", "Цю довідку Ви зможете отримати у деканаті нашого факультету😊 \r\nДля замовлення довідки напишіть у групі (https://t.me/+2e0SGXooJQ9jMWMy) ПІБ, групу, денна чи заочна форма, платне чи бюджет. \r\nТакож можете замовити її особисто за адресою: \r\nм. Львів, вул. Валова, 18, каб. 16 \r\nГрафік роботи: 10:00 до 17:00 \r\nОбідня перерва: 13:00-14:00 " },
            {"Чат студентської підтримки 🎨", "https://t.me/studentshelplnuchat" },
            {"Скринька довіри 🎨", "https://docs.google.com/forms/d/e/1FAIpQLSelXIqm80fDxnnV_C0nzfKHBNxOfgQrNTWLcy1UYa8-NolqBw/viewform" },
            {"Відновлення паролю від корпоративної пошти 🎨", "Щоб відновити пароль до корпоративної пошти напиши ось сюди 👉 studhelpoffice365@lnu.edu.ua" },
            {"Контакти Студентської ради та Профбюро 🎨", "https://kultart.lnu.edu.ua/students/schedule" },
            {"Розклад 🎨", "https://kultart.lnu.edu.ua/academics/rozklad-dennoi-formy-navchannia" },
            {"Контакти кафедри 🎨", "Контакти факультету\r\nДеканат: \r\nДенне навчання  \r\nАнастасія - Anastasiia.Bodnar.kmo@lnu.edu.ua \r\nЗаочне навчання  \r\nДана - dana.lysenko@lnu.edu.ua \r\nЛаборанти кафедр: \r\nМузичного мистецтва  \r\nНадія - 096 99 22 404 \r\nРежисури та хореографії  \r\nЯрослава - 050 56 74 674 \r\nМузикознавства та хорового мистецтва  \r\nСвітлана - 095 53 60 890 \r\nТеатрознавства та акторської майстерності  \r\nГалина Василівна - 063 74 05 956 \r\nМенеджменту соціокультурної діяльності  \r\nЮлія - 098 05 74 269 \r\nБібліотекознавства і бібліографії  \r\nДіана - 093 22 11 301" },
            {"Я вперше отримуватиму стипендію! 🎨", "Круто, тішимось за вас і нагадуємо, що вам потрібно якнайскорше надіслати реквізити на електронну пошту бухгалтерії: \r\nRekvizytylnu@gmail.com \r\nПотрібно надіслати:\r\n~копію паспорта\r\n~ідентифікаційний код\r\n~довідку за реквізитами \r\nЗауважте, що підходить лише картка для виплат." },
            {"Психологічна допомога 🎨", "Усю необхідну інформацію можна дізнатися ось тут https://instagram.com/lnu_psysluzhba?igshid=YmMyMTA2M2Y=" },
            {"Moodle 🎨", "Відкривати за допомогою корпоративної пошти https://e-learning.lnu.edu.ua/login/index.php" },
            {"Журнал успішності студента 🎨", "https://dekanat.lnu.edu.ua/cgi-bin/classman.cgi?n=999" },
            {"Соціальні мережі 🎨", "Ми тут https://linktr.ee/cultart_lnu?utm_source=linktree_profile_share&ltsid=306dd350-e69a-4313-ac21-2fb97b9dc05b" },
            {"Сайт факультету 🎨", "Необхідно більше інформації? Переходь на сайт факультету 🤩 https://kultart.lnu.edu.ua/" },
            {"Вернутися на початок 🎨", "Натисни сюди: /restart" },
            {"Зaдати питання адміністратору ФКІМ", "Напиши своє питання нижче та натисни готово, а ми обов'язково зв'яжемося з тобою!" },

        };
        public override string Name => "Факультет культури та мистецтв";
        public override ReplyKeyboardMarkup ReplyKeyboardMarkup => new(new[]
{
                new KeyboardButton[] { "Я абітурієнт 🎨", "Замовлення довідок 🎨"},
                new KeyboardButton[] { "Чат студентської підтримки 🎨", "Скринька довіри 🎨"},
                new KeyboardButton[] { "Відновлення паролю від корпоративної пошти 🎨", "Контакти Студентської ради та Профбюро 🎨"},
                new KeyboardButton[] { "Розклад 🎨", "Контакти кафедри 🎨"},
                new KeyboardButton[] { "Я вперше отримуватиму стипендію! 🎨", "Психологічна допомога 🎨"},
                new KeyboardButton[] { "Moodle 🎨", "Журнал успішності студента 🎨"},
                new KeyboardButton[] { "Соціальні мережі 🎨", "Сайт факультету 🎨"},
                new KeyboardButton[] { "Зaдати питання адміністратору ФКІМ", "Вернутися на початок 🎨" },
                new KeyboardButton[] { "Адміністрування"},
})
        {
            ResizeKeyboard = true
        };
        public override Dictionary<string, string> QuestionAnswer
        {
            get { return CultArtAnswers; }
        }
    }

}


