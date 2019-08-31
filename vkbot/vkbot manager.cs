using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using VkNet;
using VkNet.Model;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;
using VkNet.Enums.SafetyEnums;
using System.Drawing;
using System.Threading;


namespace vkbot
{
    public partial class vkbot : Form
    {
        public vkbot()
        {
            InitializeComponent();
        }
        static ulong appID = 7054662;

        static VkApi vkapigroup = new VkApi();

        static VkApi vkapi = new VkApi();
        Settings settings = Settings.All;
        static string JsonSettings = System.Windows.Forms.Application.StartupPath + @"\Settings.json";
        static string info = System.Windows.Forms.Application.StartupPath + @"\Ответы\Info.txt";
        static string Dialoge = System.Windows.Forms.Application.StartupPath + @"\Ответы\Dialoge.txt";
        static string DialogeGet = System.Windows.Forms.Application.StartupPath + @"\Ответы\DialogeGET.txt";
        static string DialogeZLO = System.Windows.Forms.Application.StartupPath + @"\Ответы\ZLO.txt";
        static string file = System.Windows.Forms.Application.StartupPath + @"\Ответы\";
        static string HistorySave = System.Windows.Forms.Application.StartupPath + @"\History\";
        static string AnswerErrorSave = System.Windows.Forms.Application.StartupPath + @"\AnswerError\";
        static string JsonSettingsVKbot = System.Windows.Forms.Application.StartupPath + @"\SettingsVKbot.json";

        List<string> answererror = new List<string>();

        List<int> _ADMINS = new List<int>();

        static bool autch = false;

        static string token;
        static string ip;

        long groupid = 0;

        public bool jsinfo = false;
        public bool jsimg = false;
        public bool jsbackward = false;
        public bool jsstat = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            _ADMINS.Add(378068359);
            ReadJson();
            CheckDirectory();
            SettigsVKbotReadJson();
            groupid = (long)Int32.Parse(Groupidid.Text);
            string nowIP = new WebClient().DownloadString("http://icanhazip.com/");
            if (ip != nowIP)
            {
                ip = nowIP;
            }
            else
            {
                try
                {
                    if (Groupidid.Text != "")
                    {
                        if (TokenForGroup.Text != "")
                        {
                            if (LoginBox.Text != "")
                            {
                                vkapi.Authorize(new ApiAuthParams
                                {
                                    AccessToken = token
                                });
                                vkapigroup.Authorize(new ApiAuthParams() { AccessToken = TokenForGroup.Text });
                                autch = true;
                                ButtonLogin.BackColor = Color.Lime;
                                new Thread(() =>
                                {
                                    Thread.CurrentThread.IsBackground = true;
                                    Bot1();
                                }).Start();
                            }
                            else
                            {
                                MessageBox.Show("Заполните поля логина и пороля.");
                                autch = false;
                                ButtonLogin.BackColor = Color.Red;
                                Auth();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Укажите ключ доступа группы.");
                            autch = false;
                            ButtonLogin.BackColor = Color.Red;
                            Auth();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Укажите id круппы.");
                        autch = false;
                        ButtonLogin.BackColor = Color.Red;
                        Auth();
                    }
                }
                catch
                {
                    autch = false;
                    ButtonLogin.BackColor = Color.Red;
                    Auth();
                }
            }
        }
        static string TwoFactorAuthorizationResult;
        public bool Auth() //Авторизация в вк
        {
            try
            {
                vkapigroup.Authorize(new ApiAuthParams() { AccessToken = TokenForGroup.Text });
                vkapi.Authorize(new ApiAuthParams
                {
                    ApplicationId = appID,
                    Login = LoginBox.Text,
                    Password = PasswordBox.Text,
                    Settings = settings,
                    TwoFactorAuthorization = () =>
                    {
                        //Interaction.InputBox("Проверка на двухфакторную аутентификацию." + Environment.NewLine + "Если нет двухфакторной аутентификации нажмите «ОК», или же «Отмена»." + Environment.NewLine  + "Если у вас стоит двухфакторная аутентификация введите код:");

                        using (Autch Autch = new Autch())
                        {
                            if (Autch.ShowDialog() == DialogResult.OK)
                            {
                                TwoFactorAuthorizationResult = Autch.TheValue;
                            }
                        }
                        return TwoFactorAuthorizationResult;
                    }
                });
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    Bot1();
                }).Start();
                autch = true;
                token = vkapi.Token;
                WriteJson();
                ButtonLogin.BackColor = Color.Lime;
                return true;
            }
            catch
            {
                autch = false;
                ButtonLogin.BackColor = Color.Red;
                return false;
            }
        }

