using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace lab_12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<string> cities = new List<string>
            {
                "Київ", "Харків", "Донецьк", "Львів"
            };

            domainUpDown1.Items.AddRange(cities);

            timer1.Interval = 3000;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            label1.Text = progressBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файли зображень|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Всі файли|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = "file.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(textBox1.Text);
                }

                MessageBox.Show("Файл збережено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при збереженні файлу: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePath = "file.txt";
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string content = reader.ReadToEnd();
                    textBox1.Text = content;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при відкритті файлу: " + ex.Message);
            }
        }

        private void domainUpDown1_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show(domainUpDown1.Text);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = String.Format("Значення: {0}", trackBar1.Value);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            MessageBox.Show(String.Format(e.Start.ToLongDateString()));
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime a = new DateTime();
            a = dateTimePicker1.Value;
            MessageBox.Show(a.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}