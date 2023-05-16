using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using Microsoft.VisualBasic;
using Telegram.Bot.Types.Enums;

namespace StudentGovernment
{
    public class StudentGovernmentBot : StudentGovernment
    {
        public bool _ifUserExist = false;
        public int whatFaculty = 0;
        AMI ami = new AMI();
        CultArt cultArt = new CultArt();
        static SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-LIT9J9L\MYDB;Initial Catalog=StudentGovernment;Integrated Security=True");
        static void Main(string[] args)
        {
            var bot = new StudentGovernmentBot(args[0]);
            bot.Run();
        }

        public StudentGovernmentBot(string botToken) : base(botToken) { }

        public async Task StartFunction(Chat chat)
        {
            await CallKeyboard(chat, "👋Привіт! Цей бот створений, щоб відповісти на всі питання, які тебе цікавлять, але перед цим обери свій факультет 😍", ami.Faculties);
        }

        public override async Task OnPrivateChat(Chat chat, User user, UpdateInfo update)
        {
            if (update.Message.Text == "/start")
            {

                await StartFunction(chat);
                return;
            }
            else if (update.Message.Text == cultArt.Name || update.Message.Text == "/ami")
            {
                await CallKeyboard(chat, "Лови усю інформацію, яку я маю для факультету прикладної математики та інформатики 😉\r\nНе знайшов свого або все ще залишилися питання? Не соромся написати мені його, а я його передам кому потрібно 🙌", ami.ReplyKeyboardMarkup);
                connection.Open();
                using (SqlCommand checkCommand = new SqlCommand($"SELECT COUNT(*) FROM STUDENT_GOVERNMENT WHERE ChatID = {chat.Id}", connection))
                {
                    int existingCount = (int)checkCommand.ExecuteScalar();

                    if (existingCount == 0)
                    {
                        using (SqlCommand command = new SqlCommand($"INSERT INTO STUDENT_GOVERNMENT (ChatID,Faculty, UserName  ) VALUES ({chat.Id}, 1, '@{user.Username}')", connection))
                        {
                            await command.ExecuteNonQueryAsync();
                        }
                    }
                    else
                    {
                        using (SqlCommand command = new SqlCommand($"UPDATE STUDENT_GOVERNMENT SET Faculty = 1 WHERE ChatID = ({chat.Id})", connection))
                        {
                            await command.ExecuteNonQueryAsync();
                        }
                    }
                }
                connection.Close();
                return;
            }
            else if (ami.QuestionAnswer.Any(response => response.Key.Contains(update.Message.Text)))
            {
                await Telegram.SendTextMessageAsync(chat, ami.QuestionAnswer.FirstOrDefault(answer => answer.Key == update.Message.Text).Value);
                if (update.Message.Text == "Задати питання адміністратру ФПМІ")
                {
                    var userQuestion = await NewTextMessage(update);
                    connection.Open();
                    using (SqlCommand command = new SqlCommand($"INSERT INTO STUDENT_QUESTIONS (Faculty ,UserName, Question, IsAnswered, ChatID  ) VALUES (1, '@{user.Username}', '{userQuestion}',0,'{chat.Id}')", connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    connection.Close();
                    await Telegram.SendTextMessageAsync(chat, "Твоє питання надіслано, очікуй відповіді ‍💻");
                    return;
                }
                return;
            }
            else if (cultArt.QuestionAnswer.Any(response => response.Key.Contains(update.Message.Text)))
            {
                await Telegram.SendTextMessageAsync(chat, cultArt.QuestionAnswer.FirstOrDefault(answer => answer.Key == update.Message.Text).Value);
                if (update.Message.Text == "Зaдати питання адміністратуру ФКІМ")
                {
                    var userQuestion = await NewTextMessage(update);
                    connection.Open();
                    using (SqlCommand command = new SqlCommand($"INSERT INTO STUDENT_QUESTIONS (Faculty ,UserName, Question, IsAnswered, ChatID  ) VALUES (2, '@{user.Username}', '{userQuestion}',0,'{chat.Id}')", connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    connection.Close();
                    await Telegram.SendTextMessageAsync(chat, "Твоє питання надіслано, очікуй відповіді ‍🎨");
                    return;
                }
                return;
            }
            else if (update.Message.Text == cultArt.Name || update.Message.Text == "/cultart")
            {
                await CallKeyboard(chat, "Лови усю інформацію, яку я маю для факультету культури та мистецтв 😉\r\nНе знайшов свого або все ще залишилися питання? Не соромся написати мені його, а я його передам кому потрібно 🙌", cultArt.ReplyKeyboardMarkup);
                connection.Open();
                using (SqlCommand checkCommand = new SqlCommand($"SELECT COUNT(*) FROM STUDENT_GOVERNMENT WHERE ChatID = {chat.Id}", connection))
                {
                    int existingCount = (int)checkCommand.ExecuteScalar();

                    if (existingCount == 0)
                    {
                        using (SqlCommand command = new SqlCommand($"INSERT INTO STUDENT_GOVERNMENT (ChatID,Faculty, UserName  ) VALUES ({chat.Id}, 2, '@{user.Username}')", connection))
                        {
                            await command.ExecuteNonQueryAsync();
                        }
                    }
                    else
                    {
                        using (SqlCommand command = new SqlCommand($"UPDATE STUDENT_GOVERNMENT SET Faculty = 2 WHERE ChatID = ({chat.Id})", connection))
                        {
                            await command.ExecuteNonQueryAsync();
                        }
                    }
                }
                connection.Close();
                return;
            }
            else if (update.Message.Text == "/restart")
            {
                await StartFunction(chat);
                return;
            }
            else if (update.Message.Text == "Адміністрування" || update.Message.Text == "/admin")
            {
                if (chat.Id.ToString() != ami.Admin.ToString())
                {
                    await Telegram.SendTextMessageAsync(chat, "На жаль, ви не маєте доступу до цієї функції, але якщо бажаєте вступити в команду - пишіть в Telegram @Seevkaa");
                }
                else
                {
                    await CallKeyboard(chat, "Ось команди для адміністрування", ami.AdminKeyboard);

                }
                return;

            }
            else if (update.Message.Text == "Побачити усі питання" && chat.Id.ToString() == ami.Admin.ToString())
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM STUDENT_QUESTIONS", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    await Telegram.SendTextMessageAsync(chat.Id, $"Question ID :{reader.GetValue(0)}" +
                        $"\r\nUserName: {reader.GetValue(2)}\r\nQuestion:" +
                        $" {reader.GetValue(3)}\r\nIsAnswered:" +
                        $" {reader.GetValue(4)}");
                }
                connection.Close();
                return;

            }
            else if (update.Message.Text == "Побачити лише питання, на які було надано відповідь" && chat.Id.ToString() == ami.Admin.ToString())
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM STUDENT_QUESTIONS WHERE IsAnswered = 1", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    await Telegram.SendTextMessageAsync(chat.Id, $"Question ID :{reader.GetValue(0)}" +
                        $"\r\nUserName: @{reader.GetValue(2)}\r\nQuestion:" +
                        $" {reader.GetValue(3)}\r\n");
                }
                connection.Close();
                return;
            }
            else if (update.Message.Text == "Побачити лише питання, на які не було надано відповідь" && chat.Id.ToString() == ami.Admin.ToString())
            {
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM STUDENT_QUESTIONS WHERE IsAnswered = 0", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        await Telegram.SendTextMessageAsync(chat.Id, $"Question ID :{reader.GetValue(0)}" +
                            $"\r\nUserName: @{reader.GetValue(2)}\r\nQuestion:" +
                            $" {reader.GetValue(3)}\r\n");
                    }
                    connection.Close();
                    return;
                }
            }
            else if (update.Message.Text == "Побачити питання студентів ФПМІ" && chat.Id.ToString() == ami.Admin.ToString())
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM STUDENT_QUESTIONS WHERE Faculty = 1", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    await Telegram.SendTextMessageAsync(chat.Id, $"Question ID :{reader.GetValue(0)}" +
                        $"\r\nUserName: @{reader.GetValue(2)}\r\nQuestion:" +
                        $" {reader.GetValue(3)}\r\n");
                }
                connection.Close();
                return;
            }
            else if (update.Message.Text == "Побачити питання студентів ФКІМ" && chat.Id.ToString() == ami.Admin.ToString())
            {
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM STUDENT_QUESTIONS WHERE Faculty = 2", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        await Telegram.SendTextMessageAsync(chat.Id, $"Question ID :{reader.GetValue(0)}" +
                            $"\r\nUserName: @{reader.GetValue(2)}\r\nQuestion:" +
                            $" {reader.GetValue(3)}\r\n");
                    }
                    connection.Close();
                    return;
                }
            }
            else if (update.Message.Text == "Відповісти на питання" && chat.Id.ToString() == ami.Admin.ToString())
            {
                connection.Open();
                await Telegram.SendTextMessageAsync(chat, "Please enter question ID");
                var questionID = await NewTextMessage(update);
                using (SqlCommand command = new SqlCommand($"UPDATE STUDENT_QUESTIONS" +
                        $" SET IsAnswered = 1" +
                        $" WHERE QuestionID = {questionID}", connection))
                    await command.ExecuteNonQueryAsync();
                connection.Close();
                await Telegram.SendTextMessageAsync(chat, "Updated");
                return;
            }
            else if (update.Message.Text == "Отримати айді користувача" && chat.Id.ToString() == ami.Admin.ToString())
            {
                var _username = "";
                await Telegram.SendTextMessageAsync(chat, "Введіть Username користувача (через @)");
                var username = await NewTextMessage(update);
                connection.Open();
                using (SqlCommand command = new SqlCommand($"SELECT ChatID FROM STUDENT_GOVERNMENT WHERE UserName = '{username}'", connection))
                {
                    _username = command.ExecuteScalar().ToString();
                }
                connection.Close();
                await Telegram.SendTextMessageAsync(chat, $"Користувач із {username} має ось такий айді: {_username}");

                return;
            }
            else
            {
                await Telegram.SendTextMessageAsync(chat, "Ти написав щось не те, спробуй ще раз");
                return;
            }
        }
    }
}