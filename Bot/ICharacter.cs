﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    interface ICharacter:IBaseCharacter
    {       
        int CraftDifficulty { get; set; }
        int[] SсhemeCraft { get; }
    }
}
