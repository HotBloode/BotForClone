using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    public class GoldCharacter :BaseCharacter, ICharacter
    {
        public int[] SсhemeCraft { get; set; }
        public GoldCharacter()
        {
            SсhemeCraft = new int[6];
        }

    }
}
