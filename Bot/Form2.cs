using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                if (mainForm.comboBoxColor.SelectedIndex == 2)
                {
                //Розовые    
                if (mainForm.blueList==null)
                {                    
                    MessageBox.Show("Список синих персонажей пуст");                   
                    return;
                }
                list = mainForm.blueList.Select(x => (BaseCharacter)x).ToList();               
                }
                else if (mainForm.comboBoxColor.SelectedIndex == 1)
                {
                //Золотые
                if (mainForm.pinkList == null)
                {                    
                    MessageBox.Show("Список розовых персонажей пуст");                   
                    return;
                }
                list = mainForm.pinkList.Select(x => (BaseCharacter)x).ToList();
                }
                else if (mainForm.comboBoxColor.SelectedIndex == 0)
                {
                //Красные
                if (mainForm.goldList == null)
                {                    
                    MessageBox.Show("Список золотых персонажей пуст");
                    return;
                }
                list = mainForm.goldList.Select(x => (BaseCharacter)x).ToList();
                }

                List<PictureBox> pictureboxList = new List<PictureBox>();
                int y = 10;
                foreach (var file in list)
                {
                    var pb = new PictureBox();

                    pb.Location = new Point(pictureboxList.Count * 120 + 20, y);
                    pb.Size = new Size(65, 75);
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
                    flowLayoutPanel1.Controls.Add(pb);
                    //Добавляем Pb в список
                    pictureboxList.Add(pb);
                }
            Show();
        }
        private void ClickPb(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            //pictureBox = pb;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Name = pb.Name;
            pictureBox.Image = pb.Image;
            flowLayoutPanel1.Controls.Clear();
            this.Hide();
            //MessageBox.Show(pb.Name);
        }
    }
}
