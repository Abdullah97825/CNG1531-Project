using System;
using System.Collections.Generic;
using System.Text;

namespace EncounterSimulator
{
    public class Attack
    {
        private String attackName;
        private int damageValue;
        private DateTime ts;

        public Attack(String name, int value, DateTime timeStamp)
        {
            attackName = name;
            damageValue = value;
            ts = timeStamp;
        }

        public Attack(String name, int value)
        {
            attackName = name;
            damageValue = value;
        }

        public string AttackName { get => attackName; set => attackName = value; }
        public int DamageValue { get => damageValue; set => damageValue = value; }
        public DateTime Ts { get => ts; set => ts = value; }
    }
}
