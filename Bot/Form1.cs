﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;



namespace Bot
{
    public partial class Form1 : Form
    {
        public Craft craft;

         //Создаём форму для выбора перса    
         private Form2 newForm = new Form2();

         private Form3 Form3 = new Form3();

        Information info =  new Information();
        //Список отображаемых PictureBox ов на окне крафта
        public List<PictureBox> picCraft = new List<PictureBox>();

        //Список отображаемых PictureBox ов на окне редактирования
        public List<PictureBox> picEdit = new List<PictureBox>();

        //id перса (берётся из имени картинки)
        public int idChange;

        //Флаг отсутствия рецепта для РОзовых персов
        public bool flagNotResept = false;

        public FAQ_controler faq =  new FAQ_controler();

        //Списки персов
        public List<RedCharacter> redList;
        public List<GoldCharacter> goldList;
        public List<PinkCharacter> pinkList;
        public List<BlueCharacter> blueList;

        public List<Label> listLabel = new List<Label>();
        public Form1()
        {
            InitializeComponent();
            
            //Ссылка на эту форму (ссылка нужна для второй формы)
            newForm.mainForm = this;
            Form3.mainForm = this;

            //Список с боксов с картинками для окна создания
            picCraft.Add(pic1);
            picCraft.Add(pic2);
            picCraft.Add(pic3);
            picCraft.Add(pic4);
            picCraft.Add(pic5);
            picCraft.Add(pic6);
            picCraft.Add(pic7);

            //Список с боксов с картинками для окна редактирования
            picEdit.Add(pic11);
            picEdit.Add(pic22);
            picEdit.Add(pic33);
            picEdit.Add(pic44);
            picEdit.Add(pic55);
            picEdit.Add(pic66);
            picEdit.Add(pic77);

            listLabel.Add(label97);
            listLabel.Add(label98);
            listLabel.Add(label99);
            listLabel.Add(label105);
            listLabel.Add(label102);
            listLabel.Add(label106);
            listLabel.Add(label100);
            listLabel.Add(label104);
            listLabel.Add(label101);
            listLabel.Add(label103);
        }

        //Чистим окно крафта
        void ClearCraftPanel()
        {
            textBoxName.Clear();
            textUrl.Clear();
            textCount.Clear();
            comboElement.SelectedIndex = -1;
            comboBoxColor.SelectedIndex = -1;
            checkBoxShop1.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            pictureBox1.Image = null;

            label29.Visible = false;
            panel.Visible = false;

            //Чистим боксы с картинками для окна крафта
            foreach (PictureBox pb in picCraft)
            {
                pb.Image = null;
            }
        }

        //Функция которая отображает информацию о колличестве персов. Херачим их в "Наклейки"
        private void CounyInfo()
        {
            label21.Text = "Синие: " + (blueList.Count - 7);
            label23.Text = "Розовые: " + (pinkList.Count-6);
            label24.Text = "Золотые: " + (goldList.Count-1);
            label25.Text = "Красные: " + redList.Count;
        }

        //Функция проверки существование картнки
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

        //Функция проверки активности чекБоксов и заполнености текстБоксов
        private bool checkedBox()
        {
            if (checkBox4.Checked == true && textBox1.Text == "" ||
                checkBox5.Checked == true && textBox2.Text == "" ||
                checkBox6.Checked == true && textBox3.Text == "" ||
                checkBox7.Checked == true && textBox4.Text == "")
            {
                MessageBox.Show("Введите уровень кампании или уберите флаг");
                return false;
            }
            return true;
        }
        
        //Функция открытия 2й формы со списком персов
        private void pictureBoxChek(object sender, EventArgs e)
        {
            //Шлём 2ой форме рабочий Пикчербокс
            newForm.pictureBox = sender as PictureBox;
            //вызываем функцию выбора перса
            newForm.SelectChamp();
        }

        //Функции добавления в список
        #region 
        //Функция добавления в список данных о поиске песронажа (В окне крафта)
        List<string> AddSearch()
        {
            List<string> seatch = new List<string>();

            if (checkBox18.Checked == true)
            {
                seatch.Add("1");
            }
            else
            {
                seatch.Add(null);
            }

            if (checkBoxShop1.Checked == true)
            {
                seatch.Add("1");
            }
            else
            {
                seatch.Add(null);
            }

            if (checkBox1.Checked == true)
            {
                seatch.Add("1");
            }
            else
            {
                seatch.Add(null);
            }

            if (checkBox2.Checked == true)
            {
                seatch.Add("1");
            }
            else
            {
                seatch.Add(null);
            }

            if (checkBox4.Checked == true)
            {
                seatch.Add(textBox1.Text);
            }
            else
            {
                seatch.Add(null);
            }

            if (checkBox5.Checked == true)
            {
                seatch.Add(textBox2.Text);
            }
            else
            {
                seatch.Add(null);
            }

            if (checkBox6.Checked == true)
            {
                seatch.Add(textBox3.Text);
            }
            else
            {
                seatch.Add(null);
            }

            if (checkBox7.Checked == true)
            {
                seatch.Add(textBox4.Text);
            }
            else
            {
                seatch.Add(null);
            }
            return seatch;
        }

