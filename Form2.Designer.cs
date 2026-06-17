namespace HomeworkApp
{
    partial class Form2
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
            textBoxSubject = new TextBox();
            button1 = new Button();
            comboBoxDay1 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            textBoxTask1 = new TextBox();
            comboBoxDay2 = new ComboBox();
            dateTimePicker2 = new DateTimePicker();
            textBoxTask2 = new TextBox();
            SuspendLayout();
            // 
            // textBoxSubject
            // 
            textBoxSubject.Location = new Point(35, 33);
            textBoxSubject.Name = "textBoxSubject";
            textBoxSubject.Size = new Size(214, 23);
            textBoxSubject.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(545, 33);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBoxDay1
            // 
            comboBoxDay1.FormattingEnabled = true;
            comboBoxDay1.Items.AddRange(new object[] { "日", "月", "火", "水", "木", "金", "土" });
            comboBoxDay1.Location = new Point(275, 152);
            comboBoxDay1.Name = "comboBoxDay1";
            comboBoxDay1.Size = new Size(121, 23);
            comboBoxDay1.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "HH:mm";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(420, 149);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 4;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // textBoxTask1
            // 
            textBoxTask1.Location = new Point(35, 152);
            textBoxTask1.Name = "textBoxTask1";
            textBoxTask1.Size = new Size(214, 23);
            textBoxTask1.TabIndex = 5;
            // 
            // comboBoxDay2
            // 
            comboBoxDay2.FormattingEnabled = true;
            comboBoxDay2.Items.AddRange(new object[] { "日", "月", "火", "水", "木", "金", "土" });
            comboBoxDay2.Location = new Point(275, 278);
            comboBoxDay2.Name = "comboBoxDay2";
            comboBoxDay2.Size = new Size(121, 23);
            comboBoxDay2.TabIndex = 6;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "HH:mm";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(420, 278);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 7;
            // 
            // textBoxTask2
            // 
            textBoxTask2.Location = new Point(35, 278);
            textBoxTask2.Name = "textBoxTask2";
            textBoxTask2.Size = new Size(214, 23);
            textBoxTask2.TabIndex = 8;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxTask2);
            Controls.Add(dateTimePicker2);
            Controls.Add(comboBoxDay2);
            Controls.Add(textBoxTask1);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBoxDay1);
            Controls.Add(button1);
            Controls.Add(textBoxSubject);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxSubject;
        private Button button1;
        private ComboBox comboBoxDay1;
        private DateTimePicker dateTimePicker1;
        private TextBox textBoxTask1;
        private ComboBox comboBoxDay2;
        private DateTimePicker dateTimePicker2;
        private TextBox textBoxTask2;
    }
}