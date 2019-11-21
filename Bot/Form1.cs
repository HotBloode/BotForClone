﻿using System;
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
        public int idChnge;
        public Form1()
        {
            InitializeComponent();
            //Список с боксов с картинками
            newForm.mainForm = this;            
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
        //Списки персов
        public List<RedCharacter> redList;
        public List<GoldCharacter> goldList;
        public List<PinkCharacter> pinkList;
        public List<BlueCharacter> blueList;


        //Подгружаем базу
        private void Form1_Load(object sender, EventArgs e)
        {
            
            if (!File.Exists("baseRed.json") || !File.Exists("baseBlue.json") || !File.Exists("baseGold.json") || !File.Exists("basePink.json"))
            {
                MessageBox.Show("Один из файлов базы не найден!");
            }
            else
            {
                redList = JsonConvert.DeserializeObject<List<RedCharacter>>(File.ReadAllText("baseRed.json"));
                blueList = JsonConvert.DeserializeObject<List<BlueCharacter>>(File.ReadAllText("baseBlue.json"));
                goldList = JsonConvert.DeserializeObject<List<GoldCharacter>>(File.ReadAllText("baseGold.json"));
                pinkList = JsonConvert.DeserializeObject<List<PinkCharacter>>(File.ReadAllText("basePink.json"));
            }
        }

        //Выгружаем
        private void buttonDes_Click(object sender, EventArgs e)
        {
            File.WriteAllText("baseBlue.json", JsonConvert.SerializeObject(blueList, Formatting.Indented));
            File.WriteAllText("basePink.json", JsonConvert.SerializeObject(pinkList, Formatting.Indented));
            File.WriteAllText("baseGold.json", JsonConvert.SerializeObject(goldList, Formatting.Indented));
            File.WriteAllText("baseRed.json", JsonConvert.SerializeObject(redList, Formatting.Indented));
        }

        private void labelElement_Click(object sender, EventArgs e)
        {
            
        }

        //Проверяем существование картнки
        private bool ChekImg(PictureBox pic, TextBox text)
        {            
            try
            {
                pic.Image = null;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Load("img\\" + text.Text);
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
            ChekImg(pictureBox1, textUrl);
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {            
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        //Взаимоисключающие чекБоксы
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
            if( checkBox4.Checked == true && textBox1.Text=="" ||
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


        //Открываем 2ю форму со списком персов
        private void pictureBoxChek(object sender, EventArgs e)
        {
            //Шлём 2ой рабочий бокс
            newForm.pictureBox = sender as PictureBox;
            newForm.SelectChamp();          
        }

        #region addToList
        void AddSearch(BaseCharacter character)
        {
            if (checkBoxShop1.Checked == true)
            {
                character.Search.Add("1");
            }
            else
            {
                character.Search.Add(null);
            }

            if (checkBox1.Checked == true)
            {
                character.Search.Add("1");
            }
            else
            {
                character.Search.Add(null);
            }

            if (checkBox2.Checked == true)
            {
                character.Search.Add("1");
            }
            else
            {
                character.Search.Add(null);
            }

            if (checkBox4.Checked == true)
            {
                character.Search.Add(textBox1.Text);
            }
            else
            {
                character.Search.Add(null);
            }

            if (checkBox5.Checked == true)
            {
                character.Search.Add(textBox2.Text);
            }
            else
            {
                character.Search.Add(null);
            }

            if (checkBox6.Checked == true)
            {
                character.Search.Add(textBox3.Text);
            }
            else
            {
                character.Search.Add(null);
            }

            if (checkBox7.Checked == true)
            {
                character.Search.Add(textBox4.Text);
            }
            else
            {
                character.Search.Add(null);
            }
        }

        //Избыточно, но работает. Позже заюзать апкаст или шаблон
        private void AddBlueToList()
        {            
                BlueCharacter tmpBlue = new BlueCharacter();

                tmpBlue.Name = textBoxName.Text;
                tmpBlue.ImgUrl = "img\\" + textUrl.Text;
                tmpBlue.Count = Convert.ToInt32(textCount.Text);
                tmpBlue.Element = comboElement.SelectedIndex;
                tmpBlue.Id = blueList.Count;

            AddSearch(tmpBlue);
            
            blueList.Add(tmpBlue);
        }
        private void AddGoldToList()
        {
            GoldCharacter tmpGold = new GoldCharacter();
            tmpGold.Name = textBoxName.Text;
            tmpGold.ImgUrl = "img\\" + textUrl.Text;
            tmpGold.Count = Convert.ToInt32(textCount.Text);
            tmpGold.Element = comboElement.SelectedIndex;
            tmpGold.Id = blueList.Count;

            AddSearch(tmpGold);

            tmpGold.SсhemeCraft[0] = Convert.ToInt32(pic1.Name);
            tmpGold.SсhemeCraft[1] = Convert.ToInt32(pic2.Name);
            tmpGold.SсhemeCraft[2] = Convert.ToInt32(pic3.Name);
            tmpGold.SсhemeCraft[3] = Convert.ToInt32(pic4.Name);
            tmpGold.SсhemeCraft[4] = Convert.ToInt32(pic5.Name);
            tmpGold.SсhemeCraft[5] = Convert.ToInt32(pic6.Name);
            tmpGold.SсhemeCraft[6] = Convert.ToInt32(pic7.Name);

            goldList.Add(tmpGold);

        }
        private void AddPinkToList()
        {
            PinkCharacter tmpPink = new PinkCharacter();
            tmpPink.Name = textBoxName.Text;
            tmpPink.ImgUrl = "img\\" + textUrl.Text;
            tmpPink.Count = Convert.ToInt32(textCount.Text);
            tmpPink.Element = comboElement.SelectedIndex;
            tmpPink.Id = blueList.Count ;

            AddSearch(tmpPink);

            tmpPink.SсhemeCraft[0] = Convert.ToInt32(pic1.Name);
            tmpPink.SсhemeCraft[1] = Convert.ToInt32(pic2.Name);
            tmpPink.SсhemeCraft[2] = Convert.ToInt32(pic3.Name);
            tmpPink.SсhemeCraft[3] = Convert.ToInt32(pic4.Name);
            tmpPink.SсhemeCraft[4] = Convert.ToInt32(pic5.Name);

            pinkList.Add(tmpPink);

        }
        private void AddRedToList()
        {
            RedCharacter tmpRed = new RedCharacter();
            tmpRed.Name = textBoxName.Text;
            tmpRed.ImgUrl = "img\\" + textUrl.Text;
            tmpRed.Count = Convert.ToInt32(textCount.Text);
            tmpRed.Element = comboElement.SelectedIndex;
            tmpRed.Id = blueList.Count;

            AddSearch(tmpRed);

            tmpRed.SсhemeCraft[0] = Convert.ToInt32(pic1.Name);
            tmpRed.SсhemeCraft[1] = Convert.ToInt32(pic2.Name);
            tmpRed.SсhemeCraft[2] = Convert.ToInt32(pic3.Name);
            tmpRed.SсhemeCraft[3] = Convert.ToInt32(pic4.Name);
            tmpRed.SсhemeCraft[4] = Convert.ToInt32(pic5.Name);
            redList.Add(tmpRed);

        }

        #endregion addToList

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
                if(!ChekImg(pictureBox1, textUrl))
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
                                            AddGoldToList();
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
                                            if (comboBoxColor.SelectedIndex == 0)
                                            {
                                                AddRedToList();
                                            }
                                            else
                                            {
                                                AddPinkToList();
                                            }
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

        //Выбираем картинку из папки, обрезаем ее адрес, пихаем в бокс и отображаем
        private void button2_Click(object sender, EventArgs e)
        {
            ImgButChek(pictureBox1, textUrl);
        }

        void ImgButChek(PictureBox pic, TextBox text)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            open_dialog.InitialDirectory = "img\\";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    text.Text = Path.GetFileName(open_dialog.FileName);
                    ChekImg(pic, text);
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
        private void EditPanel<T>(FlowLayoutPanel panel, List<T> list) where T:BaseCharacter
        {
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
                pb.Click += new System.EventHandler(BaseClickPb);
                //if ()
                //{

                //}
                //else if ()
                //{

                //}
                //else if ()
                //{

                //}
                //else if()
                //{

                //}

                //Создаём новое событие для нажатия
                //pb.Click += new System.EventHandler(ClickPb);
                //Добавляем Pb на панель
                panel.Controls.Add(pb);
                //Добавляем Pb в список
                //pictureboxList.Add(pb);
            }
        }

        //Событие для отображения всех видов персонажей
        private void BaseClickPb(object sender, EventArgs e)
        {
            ClearEditPanel();
            PictureBox pb = sender as PictureBox;
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            //Отображаем картинку перса           
            pictureBox9.Image = pb.Image;
            int idChange = Convert.ToInt32(pb.Name);
            

            BaseCharacter curenChemp = null;           

            if (tabControl2.SelectedIndex == 0)
            {
                curenChemp = blueList[idChange];
            }
            else if (tabControl2.SelectedIndex == 1)
            {
                curenChemp = pinkList[idChange];
            }
            else if (tabControl2.SelectedIndex == 2)
            {
                curenChemp = goldList[idChange];
            }
            else if (tabControl2.SelectedIndex == 3)
            {
                curenChemp = redList[idChange];
            }

            //Отображение: Имя, колличество, ссылка на файл, стихии и качества
            textBox11.Text = curenChemp.Name;
            textBox10.Text = Convert.ToString(curenChemp.Count);
            textBox9.Text = Path.GetFileName(curenChemp.ImgUrl);
            comboBox2.SelectedIndex = curenChemp.Element;
            comboBox1.SelectedIndex = 3 - tabControl2.SelectedIndex;

            if (curenChemp.Search[0]!=null)
            {                
                checkBox15.Checked = true;
            }
            if (curenChemp.Search[1]!= null)
            {
                checkBox14.Checked = true;
            }
            if (curenChemp.Search[2] != null)
            {
                checkBox13.Checked = true;
            }
            //Если в поисковом списке есть поиск хотя бы в 1 уровне кампании, то активировать чек бокс кампании
            if(curenChemp.Search[3]!=null|| curenChemp.Search[4] != null || curenChemp.Search[5] != null || curenChemp.Search[6] != null)
            {
                checkBox12.Checked = Enabled;
            }

            if (curenChemp.Search[3] != null)
            {
                textBox8.Text = curenChemp.Search[3].Trim();
                checkBox11.Checked = Enabled;
                textBox8.Enabled = true;
            }
            if (curenChemp.Search[4] != null)
            {
                textBox7.Text = curenChemp.Search[4].Trim();
                checkBox10.Checked = Enabled;
                textBox7.Enabled = true;
            }
            if (curenChemp.Search[5] != null)
            {
                textBox6.Text = curenChemp.Search[5].Trim();
                checkBox9.Checked = Enabled;
                textBox6.Enabled = true;
            }
            if (curenChemp.Search[6] != null)
            {
                textBox5.Text = curenChemp.Search[6].Trim();
                checkBox8.Checked = Enabled;
                textBox5.Enabled = true;
            }            
        }



        void ClearEditPanel()
        {
            //Чистим базовые элементы
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            pictureBox9.Image = null;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;

            //Чистим чек боксы
            checkBox15.Checked = false;
            checkBox14.Checked = false;
            checkBox13.Checked = false;
            checkBox12.Checked = false;
            checkBox10.Checked = false;
            checkBox9.Checked = false;
            checkBox8.Checked = false;

            //Чистим текст боксы
            textBox8.Text = null;
            textBox7.Text = null;
            textBox6.Text = null;
            textBox5.Text = null;

        }

        //Очистка панелей отображающих списки и очитка полей с данніми о персе
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((TabControl)sender).SelectedIndex;
            if(index ==0)
            {
                flowLayoutPanel1.Controls.Clear();
                EditPanel(flowLayoutPanel1, blueList);
            }
            else if(index ==1)
            {
                flowLayoutPanel2.Controls.Clear();
                EditPanel(flowLayoutPanel2, pinkList);
            }
            else if (index == 2)
            {
                flowLayoutPanel3.Controls.Clear();
                EditPanel(flowLayoutPanel3, goldList);
            }
            else if (index == 3)
            {
                flowLayoutPanel4.Controls.Clear();
                EditPanel(flowLayoutPanel4, redList);
            }

            ClearEditPanel();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((TabControl)sender).SelectedIndex;
            if (index == 1)
            {
                flowLayoutPanel1.Controls.Clear();
                EditPanel(flowLayoutPanel1, blueList);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        //Выбор картинки через диалог, подгрузка имени файла и проверка картинки
        private void button2_Click_1(object sender, EventArgs e)
        {
            ImgButChek(pictureBox9, textBox9);
        }

        //Поверка наличия картинки по url
        private void button4_Click(object sender, EventArgs e)
        {
            ChekImg(pictureBox9, textBox9);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        #region checkBoxes EditPanel
        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            checkBox11.Enabled = checkBox12.Checked;
            checkBox10.Enabled = checkBox12.Checked;
            checkBox9.Enabled = checkBox12.Checked;
            checkBox8.Enabled = checkBox12.Checked;

            checkBox11.Checked = false;
            checkBox10.Checked = false;
            checkBox9.Checked = false;
            checkBox8.Checked = false;

            textBox8.Enabled = false;
            textBox7.Enabled = false;
            textBox6.Enabled = false;
            textBox5.Enabled = false;

            textBox8.Text = null;
            textBox7.Text = null;
            textBox6.Text = null;
            textBox5.Text = null;
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {            
            textBox8.Enabled = checkBox11.Checked;
        }

        private void checkBox10_CheckStateChanged(object sender, EventArgs e)
        {
            textBox7.Enabled = checkBox10.Checked;
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            textBox6.Enabled = checkBox9.Checked; 
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = checkBox8.Checked;
        }
        #endregion checkBoxes EditPanel
    }
}
