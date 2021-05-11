namespace HunterSim
{
    public enum Talent
    {
        // Beast Mastery
        ImprovedAspectOfTheHawk, // While Aspect of the Hawk is active, all normal ranged attacks have a 1% chance of increasing ranged attack speed by 30% for 12 sec
        EnduranceTraining, // Increases the health of your pets by 3%
        ImprovedEyesOfTheBeast, // Increases the duragion of your Eyes of the Beast by 30 sec
        ImprovedAspectOfTheMonkey, // Increases the Dodge bonus of your Aspect of the Monkey by 1%
        ThickHide, // Increases the Armor rating of your pets by 10%
        ImprovedRevivePet, // Revive Pet's casting time is reduced by 3 sec, mana cost is reduced by 20%, and increses the health of your pet returns with by an additional 15%
        Pathfinding, // Increases the speed bonus of your Aspect of the Cheetah and Aspect of the Pack by 3%
        BestialSwiftness, // Increases the outdoor movement speed of your pets by 30%
        UnleashedFury, // Increases the damage done by your pets by 4%
        ImprovedMendPet, // Gives the mend Pet spell a 15% chance of cleansing 1 Curse, Disease, Magic or Poison effect from teh pet each tick
        Ferocity, // Increases the critical strike chance of your pets by 3%
        SpiritBond, // While your pet is active, you and your pet will regenerate 1% of total health every 10 sec
        Intimidation, // Command your pet to intimidate the target on the next successful melee attack, causing a high amount of threat and stunning the target for 3 sec (1 min CD)
        BestialDiscipline, // Increases the Focus regeneration of your pets by 10%
        Frenzy, // Gives your pet a 20% chance to gain a 30% attack speed increase for 8 sec after dealing a critical strike
        BestialWrath, // Send your pet into a rage causing 50% additional damage for 18 sec. While enraged, the beast does not feel pity or remorse or fear and it cannot be stopped unless killed (2 min CD)
        // Marksmanship
        ImprovedConcussiveShot, // Gives your Concussive Shot a 4% chance to stun the target for 3 sec (4% proc chance)
        Efficiency, // Reduces the Mana cost of your Shots and Stings by 2%
        LethalShots, // Increases your critical strike chance with ranged weapons by 1%
        ImprovedHuntersMark, // Increases the Ranged Attack Power bonus of your Hunter's Mark spell by 3%
        AimedShot, // An aimed shot that increases ranged damage by 70 (6 sec CD)
        ImprovedArcaneShot, // Reduces the cooldown of your Arcane Shot by 0.2 sec
        HawkEye, // Increases the range of your ranged weapons by 2 yards
        ImprovedSerpentSting, // Increases the damage done by your Serpent Sting by 2%
        MortalShots, // Increases your ranged weapon critical strike damage bonus by 6%
        ScatterShot, // A short-range shot that deals 50% weapon damaage and disorients the target for 4 sec. Any damage caused will remove the effect. Turns off your attack when used (30 sec CD)
        Barrage, // Increases the damage done by your Multi-Shot and Volley spells by 5%
        ImprovedScorpidSting, // Reduces teh Stamina of targets affected by your Scorpid Sting by 10% of the amount of Strength reduced
        RangedWeaponSpecialization, // Increases the damage you deal with ranged weapons by 1%
        TrueshotAura, // Increases the attack power of party members within 45 yards by 50. Lasts 30 mins
        // Survival
        MonsterSlaying, // Increases all damage caused against Beasts, Giants and Dragonkin targets by 1% and increases critical damage caused by an additional 1%
        HumanoidSlaying, // Increases all damaage caused against Humanoid targets by 1% and increases critical damage by an additional 1%
        Deflection, // Increases your Parry chance by 1%
        Entrapment, // Gives your Immolation Trap, Frost Trap, and Explosive Trap a 5% chance to entrap the target, preventing them from moving for 5 sec
        SavageStrikes, // Increases the critical strike chance of Raptor Strike and Mongoose Bite by 10%
        ImprovedWingClip, // Gives your Wing Clip ability a 4% chance to immobilize the target for 5 sec (proc chance 4%)
        CleverTraps, // Increases the duration of Freezing and Frost trap effects by 15% and the damage of Immolation and Explosive trap effects by 15%
        Survivalist, // Increases total health by 2%
        Deterrence, // When activated, increaes your Dodge and Parry chance by 25% for 10 sec (5 min CD)
        TrapMastery, // Decreases the chance enemies will resist trap effects by 5%
        Surefooted, // Increases hit chance by 1% and increases the chance movement impairing effects will be resisted by an additional 5%
        ImprovedFeignDeath, // Reduces teh chance your Feign Death ability will be resisted by 2%
        KillerInstinct, // Increases your critical strike chance with all attacks by 1%
        Counterattack, // A strike that becomes active after parrying an opponent's attack. This attack deals 40 damage and immobilizes the target for 5 sec. Counterattack cannot be blocked, dodged or parried (5 sec CD)
        LightningReflexes, // Increases your agility by 3%
        WyvernSting // A stinging shot that puts the target to sleep for 12 sec. Any damage will cancel the effect. When the target wakes up, the Sting causes 300 Nature damage over 12 sec. Only usable out of combat. Only one Sting per Hunter can be active on the target at a time (2 min CD)
    }
}