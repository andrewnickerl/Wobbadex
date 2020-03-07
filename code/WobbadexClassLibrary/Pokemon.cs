using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using static WobbadexClassLibrary.Enumerations;

namespace WobbadexClassLibrary
{
    public class Pokemon
    {
        public string Name { get; set; }
        public Types Types { get; set; }
        public List<string> Abilities { get; set; }
        public List<Pokemon> Evolutions { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAtk { get; set; }
        public int SpDef { get; set; }
        public int Speed { get; set; }
        public List<Move> MoveList { get; set; }
        public Bitmap Sprite { get; set; }
    }
}