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
            int tmp = tmpCount(min);
            if (blueList[6].Count >= 5)
            {
                for (int i = 7; i < pinkList.Count; i++)
                {
                    int tmp1 = tmpCount(pinkList[i]);
                    if (tmp1 <= tmp)
                    {
                        min = pinkList[i];
                    }
                }
            }
            return min;           
        }
        public int tmpCount(PinkCharacter pinkChamp)
        {
            //Проверка на наличие схемы крафта
            if (pinkChamp.SсhemeCraft[0] == 9999999)
            {
                return 99;
            }
            else
            {
                int tmp = 5;
                int realId = -9;
                //Присваиваем всем синим персам переменную для работы
                FakeCount();

                //Ищем "конкретного" перса в схеме крафта
                foreach (int tmpId in pinkChamp.SсhemeCraft)
                {
                    if (tmpId != 0 && tmpId != 1 && tmpId != 2 && tmpId != 3 && tmpId != 4 && tmpId != 5 && tmpId != 6)
                    {
                        realId = tmpId;
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
                            break;
                        }
                    }
                }
                for (int i = 0; i < 5; i++)
                {

                    if (blueList[pinkChamp.SсhemeCraft[i]].Id != realId)
                        switch (blueList[pinkChamp.SсhemeCraft[i]].Element)
                        {
                            case 0:
                                {
                                    if (CheckFCount(blueList[4]))
                                    {
                                        tmp--;
                                    }
                                    break;
                                }

                            case 1:
                                {
                                    if (CheckFCount(blueList[5]))
                                    {
                                        tmp--;
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    if (CheckFCount(blueList[3]))
                                    {
                                        tmp--;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    if (CheckFCount(blueList[0]))
                                    {
                                        tmp--;
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    if (CheckFCount(blueList[1]))
                                    {
                                        tmp--;
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    if (CheckFCount(blueList[2]))
                                    {
                                        tmp--;
                                    }
                                    break;
                                }
                        }
                }
                return tmp;
            }
        }

        //Функции проверки колличества персов
        public bool CheckFCount(BlueCharacter tmp)
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

        public void FakeCount()
        {
            FallBlue();
            for (int i = 0; i < blueList.Count; i++)
            {
                blueList[i].FakeCount = blueList[i].Count;
            }
        }


        //Функция подсчёта всхе видов персов
        public void FallBlue()
        {
            blueList[0].Count = 0;
            blueList[1].Count = 0;
            blueList[2].Count = 0;
            blueList[3].Count = 0;
            blueList[4].Count = 0;
            blueList[5].Count = 0;
            blueList[6].Count = 0;



            foreach (BlueCharacter curen in blueList)
            {
                switch (curen.Element)
                {
                    case 3: blueList[0].Count++; break;
                    case 4: blueList[1].Count++; break;
                    case 5: blueList[2].Count++; break;
                    case 2: blueList[3].Count++; break;
                    case 0: blueList[4].Count++; break;
                    default: blueList[5].Count++; break;
                }
            }

            blueList[0].Count = blueList[0].Count - 2;
            blueList[1].Count = blueList[1].Count - 1;
            blueList[2].Count = blueList[2].Count - 1;
            blueList[3].Count = blueList[3].Count - 1;
            blueList[4].Count = blueList[4].Count - 1;
            blueList[5].Count = blueList[5].Count - 1;
            blueList[6].Count = blueList.Count - 7;


        }
        public void FallPink()
        {
            pinkList[0].Count = 0;
            pinkList[1].Count = 0;
            pinkList[2].Count = 0;
            pinkList[3].Count = 0;
            pinkList[4].Count = 0;
            pinkList[5].Count = 0;

            foreach (PinkCharacter curen in pinkList)
            {
                switch (curen.Element)
                {
                    case 3: pinkList[0].Count++; break;
                    case 4: pinkList[1].Count++; break;
                    case 5: pinkList[2].Count++; break;
                    case 2: pinkList[3].Count++; break;
                    case 0: pinkList[4].Count++; break;
                    default: pinkList[5].Count++; break;
                }


                blueList[0].Count = blueList[0].Count - 1;
                blueList[1].Count = blueList[1].Count - 1;
                blueList[2].Count = blueList[2].Count - 1;
                blueList[3].Count = blueList[3].Count - 1;
                blueList[4].Count = blueList[4].Count - 1;
                blueList[5].Count = blueList[5].Count - 1;
            }

        }
    }
}