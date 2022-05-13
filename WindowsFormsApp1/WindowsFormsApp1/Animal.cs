using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Animal
    {
        public string name { get; set; }
        public string eat { get; set; }
        [IgnorSearch]
        public Boolean isDangerous { get; set; }
        public Animal(string name, string eat, Boolean isDangerous)
        {
            this.name = name;
            this.eat = eat;
            this.isDangerous = isDangerous;
        }
    }
}
