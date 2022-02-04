using System;
using System.Collections.Generic;
using System.Text;

namespace EncounterSimulator
{
    class Attack
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

        public string AttackName { get => attackName; set => attackName = value; }
        public int DamageValue { get => damageValue; set => damageValue = value; }
        public DateTime Ts { get => ts; set => ts = value; }
    }
}
