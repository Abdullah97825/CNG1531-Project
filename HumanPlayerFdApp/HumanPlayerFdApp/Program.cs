using System;
using Racon;
using Racon.RtiLayer;
using System.ComponentModel;

using EncounterSimulator.Som;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using EncounterFdApp.LocalData;

namespace EncounterSimulator
{
    class Program
    {
        
        //Creating the simulation manager
        public static EncounterSimulator.CSimulationManager simulationManager = new EncounterSimulator.CSimulationManager();

        public static EncounterSimulator.Som.CHumanPlayerHlaObject humanPlayerObject;
        public static EncounterSimulator.Som.CAlienPlayerHlaObject alienPlayerObject;

        public static CHumanPlayerHlaObject encapsulatedHumanPlayerObject;

        public static CPlayer humanPlayer = new CPlayer();

        public static int playerID = 1;

        public static bool readyForCombat = false;

        public static bool isAlive = true;

        public static bool encounterOngoing = true;


        //Local data
        private static List<Attack> attacks = new List<Attack>();
      

        static void Main(string[] args)
        {

            //humanPlayerFederate = new EncounterSimulator.Som.CHumanPlayerHlaObject();

            Console.Title = "Human Player Federate";
            Console.ResetColor();

            Console.WriteLine("#####################");
            simulationManager.federate.StatusMessageChanged += Federate_StatusMessageChanged;
            simulationManager.federate.LogLevel = LogLevel.ALL;
            Console.WriteLine("#####################");

            initializePlayer();

            simulationManager.federate.FederationExecution.FederateName = humanPlayer.playerID;

            bool initialize = simulationManager.federate.InitializeFederation(simulationManager.federate.FederationExecution);


            simulationManager.federate.DeclareCapability();

            Console.WriteLine("Federate is running: " + initialize);


            // *********************
            // Main Simulation Loop*
            // *********************      

            //Sending ready message
            if (simulationManager.federate.SendMessage("Human player is ready!"))
            {
                Console.WriteLine(">>>> Ready Message was sent successfully!\n");
            }
            else
            {
                Console.WriteLine(">>>> Ready Message was NOT sent successfully!\n");
            }

            // loop till the encounter is synchronized
            Console.WriteLine("\n>>>> federate is checking callbacks\n");
            do
            {
                if (simulationManager.federate.FederateState.HasFlag(Racon.FederateStates.JOINED))
                    simulationManager.federate.Run();
            } while (!readyForCombat);


            //Thread that will handle launching attacks which will allow the program to listen to
            //callbacks simultaneously
            Thread attacksLauncherThread = new Thread(Program.attacksLauncher);
            //Loop till the encounter ends
            attacksLauncherThread.Start();
            do
            {
                if (simulationManager.federate.FederateState.HasFlag(Racon.FederateStates.JOINED))
                    simulationManager.federate.Run();
            } while (isAlive && encounterOngoing);


            simulationManager.federate.DeleteObjectInstance(simulationManager.humanPlayer, Tags.deleteRemoveTag);

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
            Console.WriteLine((sender as EncounterSimulator.CHumanPlayerFdApp).StatusMessage);
        }


        private static void attacksLauncher()
        {
            while (isAlive && encounterOngoing)
            {
                launchAttack();
            }
        }

        private static void launchAttack()
        {
            Random random = new Random();
            int cooldown = random.Next(1,4);
            int attackNumber = random.Next(5);

            Thread.Sleep(TimeSpan.FromSeconds(cooldown));

            string message;

            message = humanPlayer.launchAttack();

            if (simulationManager.federate.SendMessage(message))
            {
                Console.WriteLine("Attack was successfully launched!");
            }
            else
            {
                Console.WriteLine("Failed to launch attack!");
            }
                

        }

        private static void initializePlayer()
        {
            //Generating a unique ID based on current time
            humanPlayer.playerID = DateTime.Now.Second.ToString();

            humanPlayer.healthPoints = "500";

            encapsulatedHumanPlayerObject = new CHumanPlayerHlaObject(simulationManager.federate.Som.HumanPlayerOC);
            encapsulatedHumanPlayerObject.player = humanPlayer;

            simulationManager.humanPlayer = encapsulatedHumanPlayerObject;

        }



    }
}
