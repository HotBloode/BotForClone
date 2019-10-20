using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;



namespace Bot
{
    public partial class Form1 : Form
    {
        //Создаём форму для выбора перса    
        private Form2 newForm = new Form2();
        public List<PictureBox> picCraft = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
            newForm.mainForm = this;
            //picCraft = new List<PictureBox>(pic1, pic2, pic3, pic4, pic5, pic6, pic7);
            picCraft.Add(pic1);
            picCraft.Add(pic2);
            picCraft.Add(pic3);
            picCraft.Add(pic4);
            picCraft.Add(pic5);
            picCraft.Add(pic6);
            picCraft.Add(pic7);
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }
        public List<RedCharacter> redList;
        public List<GoldCharacter> goldList;
        public List<PinkCharacter> pinkList;
        public List<BlueCharacter> blueList;
        //pic1, pic2, pic3, pic4, pic5, pic6, pic7
        
      
        private void Form1_Load(object sender, EventArgs e)
        {
            //BlueCharacter a = new BlueCharacter();
            //a.Name = "Любой Вода";
            //a.Count = 5;
            //a.Id = 0;
            //a.ImgUrl = "img\\1b.jpg";
            //a.Element = 3;
            //a.Search.Add("Любой Вода");

            //BlueCharacter b = new BlueCharacter();
            //b.Name = "Любой Свет";
            //b.Count = 5;
            //b.Id = 1;
            //b.ImgUrl = "img\\2b.jpg";
            //b.Element = 3;
            //b.Search.Add("Любой Свет");

            //List<BlueCharacter> list = new List<BlueCharacter>() { a, b };
            //File.WriteAllText("baseBlue.json", JsonConvert.SerializeObject(list));
            //RedCharacter a = new RedCharacter();
            //a.Count = 5;
            //a.Name = "First";
            //a.Id = 1;
            //a.ImgUrl = "img\\1.jpg";
            //a.Element = 0;

            //RedCharacter b = new RedCharacter();
            //b.Count = 16;
            //b.Name = "Second";
            //b.Id = 2;
            //b.ImgUrl = "img\\2.jpg";
            //b.Element = 1;

            //List<RedCharacter> list = new List<RedCharacter>() { a, b };
            //File.WriteAllText("123.json", JsonConvert.SerializeObject(list));

            if (!File.Exists("123.json"))
            {
                MessageBox.Show("Файл базы не найден!");
            }
            else
            {            
                redList = JsonConvert.DeserializeObject<List<RedCharacter>>(File.ReadAllText("123.json"));   
                blueList = JsonConvert.DeserializeObject<List<BlueCharacter>>(File.ReadAllText("baseBlue.json"));
            }     
        }

        private void buttonDes_Click(object sender, EventArgs e)
        {
            File.WriteAllText("123.json", JsonConvert.SerializeObject(redList));
        }

        private void labelElement_Click(object sender, EventArgs e)
        {
            
        }

        private bool ChekImg()
        {
            try
            {
                pictureBox1.Image = null;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load("img\\" + textUrl.Text);
                return true;
            }
            catch
            {
                pictureBox1.Image = null;
                MessageBox.Show("Проверьте имя картинки или путь по которому она лежит!");
                return false;
            }
        }

