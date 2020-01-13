using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;



namespace Bot
{
    public partial class Form1 : Form
    {
        //Создаём форму для выбора перса    
        private Form2 newForm = new Form2();

        public List<PictureBox> picCraft = new List<PictureBox>();
        public List<PictureBox> picEdit = new List<PictureBox>();
        public int idChange;
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

            picEdit.Add(pic11);
            picEdit.Add(pic22);
            picEdit.Add(pic33);
            picEdit.Add(pic44);
            picEdit.Add(pic55);
            picEdit.Add(pic66);
            picEdit.Add(pic77);
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

            foreach (PictureBox pb in picCraft)
            {
                pb.Image = null;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ClearCraftPanel();
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
        List<string> AddSearch()
        {
            List<string> seatch = new List<string>();
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

        List<string> AddEditSearch()
        {
            List<string> seatch = new List<string>();
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

        //Избыточно, но работает. Позже заюзать апкаст или шаблон
        private void AddBlueToList()
        {
            BlueCharacter tmpBlue = new BlueCharacter();

            tmpBlue.Name = textBoxName.Text;
            tmpBlue.ImgUrl = "img\\" + textUrl.Text;
            tmpBlue.Count = Convert.ToInt32(textCount.Text);
            tmpBlue.Element = comboElement.SelectedIndex;
            tmpBlue.Id = blueList.Count;

            tmpBlue.Search = AddSearch();

            blueList.Add(tmpBlue);
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
            tmpPink.Id = pinkList.Count;

            tmpPink.Search = AddSearch();

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
            tmpRed.Id = redList.Count;

            tmpRed.Search = AddSearch();

            tmpRed.SсhemeCraft[0] = Convert.ToInt32(pic1.Name);
            tmpRed.SсhemeCraft[1] = Convert.ToInt32(pic2.Name);
            tmpRed.SсhemeCraft[2] = Convert.ToInt32(pic3.Name);
            tmpRed.SсhemeCraft[3] = Convert.ToInt32(pic4.Name);
            tmpRed.SсhemeCraft[4] = Convert.ToInt32(pic5.Name);
            redList.Add(tmpRed);

        }

        #endregion addToList

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

        //Поработаем с окошками списка крафта, ёптить
        public void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxColor.SelectedIndex == 3)
            {
                //Синие персы
                panel.Visible = false;

            }
            else if (comboBoxColor.SelectedIndex == 2)
            {
                picCraft[5].Hide();
                picCraft[6].Hide();
                panel.Visible = true;
                //Розовые
            }
            else if (comboBoxColor.SelectedIndex == 1)
            {
                picCraft[5].Visible = true;
                picCraft[6].Visible = true;
                panel.Visible = true;

                //Золотые

            }
            else if (comboBoxColor.SelectedIndex == 0)
            {
                picCraft[5].Hide();
                picCraft[6].Hide();
                panel.Visible = true;
                //Красные
            }
        }

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
            ClearPb(true);
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

        private void EditPanel<T>(FlowLayoutPanel panel, List<T> list) where T : BaseCharacter
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

                panel.Controls.Add(pb);

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
            idChange = Convert.ToInt32(pb.Name);


            BaseCharacter curenChemp = null;

            if (tabControl2.SelectedIndex == 0)
            {
                curenChemp = blueList[idChange];
                panel1.Visible = false;
            }
            else if (tabControl2.SelectedIndex == 1)
            {
                panel1.Visible = true;
                picEdit[5].Hide();
                picEdit[6].Hide();
                curenChemp = pinkList[idChange];
            }
            else if (tabControl2.SelectedIndex == 2)
            {
                panel1.Visible = true;
                picEdit[5].Visible = true;
                picEdit[6].Visible = true;
                curenChemp = goldList[idChange];
            }
            else if (tabControl2.SelectedIndex == 3)
            {
                panel1.Visible = true;
                picEdit[5].Hide();
                picEdit[6].Hide();
                curenChemp = redList[idChange];
            }

            //Отображение: Имя, колличество, ссылка на файл, стихии и качества
            textBox11.Text = curenChemp.Name;
            textBox10.Text = Convert.ToString(curenChemp.Count);
            textBox9.Text = Path.GetFileName(curenChemp.ImgUrl);
            comboBox2.SelectedIndex = curenChemp.Element;


            if (curenChemp.Search[0] != null)
            {
                checkBox15.Checked = true;
            }
            if (curenChemp.Search[1] != null)
            {
                checkBox14.Checked = true;
            }
            if (curenChemp.Search[2] != null)
            {
                checkBox13.Checked = true;
            }
            //Если в поисковом списке есть поиск хотя бы в 1 уровне кампании, то активировать чек бокс кампании
            if (curenChemp.Search[3] != null || curenChemp.Search[4] != null || curenChemp.Search[5] != null || curenChemp.Search[6] != null)
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


            if (curenChemp is PinkCharacter)
            {
                ICharacter tmp = (ICharacter)curenChemp;
                for (int i = 0; i < tmp.SсhemeCraft.Length; i++)
                {
                    picEdit[i].Name = tmp.SсhemeCraft[i].ToString();
                    picEdit[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    picEdit[i].Load(blueList[tmp.SсhemeCraft[i]].ImgUrl);
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
                for (int i = 0; i < tmp.SсhemeCraft.Length; i++)
                {
                    picEdit[i].Name = tmp.SсhemeCraft[i].ToString();
                    picEdit[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    picEdit[i].Load(pinkList[tmp.SсhemeCraft[i]].ImgUrl);
                }
            }

        }

        //Сохранение изменений после редактирования перса
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

                for (int i = 0; i < 5; i++)
                {
                    pinkList[idChange].SсhemeCraft[i] = Convert.ToInt32(picEdit[i].Name);
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

        void ClearEditPanel()
        {
            //Чистим базовые элементы
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            pictureBox9.Image = null;
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((TabControl)sender).SelectedIndex;
            if (index == 1)
            {
                flowLayoutPanel1.Controls.Clear();
                EditPanel(flowLayoutPanel1, blueList);
            }
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


        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearPb(false);
        }

        private void ClickEditPb(object sender, EventArgs e)
        {

            newForm.pictureBox = sender as PictureBox;
            newForm.SelectChamp();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReSave();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Выгрузить базу перед выходом?",
        "Предупреждение!",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Information,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                File.WriteAllText("baseBlue.json", JsonConvert.SerializeObject(blueList, Formatting.Indented));
                File.WriteAllText("basePink.json", JsonConvert.SerializeObject(pinkList, Formatting.Indented));
                File.WriteAllText("baseGold.json", JsonConvert.SerializeObject(goldList, Formatting.Indented));
                File.WriteAllText("baseRed.json", JsonConvert.SerializeObject(redList, Formatting.Indented));
            }
        }
                
    }
}