        //Функция добавления в список данных о поиске песронажа (В окне редактирования)
        List<string> AddEditSearch()
        {
            List<string> seatch = new List<string>();
            if (checkBox17.Checked == true)
            {
                seatch.Add("1");
            }
            else
            {
                seatch.Add(null);
            }

            if (checkBox15.Checked == true)
            {
                seatch.Add("1");
            }
            else
            {
                seatch.Add(null);
            }

            if (checkBox14.Checked == true)
            {
                seatch.Add("1");
            }
            else
            {
                seatch.Add(null);
            }

            if (checkBox13.Checked == true)
            {
                seatch.Add("1");
            }
            else
            {
                seatch.Add(null);
            }

            if (checkBox11.Checked == true)
            {
                seatch.Add(textBox8.Text);
            }
            else
            {
                seatch.Add(null);
            }

            if (checkBox10.Checked == true)
            {
                seatch.Add(textBox7.Text);
            }
            else
            {
                seatch.Add(null);
            }

            if (checkBox9.Checked == true)
            {
                seatch.Add(textBox6.Text);
            }
            else
            {
                seatch.Add(null);
            }

            if (checkBox8.Checked == true)
            {
                seatch.Add(textBox5.Text);
            }
            else
            {
                seatch.Add(null);
            }
            return seatch;
        }


        //Посдчёт сложности поиска/крафта персов
        private void FDifficulty(BlueCharacter x)
        {
            if (x.Search[4] != null || x.Search[5] != null || x.Search[6] != null || x.Search[7] != null)
            {
                x.TotalDifficulty = 1;
            }
            else if (x.Search[1] != null || x.Search[2] != null || x.Search[3] != null)
            {
                x.TotalDifficulty = 2;
            }
            else if (x.Search[0] != null)
            {
                x.TotalDifficulty = 3;
            }
            else
            {
                x.TotalDifficulty = 4;
            }
        }

        private void FDifficulty(PinkCharacter x)
        { 
                    if (x.Search[4] != null || x.Search[5] != null || x.Search[6] != null || x.Search[7] != null)
                    {
                        x.TotalDifficulty = 1;
                    }
                    else if (x.Search[1] != null || x.Search[2] != null || x.Search[3] != null)
                    {
                        x.TotalDifficulty = 2;
                    }
                    else if (x.Search[0] != null)
                    {
                        x.TotalDifficulty = 3;
                    }
                    else if (x.SсhemeCraft[0] != 9999999)
                    {
                        x.TotalDifficulty = 4;
                    }
                    else
                    {
                        x.TotalDifficulty = 5;
                    }

                    if (x.SсhemeCraft[0] != 9999999)
                    {
                        int tmp1 = 0;
                        for (int i = 0; i < x.SсhemeCraft.Length; i++)
                        {
                            if (x.SсhemeCraft[i] == 0 || x.SсhemeCraft[i] == 1 || x.SсhemeCraft[i] == 2 || x.SсhemeCraft[i] == 3 || x.SсhemeCraft[i] == 4 || x.SсhemeCraft[i] == 5 || x.SсhemeCraft[i] == 6)
                            {

                            }
                            else
                            {
                                tmp1 += blueList[x.SсhemeCraft[i]].TotalDifficulty;
                            }
                        }
                        x.CraftDifficulty = tmp1;
                    }
                    else
                    {
                        x.CraftDifficulty = 9999999;
                    }                           
        }

        private void FDifficulty(GoldCharacter x)
        {
            if (x.Search[4] != null || x.Search[5] != null || x.Search[6] != null || x.Search[7] != null)
                            {
                                x.TotalDifficulty = 1;
                            }
                            else if (x.Search[1] != null || x.Search[2] != null || x.Search[3] != null)
                            {
                                x.TotalDifficulty = 2;
                            }
                            else if (x.Search[0] != null)
                            {
                                x.TotalDifficulty = 3;
                            }
                            else if (x.SсhemeCraft[0] != 9999999)
                            {
                                x.TotalDifficulty = 4;
                            }
                            else
                            {
                                x.TotalDifficulty = 5;
                            }
                        

                    if (x.SсhemeCraft[0] != 9999999)
                    {
                        int tmp1 = 0;
                        for (int i = 0; i < x.SсhemeCraft.Length; i++)
                        {
                            if (x.SсhemeCraft[i] == 0 || x.SсhemeCraft[i] == 1 || x.SсhemeCraft[i] == 2 || x.SсhemeCraft[i] == 3 || x.SсhemeCraft[i] == 4 || x.SсhemeCraft[i] == 5)
                            {

                            }
                            else
                            {
                                tmp1 += pinkList[x.SсhemeCraft[i]].TotalDifficulty;
                            }
                        }
                        x.CraftDifficulty = tmp1;
                    }
                    else
                    {
                        x.CraftDifficulty = 9999999;
                    }
                
        }