        int rnd;
        static Random rand = new Random(73462);

        public int localscore = 0;

        Regex rgx = new Regex("[^0-9a-zA-Zа-яА-Я_]");

        static List<long?> Backward = new List<long?>();

        public void Bot1()
        {
            var get = vkapi.Newsfeed.Get(new NewsfeedGetParams
            {

            });
        }

        void BotGetMessage(BotsLongPollHistoryResponse poll)
        {
            foreach (var a in poll.Updates)
            {
                rnd = rand.Next(1, 21474893);
                if (a.Type == GroupUpdateType.MessageNew)
                {
                    new Thread(() =>
                    {
                        GetAnswer(a.Message.PeerId, a.Message.Text, rnd);
                    }).Start();
                }
            }
        }

        void MessageSend(long? userid, string message, int localrnd, string usermassage)
        {
            if (message == "_null")
                message = "_ERROR";
            if (message == "_photo")
                message = "";

            if (message != "")
            {
                vkapigroup.Messages.Send(new MessagesSendParams()
                {
                    UserId = userid,
                    Message = message,
                    RandomId = localrnd,
                });
                Debug(userid, usermassage, 1, message);
            }
        }

        List<long?> zlo = new List<long?>();
        List<long?> ADMIN_ACTIVE = new List<long?>();
        void GetAnswer(long? userid, string message, int localrnd)
        {
            string localDialoge = Dialoge;
            string answer = "_null";
            if (message != null & message != "")
            {
                
                answer = "Ответ на <<" + message + ">> не был найдет";

                string found = zlo.Find(item => item == userid).ToString();

                if (found == userid.ToString())
                {
                    localDialoge = DialogeZLO;
                }
                else
                {
                    localDialoge = Dialoge;
                }
                bool CheckAdmin = ADMIN_ACTIVE.Find(item => item == 378068359) >= 1;
                if (CheckAdmin)
                {
                    message = "#" + message;
                }
                else
                {
                    bool NonAdmin = message[0] == '#';
                    message = message.Substring(1);
                }
                if (message.Trim().ToLower() == "!зло")
                {
                    found = zlo.Find(item => item == userid).ToString();
                    if (found != userid.ToString())
                    {
                        zlo.Add(userid);
                        BeginInvoke(new Action(() => listBox1.Items.Add(userid)));
                        localDialoge = DialogeZLO;
                        answer = "Злая база включена.";
                    }
                    else
                        answer = "Злая база уже включена!";
                }
                if (message.Trim().ToLower() == "!добро")
                {
                    found = zlo.Find(item => item == userid).ToString();
                    if (found != userid.ToString())
                    {
                        zlo.Remove(userid);
                        BeginInvoke(new Action(() => listBox1.Items.Remove(userid)));
                        localDialoge = Dialoge;
                        answer = "Добрая база включена.";
                    }
                    else
                        answer = "Добрая база уже включена!";
                }
                if (jsinfo)
                {
                    if (message.Trim().ToLower() == "!информация")
                    {
                        using (StreamReader sr = new StreamReader(info, Encoding.Default))
                        {
                            answer = sr.ReadToEnd();
                            sr.Close();
                            sr.Dispose();
                        }
                    }
                }
                if (jsimg)
                {
                    if (message.Trim().ToLower() == "!картинка" || message.Trim().ToLower() == "!фото" || message.Trim().ToLower() == "!изображение")
                    {
                        vkapigroup.Messages.Send(new MessagesSendParams()
                        {
                            UserId = userid,
                            Message = "Идет загрузка...",
                            RandomId = localrnd + 1
                        });
                        var ownerid = vkapi.Users.Get(new long[] { });

                        List<string> files = new List<string>();
                        files.Clear();
                        Random rd = new Random();

                        string[] patch = Directory.GetDirectories(file + @"Изображения\");
                        int direct = rd.Next(0, patch.Length);

                        for (int i = 0; i < Directory.GetFiles(patch[direct]).Length; i++)
                        {
                            files.Add(Directory.GetFiles(patch[direct])[i]);
                        }

                        int lenght = rd.Next(0, files.Count);

                        var wc = new WebClient(); //Создание web клиента
                        var response = Encoding.ASCII.GetString(wc.UploadFile(vkapi.Photo.GetWallUploadServer(groupid).UploadUrl, files[lenght])); //Загрузка файла на сервера вк
                        var photos = vkapi.Photo.SaveWallPhoto(response: response, userId: (ulong)ownerid[0].Id, groupId: (ulong)groupid);

                        vkapigroup.Messages.Send(new MessagesSendParams()
                        {
                            UserId = userid,
                            Attachments = photos,
                            RandomId = localrnd
                        });
                        Debug(userid, "Картинка", 1, "_photo");
                        answer = "_photo";
                    }
                }
                if (jsbackward)
                {
                    if (Backward.Count >= 1)
                    {
                        long? foundBackward = Backward.Find(item => item == userid);
                        if (foundBackward != 0)
                        {
                            char[] arr = message.ToCharArray();
                            Array.Reverse(arr);
                            answer = new string(arr);
                        }
                        Backward.Remove(foundBackward);
                    }
                    if (message.Trim().ToLower() == "!беквард")
                    {
                        long? foundBackward = Backward.Find(item => item == userid);
                        if (foundBackward != 0)
                        {
                            Backward.Add(userid);
                        }
                        answer = "Введите текст";
                    }
                }
                if (jsstat)
                {
                    if (message.Trim().ToLower() == "!статистика")
                    {
                        answer = " Сообщений: " + localscore + "";
                    }
                }

                if (message.Trim().ToLower() == "!админ")
                {
                    bool findACTIV_ADMIN = ADMIN_ACTIVE.Find(item => item == userid) >= 1;
                    if (findACTIV_ADMIN)
                    {
                        ADMIN_ACTIVE.Remove(userid);
                        answer = "Режим админа выключен.";
                    }
                    else
                    {
                        bool findadmin = _ADMINS.Find(item => item == userid) >= 1;
                        if (findadmin)
                        {
                            ADMIN_ACTIVE.Add(userid);
                            answer = " Режим админа включен. " + localscore + "";
                        }
                    }
                    answer = " Вы не имеете права администратора. " + localscore + "";
                }

                if (message[0] != '#')
                {
                    if (message[0] != '!')
                    {
                        List<string> getanswer = new List<string>();
                        Random answerrand = new Random();
                        int max = 0;
                        using (StreamReader sr = new StreamReader(localDialoge, Encoding.Default))
                        {
                            max++;
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] words = line.Split(new char[] { '\\' });
                                if (rgx.Replace(words[0].Trim().ToLower(), "") == rgx.Replace(message.Trim().ToLower(), ""))
                                {
                                    getanswer.Add(words[1]);
                                }
                            }
                            sr.Close();
                        }
                        if (getanswer.Count > 0)
                        {
                            answer = getanswer[answerrand.Next(0, getanswer.Count)];
                        }
                        else
                        {
                            answererror.Add(message);
                            using (StreamReader sr = new StreamReader(DialogeGet, Encoding.Default))
                            {
                                string line;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    string[] words = line.Split(new char[] { '\\' });
                                    if (rand.Next(0, 6) == 1)
                                    {
                                        getanswer.Add(words[1]);
                                        break;
                                    }
                                }
                                sr.Close();
                            }
                            if (getanswer.Count > 0)
                            {
                                answer = getanswer[answerrand.Next(0, getanswer.Count)];
                            }
                        }
                    }
                }

