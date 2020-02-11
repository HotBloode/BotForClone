using System.Collections.Generic;
using System.Windows.Forms;


namespace Bot
{
    public class Craft
    {
        List<RedCharacter> redList;
        List<GoldCharacter> goldList;
        List<PinkCharacter> pinkList;
        List<BlueCharacter> blueList;
        public int tmp;

        int pinkCount=0;
       

        public Craft(List<RedCharacter> redList, List<GoldCharacter> goldList, List<PinkCharacter> pinkList, List<BlueCharacter> blueList)
            {
            this.redList = redList;
            this.goldList = goldList;
            this.pinkList = pinkList;
            this.blueList = blueList;
        }

        public PinkCharacter CraftPink()
        {

            PinkCharacter min = pinkList[6];
            tmp = tmpCount(min);

                for (int i = 7; i < pinkList.Count; i++)
                {
                    int tmp1 = tmpCount(pinkList[i]);
                    if (tmp1 <= tmp)
                    {
                        min = pinkList[i];
                    }
                }
            
            return min;           
        }
        public GoldCharacter CraftGold()
        {

            GoldCharacter min = goldList[1];
            CountAllPink();
            tmp = tmpCount(min);

                for (int i = 2; i < goldList.Count; i++)
                {
                    int tmp1 = tmpCount(goldList[i]);
                    if (tmp1 < tmp)
                    {
                        min = goldList[i];
                    }
                }
            
            return min;
        }
        public RedCharacter CraftRed()
        {

            RedCharacter min = redList[0];
            
            tmp = tmpCount(min);
                        
                for (int i = 1; i < redList.Count; i++)
                {
                    int tmp1 = tmpCount(redList[i]);
                    if (tmp1 < tmp)
                    {
                        min = redList[i];
                    }
                }
           
            return min;
        }


        public int tmpCount(PinkCharacter pinkChamp)
        {
            //Флаг проверки наличия 1 реального перса и пропуск 1 итерации.
            //Если мы нашли 1 реального перса с к-ом больш 0, то мы минисуме его колличество и флагом в общем цикле пропускаем его 1 раз
            bool flag = false;

            //Проверка на наличие схемы крафта
            if (pinkChamp.SсhemeCraft[0] == 9999999)
            {
                return 99;
            }
            else
            {
                //Общее к-во персов в крафте
                int tmp = 5;

                //Айдишник для запоминания
                int realId=-9;//Для условности даём любое значение

                //Присваиваем всем синим персам переменную для работы
                FakeCount(0);

                //Ищем "конкретного" перса в схеме крафта
                foreach (int tmpId in pinkChamp.SсhemeCraft)
                {
                    //Ищем реального, не обобщённого перса
                    if (tmpId != 0 || tmpId != 1 || tmpId != 2 || tmpId != 3 || tmpId != 4 || tmpId != 5 || tmpId != 6)
                    {
                        //Сохраняем его Ид
                        realId = tmpId;

                        //ПРоверяем, что бы его к-во было больше 0
                        if (blueList[tmpId].FakeCount > 0)
                        {
                            //Минусуем фейковое значение САМОГО ПЕРСА
                            blueList[tmpId].FakeCount--;

                            //Минусуем фейковое значение персов этой стихии
                            switch (blueList[tmpId].Element)
                            {
                                case 0: blueList[4].FakeCount--; break;
                                case 1: blueList[5].FakeCount--; break;
                                case 2: blueList[3].FakeCount--; break;
                                case 3: blueList[0].FakeCount--; break;
                                case 4: blueList[1].FakeCount--; break;
                                case 5: blueList[2].FakeCount--; break;
                            }

                            //Минисуем общее кол всех персов
                            blueList[6].FakeCount--;

                            //Минусуем колличество недостающих персов для крафта
                            tmp--;
                            //Меняем флаг, что бы 1 раз пропустить в общем поиске
                            flag = false;
                            break;
                        }
                        else
                        {
                            //Если не нашли перса в рецепте с к-вом больше 0, то поднимаем флаг
                            flag = true;
                        }
                    }
                }
                
                //Общий обход рецепта
                for (int i = 0; i < 5; i++)
                {
                    //Если мы уже гнашли 1 перса и уменьшили его-кво, то пропускаем его 1 раз и опускаем фалг, что бы снова не заходить в условие
                    if (blueList[pinkChamp.SсhemeCraft[i]].Id != realId && !flag)
                    {
                        flag = true;
                        continue;
                    }
                    
                    //Проверяем перса на обобщённость
                    if (blueList[pinkChamp.SсhemeCraft[i]].Id != 0 ||
                       blueList[pinkChamp.SсhemeCraft[i]].Id != 1 ||
                       blueList[pinkChamp.SсhemeCraft[i]].Id != 2 ||
                       blueList[pinkChamp.SсhemeCraft[i]].Id != 3 ||
                       blueList[pinkChamp.SсhemeCraft[i]].Id != 4 ||
                       blueList[pinkChamp.SсhemeCraft[i]].Id != 5 ||
                       blueList[pinkChamp.SсhemeCraft[i]].Id != 6)
                    {
                        //Елси реальный перс, то проверяем на его наличие у нас
                        if (blueList[pinkChamp.SсhemeCraft[i]].FakeCount > 0)
                        {
                            //Минусуем его к-во
                            blueList[pinkChamp.SсhemeCraft[i]].FakeCount--;

                            //Минусуем недостающих персов
                            tmp--;

                            //Минусуем перса по стихиям
                            switch (blueList[pinkChamp.SсhemeCraft[i]].Element)
                            {
                                case 0: blueList[4].FakeCount--; break;
                                case 1: blueList[5].FakeCount--; break;
                                case 2: blueList[3].FakeCount--; break;
                                case 3: blueList[0].FakeCount--; break;
                                case 4: blueList[1].FakeCount--; break;
                                case 5: blueList[2].FakeCount--; break;
                            }

                            //Минусуем общее к-во
                            blueList[6].FakeCount--;
                        }
                    }
                    else
                    {
                        //Если перс обобщённый

                        //Проверяем на наличие
                        if (blueList[pinkChamp.SсhemeCraft[i]].FakeCount > 0)
                        {
                            //Минусуем по стихиям
                            switch (blueList[pinkChamp.SсhemeCraft[i]].Element)
                            {
                                case 0: pinkList[4].FakeCount--; break;
                                case 1: pinkList[5].FakeCount--; break;
                                case 2: pinkList[3].FakeCount--; break;
                                case 3: pinkList[0].FakeCount--; break;
                                case 4: pinkList[1].FakeCount--; break;
                                case 5: pinkList[2].FakeCount--; break;
                            }
                            //Минусуем недостающих персов
                            tmp--;

                            //Минусуем общее к-во
                            blueList[6].FakeCount--;
                        }
                    }
                }
                return tmp;
            }
        }

