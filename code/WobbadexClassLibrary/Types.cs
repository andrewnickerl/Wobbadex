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
                    VsFighting = 2;
                    VsBug = 2;
                    VsGhost = .5;
                    VsPsychic = 0;
                    VsDark = .5;
                    VsFairy = 2;
                    break;
                case TypeNames.Dragon:
                    VsFire = .5;
                    VsWater = .5;
                    VsGrass = .5;
                    VsElectric = .5;
                    VsIce = 2;
                    VsDragon = 2;
                    VsFairy = 2;
                    break;
                case TypeNames.Electric:
                    VsFlying = .5;
                    VsGround = 2;
                    VsElectric = .5;
                    VsSteel = .5;
                    break;
                case TypeNames.Fairy:
                    VsFighting = .5;
                    VsPoison = 2;
                    VsBug = .5;
                    VsSteel = 2;
                    VsDragon = 0;
                    VsDark = .5;
                    break;
                case TypeNames.Fighting:
                    VsFlying = 2;
                    VsRock = .5;
                    VsBug = .5;
                    VsPsychic = 2;
                    VsDark = .5;
                    VsFairy = 2;
                    break;
                case TypeNames.Fire:
                    VsGround = 2;
                    VsRock = 2;
                    VsBug = .5;
                    VsSteel = .5;
                    VsFire = .5;
                    VsWater = 2;
                    VsGrass = .5;
                    VsIce = .5;
                    VsFairy = .5;
                    break;
                case TypeNames.Flying:
                    VsFighting = .5;
                    VsGround = 0;
                    VsRock = 2;
                    VsBug = .5;
                    VsGrass = .5;
                    VsElectric = 2;
                    VsIce = 2;
                    break;
                case TypeNames.Ghost:
                    VsNormal = 0;
                    VsFighting = 0;
                    VsPoison = .5;
                    VsBug = .5;
                    VsGhost = 2;
                    VsDark = 2;
                    break;
                case TypeNames.Grass:
                    VsFlying = 2;
                    VsPoison = 2;
                    VsGround = .5;
                    VsBug = 2;
                    VsFire = 2;
                    VsWater = .5;
                    VsElectric = .5;
                    VsIce = 2;
                    VsGrass = .5;
                    break;
                case TypeNames.Ground:
                    VsPoison = .5;
                    VsRock = .5;
                    VsWater = 2;
                    VsGrass = 2;
                    VsElectric = 0;
                    VsIce = 2;
                    break;
                case TypeNames.Ice:
                    VsFighting = 2;
                    VsRock = 2;
                    VsSteel = 2;
                    VsFire = 2;
                    VsIce = .5;
                    break;
                case TypeNames.Normal:
                    VsFighting = 2;
                    VsGhost = 0;
                    break;
                case TypeNames.Poison:
                    VsPoison = .5;
                    VsFighting = .5;
                    VsGround = 2;
                    VsBug = .5;
                    VsGrass = .5;
                    VsPsychic = 2;
                    VsFairy = .5;
                    break;
                case TypeNames.Psychic:
                    VsFighting = .5;
                    VsBug = 2;
                    VsGhost = 2;
                    VsPsychic = .5;
                    VsDark = 2;
                    break;
                case TypeNames.Rock:
                    VsNormal = .5;
                    VsFighting = 2;
                    VsFlying = .5;
                    VsPoison = .5;
                    VsGround = 2;
                    VsSteel = 2;
                    VsFire = .5;
                    VsWater = 2;
                    VsGrass = 2;
                    break;
                case TypeNames.Steel:
                    VsNormal = .5;
                    VsFighting = 2;
                    VsFlying = .5;
                    VsPoison = 0;
                    VsGround = 2;
                    VsRock = .5;
                    VsBug = .5;
                    VsSteel = .5;
                    VsFire = 2;
                    VsGrass = .5;
                    VsPsychic = .5;
                    VsDragon = .5;
                    VsIce = .5;
                    VsFairy = .5;
                    break;
                case TypeNames.Water:
                    VsSteel = .5;
                    VsFire = .5;
                    VsWater = .5;
                    VsGrass = 2;
                    VsElectric = 2;
                    VsIce = .5;
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