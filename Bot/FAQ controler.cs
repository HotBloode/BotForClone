using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Bot
{
    public class FAQ_controler
    {
        //Список тем
        public List<FAQ> faqList =  new List<FAQ>();
        //Бокс с заголовками
        public RichTextBox textBox;
        //Бокс для текста
        public ComboBox head;

        //Очистка компонентов
        public void Clear()
        {
            textBox.Clear();
            head.Items.Clear();
            head.Text = "";
                       
        }
        //Подгрузка заголовков в бокс
        public void GetHead()
        {
            for (int i = 0; i < faqList.Count; i++)
            {
                head.Items.Insert(i, faqList[i].Headline);
            }
        }
        //Подгрузка текста в бокс по выбраному индексу
        public void Select(int x)
        {
            textBox.Text = faqList[x].Text;
        }

            
    }
}
