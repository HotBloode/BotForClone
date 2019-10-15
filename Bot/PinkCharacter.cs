using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    public class PinkCharacter : BaseCharacter, ICharacter
    {
        public int[] SсhemeCraft { get; set; }
        PinkCharacter()
        {
            SсhemeCraft = new int[4];
        }
    }
}
