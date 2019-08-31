namespace vkbot
{
    partial class SettingVKbot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonDone = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.CheckBox();
            this.img = new System.Windows.Forms.CheckBox();
            this.backward = new System.Windows.Forms.CheckBox();
            this.stat = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ButtonDone
            // 
            this.ButtonDone.Location = new System.Drawing.Point(265, 219);
            this.ButtonDone.Name = "ButtonDone";
            this.ButtonDone.Size = new System.Drawing.Size(75, 23);
            this.ButtonDone.TabIndex = 0;
            this.ButtonDone.Text = "ОК";
            this.ButtonDone.UseVisualStyleBackColor = true;
            this.ButtonDone.Click += new System.EventHandler(this.ButtonDone_Click);
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Location = new System.Drawing.Point(12, 12);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(95, 17);
            this.info.TabIndex = 1;
            this.info.Text = "!Информация";
            this.info.UseVisualStyleBackColor = true;
            // 
            // img
            // 
            this.img.AutoSize = true;
            this.img.Location = new System.Drawing.Point(12, 35);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(188, 17);
            this.img.TabIndex = 2;
            this.img.Text = "!Фото | картинка | изображение";
            this.img.UseVisualStyleBackColor = true;
            // 
            // backward
            // 
            this.backward.AutoSize = true;
            this.backward.Location = new System.Drawing.Point(12, 58);
            this.backward.Name = "backward";
            this.backward.Size = new System.Drawing.Size(72, 17);
            this.backward.TabIndex = 3;
            this.backward.Text = "!Беквард";
            this.backward.UseVisualStyleBackColor = true;
            // 
            // stat
            // 
            this.stat.AutoSize = true;
            this.stat.Location = new System.Drawing.Point(12, 81);
            this.stat.Name = "stat";
            this.stat.Size = new System.Drawing.Size(87, 17);
            this.stat.TabIndex = 4;
            this.stat.Text = "!Статистика";
            this.stat.UseVisualStyleBackColor = true;
            // 
            // SettingVKbot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 254);
            this.ControlBox = false;
            this.Controls.Add(this.stat);
            this.Controls.Add(this.backward);
            this.Controls.Add(this.img);
            this.Controls.Add(this.info);
            this.Controls.Add(this.ButtonDone);
            this.Name = "SettingVKbot";
            this.Text = "SettingVKbot";
            this.Load += new System.EventHandler(this.SettingVKbot_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonDone;
        private System.Windows.Forms.CheckBox info;
        private System.Windows.Forms.CheckBox img;
        private System.Windows.Forms.CheckBox backward;
        private System.Windows.Forms.CheckBox stat;
    }
}