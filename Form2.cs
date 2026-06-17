using System;
using System.Windows.Forms;

namespace HomeworkApp
{
    public partial class Form2 : Form
    {
        public string Subject { get; set; }

        public string Task1 { get; set; }
        public DayOfWeek Day1 { get; set; }
        public TimeSpan Time1 { get; set; }

        public string Task2 { get; set; }
        public DayOfWeek Day2 { get; set; }
        public TimeSpan Time2 { get; set; }


        public bool Task1Completed { get; set; } = false;
        public bool Task2Completed { get; set; } = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Subject = textBoxSubject.Text;

            Task1 = textBoxTask1.Text;
            Time1 = dateTimePicker1.Value.TimeOfDay;
            Day1 = (DayOfWeek)comboBoxDay1.SelectedIndex;

            Task2 = textBoxTask2.Text;
            Time2 = dateTimePicker2.Value.TimeOfDay;
            Day2 = (DayOfWeek)comboBoxDay2.SelectedIndex;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}