        private void FDifficulty(RedCharacter x)
        {
            x.TotalDifficulty = 5;
            int tmp1 = 0;
            for (int i = 0; i < x.SсhemeCraft.Length; i++)
            {
                if (x.SсhemeCraft[i] == 0)
                {
                }
                else
                {
                    tmp1 += goldList[x.SсhemeCraft[i]].TotalDifficulty;
                }
            }
            x.CraftDifficulty = tmp1;
        }

        //Пересчёт сложности сложности поиска/крафта для всех персов
        private void RecountDifficulty()
        {
            foreach(BlueCharacter x in blueList)
            {
                FDifficulty(x);
            }
            foreach (PinkCharacter x in pinkList)
            {
                FDifficulty(x);
            }
            foreach (GoldCharacter x in goldList)
            {
                FDifficulty(x);
            }
            foreach (RedCharacter x in redList)
            {
                FDifficulty(x);
            }
        }

        //Функции добавления нового персонажа в список
        //Избыточно, но работает. Позже заюзать апкаст или шаблон
        private void AddBlueToList()
        {
            //Создание нового экземпляра синего перса
            BlueCharacter tmpBlue = new BlueCharacter();
            //Заполнение имени перса
            tmpBlue.Name = textBoxName.Text;
            //Ссылка на картинку
            tmpBlue.ImgUrl = "img\\" + textUrl.Text;
            //Колличество
            tmpBlue.Count = Convert.ToInt32(textCount.Text);
            //Стихия
            tmpBlue.Element = comboElement.SelectedIndex;
            //Id
            tmpBlue.Id = blueList.Count;
            //Список поиска
            tmpBlue.Search = AddSearch();

            //Расчёт сложности поиска перса
            FDifficulty(tmpBlue);

            //Добавление в список
            blueList.Add(tmpBlue);
            //Обновлене информации
            CounyInfo();
        }
        private void AddGoldToList()
        {
            GoldCharacter tmpGold = new GoldCharacter();
            tmpGold.Name = textBoxName.Text;
            tmpGold.ImgUrl = "img\\" + textUrl.Text;
            tmpGold.Count = Convert.ToInt32(textCount.Text);
            tmpGold.Element = comboElement.SelectedIndex;
            tmpGold.Id = goldList.Count;

            tmpGold.Search = AddSearch();
            if (flagNotResept)
            {                
                tmpGold.SсhemeCraft[0] = 9999999;
                tmpGold.SсhemeCraft[1] = 9999999;
                tmpGold.SсhemeCraft[2] = 9999999;
                tmpGold.SсhemeCraft[3] = 9999999;
                tmpGold.SсhemeCraft[4] = 9999999;
                tmpGold.SсhemeCraft[5] = 9999999;
                tmpGold.SсhemeCraft[6] = 9999999;
            }
            else
            {
                tmpGold.SсhemeCraft[0] = Convert.ToInt32(pic1.Name);
                tmpGold.SсhemeCraft[1] = Convert.ToInt32(pic2.Name);
                tmpGold.SсhemeCraft[2] = Convert.ToInt32(pic3.Name);
                tmpGold.SсhemeCraft[3] = Convert.ToInt32(pic4.Name);
                tmpGold.SсhemeCraft[4] = Convert.ToInt32(pic5.Name);
                tmpGold.SсhemeCraft[5] = Convert.ToInt32(pic6.Name);
                tmpGold.SсhemeCraft[6] = Convert.ToInt32(pic7.Name);
            }

            FDifficulty(tmpGold);
            goldList.Add(tmpGold);
            CounyInfo();
        }
        private void AddPinkToList()
        {
            PinkCharacter tmpPink = new PinkCharacter();
            tmpPink.Name = textBoxName.Text;
            tmpPink.ImgUrl = "img\\" + textUrl.Text;
            tmpPink.Count = Convert.ToInt32(textCount.Text);
            tmpPink.Element = comboElement.SelectedIndex;
            tmpPink.Id = pinkList.Count;

            tmpPink.Search = AddSearch();

            if (flagNotResept)
            {
                tmpPink.SсhemeCraft[0] = 9999999;
                tmpPink.SсhemeCraft[1] = 9999999;
                tmpPink.SсhemeCraft[2] = 9999999;
                tmpPink.SсhemeCraft[3] = 9999999;
                tmpPink.SсhemeCraft[4] = 9999999;
            }
            else
            {
                tmpPink.SсhemeCraft[0] = Convert.ToInt32(pic1.Name);
                tmpPink.SсhemeCraft[1] = Convert.ToInt32(pic2.Name);
                tmpPink.SсhemeCraft[2] = Convert.ToInt32(pic3.Name);
                tmpPink.SсhemeCraft[3] = Convert.ToInt32(pic4.Name);
                tmpPink.SсhemeCraft[4] = Convert.ToInt32(pic5.Name);
            }
            FDifficulty(tmpPink);
            pinkList.Add(tmpPink);
            CounyInfo();
        }
        private void AddRedToList()
        {
            RedCharacter tmpRed = new RedCharacter();
            tmpRed.Name = textBoxName.Text;
            tmpRed.ImgUrl = "img\\" + textUrl.Text;
            tmpRed.Count = Convert.ToInt32(textCount.Text);
            tmpRed.Element = comboElement.SelectedIndex;
            tmpRed.Id = redList.Count;

            tmpRed.Search = AddSearch();

            tmpRed.SсhemeCraft[0] = Convert.ToInt32(pic1.Name);
            tmpRed.SсhemeCraft[1] = Convert.ToInt32(pic2.Name);
            tmpRed.SсhemeCraft[2] = Convert.ToInt32(pic3.Name);
            tmpRed.SсhemeCraft[3] = Convert.ToInt32(pic4.Name);
            tmpRed.SсhemeCraft[4] = Convert.ToInt32(pic5.Name);

            FDifficulty(tmpRed);
            redList.Add(tmpRed);
            CounyInfo();
        }
        #endregion addToList