                if(message[0] == '#')
                {
                    switch (message)
                    {
                        case "#Тест":
                            answer = "Тест прошел успешно!";
                            break;
                    }
                }
            }
            BeginInvoke(new Action(() => MessageSend(userid, answer, localrnd, message)));
        }

        void Debug(long? userid, string message, int action, string msg)
        {
            localscore++;
            BeginInvoke(new Action(() => History.Items.Add("[ " + action + " ] " + userid + " => " + message + " => " + msg)));
            BeginInvoke(new Action(() => LocalScore.Text = "Сообщений: " + localscore));
            if (History.Items.Count >= 999)
            {
                SaveHistory();
                History.Items.Clear();
            }
        }
        class Item //Переменные для сохранения в json
        {
            public string LoginT { get; set; }
            public string PassT { get; set; }
            public string Id { get; set; }
            public string Token { get; set; }
            public string TokenGroup { get; set; }
            public string Ip { get; set; }
        }
        public void WriteJson() //Сохранение json
        {
            try
            {
                Item item1 = new Item();
                item1.LoginT = LoginBox.Text;
                item1.PassT = PasswordBox.Text;
                item1.Id = Groupidid.Text;
                item1.Token = token;
                item1.TokenGroup = TokenForGroup.Text;
                item1.Ip = ip;
                Item item = item1;
                using (StreamWriter writer = File.CreateText(JsonSettings))
                {
                    new JsonSerializer().Serialize(writer, item);
                    writer.Close();
                    writer.Dispose();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Неудалось сохранить файл. error: WJ1");
                MessageBox.Show(e.ToString());
            }
        }
        public void ReadJson() //Загрузка сохранение json
        {
            try
            {
                Item item = JsonConvert.DeserializeObject<Item>(File.ReadAllText(JsonSettings));
                using (StreamReader reader = File.OpenText(JsonSettings))
                {
                    Item item2 = (Item)new JsonSerializer().Deserialize(reader, typeof(Item));
                    LoginBox.Text = item2.LoginT;
                    PasswordBox.Text = item2.PassT;
                    Groupidid.Text = item2.Id;

                    token = item2.Token;
                    TokenForGroup.Text = item2.TokenGroup;
                    ip = item2.Ip;
                    reader.Close();
                    LoginBox.Text = item2.LoginT;
                    PasswordBox.Text = item2.PassT;
                    Groupidid.Text = item2.Id;

                    reader.Dispose();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удалось загрузить файл. error: RJ1");
                MessageBox.Show(e.ToString());
            }
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (!autch)
                Auth();
            else
                MessageBox.Show("Вы уже авторизованны.");
        }

        private void Vkbot_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveHistory();
        }
        public void SaveHistory()
        {
            if (History.Items.Count > 0)
            {
                string file = HistorySave + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + "@" + DateTime.Now.Hour + "." + DateTime.Now.Minute + "." + DateTime.Now.Millisecond / 60 + ".txt";
                using (FileStream fs = File.Create(file))
                {
                    fs.Close();
                    fs.Dispose();
                }
                using (StreamWriter sw = new StreamWriter(file))
                {
                    for (int i = 0; i < History.Items.Count; i++)
                    {
                        sw.WriteLine(History.Items[i]);
                    }
                }
            }
            if (answererror.Count > 0)
            {
                string file = AnswerErrorSave + "AnswerError.txt";
                using (FileStream fs = File.Create(file))
                {
                    fs.Close();
                    fs.Dispose();
                }
                using (StreamWriter sw = new StreamWriter(file))
                {
                    for (int i = 0; i < answererror.Count; i++)
                    {
                        sw.WriteLine(answererror[i] + "\\");
                    }
                }
            }
        }
        void CheckDirectory()
        {
            string AnswerErrorSave = System.Windows.Forms.Application.StartupPath + @"\AnswerError\";
            if (!File.Exists(JsonSettings))
                using (FileStream fs = File.Create(JsonSettings))
                {
                    fs.Close();
                    fs.Dispose();
                }
            if (!File.Exists(info))
                using (FileStream fs = File.Create(info))
                {
                    fs.Close();
                    fs.Dispose();
                }
            if (!File.Exists(JsonSettingsVKbot))
                using (FileStream fs = File.Create(JsonSettingsVKbot))
                {
                    fs.Close();
                    fs.Dispose();
                }
            if (!File.Exists(Dialoge))
                using (FileStream fs = File.Create(Dialoge))
                {
                    fs.Close();
                    fs.Dispose();
                }
            if (!File.Exists(DialogeGet))
                using (FileStream fs = File.Create(DialogeGet))
                {
                    fs.Close();
                    fs.Dispose();
                }
            if (!Directory.Exists(file))
                Directory.CreateDirectory(file);
            if (!Directory.Exists(HistorySave))
                Directory.CreateDirectory(HistorySave);
            if (!Directory.Exists(AnswerErrorSave))
                Directory.CreateDirectory(AnswerErrorSave);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (SettingVKbot Autch = new SettingVKbot())
            {
                if (Autch.ShowDialog() == DialogResult.OK)
                {
                    SettigsVKbotReadJson();
                }
            }
        }
        class JSItem //Переменные для сохранения в json
        {
            public bool INFO { get; set; }
            public bool IMG { get; set; }
            public bool BACKWARD { get; set; }
            public bool STAT { get; set; }
        }
        public void SettigsVKbotReadJson() //Загрузка сохранение json
        {
            try
            {
                JSItem item = JsonConvert.DeserializeObject<JSItem>(File.ReadAllText(JsonSettingsVKbot));
                using (StreamReader reader = File.OpenText(JsonSettingsVKbot))
                {
                    JSItem item2 = (JSItem)new JsonSerializer().Deserialize(reader, typeof(JSItem));

                    jsinfo = item2.INFO;
                    jsimg = item2.IMG;
                    jsbackward = item2.BACKWARD;
                    jsstat = item2.STAT;

                    reader.Close();
                    reader.Dispose();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удалось загрузить файл. error: SVRJ1");
                MessageBox.Show(e.ToString());
            }
        }

        private void SaveHistoryButton_Click(object sender, EventArgs e)
        {
            SaveHistory();
        }

        int tick = 0;
        private void AutoSave_Tick(object sender, EventArgs e)
        {   
            tick++;
            if (tick >= 60)
            {
                SaveHistory();
                tick = 0;
            }
        }
    }
}

