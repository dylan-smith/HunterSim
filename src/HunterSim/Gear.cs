using System.Collections.Generic;

namespace HunterSim
{
    public class Gear
    {
        public GearItem Head { get; set; }
        public GearItem Neck { get; set; }
        public GearItem Shoulders { get; set; }
        public GearItem Back { get; set; }
        public GearItem Chest { get; set; }
        public GearItem Wrists { get; set; }
        public GearItem MainHand { get; set; }
        public GearItem OffHand { get; set; }
        public GearItem Hands { get; set; }
        public GearItem Waist { get; set; }
        public GearItem Legs { get; set; }
        public GearItem Feet { get; set; }
        public GearItem Finger1 { get; set; }
        public GearItem Finger2 { get; set; }
        public GearItem Trinket1 { get; set; }
        public GearItem Trinket2 { get; set; }
        public GearItem Ranged { get; set; }

        public IEnumerable<GearItem> GetAllGear()
        {
            if (Head != null) yield return Head;
            if (Neck != null) yield return Neck;
            if (Shoulders != null) yield return Shoulders;
            if (Back != null) yield return Back;
            if (Chest != null) yield return Chest;
            if (Wrists != null) yield return Wrists;
            if (MainHand != null) yield return MainHand;
            if (OffHand != null) yield return OffHand;
            if (Hands != null) yield return Hands;
            if (Waist != null) yield return Waist;
            if (Legs != null) yield return Legs;
            if (Feet != null) yield return Feet;
            if (Finger1 != null) yield return Finger1;
            if (Finger2 != null) yield return Finger2;
            if (Trinket1 != null) yield return Trinket1;
            if (Trinket2 != null) yield return Trinket2;
            if (Ranged != null) yield return Ranged;
        }
    }
}
