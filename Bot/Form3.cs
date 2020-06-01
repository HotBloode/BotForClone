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
    public partial class Form3 : Form
    {
        List<PictureBox> picList = new List<PictureBox>();
        List<Label> nameList = new List<Label>();
        List<Label> countList = new List<Label>();
        List<Label> totalDifficultyList = new List<Label>();
        List<Label> SearchList = new List<Label>();

        public Form3()
        {
            InitializeComponent();
            picList.Add(pic11);
            picList.Add(pic22);
            picList.Add(pic33);
            picList.Add(pic44);
            picList.Add(pic55);
            picList.Add(pic66);
            picList.Add(pic77);

            nameList.Add(label4);
            nameList.Add(label5);
            nameList.Add(label6);
            nameList.Add(label7);
            nameList.Add(label8);
            nameList.Add(label9);
            nameList.Add(label10);

            countList.Add(label11);
            countList.Add(label12);
            countList.Add(label13);
            countList.Add(label14);
            countList.Add(label15);
            countList.Add(label16);
            countList.Add(label17);

            totalDifficultyList.Add(label18);
            totalDifficultyList.Add(label19);
            totalDifficultyList.Add(label20);
            totalDifficultyList.Add(label21);
            totalDifficultyList.Add(label22);
            totalDifficultyList.Add(label23);
            totalDifficultyList.Add(label24);

            SearchList.Add(label25);
            SearchList.Add(label26);
            SearchList.Add(label27);
            SearchList.Add(label28);
            SearchList.Add(label29);
            SearchList.Add(label30);
            SearchList.Add(label31);

        }
        public Form1 mainForm;

        string SearchString(BaseCharacter character)
        {
            string a= "";

            if(character.Search[0]!=null)
            {
                a += "Маг.казино\n";
            }
            if (character.Search[1] != null)
            {
                a += "Маг.арены\n";
            }
            if (character.Search[2] != null)
            {
                a += "Маг.таверны\n";
            }
            if (character.Search[3] != null)
            {
                a += "Маг.экспедиции\n";
            }
            if (character.Search[4] != null)
            {
                a += "Камп.об.ур:" + character.Search[4] + "\n";
            }
            if (character.Search[5] != null)
            {
                a += "Камп.эл.ур:" + character.Search[5] + "\n";
            }
            if (character.Search[6] != null)
            {
                a += "Камп.лег.ур:" + character.Search[6] + "\n";
            }
            if (character.Search[7] != null)
            {
                a += "Камп.эп.ур:" + character.Search[7] + "\n";
            }
            return a;
        }

        void ClearForm()
        {
            this.Controls.Clear();
        }

        void UiCraftListRed(RedCharacter red)
        {
            for (int i = 0; i < 5; i++)
            {
                picList[i].Image = null;
                picList[i].SizeMode = PictureBoxSizeMode.StretchImage;
                picList[i].Image = Image.FromFile(mainForm.goldList[red.SсhemeCraft[i]].ImgUrl);

                nameList[i].Text = mainForm.goldList[red.SсhemeCraft[i]].Name;
                countList[i].Text = mainForm.goldList[red.SсhemeCraft[i]].Count.ToString();
                totalDifficultyList[i].Text = mainForm.goldList[red.SсhemeCraft[i]].TotalDifficulty.ToString();
                SearchList[i].Text = SearchString(mainForm.goldList[red.SсhemeCraft[i]]);
            }
        }
        void UiCraftListGold(GoldCharacter gold)
        {
            for (int i = 0; i < 7; i++)
            {
                picList[i].Image = null;
                picList[i].SizeMode = PictureBoxSizeMode.StretchImage;
                picList[i].Image = Image.FromFile(mainForm.pinkList[gold.SсhemeCraft[i]].ImgUrl);

                nameList[i].Text = mainForm.pinkList[gold.SсhemeCraft[i]].Name;
                countList[i].Text = mainForm.pinkList[gold.SсhemeCraft[i]].Count.ToString();
                totalDifficultyList[i].Text = mainForm.pinkList[gold.SсhemeCraft[i]].TotalDifficulty.ToString();

                if(mainForm.pinkList[gold.SсhemeCraft[i]].Id==0||
                  mainForm.pinkList[gold.SсhemeCraft[i]].Id == 1 ||
                  mainForm.pinkList[gold.SсhemeCraft[i]].Id == 2 ||
                  mainForm.pinkList[gold.SсhemeCraft[i]].Id == 3 ||
                  mainForm.pinkList[gold.SсhemeCraft[i]].Id == 4 ||
                  mainForm.pinkList[gold.SсhemeCraft[i]].Id == 5)
                {
                    SearchList[i].Text = "";
                }
                else
                {
                    SearchList[i].Text = SearchString(mainForm.pinkList[gold.SсhemeCraft[i]]);
                }
            }
        }
        void UiCraftListPink(PinkCharacter pink)
        {
           for(int i = 0; i<5;  i++)
            {
                picList[i].Image = null;
                picList[i].SizeMode = PictureBoxSizeMode.StretchImage;
                picList[i].Image = Image.FromFile(mainForm.blueList[pink.SсhemeCraft[i]].ImgUrl);

                nameList[i].Text = mainForm.blueList[pink.SсhemeCraft[i]].Name;
                countList[i].Text = mainForm.blueList[pink.SсhemeCraft[i]].Count.ToString();
                totalDifficultyList[i].Text = mainForm.blueList[pink.SсhemeCraft[i]].TotalDifficulty.ToString();

                if (mainForm.blueList[pink.SсhemeCraft[i]].Id == 0 ||
                  mainForm.blueList[pink.SсhemeCraft[i]].Id == 1 ||
                  mainForm.blueList[pink.SсhemeCraft[i]].Id == 2 ||
                  mainForm.blueList[pink.SсhemeCraft[i]].Id == 3 ||
                  mainForm.blueList[pink.SсhemeCraft[i]].Id == 4 ||
                  mainForm.blueList[pink.SсhemeCraft[i]].Id == 5||
                  mainForm.blueList[pink.SсhemeCraft[i]].Id == 6)
                {
                    SearchList[i].Text = "";
                }
                else
                {
                    SearchList[i].Text = SearchString(mainForm.blueList[pink.SсhemeCraft[i]]);
                }
            }                      
        }

        void UiMain(BaseCharacter character, int color)
        {            
            pictureBox1.Image = null;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(character.ImgUrl);           
            label1.Text = character.Name;
            label2.Text = character.TotalDifficulty.ToString();
            label2.Text = "Сложность поиска: " + character.TotalDifficulty;

            if (!(character is BlueCharacter))
            {
                label3.Text = "Сложность крафта: " + (character as ICharacter).CraftDifficulty;
            }
            if (color == 2)
            {
                UiCraftListPink(character as PinkCharacter);
            }
            else if(color == 1)
            {
                UiCraftListGold(character as GoldCharacter);
            }
            else if(color == 0)
            {
                UiCraftListRed(character as RedCharacter);
            }
        }
        public void Ui(int color, int id, int key)
        {
            label32.Text = "Не хватает персонажей: " + key.ToString();
            if(key>0)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
            //ClearForm();
            if (color==2)
            {
                pic66.Visible = false;
                pic77.Visible = false;
                label9.Visible = false;
                label16.Visible = false;
                label23.Visible = false;
                label30.Visible = false;
                label10.Visible = false;
                label17.Visible = false;
                label24.Visible = false;
                label31.Visible = false;

                UiMain(mainForm.pinkList[id], color);
            }
            else if(color == 1)
            {
                pic66.Visible = true;
                pic77.Visible = true;
                label9.Visible = true;
                label16.Visible = true;
                label23.Visible = true;
                label30.Visible = true;
                label10.Visible = true;
                label17.Visible = true;
                label24.Visible = true;
                label31.Visible = true;

                UiMain(mainForm.goldList[id], color);
            }
            else if(color == 0)
            {
                pic66.Visible = false;
                pic77.Visible = false;
                label9.Visible = false;
                label16.Visible = false;
                label23.Visible = false;
                label30.Visible = false;
                label10.Visible = false;
                label17.Visible = false;
                label24.Visible = false;
                label31.Visible = false;

                UiMain(mainForm.redList[id], color);
            }



        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
