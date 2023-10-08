namespace Organizer
{
    partial class Form1
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
            this.AddBut = new System.Windows.Forms.Button();
            this.elementBox = new System.Windows.Forms.TextBox();
            this.daysBox = new System.Windows.Forms.ComboBox();
            this.hardBox = new System.Windows.Forms.ComboBox();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.updateBut = new System.Windows.Forms.Button();
            this.newBut = new System.Windows.Forms.Button();
            this.statudBut = new System.Windows.Forms.Button();
            this.sortDayBut = new System.Windows.Forms.Button();
            this.sortHardSort = new System.Windows.Forms.Button();
            this.sortAllBut = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.del = new System.Windows.Forms.Button();
            this.redDayBut = new System.Windows.Forms.Button();
            this.type = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddBut
            // 
            this.AddBut.Location = new System.Drawing.Point(188, 103);
            this.AddBut.Name = "AddBut";
            this.AddBut.Size = new System.Drawing.Size(92, 37);
            this.AddBut.TabIndex = 0;
            this.AddBut.Text = "Добавить";
            this.AddBut.UseVisualStyleBackColor = true;
            this.AddBut.Click += new System.EventHandler(this.AddBut_Click);
            // 
            // elementBox
            // 
            this.elementBox.Location = new System.Drawing.Point(12, 12);
            this.elementBox.Name = "elementBox";
            this.elementBox.Size = new System.Drawing.Size(303, 22);
            this.elementBox.TabIndex = 1;
            // 
            // daysBox
            // 
            this.daysBox.FormattingEnabled = true;
            this.daysBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "0"});
            this.daysBox.Location = new System.Drawing.Point(12, 62);
            this.daysBox.Name = "daysBox";
            this.daysBox.Size = new System.Drawing.Size(121, 24);
            this.daysBox.TabIndex = 2;
            this.daysBox.Tag = "";
            this.daysBox.Text = "Дни";
            // 
            // hardBox
            // 
            this.hardBox.FormattingEnabled = true;
            this.hardBox.ItemHeight = 16;
            this.hardBox.Items.AddRange(new object[] {
            "0",
            "1",
            "3",
            "5"});
            this.hardBox.Location = new System.Drawing.Point(12, 110);
            this.hardBox.Name = "hardBox";
            this.hardBox.Size = new System.Drawing.Size(121, 24);
            this.hardBox.TabIndex = 3;
            this.hardBox.Tag = "";
            this.hardBox.Text = "Слжность";
            // 
            // typeBox
            // 
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Location = new System.Drawing.Point(12, 156);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(121, 24);
            this.typeBox.TabIndex = 4;
            this.typeBox.Tag = "";
            this.typeBox.Text = "Деятельность";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(366, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(404, 22);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Активность";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(778, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(65, 22);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "Дни";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(849, 12);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(91, 22);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "Сложность";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(946, 12);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(134, 22);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "Тип";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(1086, 12);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(71, 22);
            this.textBox5.TabIndex = 9;
            this.textBox5.Text = "Удалить";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // updateBut
            // 
            this.updateBut.Location = new System.Drawing.Point(12, 205);
            this.updateBut.Name = "updateBut";
            this.updateBut.Size = new System.Drawing.Size(268, 37);
            this.updateBut.TabIndex = 11;
            this.updateBut.Text = "Обновить";
            this.updateBut.UseVisualStyleBackColor = true;
            this.updateBut.Click += new System.EventHandler(this.updateBut_Click);
            // 
            // newBut
            // 
            this.newBut.Location = new System.Drawing.Point(12, 248);
            this.newBut.Name = "newBut";
            this.newBut.Size = new System.Drawing.Size(268, 37);
            this.newBut.TabIndex = 12;
            this.newBut.Text = "Новый день";
            this.newBut.UseVisualStyleBackColor = true;
            this.newBut.Click += new System.EventHandler(this.newBut_Click);
            // 
            // statudBut
            // 
            this.statudBut.Location = new System.Drawing.Point(12, 291);
            this.statudBut.Name = "statudBut";
            this.statudBut.Size = new System.Drawing.Size(268, 37);
            this.statudBut.TabIndex = 13;
            this.statudBut.Text = "Удалить без дней";
            this.statudBut.UseVisualStyleBackColor = true;
            this.statudBut.Click += new System.EventHandler(this.statudBut_Click);
            // 
            // sortDayBut
            // 
            this.sortDayBut.Location = new System.Drawing.Point(12, 334);
            this.sortDayBut.Name = "sortDayBut";
            this.sortDayBut.Size = new System.Drawing.Size(268, 37);
            this.sortDayBut.TabIndex = 14;
            this.sortDayBut.Text = "Сорт. по дням";
            this.sortDayBut.UseVisualStyleBackColor = true;
            this.sortDayBut.Click += new System.EventHandler(this.sortDayBut_Click);
            // 
            // sortHardSort
            // 
            this.sortHardSort.Location = new System.Drawing.Point(12, 377);
            this.sortHardSort.Name = "sortHardSort";
            this.sortHardSort.Size = new System.Drawing.Size(268, 37);
            this.sortHardSort.TabIndex = 15;
            this.sortHardSort.Text = "Сорт. по сложности";
            this.sortHardSort.UseVisualStyleBackColor = true;
            this.sortHardSort.Click += new System.EventHandler(this.sortHardSort_Click);
            // 
            // sortAllBut
            // 
            this.sortAllBut.Location = new System.Drawing.Point(12, 420);
            this.sortAllBut.Name = "sortAllBut";
            this.sortAllBut.Size = new System.Drawing.Size(268, 37);
            this.sortAllBut.TabIndex = 16;
            this.sortAllBut.Text = "Сорт. по дням и сложности";
            this.sortAllBut.UseVisualStyleBackColor = true;
            this.sortAllBut.Click += new System.EventHandler(this.sortAllBut_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(171, 55);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(127, 37);
            this.add.TabIndex = 17;
            this.add.Text = "Добавить деят.";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // del
            // 
            this.del.Location = new System.Drawing.Point(171, 149);
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(127, 37);
            this.del.TabIndex = 18;
            this.del.Text = "Удалить деят.";
            this.del.UseVisualStyleBackColor = true;
            this.del.Click += new System.EventHandler(this.del_Click);
            // 
            // redDayBut
            // 
            this.redDayBut.Location = new System.Drawing.Point(12, 463);
            this.redDayBut.Name = "redDayBut";
            this.redDayBut.Size = new System.Drawing.Size(268, 37);
            this.redDayBut.TabIndex = 19;
            this.redDayBut.Text = "Изменить кол-во дней";
            this.redDayBut.UseVisualStyleBackColor = true;
            this.redDayBut.Click += new System.EventHandler(this.redDayBut_Click);
            // 
            // type
            // 
            this.type.FormattingEnabled = true;
            this.type.Items.AddRange(new object[] {
            "Обычный",
            "Ожидание",
            "Параллельно",
            "Ежедневно"});
            this.type.Location = new System.Drawing.Point(12, 506);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(268, 24);
            this.type.TabIndex = 20;
            this.type.Tag = "";
            this.type.Text = "Обычный";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 536);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(268, 37);
            this.button1.TabIndex = 21;
            this.button1.Text = "Замарозка";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1196, 589);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.type);
            this.Controls.Add(this.redDayBut);
            this.Controls.Add(this.del);
            this.Controls.Add(this.add);
            this.Controls.Add(this.sortAllBut);
            this.Controls.Add(this.sortHardSort);
            this.Controls.Add(this.sortDayBut);
            this.Controls.Add(this.statudBut);
            this.Controls.Add(this.newBut);
            this.Controls.Add(this.updateBut);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.daysBox);
            this.Controls.Add(this.hardBox);
            this.Controls.Add(this.AddBut);
            this.Controls.Add(this.elementBox);
            this.Name = "Form1";
            this.Text = "Органайзер";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddBut;
        private System.Windows.Forms.TextBox elementBox;
        private System.Windows.Forms.ComboBox daysBox;
        private System.Windows.Forms.ComboBox hardBox;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button updateBut;
        private System.Windows.Forms.Button newBut;
        private System.Windows.Forms.Button statudBut;
        private System.Windows.Forms.Button sortDayBut;
        private System.Windows.Forms.Button sortHardSort;
        private System.Windows.Forms.Button sortAllBut;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button del;
        private System.Windows.Forms.Button redDayBut;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.Button button1;
    }
}

