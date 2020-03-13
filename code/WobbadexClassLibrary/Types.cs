using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static WobbadexClassLibrary.Enumerations;

namespace WobbadexClassLibrary
{
    public class Types
    {
        public Types(TypeNames type)
        {
            this.Type = type;
            //this switch sets values based off the type passed (like "Bug" right now), we'll finish filling that out later
            switch(type)
            {
                case TypeNames.Bug:
                    VsFighting = .5;
                    VsFlying = 2;
                    VsGround = .5;
                    VsRock = 2;
                    VsFire = 2;
                    VsGrass = .5;
                    break;
                case TypeNames.Dark:
                    break;
                case TypeNames.Dragon:
                    break;
                case TypeNames.Electric:
                    break;
                case TypeNames.Fairy:
                    break;
                case TypeNames.Fighting:
                    break;
                case TypeNames.Fire:
                    break;
                case TypeNames.Flying:
                    break;
                case TypeNames.Ghost:
                    break;
                case TypeNames.Grass:
                    break;
                case TypeNames.Ground:
                    break;
                case TypeNames.Ice:
                    break;
                case TypeNames.Normal:
                    break;
                case TypeNames.Poison:
                    break;
                case TypeNames.Psychic:
                    break;
                case TypeNames.Rock:
                    break;
                case TypeNames.Steel:
                    break;
                case TypeNames.Water:
                    break;
            }
                
        }
        public TypeNames Type { get; set; }
        public double VsBug { get; set; } = 1;
        public double VsDark { get; set; } = 1;
        public double VsDragon { get; set; } = 1;
        public double VsElectric { get; set; } = 1;
        public double VsFairy { get; set; } = 1;
        public double VsFighting { get; set; } = 1;
        public double VsFire { get; set; } = 1;
        public double VsFlying { get; set; } = 1;
        public double VsGhost { get; set; } = 1;
        public double VsGrass { get; set; } = 1;
        public double VsGround { get; set; } = 1;
        public double VsIce { get; set; } = 1;
        public double VsNormal { get; set; } = 1;
        public double VsPoison { get; set; } = 1;
        public double VsPsychic { get; set; } = 1;
        public double VsRock { get; set; } = 1;
        public double VsSteel { get; set; } = 1;
        public double VsWater { get; set; } = 1;
    }
}