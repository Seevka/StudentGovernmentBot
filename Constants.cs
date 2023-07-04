using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace StudentGovernment
{
    public abstract class MainClass
    {
        public abstract string Name { get; }
        public abstract ReplyKeyboardMarkup ReplyKeyboardMarkup { get; }
        public abstract Dictionary<string, string> QuestionAnswer { get; }

    }

    class Bachelor : MainClass
    {
        private static Dictionary<string, string> BachelorAnswers = new Dictionary<string, string>()
        {
            {"Правила прийому до Львівського національного університету імені Івана Франка у 2023 році📋", "Правила прийому до Львівського національного університету імені Івана Франка у 2023 році та всі необхідні додатки розміщенні за посиланням: \r\n\r\nhttps://admission.lnu.edu.ua/wp-content/uploads/2023/06/PP2023.pdf"},
            {"Перелік освітніх ступенів та спеціальностей, за якими оголошується прийом на навчання, ліцензійні обсяги та нормативні терміни навчання📚", "Перелік освітніх ступенів та спеціальностей, за якими оголошується прийом на навчання, ліцензійних обсягів та нормативних термінів навчання розміщенні за посиланням: \r\n\r\nhttps://admission.lnu.edu.ua/wp-content/uploads/2023/06/Dodatok_1.pdf" },
            {"📃Перелік конкурсних предметів, вагових коефіцієнтів та мінімальна кількість балів для допуску до участі в конкурсі", "📍Вступ на основі предметів НМТ 2022-2023 рр.\r\n\r\n📎 https://admission.lnu.edu.ua/wp-content/uploads/2023/06/Dodatok_3_2.pdf\r\n\r\n📍Вступ на основі предметів ЗНО 2020-2021 рр. \r\n\r\n📎 https://admission.lnu.edu.ua/wp-content/uploads/2023/06/Dodatok_3_3.pdf"},
            {"Вартість навчання💶", "Дізнатись вартість навчання на бакалавраті можна за посиланням:\r\n\r\nhttp://paidservices.lnu.edu.ua/wp-content/uploads/2023/04/Bakalavr-2023-2024-n.r.pdf" },
            {"Порядок розгляду та вимоги до написання мотиваційного листа✍️", "📃Із порядком розгляду мотиваційних листів до ЛНУ ім. Івана Франка та вимогами до написання, можете ознайомитись за посиланням: \r\n\r\nhttps://admission.lnu.edu.ua/wp-content/uploads/2023/04/Dodatok_11.pdf" },
            {"Творчі конкурси та терміни реєстрації🎭", "🎬Програми творчих конкурсів та відповідні терміни реєстрації розміщені за посиланням: \r\n\r\nhttps://admission.lnu.edu.ua/applicants/creative-competitions-2/" },
            {"Вступ на основі співбесіди🗣", "👩‍💻\U0001f9d1‍💻Етапи вступної кампанії для осіб, які мають право на вступ за співбесідою розміщені за посиланням: \r\n\r\nhttps://admission.lnu.edu.ua/applicants/prohramy-spivbesidy/" },
            {"Місця державного замовлення 😉", "Розподіл максимальних обсягів державного замовлення за освітніми програмами за посиланням💡\r\n\r\nhttps://admission.lnu.edu.ua/wp-content/uploads/2023/07/OP_max_2023.pdf" },
            {"Зарахування на навчання✅", "Необхідні документи та терміни зарахування шукайте за посиланням:⬇️\r\n\r\nhttps://admission.lnu.edu.ua/doc-originals/documents-bachelor/" },
            {"📆Етапи вступної кампанії", "Детальніше⬇️\r\n\r\nhttps://admission.lnu.edu.ua/applicants/admission-process-stages/" },
        };
        public override string Name => "Вступ до бакалаврату";
        public override ReplyKeyboardMarkup ReplyKeyboardMarkup => new(new[] {

                new KeyboardButton[] { "Місця державного замовлення 😉", "Творчі конкурси та терміни реєстрації🎭"},
                new KeyboardButton[] { "Зарахування на навчання✅", "Вартість навчання💶"},
                new KeyboardButton[] { "Порядок розгляду та вимоги до написання мотиваційного листа✍️", "📆Етапи вступної кампанії"},
                new KeyboardButton[] { "Правила прийому до Львівського національного університету імені Івана Франка у 2023 році📋"},
                new KeyboardButton[] { "Перелік освітніх ступенів та спеціальностей, за якими оголошується прийом на навчання, ліцензійні обсяги та нормативні терміни навчання📚"},
                new KeyboardButton[] { "📃Перелік конкурсних предметів, вагових коефіцієнтів та мінімальна кількість балів для допуску до участі в конкурсі"},
                new KeyboardButton[] { "Вернутися на початок"},

})
        {
            ResizeKeyboard = true
        };
        public override Dictionary<string, string> QuestionAnswer
        {
            get { return BachelorAnswers; }
        }
    }

    class Master : MainClass
    {
        private Dictionary<string, string> MasterAnswers = new Dictionary<string, string>()
        {
            {"Програми фахових випробувань📃", "Програми вступних випробувань для здобуття ОС «Магістри» у Львівському національному університеті імені Івана Франка на 2023 рік можете переглянути за посиланням: \r\n\r\nhttps://admission.lnu.edu.ua/for-undergraduate-students/programs-of-entrance-examinations/"},
            {"Розклад фахових випробувань📆", "Розклад фахових вступних випробувань (ФВВ) та творчих конкурсів (ТК) для вступу на навчання для здобуття ОС «Магістр» у 2023 році⬇️\r\n\r\nhttps://admission.lnu.edu.ua/wp-content/uploads/2023/06/FVV_rozklad_2023.pdf" },
            {"Розклад проведення творчих конкурсів для вступу на ОС «Магістр»⏰", "Розклад проведення творчих конкурсів для вступу на ОС «Магістр» для вступників на місця державного замовлення за кошти фізичних та/або юридичних осіб⬇️\r\n\r\nhttps://admission.lnu.edu.ua/wp-content/uploads/2023/06/Rozklad-TK-2023_mahistr.pdf" },
            {"Детальніше про вступ в магістратуру🧑‍🎓", "Усю актуальну інформацію щодо вступу в магістратуру можете дізнатись за посиланням: \r\n\r\nhttps://admission.lnu.edu.ua/for-undergraduate-students/admission-requirements-for-the-master-degree/" },
            {"Як подати заяву на участь у фаховому випробуванні?👨‍💻","З 1 липня розпочалася реєстрація заяв вступників в магістратуру на участь у співбесіді замість ЄВІ, фаховому іспиті, фаховому іспиті замість ЄФВВ. \r\n \r\n‼️Реєстрація відбувається з електронного кабінету вступника (https://cabinet.edbo.gov.ua/login).  \r\n \r\nСпівбесіди та фахові іспити триватимуть упродовж 24-27 липня.  \r\n  \r\nРеєстрація триватиме до 18:00 год. 16 липня 2023 року! \r\n \r\nІнформація щодо механізму подачі заяви на фахове випробування є подана у презентації, яка розміщена нижче⬇️\r\n\r\nhttps://drive.google.com/file/d/1rBj70vP6WvDSCH47kL72EgXsoq8Sj00q/view?usp=sharing" },

        };
        public override string Name => "Вступ до магістратури";
        public override ReplyKeyboardMarkup ReplyKeyboardMarkup => new(new[]
{               new KeyboardButton[] { "Детальніше про вступ в магістратуру🧑‍🎓", "Як подати заяву на участь у фаховому випробуванні?👨‍💻"},
                new KeyboardButton[] { "Програми фахових випробувань📃", "Розклад фахових випробувань📆"},
                new KeyboardButton[] { "Розклад проведення творчих конкурсів для вступу на ОС «Магістр»⏰"},
                new KeyboardButton[] { "Вернутися на початок"},
})
        {
            ResizeKeyboard = true
        };
        public override Dictionary<string, string> QuestionAnswer
        {
            get { return MasterAnswers; }
        }
    }

    class Faculties : MainClass
    {
        private Dictionary<string, string> FacultyAnswers = new Dictionary<string, string>()
        {
            {"🌱Біологічний факультет", "🌱\r\n[Інстаграм](https://instagram.com/facultyofbiology_lnu?igshid=MzRlODBiNWFlZA==)\r\n[Фейсбук](https://www.facebook.com/groups/299608450426486)\r\n[Телеграм](https://t.me/facultyofbiology)\r\n[Тікток](https://www.tiktok.com/@facultyofbiology_lnu?_t=8dSsqPSZer8&_r=1)"},
            {"🏔Географічний факультет", "🏔\r\n[Інстаграм](https://instagram.com/franko_geo_life?igshid=MzRlODBiNWFlZA==)" },
            {"💎Геологічний факультет", "💎\r\n[Інстаграм](https://instagram.com/geology_lnu?igshid=MzRlODBiNWFlZA==)" },
            {"💸Економічний факультет", "💸\r\n[Інстаграм](https://instagram.com/studrada_econom_lnu?igshid=MzRlODBiNWFlZA==)\r\n[Телеграм](https://t.me/studrada_econom_lnu)\r\n[Тікток](https://www.tiktok.com/@econom.lnu?_t=8dUcBS5yiJB&_r=1)" },
            {"💻 Факультет електроніки та комп’ютерних технологій", "💻\r\n[Інстаграм](https://instagram.com/electronics_lnu?igshid=MzRlODBiNWFlZA==)\r\n[Телеграм](https://t.me/electronics_lnu)\r\n[Тікток](https://www.tiktok.com/@electronics_lnu?_t=8dSprMzYtxW&_r=1)" },
            {"📜Факультет журналістики", "📜\r\n[Інстаграм](https://instagram.com/journ_lnu?igshid=MzRlODBiNWFlZA==)\r\n[Фейсбук](https://www.facebook.com/journ.lnu) \r\n[Телеграм](https://web.telegram.org/k/%D1%82%D0%B2%D0%BE%D1%8F%20%D0%A1%D1%82%D1%83%D0%B4%D0%B5%D0%BD%D1%82%D1%81%D1%8C%D0%BA%D0%B0%20%D1%80%D0%B0%D0%B4%D0%B0%20%20%20%D1%87%D0%B0%D1%82%20:%20https://t.me/joinchat/yUhB_hGkTXQxNzRi)" },
            {"🇺🇸 Факультет іноземних мов", "🇺🇸\r\n[Інстаграм](https://instagram.com/studrada.inmov?igshid=MzRlODBiNWFlZA==)\r\n[Телеграм](https://t.me/studradainmov)" },
            {"⌛️Історичний факультет", "⌛️\r\n[Інстаграм](https://instagram.com/histfac.lnu?igshid=MzRlODBiNWFlZA==)\r\n[Фейсбук](https://www.facebook.com/groups/1410143449247797) \r\n[Телеграм](https://t.me/histfaclnu)\r\n[Тікток](https://www.tiktok.com/@histfac.lnu?_t=8dSsi65YDgb&_r=1)" },
            {"🎭Факультет культури та мистецтв", "🎭\r\n[Інстаграм](https://instagram.com/cultart_lnu?igshid=MzRlODBiNWFlZA==)\r\n[Фейсбук](https://www.facebook.com/profile.php?id=100086753050086) \r\n[Телеграм](https://t.me/fkim_valova_18)" },
            {"\U0001f9eeМеханіко-математичний факультет", "\U0001f9ee\r\n[Інстаграм](https://instagram.com/mmf_live?igshid=NTc4MTIwNjQ2YQ==)\r\n[Телеграм](https://t.me/mmflnu)" },
            {"\U0001f91d Факультет міжнародних відносин", "\U0001f91d\r\n[Інстаграм](https://instagram.com/intrel_lnu_official?igshid=MzRlODBiNWFlZA==)\r\n[Фейсбук](https://www.facebook.com/stud.rada.intrel) " },
            {"👩‍🏫 Факультет педагогічної освіти", "👩‍🏫\r\n[Інстаграм](https://instagram.com/sr_fpo_lnu?igshid=MzRlODBiNWFlZA==)\r\n[Фейсбук](https://www.facebook.com/groups/895994010446431/?ref=share_group_link) " },
            {"\U0001f9d1‍💻 Факультет прикладної математики та інформатики", "\U0001f9d1‍💻\r\n[Інстаграм](https://instagram.com/lnu.prykladna?igshid=MzRlODBiNWFlZA==)\r\n[Телеграм](https://t.me/darkside_ami)\r\n[Тікток](https://www.tiktok.com/@ami.lnu)" },
            {"💰 Факультет управління фінансами та бізнесу", "💰\r\n[Інстаграм](https://instagram.com/fufb_life.lnu?igshid=MzRlODBiNWFlZA==)\r\n[Фейсбук](https://m.facebook.com/fufbstudents) \r\n[Телеграм](https://t.me/fufb_lnu) " },
            {"\U0001f9f2 Фізичний факультет", "\U0001f9f2\r\n[Інстаграм](https://instagram.com/physical.faculty?igshid=MzRlODBiNWFlZA==)\r\n[Телеграм](https://t.me/sr_phys) " },
            {"✍️ Філологічний факультет", "✍️\r\n[Інстаграм](https://instagram.com/studphil_lnu?igshid=MzRlODBiNWFlZA==)\r\n[Фейсбук](https://www.facebook.com/lnu.studphil) \r\n[Телеграм](https://t.me/studphil_lnu)\r\n[Тікток](https://www.tiktok.com/@studphil_lnu?_t=8dSsRW0jk86&_r=1)" },
            {"\U0001f9e0 Філософський факультет", "\U0001f9e0\r\n[Інстаграм](https://instagram.com/studrada.filos?igshid=MzRlODBiNWFlZA==) \r\n[Телеграм](https://t.me/filos_rada) " },
            {"\U0001f9ea Хімічний факультет", "\U0001f9ea\r\n[Інстаграм](https://instagram.com/lnu.chem?igshid=MzRlODBiNWFlZA==)\r\n[Телеграм](https://t.me/chem_lnu)" },
            {"⚖️ Юридичний факультет", "⚖️\r\n[Інстаграм](https://instagram.com/studrada_law?igshid=MzRlODBiNWFlZA==)\r\n[Телеграм](https://t.me/studlawlnu)\r\n[Тікток](https://www.tiktok.com/@studradalaw_lnu?_t=8dUcH31lUs2&_r=1" },
            {"\U0001f9d2👧 Педагогічний фаховий коледж", "\U0001f9d2👧\r\n[Інстаграм](https://instagram.com/_ped_college_?igshid=MzRlODBiNWFlZA==)" },

        };
        public override string Name => "Студентські ради у соціальних мережах💻";
        public override ReplyKeyboardMarkup ReplyKeyboardMarkup => new(new[]
{
                new KeyboardButton[] { "🌱Біологічний факультет", "🏔Географічний факультет"},
                new KeyboardButton[] { "💎Геологічний факультет", "💸Економічний факультет"},
                new KeyboardButton[] { "💻 Факультет електроніки та комп’ютерних технологій", "📜Факультет журналістики" },
                new KeyboardButton[] { "🇺🇸 Факультет іноземних мов", "⌛️Історичний факультет" },
                new KeyboardButton[] { "🎭Факультет культури та мистецтв", "🧮Механіко-математичний факультет" },
                new KeyboardButton[] { "🤝 Факультет міжнародних відносин", "👩‍🏫 Факультет педагогічної освіти" },
                new KeyboardButton[] { "🧑‍💻 Факультет прикладної математики та інформатики", "💰 Факультет управління фінансами та бізнесу" },
                new KeyboardButton[] { "🧲 Фізичний факультет", "✍️ Філологічний факультет" },
                new KeyboardButton[] { "🧠 Філософський факультет", "🧪 Хімічний факультет" },
                new KeyboardButton[] { "⚖️ Юридичний факультет", "🧒👧 Педагогічний фаховий коледж" },
                new KeyboardButton[] { "Вернутися на початок" },
})
        {
            ResizeKeyboard = true
        };
        public override Dictionary<string, string> QuestionAnswer
        {
            get { return FacultyAnswers; }
        }
    }

}
