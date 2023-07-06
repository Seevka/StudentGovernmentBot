using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using Microsoft.VisualBasic;
using Telegram.Bot.Types.Enums;
using Google.Protobuf.WellKnownTypes;

namespace StudentGovernment
{
    public class StudentGovernmentBot : StudentGovernment
    {
        Bachelor bachelor = new Bachelor();
        Master master = new Master();
        Faculties faculties = new Faculties();
        static void Main(string[] args)
        {
            var bot = new StudentGovernmentBot(args[0]);
            bot.Run();
        }

        public StudentGovernmentBot(string botToken) : base(botToken) { }

        public async Task StartFunction(Chat chat)
        {
            await CallKeyboard(chat, "👋 Привіт, майбутнім студентам Франкового Університету!  \r\n \r\nМене звати @LNU_abit та я тут, щоб допомогти тобі розібратись з усіма проблемами, які виникатимуть під час вступної кампанії😉 \r\n \r\nЯкщо хочеш щось дізнатися - натискай клавішу з відповідним запитанням або переходь в чат, де мої колеги тобі допоможуть❤️‍🔥" +
                " \r\n \r\nДо зустрічі у #вже_зовсім_скоро_рідних_стінах !\U0001f929", startKeyboard);
        }

        ReplyKeyboardMarkup startKeyboard = new(new[]
{
                new KeyboardButton[] { "Контакти Приймальної комісії📲", "Студентські ради у соціальних мережах💻"},
                new KeyboardButton[] { "Дні відкритих дверей⏰", "Консультаційний центр для вступників та Приймальні комісії факультетів👥"},
                new KeyboardButton[] { "Вступ до бакалаврату", "Вступ до магістратури" },
                new KeyboardButton[] { "Дізнатись більше про навчання на факультеті 😎"},
                new KeyboardButton[] { "🤔Виникло питання або проблема?"},
})
        {
            ResizeKeyboard = true
        };

