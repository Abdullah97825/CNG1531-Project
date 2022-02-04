using System;
using Racon;
using Racon.RtiLayer;
using System.ComponentModel;

using EncounterSimulator.Som;
using System.Collections.Generic;

namespace EncounterSimulator
{
    class Program
    {

        //Creating the simulation manager
        public static EncounterSimulator.CSimulationManager simulationManager = new EncounterSimulator.CSimulationManager();

        public static EncounterSimulator.Som.CEncounterHlaObject encounter;
        public static CEncounterFdApp federate;

        public static int encounterID = 1;

        public static int joinedPlayers = 0;

        public static bool encounterReady = false;

        public static bool encounterIsOver = false;
        
        public static List<Attack> humanPlayerLogs = new List<Attack>();
        public static List<Attack> alienPlayerLogs = new List<Attack>();

        public static CHumanPlayerHlaObject humanPlayer = new CHumanPlayerHlaObject(simulationManager.federate.Som.HumanPlayerOC);
        public static CAlienPlayerHlaObject alienPlayer = new CAlienPlayerHlaObject(simulationManager.federate.Som.AlienPlayerOC);


        static void Main(string[] args)
        {
            Console.Title = "Encounter Federate";
            Console.ResetColor();

            federate = new CEncounterFdApp();
            encounter = new CEncounterHlaObject(federate.Som.EncounterOC);
            initializeEncounter();


            Console.WriteLine("----");
            simulationManager.federate.StatusMessageChanged += Federate_StatusMessageChanged;
            simulationManager.federate.LogLevel = LogLevel.ALL;
            Console.WriteLine("----");

            simulationManager.federate.FederationExecution.FederateName = encounter.encounterName;

            // Initialization  and joining the federation
            bool initialize = simulationManager.federate.InitializeFederation(simulationManager.federate.FederationExecution);

            simulationManager.federate.DeclareCapability();


            Console.WriteLine("Federate is running..\n" + initialize);

            // ********************//
            // Main Simulation Loop//
            // ********************//
            Console.WriteLine("----------Main Simulation Loop----------");

            Console.WriteLine("Encounter is ongoing!");


            // send ready message to subscribers
            if (simulationManager.federate.SendMessage("Encounter is ready!"))
                Console.WriteLine(">>>> Ready Message sent successfully! \n--");
            else
                Console.WriteLine(">>>> Ready Message NOT sent successfully! \n--");

            

            Console.WriteLine(">>>> federate is checking callbacks...waiting for players to announce that they are ready...\n");
            do
            {

                if (simulationManager.federate.FederateState.HasFlag(Racon.FederateStates.JOINED))
                    simulationManager.federate.Run();
            } while (joinedPlayers != 2);

            simulationManager.federate.RegisterFederationSynchronizationPoint("readyForCombat", "Report combat readiness!");

            Console.WriteLine(">>>> federate is checking callbacks...waiting for players to announce combat readiness...\n");
            do
            {

                if (simulationManager.federate.FederateState.HasFlag(Racon.FederateStates.JOINED))
                    simulationManager.federate.Run();
            } while (!encounterReady);


            Console.WriteLine(">>>> Starting the encounter...\n...\n");

            if (simulationManager.federate.SendMessage("Encounter has started!"))
                Console.WriteLine(">>>> Encounter has started!\n");
            else
                Console.WriteLine(">>>> Encounter failed to start! \n--");

            do
            {

                if (simulationManager.federate.FederateState.HasFlag(Racon.FederateStates.JOINED))
                    simulationManager.federate.Run();
            } while (!encounterIsOver);

            playersPerformance();


            bool finalize = simulationManager.federate.FinalizeFederation(simulationManager.federate.FederationExecution, ResignAction.NO_ACTION);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }


        private void Federate_FederateStateChanged(object sender, Racon.CFederateStateEventArgs e)
        {
            switch (e.FdState)
            {
                case Racon.FederateStates.NOTCONNECTED:
                    Console.WriteLine("NOTCONNECTED!");
                    break;
                case Racon.FederateStates.CONNECTED | Racon.FederateStates.JOINED | Racon.FederateStates.FREERUN:
                    Console.WriteLine("CONNECTED|JOINED|FREERUN!");
                    break;
                default:
                    break;
            }
        }

        private static void Federate_StatusMessageChanged(object sender, EventArgs e)
        {
            Console.ResetColor();
            Console.WriteLine((sender as EncounterSimulator.CEncounterFdApp).StatusMessage);
        }


        private static void initializeEncounter()
        {
            encounter.encounterName = "Encounter" + DateTime.Now.Second.ToString();
        }

        private static void playersPerformance()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n##########################################################################");
            Console.WriteLine("########################## Players' Performance ##########################");
            Console.WriteLine("##########################################################################");
            humanPlayerPerformance();
            alienPlayerPerformance();
            Console.WriteLine("##########################################################################");
            Console.ResetColor();
        }

        private static void humanPlayerPerformance()
        {
            int totalDamage = 0;
            int numOfAttacks = humanPlayerLogs.Count;
            var encounterLength = (humanPlayerLogs[numOfAttacks - 1].Ts - humanPlayerLogs[0].Ts).TotalSeconds;

            foreach (var attack in humanPlayerLogs)
            {
                totalDamage += attack.DamageValue;
            }

            Console.WriteLine("\n\n-----------------human Player-----------------");
            Console.WriteLine("Total damage dealt: " + totalDamage.ToString());
            Console.WriteLine("DPS (Damage Per Second): " + (totalDamage / encounterLength).ToString());
            Console.WriteLine("Total number of attacks: " + numOfAttacks.ToString());
            Console.WriteLine("Damage per attack ratio: " + (totalDamage / numOfAttacks).ToString());
            Console.WriteLine("----------------------------------------------");

        }

        private static void alienPlayerPerformance()
        {
            int totalDamage = 0;
            int numOfAttacks = alienPlayerLogs.Count;
            var encounterLength = (alienPlayerLogs[numOfAttacks - 1].Ts - alienPlayerLogs[0].Ts).TotalSeconds;

            foreach (var attack in alienPlayerLogs)
            {
                totalDamage += attack.DamageValue;
            }

            Console.WriteLine("\n\n-----------------Alien Player-----------------");
            Console.WriteLine("Total damage dealt: " + totalDamage.ToString());
            Console.WriteLine("DPS (Damage Per Second): " + (totalDamage / encounterLength).ToString());
            Console.WriteLine("Total number of attacks: " + numOfAttacks.ToString());
            Console.WriteLine("Damage per attack ratio: " + (totalDamage / numOfAttacks).ToString());
            Console.WriteLine("----------------------------------------------");
        }



    }
}