        //Функция очистки ПикчерБоксов на панели крафта
        public void ClearPb(bool flagPanel)
        {
            if (flagPanel)
            {
                foreach (PictureBox tmp in picCraft)
                {
                    tmp.Image = null;
                }
            }
            else
            {
                foreach (PictureBox tmp in picEdit)
                {
                    tmp.Image = null;
                }
            }
        }

        //Функция проверки и загрузки картинки
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

        //Функция отображения списка персонажей в окне редактирования
        private void EditPanel<T>(FlowLayoutPanel panel, List<T> list) where T : BaseCharacter
        {
            //Создаём список ПБ
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

                panel.Controls.Add(pb);
            }
        }

        //Функция-Событие для отображения информации о персонаже
        private void BaseClickPb(object sender, EventArgs e)
        {
            ClearEditPanel();
            PictureBox pb = sender as PictureBox;
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            //Отображаем картинку перса           
            pictureBox9.Image = pb.Image;
            idChange = Convert.ToInt32(pb.Name);

            

            BaseCharacter curenChemp = null;

            if (tabControl2.SelectedIndex == 0)
            {
                curenChemp = blueList[idChange];
                panel1.Visible = false;               
                label28.Visible = false;
                label95.Visible = false;
            }
            else if (tabControl2.SelectedIndex == 1)
            {
                //Если розовый перс не имеет рецепта крафта то скрываем панель
                if (pinkList[idChange].SсhemeCraft[0] == 9999999)
                {
                    panel1.Visible = false;
                    label28.Visible = false;
                    label95.Visible = true;
                    curenChemp = pinkList[idChange];
                }
                else
                {
                    curenChemp = pinkList[idChange];
                    panel1.Visible = true;
                    label28.Visible = true;
                    label95.Visible = true;
                    picEdit[5].Hide();
                    picEdit[6].Hide();
                }
            }
            else if (tabControl2.SelectedIndex == 2)
            {
                if (goldList[idChange].SсhemeCraft[0] == 9999999)
                {
                    label28.Visible = false;
                    panel1.Visible = false;
                    label95.Visible = true;
                    curenChemp = pinkList[idChange];
                }
                else
                {
                    label28.Visible = true;
                    panel1.Visible = true;
                    label95.Visible = true;
                    picEdit[5].Visible = true;
                    picEdit[6].Visible = true;
                }
                curenChemp = goldList[idChange];
            }
            else if (tabControl2.SelectedIndex == 3)
            {
                panel1.Visible = true;
                label28.Visible = true;
                label95.Visible = true;
                picEdit[5].Hide();
                picEdit[6].Hide();
                curenChemp = redList[idChange];                
            }

            //Отображение: Имя, колличество, ссылка на файл, стихии и качества
            textBox11.Text = curenChemp.Name;
            label94.Text = "Сложность поиска: " + curenChemp.TotalDifficulty;
            textBox10.Text = Convert.ToString(curenChemp.Count);
            textBox9.Text = Path.GetFileName(curenChemp.ImgUrl);
            comboBox2.SelectedIndex = curenChemp.Element;

            if(!(curenChemp is BlueCharacter))
            {                
                label95.Text = "Сложность крафта: " + (curenChemp as ICharacter).CraftDifficulty;
            }


            if (curenChemp.Search[0] != null)
            {
                checkBox17.Checked = true;
            }
            if (curenChemp.Search[1] != null)
            {
                checkBox15.Checked = true;
            }
            if (curenChemp.Search[2] != null)
            {
                checkBox14.Checked = true;
            }
            if (curenChemp.Search[3] != null)
            {
                checkBox13.Checked = true;
            }

            //Если в поисковом списке есть поиск хотя бы в 1 уровне кампании, то активировать чек бокс кампании
            if (curenChemp.Search[4] != null || curenChemp.Search[5] != null || curenChemp.Search[6] != null || curenChemp.Search[7] != null)
            {
                checkBox12.Checked = Enabled;
            }

            if (curenChemp.Search[4] != null)
            {
                textBox8.Text = curenChemp.Search[4].Trim();
                checkBox11.Checked = Enabled;
                textBox8.Enabled = true;
            }
            if (curenChemp.Search[5] != null)
            {
                textBox7.Text = curenChemp.Search[5].Trim();
                checkBox10.Checked = Enabled;
                textBox7.Enabled = true;
            }
            if (curenChemp.Search[6] != null)
            {
                textBox6.Text = curenChemp.Search[6].Trim();
                checkBox9.Checked = Enabled;
                textBox6.Enabled = true;
            }
            if (curenChemp.Search[7] != null)
            {
                textBox5.Text = curenChemp.Search[7].Trim();
                checkBox8.Checked = Enabled;
                textBox5.Enabled = true;
            }


            if (curenChemp is PinkCharacter)
            {
                ICharacter tmp = (ICharacter)curenChemp;
                if (tmp.SсhemeCraft[0] == 9999999)
                {
                    //Если розовый перс не имеет рецепта крафта то не пытаемся отобразить схему
                }
                else
                {
                    for (int i = 0; i < tmp.SсhemeCraft.Length; i++)
                    {
                        picEdit[i].Name = tmp.SсhemeCraft[i].ToString();
                        picEdit[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        picEdit[i].Load(blueList[tmp.SсhemeCraft[i]].ImgUrl);
                    }
                }
            }
            else if (curenChemp is RedCharacter)
            {
                ICharacter tmp = (ICharacter)curenChemp;
                for (int i = 0; i < tmp.SсhemeCraft.Length; i++)
                {
                    picEdit[i].Name = tmp.SсhemeCraft[i].ToString();
                    picEdit[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    picEdit[i].Load(goldList[tmp.SсhemeCraft[i]].ImgUrl);
                }
            }
            else if (curenChemp is GoldCharacter)
            {
                ICharacter tmp = (ICharacter)curenChemp;
                if (tmp.SсhemeCraft[0] == 9999999)
                {
                    //Если розовый перс не имеет рецепта крафта то не пытаемся отобразить схему
                }
                else
                {
                    for (int i = 0; i < tmp.SсhemeCraft.Length; i++)
                    {
                        picEdit[i].Name = tmp.SсhemeCraft[i].ToString();
                        picEdit[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        picEdit[i].Load(pinkList[tmp.SсhemeCraft[i]].ImgUrl);
                    }
                }
            }
        }

        //Функця сохранения изменений после редактирования перса
        void ReSave()
        {
            /*
             Имя
             Картинка
             Колличество
             Стихия
             Поиск
             */

            //Синие
            if (tabControl2.SelectedIndex == 0)
            {
                blueList[idChange].Name = textBox11.Text;
                blueList[idChange].ImgUrl = "img\\" + textBox9.Text;
                blueList[idChange].Count = Convert.ToInt32(textBox10.Text);
                blueList[idChange].Element = comboBox2.SelectedIndex;
                blueList[idChange].Search = AddEditSearch();

                //Обновление отображаемых персонажей
                flowLayoutPanel1.Controls.Clear();

                EditPanel(flowLayoutPanel1, blueList);
            }
            //Розовые
            else if (tabControl2.SelectedIndex == 1)
            {
                pinkList[idChange].Name = textBox11.Text;
                pinkList[idChange].ImgUrl = "img\\" + textBox9.Text;
                pinkList[idChange].Count = Convert.ToInt32(textBox10.Text);
                pinkList[idChange].Element = comboBox2.SelectedIndex;

                pinkList[idChange].Search = AddEditSearch();
                if (pinkList[idChange].SсhemeCraft[0] != 9999999)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        pinkList[idChange].SсhemeCraft[i] = Convert.ToInt32(picEdit[i].Name);
                    }
                }

                flowLayoutPanel2.Controls.Clear();
                EditPanel(flowLayoutPanel2, pinkList);

            }
            //Золотые
            else if (tabControl2.SelectedIndex == 2)
            {
                goldList[idChange].Name = textBox11.Text;
                goldList[idChange].ImgUrl = "img\\" + textBox9.Text;
                goldList[idChange].Count = Convert.ToInt32(textBox10.Text);
                goldList[idChange].Element = comboBox2.SelectedIndex;

                goldList[idChange].Search = AddEditSearch();

                for (int i = 0; i < 7; i++)
                {
                    goldList[idChange].SсhemeCraft[i] = Convert.ToInt32(picEdit[i].Name);
                }

                flowLayoutPanel3.Controls.Clear();
                EditPanel(flowLayoutPanel3, goldList);
            }
            //Красные
            else if (tabControl2.SelectedIndex == 3)
            {
                redList[idChange].Name = textBox11.Text;
                redList[idChange].ImgUrl = "img\\" + textBox9.Text;
                redList[idChange].Count = Convert.ToInt32(textBox10.Text);
                redList[idChange].Element = comboBox2.SelectedIndex;

                redList[idChange].Search = AddEditSearch();

                for (int i = 0; i < 5; i++)
                {
                    redList[idChange].SсhemeCraft[i] = Convert.ToInt32(picEdit[i].Name);
                }

                flowLayoutPanel4.Controls.Clear();
                EditPanel(flowLayoutPanel4, redList);
            }


        }

        //Функция очистки окна редактирования
        void ClearEditPanel()
        {
            //Чистим базовые элементы
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            pictureBox9.Image = null;
            comboBox2.SelectedIndex = -1;

            //Чистим чек боксы
            checkBox17.Checked = false;
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

        //Функция отвечающая за скрытие ПБ рецепта и установку флага в случае если у розового перса нет рецепта
        private void NotReseptPink()
        {
            if (comboBoxColor.SelectedIndex == 2 && checkBox16.Checked == true || comboBoxColor.SelectedIndex == 1 && checkBox16.Checked == true )
            {

                panel.Visible = false;
                flagNotResept = true;

                label29.Visible = false;
            }
            if (comboBoxColor.SelectedIndex == 2 && checkBox16.Checked == false || comboBoxColor.SelectedIndex == 1 && checkBox16.Checked == false)
            {
                panel.Visible = true;
                flagNotResept = false;

                label29.Visible = true;
            }

        }

        //Кнопка очистки окна крафта
        private void button1_Click(object sender, EventArgs e)
        {
            ClearCraftPanel();           
        }



        
        //////////////////////////////////////////////////////////////////////////////

        //Загрузка базы из json
        private void Form1_Load(object sender, EventArgs e)
        {
            //Проверка на существование файлов
            if (!File.Exists("baseRed.json") || !File.Exists("baseBlue.json") || !File.Exists("baseGold.json") || !File.Exists("basePink.json"))
            {
                MessageBox.Show("Один из файлов базы не найден!");
            }
            else
            {
                //Подгрузка БД из файлов
                redList = JsonConvert.DeserializeObject<List<RedCharacter>>(File.ReadAllText("baseRed.json"));
                blueList = JsonConvert.DeserializeObject<List<BlueCharacter>>(File.ReadAllText("baseBlue.json"));
                goldList = JsonConvert.DeserializeObject<List<GoldCharacter>>(File.ReadAllText("baseGold.json"));
                pinkList = JsonConvert.DeserializeObject<List<PinkCharacter>>(File.ReadAllText("basePink.json"));

                faq.faqList = JsonConvert.DeserializeObject<List<FAQ>>(File.ReadAllText("FAQ.json"));
                faq.head = comboBox3;
                faq.textBox = richTextBox1;


                //Подгрузка инфы FAQ
                craft = new Craft(redList, goldList, pinkList, blueList);

                craft.FallPink();
                craft.FallBlue();
                craft.FallGold();              


                //Вызов функции отображения информации о количестве персов в БД
                CounyInfo();
            }
        }       

        //Выгрузка БД в файлы json
        private void buttonDes_Click(object sender, EventArgs e)
        {
            File.WriteAllText("baseBlue.json", JsonConvert.SerializeObject(blueList, Formatting.Indented));
            File.WriteAllText("basePink.json", JsonConvert.SerializeObject(pinkList, Formatting.Indented));
            File.WriteAllText("baseGold.json", JsonConvert.SerializeObject(goldList, Formatting.Indented));
            File.WriteAllText("baseRed.json", JsonConvert.SerializeObject(redList, Formatting.Indented));
        }
        
        private void buttonChekImg_Click(object sender, EventArgs e)
        {
            ChekImg(pictureBox1, textUrl);
        }

        //Взаимоисключающие чекБоксы кампании
        #region
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
        #endregion

        //Включение и выключение ПикчерБоксов в зависимости от цвета перса
        public void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxColor.SelectedIndex == 3)
            {
                //Синие персы
                panel.Visible = false;
                label29.Visible = false;

            }
            else if (comboBoxColor.SelectedIndex == 2)
            {

                picCraft[5].Hide();
                picCraft[6].Hide(); 

                NotReseptPink();
                //Розовые
            }
            else if (comboBoxColor.SelectedIndex == 1)
            {
                picCraft[5].Visible = true;
                picCraft[6].Visible = true;
                panel.Visible = true;
                label29.Visible = true;

                NotReseptPink();
                //Золотые

            }
            else if (comboBoxColor.SelectedIndex == 0)
            {
                picCraft[5].Hide();
                picCraft[6].Hide();
                panel.Visible = true;
                label29.Visible = true;
                //Красные
            }
        }

