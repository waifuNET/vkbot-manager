namespace vkbot
{
    partial class vkbot
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.History = new System.Windows.Forms.ListBox();
            this.LocalScore = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Groupidid = new System.Windows.Forms.RichTextBox();
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.PasswordBox = new System.Windows.Forms.RichTextBox();
            this.LoginBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TokenForGroup = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SaveHistoryButton = new System.Windows.Forms.Button();
            this.AutoSave = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // History
            // 
            this.History.BackColor = System.Drawing.SystemColors.Desktop;
            this.History.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.History.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.History.FormattingEnabled = true;
            this.History.ItemHeight = 20;
            this.History.Location = new System.Drawing.Point(12, 214);
            this.History.Name = "History";
            this.History.Size = new System.Drawing.Size(776, 224);
            this.History.TabIndex = 0;
            // 
            // LocalScore
            // 
            this.LocalScore.AutoSize = true;
            this.LocalScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LocalScore.ForeColor = System.Drawing.SystemColors.Control;
            this.LocalScore.Location = new System.Drawing.Point(648, 9);
            this.LocalScore.Name = "LocalScore";
            this.LocalScore.Size = new System.Drawing.Size(113, 20);
            this.LocalScore.TabIndex = 1;
            this.LocalScore.Text = "Сообщений: 0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(26, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 25);
            this.label9.TabIndex = 28;
            this.label9.Text = "ID группы";
            // 
            // Groupidid
            // 
            this.Groupidid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Groupidid.Location = new System.Drawing.Point(12, 147);
            this.Groupidid.Name = "Groupidid";
            this.Groupidid.Size = new System.Drawing.Size(134, 21);
            this.Groupidid.TabIndex = 27;
            this.Groupidid.Text = "";
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.BackColor = System.Drawing.Color.Red;
            this.ButtonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLogin.Location = new System.Drawing.Point(12, 179);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(134, 23);
            this.ButtonLogin.TabIndex = 26;
            this.ButtonLogin.Text = "Login";
            this.ButtonLogin.UseVisualStyleBackColor = false;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordBox.Location = new System.Drawing.Point(12, 86);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(134, 21);
            this.PasswordBox.TabIndex = 25;
            this.PasswordBox.Text = "";
            // 
            // LoginBox
            // 
            this.LoginBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginBox.Location = new System.Drawing.Point(12, 35);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(134, 21);
            this.LoginBox.TabIndex = 24;
            this.LoginBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(27, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 24);
            this.label2.TabIndex = 23;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Adobe Gothic Std B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(49, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Login";
            // 
            // TokenForGroup
            // 
            this.TokenForGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TokenForGroup.Location = new System.Drawing.Point(152, 35);
            this.TokenForGroup.Name = "TokenForGroup";
            this.TokenForGroup.Size = new System.Drawing.Size(636, 72);
            this.TokenForGroup.TabIndex = 29;
            this.TokenForGroup.Text = "b61d9b254aa96b88d787038a122fca13b4e0e3adc72c8b2736a7e3d7eaf82e9c9016e8bef06eb3816" +
    "7990";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Adobe Gothic Std B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(295, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "Ключ   доступа";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(651, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Настройки";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // SaveHistoryButton
            // 
            this.SaveHistoryButton.Location = new System.Drawing.Point(651, 142);
            this.SaveHistoryButton.Name = "SaveHistoryButton";
            this.SaveHistoryButton.Size = new System.Drawing.Size(134, 23);
            this.SaveHistoryButton.TabIndex = 32;
            this.SaveHistoryButton.Text = "Save";
            this.SaveHistoryButton.UseVisualStyleBackColor = true;
            this.SaveHistoryButton.Click += new System.EventHandler(this.SaveHistoryButton_Click);
            // 
            // AutoSave
            // 
            this.AutoSave.Enabled = true;
            this.AutoSave.Interval = 1000;
            this.AutoSave.Tick += new System.EventHandler(this.AutoSave_Tick);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(470, 113);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(175, 95);
            this.listBox1.TabIndex = 33;
            // 
            // vkbot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(797, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.SaveHistoryButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TokenForGroup);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Groupidid);
            this.Controls.Add(this.ButtonLogin);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LocalScore);
            this.Controls.Add(this.History);
            this.Name = "vkbot";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Vkbot_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox History;
        private System.Windows.Forms.Label LocalScore;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox Groupidid;
        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.RichTextBox PasswordBox;
        private System.Windows.Forms.RichTextBox LoginBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox TokenForGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SaveHistoryButton;
        private System.Windows.Forms.Timer AutoSave;
        private System.Windows.Forms.ListBox listBox1;
    }
}

