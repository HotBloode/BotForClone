﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
   public  class RedCharacter : BaseCharacter, ICharacter
    {        
        public int[] SсhemeCraft { get; set; }
        RedCharacter()
        {
            SсhemeCraft = new int [5];
        }

    }
}