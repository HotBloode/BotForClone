using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    interface IBaseCharacter
    {
        int Id { get;  set; }
        string Name { get;  set; }       
        string ImgUrl { get;  set; }
        int Count { get;  set; }
        int Element { get;  set; }   
        int FakeCount { get; set; }
        void AddCharacter(int count);
        void DelCharacter(int count);
        List<string> Search { get; set; }
    }

}