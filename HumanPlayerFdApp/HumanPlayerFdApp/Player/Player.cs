using System;
using System.Collections.Generic;
using System.Text;
using EncounterSimulator;

namespace EncounterFdApp.LocalData
{
    public class CPlayer
    {

        public String healthPoints;
        public List<Attack> attacksList;
        public String playerID;


        public CPlayer()
        {
            healthPoints = "";
            attacksList = new List<Attack>(); ;
            playerID = "";

            registerAttacksList();
        }


        public String launchAttack()
        {
            Random random = new Random();
            int cooldown = random.Next(1, 4);
            int attackNumber = random.Next(5);
            string message;

            message = attacksList[attackNumber].AttackName + "," + (attacksList[attackNumber].DamageValue).ToString();

            return message;
        }

        public void registerAttacksList()
        {
            attacksList.Add(new Attack("Pistol Attack", 50));
            attacksList.Add(new Attack("Sword Attack", 100));
            attacksList.Add(new Attack("Flamethrower Attack", 70));
            attacksList.Add(new Attack("Grenade Attack", 80));
            attacksList.Add(new Attack("Fist Attack", 20));   //5 attacks
        }

    }
}

    