        private void buttonChekImg_Click(object sender, EventArgs e)
        {
            ChekImg();
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {            
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {           
            checkBox4.Enabled = checkBox3.Checked;            
            checkBox5.Enabled = checkBox3.Checked;           
            checkBox6.Enabled = checkBox3.Checked;            
            checkBox7.Enabled = checkBox3.Checked;            

            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;

            textBox1.Enabled = false;           
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Enabled = checkBox4.Checked;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.Enabled = checkBox5.Checked;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.Enabled = checkBox6.Checked;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox4.Enabled = checkBox7.Checked;
        }

        //Проверка активности чекБоксов и заполнености текстБоксов
        private bool checkedBox()
        {
            if( checkBox1.Checked == true && textBox1.Text=="" ||
                checkBox5.Checked == true && textBox2.Text == "" ||
                checkBox6.Checked == true && textBox3.Text == "" ||
                checkBox7.Checked == true && textBox4.Text == "")
            {
                MessageBox.Show("Введите уровень кампании или уберите флаг");
                return false;
            }
            return true;            
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //private BaseCharacter SelectChar(List<BaseCharacter> list, PictureBox imj)
        //{
        //    BaseCharacter a = (BaseCharacter)from t in list where t.Id == Convert.ToInt32(imj.Name) select t;  
        //    return a;
        //}


        //Открываем 2ю форму со списков персов
        private void pictureBoxChek(object sender, EventArgs e)
        {
            //Шлём 2ой рабочий бокс
            newForm.pictureBox = sender as PictureBox;
            newForm.SelectChamp();          
        }

        private void AddBlueToList()
        {            
                BlueCharacter tmpBlue = new BlueCharacter();

                tmpBlue.Name = textBoxName.Text;
                tmpBlue.ImgUrl = "img\\" + textUrl.Text;
                tmpBlue.Count = Convert.ToInt32(textCount.Text);
                tmpBlue.Element = comboElement.SelectedIndex;
                tmpBlue.Id = blueList.Count + 1;

                if(checkBoxShop1.Checked==true)
                {
                    tmpBlue.Search.Add("Магазин арены");
                }
                if(checkBox1.Checked == true)
                {
                    tmpBlue.Search.Add("Магазин таверны");
                }
                if (checkBox2.Checked == true)
                {
                    tmpBlue.Search.Add("Магазин экспедиции: ");
                }                
                if (checkBox4.Checked == true)
                {
                    tmpBlue.Search.Add("Кампания общий: "+textBox1.Text);
                }
                if (checkBox5.Checked == true)
                {
                    tmpBlue.Search.Add("Кампания элитный: " + textBox2.Text);
                }
                if (checkBox6.Checked == true)
                {
                    tmpBlue.Search.Add("Кампания легендарный: " + textBox3.Text);
                }
                if (checkBox7.Checked == true)
                {
                    tmpBlue.Search.Add("Кампания эпический: "+textBox4.Text);   
                }
        }
        private void AddGoldToList()
        {
            GoldCharacter tmpGold = new GoldCharacter();
            tmpGold.Name = textBoxName.Text;
            tmpGold.ImgUrl = "img\\" + textUrl.Text;
            tmpGold.Count = Convert.ToInt32(textCount.Text);
            tmpGold.Element = comboElement.SelectedIndex;
            tmpGold.Id = blueList.Count + 1;

            if (checkBoxShop1.Checked == true)
            {
                tmpGold.Search.Add("Магазин арены");
            }
            if (checkBox1.Checked == true)
            {
                tmpGold.Search.Add("Магазин таверны");
            }
            if (checkBox2.Checked == true)
            {
                tmpGold.Search.Add("Магазин экспедиции: ");
            }
            if (checkBox4.Checked == true)
            {
                tmpGold.Search.Add("Кампания общий: " + textBox1.Text);
            }
            if (checkBox5.Checked == true)
            {
                tmpGold.Search.Add("Кампания элитный: " + textBox2.Text);
            }
            if (checkBox6.Checked == true)
            {
                tmpGold.Search.Add("Кампания легендарный: " + textBox3.Text);
            }
            if (checkBox7.Checked == true)
            {
                tmpGold.Search.Add("Кампания эпический: " + textBox4.Text);
            }

            tmpGold.SсhemeCraft[0] = Convert.ToInt32(pic1.Name);
            tmpGold.SсhemeCraft[1] = Convert.ToInt32(pic2.Name);
            tmpGold.SсhemeCraft[2] = Convert.ToInt32(pic3.Name);
            tmpGold.SсhemeCraft[3] = Convert.ToInt32(pic4.Name);
            tmpGold.SсhemeCraft[4] = Convert.ToInt32(pic5.Name);
            tmpGold.SсhemeCraft[5] = Convert.ToInt32(pic6.Name);
            tmpGold.SсhemeCraft[6] = Convert.ToInt32(pic7.Name);




        }
      
        public void ClearPb()
        {
            foreach(PictureBox tmp in picCraft)
            {
                tmp.Image = null;
            }
        }

        //Поработаем с окошками списка крафта, ёптить
        public void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if(comboBoxColor.SelectedIndex==3)
            {
                //Синие персы
                panel.Visible = false;
               
            }            
            else if (comboBoxColor.SelectedIndex == 2)
            {
                panel.Visible = true;               
                //Розовые
            }
            else if (comboBoxColor.SelectedIndex == 1)
            {
                panel.Visible = true;
               
                //Золотые

            }
            else if (comboBoxColor.SelectedIndex == 0)
            {
                panel.Visible = true;
                
                //Красные
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(textBoxName.Text == "")
            {
                MessageBox.Show("Введите Имя");
            }
            else
            {
                if(!ChekImg())
                {
                    //МСБ с ошибкой
                }
                else
                {
                    if(textCount.Text == "")
                    {
                        MessageBox.Show("Введите колличество");
                    }
                    else
                    {
                        if(comboElement.SelectedIndex<0)
                        {
                            
                            MessageBox.Show("Выбирите стихию");
                        }
                        else
                        {
                            if(comboBoxColor.SelectedIndex < 0)
                            {
                                MessageBox.Show("Выбирите качество");
                            }
                            else
                            {
                               if(comboBoxColor.SelectedIndex == 1)
                                {
                                    if(pic1==null|| pic2 == null || pic3 == null || pic4 == null || pic5 == null || pic6 == null || pic7 == null)
                                    {
                                        MessageBox.Show("Выберите всех персонажей для крафта");
                                    }
                                    else
                                    {
                                        if(!checkedBox())
                                        {
                                            //МСБ с ошибкой
                                        }
                                        else
                                        {

                                        }                                        
                                    }
                                }
                               else if(comboBoxColor.SelectedIndex==0|| comboBoxColor.SelectedIndex == 2)
                                {
                                    if (pic1.Image == null || pic2 == null || pic3 == null || pic4 == null || pic5 == null)
                                    {
                                        MessageBox.Show("Выберите всех персонажей для крафта");
                                    }
                                    else
                                    {
                                        if (!checkedBox())
                                        {
                                            //МСБ с ошибкой
                                        }
                                        else
                                        {
                                            
                                        }
                                    }
                                }
                                else
                                {
                                    if (!checkedBox())
                                    {
                                        //МСБ с ошибкой
                                    }
                                    else
                                    {
                                        AddBlueToList();
                                    }
                                }

                            }
                        }
                    }
                    
                }
            }      
        }

        private void comboBoxColor_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearPb();
        }
    }
}
