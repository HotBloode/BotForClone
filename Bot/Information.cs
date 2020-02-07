using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    class Information
    {
        int countAllLand;
        int countAllFire;
        int countAllLightning;
        int countAllShine;
        int countAllDark;
        int countWater;
        int countAll;

        int RealCountLand;
        int RealCountFire;
        int RealCountLightning;
        int RealCountShine;
        int RealCountDark;
        int RealCountWater;
        int RealcountAll;


        public void InfoPage<T>(
        Label first,
        Label second,
        Label third,
        Label fourth,
        Label fifth,
        Label sixth,
        Label all,
        Label realFirst,
        Label realSecond,
        Label realThird,
        Label realFourth,
        Label realFifth,
        Label realSixth,
        Label realAll,
        List<T> list) where T : BaseCharacter
        {
            countAllLand = 0;
            countAllFire = 0;
            countAllLightning = 0;
            countAllShine = 0;
            countAllDark = 0;
            countWater = 0;
            countAll = 0;

            if (list[0] is BlueCharacter)
            {
                countAllLand = -1;
                countAllFire = -1;
                countAllLightning = -1;
                countAllShine = -1;
                countAllDark = -1;
                countWater = -2;

                RealCountLand = list[5].Count;
                RealCountFire = list[3].Count;
                RealCountLightning = list[4].Count;
                RealCountShine = list[1].Count;;
                RealCountDark = list[2].Count;
                RealCountWater = list[0].Count;
                RealcountAll= list[6].Count;


            }
            if(list[0] is PinkCharacter)
            {
                countAllLand = -1;
                countAllFire = -1;
                countAllLightning = -1;
                countAllShine = -1;
                countAllDark = -1;
                countWater = -1;

                RealCountLand = list[5].Count;
                RealCountFire = list[3].Count;
                RealCountLightning = list[4].Count;
                RealCountShine = list[1].Count;
                RealCountDark = list[2].Count;
                RealCountWater = list[0].Count;
                RealcountAll = RealCountLand+ RealCountFire+ RealCountLightning+ RealCountShine+ RealCountDark+ RealCountWater;
            }
            if (list[0] is GoldCharacter)
            {
                countAllLand = 0;
                countAllFire = 0;
                countAllLightning = 0;
                countAllShine = 0;
                countAllDark = 0;
                countWater = 0;

                RealCountLand = 0;
                RealCountFire = 0;
                RealCountLightning = 0;
                RealCountShine = 0;
                RealCountDark = 0;
                RealCountWater = 0;

                for (int i = 1; i < list.Count; i++)
                {
                    switch (list[i].Element)
                    {

                        case 0: RealCountLightning += list[i].Count; break;
                        case 1: RealCountLightning += list[i].Count; break;
                        case 2: RealCountLand += list[i].Count; break;
                        case 3: RealCountWater += list[i].Count; break;
                        case 4: RealCountShine += list[i].Count; break;
                        case 5: RealCountDark += list[i].Count; break;

                    }
                }
                RealcountAll = RealCountLand + RealCountFire + RealCountLightning + RealCountShine + RealCountDark + RealCountWater;
            }
            for (int i = 0; i < list.Count; i++)
            {
                switch (list[i].Element)
                {

                    case 0:
                        {
                            countAllLightning++;
                            break;
                        }
                    case 1:
                        {
                            countAllLand++;
                            break;
                        }
                    case 2:
                        {
                            countAllFire++;
                            break;
                        }
                    case 3:
                        {
                            countWater++;
                            break;
                        }
                    case 4:
                        {
                            countAllShine++;
                            break;
                        }
                    case 5:
                        {
                            countAllDark++;
                            break;
                        }
                }

            }

            countAll = countAllLightning + countAllLand + countAllFire + countWater + countAllShine + countAllDark;
            first.Text = "К-во персонажей стихии Молнии: " + (countAllLightning);
            second.Text = "К-во персонажей стихии Земли: " + (countAllLand);
            third.Text = "К-во персонажей стихии Огня: " + (countAllFire);
            fourth.Text = "К-во персонажей стихии Воды: " + (countWater);
            fifth.Text = "К-во персонажей стихии Света: " + (countAllShine);
            sixth.Text = "К-во персонажей стихии Тьмы: " + (countAllDark);
            all.Text = "К-во персонажей всего: " + countAll;

            realFirst.Text = "Реальное к-во персонажей Земли: " + RealCountLand;
            realSecond.Text = "Реальное к-во персонажей Огня: " + RealCountFire;
            realThird.Text = "Реальное к-во персонажей Молнии: " + RealCountLightning;
            realFourth.Text = "Реальное к-во персонажей Света: " + RealCountShine;
            realFifth.Text = "Реальное к-во персонажей Тьмы: " + RealCountDark;
            realSixth.Text = "Реальное к-во персонажей Воды: " + RealCountWater;
            realAll.Text = "Реальное к-во персонажей всего: " + RealcountAll;
        }

    }
}