        //Кнопка добавления персов в список
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Введите Имя");
            }
            else
            {
                if (!ChekImg(pictureBox1, textUrl))
                {
                    //МСБ с ошибкой
                }
                else
                {
                    if (textCount.Text == "")
                    {
                        MessageBox.Show("Введите колличество");
                    }
                    else
                    {
                        if (comboElement.SelectedIndex < 0)
                        {

                            MessageBox.Show("Выбирите стихию");
                        }
                        else
                        {
                            if (comboBoxColor.SelectedIndex < 0)
                            {
                                MessageBox.Show("Выбирите качество");
                            }
                            else
                            {
                                if (comboBoxColor.SelectedIndex == 1)
                                {
                                    if (pic1 == null || pic2 == null || pic3 == null || pic4 == null || pic5 == null || pic6 == null || pic7 == null)
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
                                            AddGoldToList();                                            
                                        }
                                    }
                                }
                                else if (comboBoxColor.SelectedIndex == 0 || comboBoxColor.SelectedIndex == 2)
                                {
                                    //Если флаг БЕзРецепта активен и выбран розовый перс
                                    if (flagNotResept && comboBoxColor.SelectedIndex == 2)
                                    {
                                        AddPinkToList();
                                    }
                                    //Если нет то поступаем как обычно
                                    else
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

        //Кнопка очисткики ПБ
        private void comboBoxColor_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearPb(true);
        }

        //Кнопка выбора картинки из папки, обрезаем ее адрес, пихаем в бокс и отображаем
        private void button2_Click(object sender, EventArgs e)
        {
            ImgButChek(pictureBox1, textUrl);
        }

        //Очистка панелей отображающих списки и очитка полей с данными о персе
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((TabControl)sender).SelectedIndex;
            if (index == 0)
            {
                ClearPb(false);
                flowLayoutPanel1.Controls.Clear();
                EditPanel(flowLayoutPanel1, blueList);
                panel1.Visible = false;
            }
            else if (index == 1)
            {
                ClearPb(false);
                flowLayoutPanel2.Controls.Clear();
                EditPanel(flowLayoutPanel2, pinkList);
                panel1.Visible = false;
            }
            else if (index == 2)
            {
                ClearPb(false);
                flowLayoutPanel3.Controls.Clear();
                EditPanel(flowLayoutPanel3, goldList);
                panel1.Visible = false;
            }
            else if (index == 3)
            {
                ClearPb(false);
                flowLayoutPanel4.Controls.Clear();
                EditPanel(flowLayoutPanel4, redList);
                panel1.Visible = false;
            }

            ClearEditPanel();

        }

        //Очистка панелей с персонажами в окне редактирования и сохранение
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {           

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel3.Controls.Clear();
            flowLayoutPanel4.Controls.Clear();

            EditPanel(flowLayoutPanel1, blueList);
            EditPanel(flowLayoutPanel2, pinkList);
            EditPanel(flowLayoutPanel3, goldList);
            EditPanel(flowLayoutPanel4, redList);

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

        //Снова взаимоисключение ЧекБоксов
        #region 
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

        //Очистка полей в окне редактирования
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearPb(false);
        }

        //Вызов второй формы по нажатию на ПБ в окне редактирования
        private void ClickEditPb(object sender, EventArgs e)
        {
            newForm.pictureBox = sender as PictureBox;
            newForm.SelectChamp();
        }

        //Пересохранене персонажа после редактирования
        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox9.Text == "")
            {
                MessageBox.Show("Выберите персонажа или заполните поле адреса картинки");
            }
            else
            {            
                ReSave();
                craft.FallBlue();
                craft.FallPink();
                craft.FallGold();
                RecountDifficulty();
            }
        }

        //ПРи закрыти приложения удостоверимся, что всё сохранено
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Выгрузить базу перед выходом?",
        "Предупреждение!",
        MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                File.WriteAllText("baseBlue.json", JsonConvert.SerializeObject(blueList, Formatting.Indented));
                File.WriteAllText("basePink.json", JsonConvert.SerializeObject(pinkList, Formatting.Indented));
                File.WriteAllText("baseGold.json", JsonConvert.SerializeObject(goldList, Formatting.Indented));
                File.WriteAllText("baseRed.json", JsonConvert.SerializeObject(redList, Formatting.Indented));
            }
        }

        //ЧБ отвечающий за вызов функции "Нет рецепта
        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            NotReseptPink();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

            if (e.TabPageIndex==4)
            {
                info.InfoPage(label31, label32, label33, label34, label35, label36, label37, label50, label53, label48, label49, label54, label52, label51, blueList);
                info.InfoPage(label42, label45, label40, label41, label46, label44, label43, label58, label61, label56, label57, label62, label60, label59, pinkList);
                info.InfoPage(label74, label77, label72, label73, label78, label76, label75, label66, label69, label64, label65, label70, label68, label67, goldList);
                info.InfoPage(label89, label92, label87, label88, label93, label91, label90, label81, label84, label79, label80, label85, label83, label82, redList);
            }
            else if(e.TabPageIndex == 2)
            {                
                comboBox1.SelectedIndex = -1;
                UiCraftListClear();

            }
            else if (e.TabPageIndex == 3)
            {
                faq.Clear();
                faq.GetHead();
            }
        }
        
        void UiCraftListClear()
        {            
            flowLayoutPanel5.Controls.Clear();
            label97.Text = "";
            label98.Text = "";
            label99.Text = "";
            label105.Text = "";
            label102.Text = "";
            label106.Text = "";
            label100.Text = "";
            label104.Text = "";
            label101.Text = "";
            label103.Text = "";
        }

        void UiCraftList(int flagColor)
        {           
            List <PictureBox> pictureboxList = new List<PictureBox>();
            int y = 0;
            foreach (var file in craft.minLst)
            {
                var pb = new PictureBox();

                pb.Location = new Point(pictureboxList.Count * 120 + 20, y);                
                pb.Size = new Size(55, 75);
                try
                {
                    Image img = null;
                    if (flagColor == 2)
                     {
                        img = Image.FromFile(pinkList[file.IdCharacter].ImgUrl);
                    }
                    else if(flagColor == 1)
                    {
                        img = Image.FromFile(goldList[file.IdCharacter].ImgUrl);
                    }
                    else
                    {
                        img = Image.FromFile(redList[file.IdCharacter].ImgUrl);
                    }

                    if (file.Key > 0)
                    {
                        SetBW(img);
                    }
                    pb.Click += new System.EventHandler(ClickPb);
                    pb.Image = img;
                    pb.Name = file.IdCharacter.ToString();
                    pictureboxList.Add(pb);
                }
                catch (OutOfMemoryException)
                {
                    continue;
                }
                pb.SizeMode = PictureBoxSizeMode.StretchImage;

                flowLayoutPanel5.Controls.Add(pb);
                Show();
            }

            for(int i =0; i< craft.minLst.Count; i++)
            {
                listLabel[i].Text = craft.minLst[i].Key.ToString();
            }

           
        }

        private void ClickPb(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;

            int key=0;
            for(int i =0;i<craft.minLst.Count;i++)
            {
                if(craft.minLst[i].IdCharacter== Int32.Parse(pb.Name))
                {
                    key = craft.minLst[i].Key;
                    break;
                }
            }
            Form3.Ui(comboBox1.SelectedIndex, Int32.Parse(pb.Name),key);
            Form3.Show();
        }   
        //Накладываем маску ЧБ на картинку
        void SetBW(Image img)
        {
            var sr =  0.2126f;
            var sg =  0.7152f;
            var sb =  0.0722f;

            using (var gfx = Graphics.FromImage(img))
            using (var attr = new ImageAttributes())
            {
                attr.SetColorMatrix(new ColorMatrix
                {
                    Matrix00 = sr,
                    Matrix01 = sr,
                    Matrix02 = sr,
                    Matrix10 = sg,
                    Matrix11 = sg,
                    Matrix12 = sg,
                    Matrix20 = sb,
                    Matrix21 = sb,
                    Matrix22 = sb
                });

                gfx.DrawImage(img,
                    new Rectangle(Point.Empty, img.Size),
                    0, 0,
                    img.Width,
                    img.Height,
                    GraphicsUnit.Pixel,
                    attr);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UiCraftListClear();
            if (comboBox1.SelectedIndex == 2)
            {                
                craft.CraftPink();
                UiCraftList(2);
            }
            if (comboBox1.SelectedIndex == 1)
            {                
               craft.CraftGold();                             
               UiCraftList(1);

            }
            if (comboBox1.SelectedIndex == 0)
            {                
               craft.CraftRed();
               UiCraftList(0);
            }
            
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            //Список для отображения
            List<BaseCharacter> SearchList =  new List<BaseCharacter>();
            List<BaseCharacter> SearchBaseList;

            int index = tabControl2.SelectedIndex;
            if (index == 0)
            {
                 SearchBaseList = new List<BaseCharacter>(blueList);
                Seatch(textBox12.Text, SearchList, SearchBaseList);

                ClearPb(false);
                flowLayoutPanel1.Controls.Clear();
                EditPanel(flowLayoutPanel1, SearchList);
                panel1.Visible = false;
            }
            else if (index == 1)
            {
                SearchBaseList = new List<BaseCharacter>(pinkList);
                Seatch(textBox12.Text, SearchList, SearchBaseList);

                ClearPb(false);
                flowLayoutPanel2.Controls.Clear();
                EditPanel(flowLayoutPanel2, SearchList);
                panel1.Visible = false;
            }
            else if (index == 2)
            {
                SearchBaseList = new List<BaseCharacter>(goldList);
                Seatch(textBox12.Text, SearchList, SearchBaseList);

                ClearPb(false);
                flowLayoutPanel3.Controls.Clear();
                EditPanel(flowLayoutPanel3, SearchList);
                panel1.Visible = false;
            }
            else if (index == 3)
            {
                SearchBaseList = new List<BaseCharacter>(redList);
                Seatch(textBox12.Text, SearchList, SearchBaseList);

                ClearPb(false);
                flowLayoutPanel4.Controls.Clear();
                EditPanel(flowLayoutPanel4, SearchList);
                panel1.Visible = false;
            }

            ClearEditPanel();

        }

        //Функция поиска персов в имя которых включается введённый текст
        void Seatch(string text, List<BaseCharacter> SearchList, List<BaseCharacter> BaseList)
        {     
            //перебираем имена
            foreach (BaseCharacter x in BaseList)
            {
                //Забиваем болт на регистр букв
                if(x.Name.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    SearchList.Add(x);
                }
            }          
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            faq.Select(comboBox3.SelectedIndex);
        }

        private void label97_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
