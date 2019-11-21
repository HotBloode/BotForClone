using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
  public  class BaseCharacter:IBaseCharacter
    {
        public int Id { get;  set; }
        public string Name { get;  set; }       
        public string ImgUrl { get;  set; }
        public int Count { get;  set; }
        public int FakeCount { get; set; }
        public int Element { get;  set; }
        public void AddCharacter(int count)
        {
            Count += count;
        }
        public void DelCharacter(int count)
        {
            Count -= count;
        }
        public List<string> Search { get; set; }
        public BaseCharacter()
        {
            Search = new List<string>(7);
        }
    }
}