        public override async Task OnPrivateChat(Chat chat, User user, UpdateInfo update)
        {
            if (update.UpdateKind != UpdateKind.NewMessage || update.MsgCategory != MsgCategory.Text)
                return;
            if (update.Message.Text == "/start")
            {
                await StartFunction(chat);
                return;
            }
            else if (update.Message.Text == bachelor.Name || update.Message.Text == "/bachelor")
            {
                await CallKeyboard(chat, "Лови усю інформацію, яку я маю для тебе 😉", bachelor.ReplyKeyboardMarkup);

                return;
            }
            else if (update.Message.Text == "Контакти Приймальної комісії📲" || update.Message.Text == "/contacts")
            {
                await Telegram.SendTextMessageAsync(chat, "Адреса: вул. Січових Cтрільців, 14, \r\nм. Львів, 79000 \r\n" +
                    "каб. 112, 113 \r\n📞 тел. (032) 239-45-70, 255-39-65, 239-43-30, 239-48-70 \r\nмоб. тел." +
                    " (096) 600-77-31 \r\n📩e-mail: pkunivlv@lnu.edu.ua \r\n \r\nСторінки для вступників у соціальних мережах:" +
                    " \r\n\r\n[Інстаграм](https://instagram.com/lnuvstup?igshid=MzRlODBiNWFlZA==) \r\n \r\n[Телеграм-канал]" +
                    "(https://t.me/entrantlnu)\r\n\r\n[Сайт Вступної кампанії](https://admission.lnu.edu.ua/)\r\n\r\n📆 " +
                    "Розклад роботи Приймальної комісії:  \r\nпонеділок – п’ятниця з 9:00 до 18:00; \r\nобідня перерва – 13:00-14:00;" +
                    " \r\nсубота та неділя – вихідні дні.", disableWebPagePreview: true, parseMode: ParseMode.Markdown);
                return;
            }
            else if (update.Message.Text == "Дізнатись більше про навчання на факультеті 😎" || update.Message.Text == "/information")
            {
                await Telegram.SendTextMessageAsync(chat, "\U0001f9ecБіологічний факультет - @vichechhka\r\n\r\n🏔️Географічний факультет - @lyerochka\r\n\r\n💎Геологічний факультет - @asya_kejsn @aeiknorvvv\r\n\r\n💸Економічний факультет - @studrada_econom_lnu_support\r\n\r\n💻Факультет електроніки та \r\nкомп’ютерних технологій - @kytsik7\r\n\r\n📽️Факультет журналістики - @nichenka\r\n\r\n🇺🇸Факультет іноземних мов - @olenka_heriak\r\n\r\n⏳Історичний факультет - @symvko\r\n\r\n 🎭Факультет культури і мистецтв - @YuliaBilokur\r\n\r\n \U0001f9eeМеханіко-математичний факультет- @havrishkaterina\r\n\r\n \U0001f91dФакультет міжнародних відносин - @A_Parkhomchuk\r\n\r\n 👩🏻‍🏫Факультет педагогічної освіти - @KarinaLNU\r\n\r\n 👨‍💻 Факультет прикладної математики та інформатики - @Seevkaa\r\n\r\n💰Факультет управління фінансами та бізнесу - @mkormylo\r\n\r\n\U0001f9f2Фізичний факультет - @vkiglad\r\n\r\n✍🏻Філологічний факультет - @pampushok_z_makom\r\n\r\n🤔Філософський факультет - @stepranenko\r\n\r\n \U0001f9eaХімічний факультет - @natahrynechko, @svistaak\r\n\r\n⚖️Юридичний факультет - @markiian_LY\r\n\r\n👧🏻\U0001f9d2🏼 Педагогічний фаховий коледж - @maria_ivanevych24", disableWebPagePreview: true, parseMode: ParseMode.Markdown);
                return;
            }
            else if (update.Message.Text == "Дні відкритих дверей⏰" || update.Message.Text == "/opendays")
            {
                await Telegram.SendTextMessageAsync(chat, "Актуальна інформація щодо розкладу та анонсів Днів відкритих дверей у Львівському національному університету імені Івана Франка розміщується на сторінках для вступників у соціальних мережах\r\n\r\n 📎[Інстаграм](https://instagram.com/lnuvstup?igshid=MzRlODBiNWFlZA==)\r\n\r\n📎[Телеграм](https://t.me/entrantlnu)", disableWebPagePreview: true, parseMode: ParseMode.Markdown);
                return;
            }
            else if (update.Message.Text == "Консультаційний центр для вступників та Приймальні комісії факультетів👥" || update.Message.Text == "/consult")
            {
                await Telegram.SendTextMessageAsync(chat, "Консультаційний центр для вступників працює у будні дні з 10:00 до 17:00 год. у 116 авдиторії Головного корпусу Університету ( вул. Університетська,1).", disableWebPagePreview: true, parseMode: ParseMode.Markdown);
                return;
            }
            else if (update.Message.Text == "🤔Виникло питання або проблема?" || update.Message.Text == "/questions")
            {
                await Telegram.SendTextMessageAsync(chat, "Якщо ж тут немає відповіді на твоє запитання, переходь в чат-бесіду каналу, за посиланням, де мої колеги тобі допоможуть❤️‍🔥\r\n\r\n📎https://t.me/entrantlnu", disableWebPagePreview: true, parseMode: ParseMode.Markdown);
                return;
            }
            else if (update.Message.Text == bachelor.Name || update.Message.Text == "/bachelor")
            {
                await CallKeyboard(chat, "Лови усю інформацію, яку я маю для тебе 😉", bachelor.ReplyKeyboardMarkup);

                return;
            }
            else if (bachelor.QuestionAnswer.Any(response => response.Key.Contains(update.Message.Text)))
            {
                await Telegram.SendTextMessageAsync(chat, bachelor.QuestionAnswer.FirstOrDefault(answer => answer.Key == update.Message.Text).Value, disableWebPagePreview: true);
                return;
            }
            else if (master.QuestionAnswer.Any(response => response.Key.Contains(update.Message.Text)))
            {
                await Telegram.SendTextMessageAsync(chat, master.QuestionAnswer.FirstOrDefault(answer => answer.Key == update.Message.Text).Value, disableWebPagePreview: true);
                return;
            }
            else if (update.Message.Text == master.Name || update.Message.Text == "/master")
            {
                await CallKeyboard(chat, "Лови усю інформацію, яку я маю для тебе 😉", master.ReplyKeyboardMarkup);
                return;
            }
            else if (faculties.QuestionAnswer.Any(response => response.Key.Contains(update.Message.Text)))
            {
                await Telegram.SendTextMessageAsync(chat, faculties.QuestionAnswer.FirstOrDefault(answer => answer.Key == update.Message.Text).Value, disableWebPagePreview: true, parseMode: ParseMode.Markdown);
                return;
            }
            else if (update.Message.Text == faculties.Name || update.Message.Text == "/faculties")
            {
                await CallKeyboard(chat, "Лови усю інформацію, яку я маю для тебе 😉", faculties.ReplyKeyboardMarkup);
                return;
            }
            else if (update.Message.Text == "/restart" || update.Message.Text == "Вернутися на початок")
            {
                await CallKeyboard(chat, "👩‍🎓🧑‍🎓", startKeyboard);
                return;
            }
            else
            {
                await CallKeyboard(chat, "Ти написав щось не те, спробуй ще раз", startKeyboard);
                return;
            }

        }
    }
}