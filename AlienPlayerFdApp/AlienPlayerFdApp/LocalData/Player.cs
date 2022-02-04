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
            int attackNumber = random.Next(5);
            string message;

            message = attacksList[attackNumber].AttackName + "," + (attacksList[attackNumber].DamageValue).ToString();

            return message;
        }

        public void registerAttacksList()
        {
            attacksList.Add(new Attack("Slash Attack", 110));
            attacksList.Add(new Attack("Poison Attack", 30));
            attacksList.Add(new Attack("Jaw Attack", 50));
            attacksList.Add(new Attack("Thorn Projectiles Attack", 60));
            attacksList.Add(new Attack("Screech Attack", 20));   //5 attacks
        }

    }
}

    
