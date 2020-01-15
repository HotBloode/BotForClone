using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Bot
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }
        //Переменная с сылкой на перфую форму
        public Form1 mainForm;
        
        //Ссылка на pb на первой форме
        public PictureBox pictureBox = new PictureBox();

        private void Form2_Load(object sender, EventArgs e)
        {
        }
        public void SelectChamp()
        {
            List<BaseCharacter> list = new List<BaseCharacter>();
            //Выбираем список из первой формы с которым будем работать(зависит от комбоБокса)
            int index;
            if(mainForm.tabControl1.SelectedIndex == 0)
            {
                index = mainForm.comboBoxColor.SelectedIndex;
            }
            else
            {
                index = 3 - mainForm.tabControl2.SelectedIndex;
            }
           
                if (index == 2)
                {
                    //Розовые    
                    if (mainForm.blueList == null)
                    {
                        MessageBox.Show("Список синих персонажей пуст");
                        return;
                    }
                    list = mainForm.blueList.Select(x => (BaseCharacter)x).ToList();
                }
                else if (index == 1)
                {
                    //Золотые
                    if (mainForm.pinkList == null)
                    {
                        MessageBox.Show("Список розовых персонажей пуст");
                        return;
                    }
                    list = mainForm.pinkList.Select(x => (BaseCharacter)x).ToList();
                }
                else if (index == 0)
                {
                    //Красные
                    if (mainForm.goldList == null)
                    {
                        MessageBox.Show("Список золотых персонажей пуст");
                        return;
                    }
                    list = mainForm.goldList.Select(x => (BaseCharacter)x).ToList();
                }
            #region Только отображение
            List<PictureBox> pictureboxList = new List<PictureBox>();
            int y = 0;
            foreach (var file in list)
            {
                var pb = new PictureBox();

                pb.Location = new Point(pictureboxList.Count * 120 + 20, y);
                pb.Size = new Size(55, 75);
                try
                {
                    pb.Image = Image.FromFile(file.ImgUrl);
                    pb.Name = file.Id.ToString();
                }
                catch (OutOfMemoryException) { continue; }
                pb.SizeMode = PictureBoxSizeMode.StretchImage;

                //Создаём новое событие для нажатия
                pb.Click += new System.EventHandler(ClickPb);
                //Добавляем Pb на панель
                if (file.Element == 0)
                {
                    flowLayoutPanel1.Controls.Add(pb);
                }
                else if(file.Element == 1)
                {
                    flowLayoutPanel2.Controls.Add(pb);
                }
                else if (file.Element == 2)
                {
                    flowLayoutPanel3.Controls.Add(pb);
                }
                else
                {
                    flowLayoutPanel4.Controls.Add(pb);
                }
                //Добавляем Pb в список
                //pictureboxList.Add(pb);
            }
            Show();
            #endregion
        }

        private void ClickPb(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            //pictureBox = pb;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Name = pb.Name;
            pictureBox.Image = pb.Image;

            
            this.Hide();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel3.Controls.Clear();
            flowLayoutPanel4.Controls.Clear();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }       

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
           
        }
    }
}
