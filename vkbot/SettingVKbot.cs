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
    public partial class SettingVKbot : Form
    {
        public SettingVKbot()
        {
            InitializeComponent();
        }

        static string JsonSettingsVKbot = System.Windows.Forms.Application.StartupPath + @"\SettingsVKbot.json";

        private void SettingVKbot_Load(object sender, EventArgs e)
        {
            ReadJson();
        }
        class Item //Переменные для сохранения в json
        {
            public bool INFO { get; set; }
            public bool IMG { get; set; }
            public bool BACKWARD { get; set; }
            public bool STAT { get; set; }
        }
        public void WriteJson() //Сохранение json
        {
            try
            {
                Item item1 = new Item();
                item1.INFO = info.Checked;
                item1.IMG = img.Checked;
                item1.BACKWARD = backward.Checked;
                item1.STAT = stat.Checked;
                Item item = item1;
                using (StreamWriter writer = File.CreateText(JsonSettingsVKbot))
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
                Item item = JsonConvert.DeserializeObject<Item>(File.ReadAllText(JsonSettingsVKbot));
                using (StreamReader reader = File.OpenText(JsonSettingsVKbot))
                {
                    Item item2 = (Item)new JsonSerializer().Deserialize(reader, typeof(Item));
                    info.Checked = item2.INFO;
                    img.Checked = item2.IMG;
                    backward.Checked = item2.BACKWARD;
                    stat.Checked = item2.STAT;

                    reader.Close();
                    reader.Dispose();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удалось загрузить файл. error: RJ1");
                MessageBox.Show(e.ToString());
            }
        }

        private void ButtonDone_Click(object sender, EventArgs e)
        {
            WriteJson();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