        //Почти такая же функция как у розовых
        public int tmpCount(GoldCharacter goldkChamp)
        {
            bool flag = false;
            //Проверка на наличие схемы крафта
            if (goldkChamp.SсhemeCraft[0] == 9999999)
            {
                return 99;
            }
            else
            {
                int tmp = 7;
                int realId = -9;
                //Присваиваем всем синим персам переменную для работы
                
                FakeCount(1);

                //Ищем "конкретного" перса в схеме крафта
                foreach (int tmpId in goldkChamp.SсhemeCraft)
                {
                    if (tmpId != 0 || tmpId != 1 || tmpId != 2 || tmpId != 3 || tmpId != 4 || tmpId != 5)
                    {
                        realId = tmpId;
                        if (pinkList[tmpId].FakeCount > 0)
                        {
                            //Минусуем фейковое значение САМОГО ПЕРСА
                            pinkList[tmpId].FakeCount--;

                            //Минусуем фейковое значение персов этой стихии
                            switch (pinkList[tmpId].Element)
                            {
                                case 0: pinkList[4].FakeCount--; break;
                                case 1: pinkList[5].FakeCount--; break;
                                case 2: pinkList[3].FakeCount--; break;
                                case 3: pinkList[0].FakeCount--; break;
                                case 4: pinkList[1].FakeCount--; break;
                                case 5: pinkList[2].FakeCount--; break;
                            }

                            //Минусуем колличество недостающих персов для крафта
                            tmp--;
                            flag = false;
                            break;
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                }

                for (int i = 0; i < 7; i++)
                {

                    if (pinkList[goldkChamp.SсhemeCraft[i]].Id == realId && !flag)
                    {
                        flag = true;
                        continue;
                    }

                    if (pinkList[goldkChamp.SсhemeCraft[i]].Id != 0 ||
                       pinkList[goldkChamp.SсhemeCraft[i]].Id != 1 ||
                       pinkList[goldkChamp.SсhemeCraft[i]].Id != 2 ||
                       pinkList[goldkChamp.SсhemeCraft[i]].Id != 3 ||
                       pinkList[goldkChamp.SсhemeCraft[i]].Id != 4 ||
                       pinkList[goldkChamp.SсhemeCraft[i]].Id != 5)
                    {
                        if (pinkList[goldkChamp.SсhemeCraft[i]].FakeCount > 0)
                        {
                            pinkList[goldkChamp.SсhemeCraft[i]].FakeCount--;
                            tmp--;

                            switch (pinkList[goldkChamp.SсhemeCraft[i]].Element)
                            {
                                case 0: pinkList[4].FakeCount--; break;
                                case 1: pinkList[5].FakeCount--; break;
                                case 2: pinkList[3].FakeCount--; break;
                                case 3: pinkList[0].FakeCount--; break;
                                case 4: pinkList[1].FakeCount--; break;
                                case 5: pinkList[2].FakeCount--; break;
                            }
                        }
                    }
                    else
                    {
                        if (pinkList[goldkChamp.SсhemeCraft[i]].FakeCount > 0)
                        {
                            switch (pinkList[goldkChamp.SсhemeCraft[i]].Element)
                            {
                                case 0: pinkList[4].FakeCount--; break;
                                case 1: pinkList[5].FakeCount--; break;
                                case 2: pinkList[3].FakeCount--; break;
                                case 3: pinkList[0].FakeCount--; break;
                                case 4: pinkList[1].FakeCount--; break;
                                case 5: pinkList[2].FakeCount--; break;
                            }
                            tmp--;
                        }
                    }

                }
                return tmp;
            }
        }

        public int tmpCount(RedCharacter redChamp)
        {
            bool flag = false;
            
                int tmp = 5;
                int realId = -9;               

                FakeCount(3);

                //Ищем "конкретного" перса в схеме крафта
                foreach (int tmpId in redChamp.SсhemeCraft)
                {
                    if (tmpId != 0)
                    {
                        realId = tmpId;
                        if (goldList[tmpId].FakeCount > 0)
                        {
                            //Минусуем фейковое значение САМОГО ПЕРСА
                            pinkList[tmpId].FakeCount--;
                            pinkList[0].FakeCount--;

                            //Минусуем колличество недостающих персов для крафта
                            tmp--;
                            flag = false;
                            break;
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                }

                for (int i = 0; i < 5; i++)
                {

                    if (goldList[redChamp.SсhemeCraft[i]].Id == realId && !flag)
                    {
                        flag = true;
                        continue;
                    }

                    if (goldList[redChamp.SсhemeCraft[i]].Id != 0)
                    {
                        if (goldList[redChamp.SсhemeCraft[i]].FakeCount > 0)
                        {
                            goldList[redChamp.SсhemeCraft[i]].FakeCount--;
                            tmp--;
                            goldList[0].FakeCount--;
                        }
                    }
                    else
                    {
                        if (goldList[redChamp.SсhemeCraft[i]].FakeCount > 0)
                        {
                            goldList[0].FakeCount--;
                            tmp--;
                        }
                    }

                }
                return tmp;
            
        }

        //Функции проверки колличества персов
        public bool CheckFCount(BaseCharacter tmp)
        {
            if (tmp.FakeCount > 0)
            {
                tmp.FakeCount--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void FakeCount(int idColor)
        {
            
            switch (idColor)
             {
                case 0:
                    {
                        FallBlue(); ; 
                        for (int i = 0; i < blueList.Count; i++)
                        {
                            blueList[i].FakeCount = blueList[i].Count;
                        }
                        break;
                    }

                   
                case 1:
                    {
                        FallPink();
                         for (int i = 0; i < pinkList.Count; i++)
                        {
                            pinkList[i].FakeCount = pinkList[i].Count;
                        }
                        break;
                    }
                case 3:
                    {                        
                        for (int i = 0; i < goldList.Count; i++)
                        {
                            goldList[i].FakeCount = goldList[i].Count;
                        }
                        break;
                    }
            }
            

        }


        //Функция подсчёта всхе видов обощ персов
        public void FallBlue()
        {
            blueList[0].Count = 0;
            blueList[1].Count = 0;
            blueList[2].Count = 0;
            blueList[3].Count = 0;
            blueList[4].Count = 0;
            blueList[5].Count = 0;
            blueList[6].Count = 0;



            foreach (BlueCharacter curent in blueList)
            {
                switch (curent.Element)
                {
                    case 3: blueList[0].Count+= curent.Count; break;
                    case 4: blueList[1].Count += curent.Count; break;
                    case 5: blueList[2].Count += curent.Count; break;
                    case 2: blueList[3].Count += curent.Count; break;
                    case 0: blueList[4].Count += curent.Count; break;
                    default: blueList[5].Count += curent.Count; break;
                }
            }
            blueList[6].Count = blueList[0].Count + blueList[1].Count + blueList[2].Count + blueList[3].Count + blueList[4].Count + blueList[5].Count;


        }
        public void FallPink()
        {
            pinkList[0].Count = 0;
            pinkList[1].Count = 0;
            pinkList[2].Count = 0;
            pinkList[3].Count = 0;
            pinkList[4].Count = 0;
            pinkList[5].Count = 0;

            foreach (PinkCharacter curent in pinkList)
            {
                switch (curent.Element)
                {
                    case 3: pinkList[0].Count += curent.Count; break;
                    case 4: pinkList[1].Count += curent.Count; break;
                    case 5: pinkList[2].Count += curent.Count; break;
                    case 2: pinkList[3].Count += curent.Count; break;
                    case 0: pinkList[4].Count += curent.Count; break;
                    default: pinkList[5].Count += curent.Count; break;
                }

            }

        }
        public void FallGold()
        {
            goldList[0].Count = 0;
            for(int i = 1;i<goldList.Count;i++)
            {
                goldList[0].Count += goldList[i].Count;
            }
        }

        //Т.к у розовых нет обобщённого перса который хранит общее к-во, то нужно почитать их отдельно
        public void CountAllPink()
        {
            for(int i =1; i<pinkList.Count;i++)
            {
                pinkCount+= pinkList[0].Count+ pinkList[1].Count+ pinkList[2].Count+ pinkList[3].Count+ pinkList[4].Count+ pinkList[5].Count;
            }
        }
       
    }
}