using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static WobbadexClassLibrary.Enumerations;

namespace WobbadexClassLibrary
{
    public class Move
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public Types Type { get; set; }
        public Categories Category { get; set; }
        public int PowerPoints { get; set; }
        public int Accuracy { get; set; }
        public string LearningMethod { get; set; }
    }
}