// **************************************************************************************************
//		CEncounterFdApp
//
//		generated
//			by		: 	Simulation Generator (SimGe) v.0.3.3
//			at		: 	Monday, December 27, 2021 9:52:11 PM
//		compatible with		: 	RACoN v.0.0.2.5
//
//		copyright		: 	(C) 
//		email			: 	
// **************************************************************************************************
/// <summary>
/// The application specific federate that is extended from the Generic Federate Class of RACoN API
/// </summary>

// System
using System;
using System.Collections.Generic; // for List
// Racon
using Racon;
using Racon.RtiLayer;
// Application
using EncounterSimulator.Som;

namespace EncounterSimulator
{
    public partial class CEncounterFdApp : Racon.CGenericFederate
    {
        #region Declarations
        public EncounterSimulator.Som.FederateSom Som;
        #endregion //Declarations

        #region Constructor
        public CEncounterFdApp() : base(RTILibraryType.HLA1516e_OpenRti)
        {
            // Create and Attach Som to federate
            Som = new EncounterSimulator.Som.FederateSom();
            SetSom(Som);
        }
        #endregion //Constructor



        public bool SendMessage(string msg)
        {

            Console.WriteLine(">>>> Sending message now..\n");
            // initialise interaction 
            HlaInteraction message = new Racon.RtiLayer.HlaInteraction(Som.PacketIC, "Packet");
            try
            {
                // Add Values
                message.AddParameterValue(Som.PacketIC.playerID, "encounter1");
                message.AddParameterValue(Som.PacketIC.message, msg);
                message.AddParameterValue(Som.PacketIC.timeStamp, DateTime.Now);
                message.AddParameterValue(Som.PacketIC.isStatus, true);

                return SendInteraction(message, "");
            }
            catch (Exception)
            {
                return false;
            }

        }

        public void checkPlayerStatus()
        {
            int humanPlayerHP = Int32.Parse(Program.humanPlayer.healthPoints);
            int alienPlayerHP = Int32.Parse(Program.alienPlayer.healthPoints);

            if (humanPlayerHP <= 0 || alienPlayerHP <= 0)
            {
                Console.WriteLine(">>>> Encounter ended!");
                SendMessage("Encounter ended!");
                Program.encounterIsOver = true;
            }
        }


        #region Event Handlers
        #region Federate Callback Event Handlers

        #region Federation Management Callbacks
        // FdAmb_ConnectionLost
        public override void FdAmb_ConnectionLost(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_ConnectionLost(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_ConnectionLost");
            #endregion //User Code
        }
        // FdAmb_FederationExecutionsReported
        public override void FdAmb_FederationExecutionsReported(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_FederationExecutionsReported(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_FederationExecutionsReported");
            #endregion //User Code
        }
        // FdAmb_OnSynchronizationPointRegistrationConfirmedHandler
        public override void FdAmb_OnSynchronizationPointRegistrationConfirmedHandler(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_OnSynchronizationPointRegistrationConfirmedHandler(sender, data);

            #region User Code
            Console.WriteLine("Combat readiness request is accepted by RTI.");
            #endregion //User Code
        }
        // FdAmb_OnSynchronizationPointRegistrationFailedHandler
        public override void FdAmb_OnSynchronizationPointRegistrationFailedHandler(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_OnSynchronizationPointRegistrationFailedHandler(sender, data);

            #region User Code
            //throw new NotImplementedException("FdAmb_OnSynchronizationPointRegistrationFailedHandler");
            #endregion //User Code
        }
        // FdAmb_SynchronizationPointAnnounced
        public override void FdAmb_SynchronizationPointAnnounced(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_SynchronizationPointAnnounced(sender, data);

            #region User Code
            Program.simulationManager.federate.SynchronizationPointAchieved(data.Label, true);
            #endregion //User Code
        }
        // FdAmb_FederationSynchronized
        public override void FdAmb_FederationSynchronized(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_FederationSynchronized(sender, data);

            #region User Code
            Console.WriteLine(">>>>Federation is synchronized, all players are ready for combat.");
            Program.encounterReady = true;
            #endregion //User Code
        }
        #endregion //Federation Management Callbacks


        #region Declaration Management Callbacks
        // FdAmb_StartRegistrationForObjectClassAdvisedHandler
        public override void FdAmb_StartRegistrationForObjectClassAdvisedHandler(object sender, HlaDeclarationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_StartRegistrationForObjectClassAdvisedHandler(sender, data);

            #region User Code
            //throw new NotImplementedException("FdAmb_StartRegistrationForObjectClassAdvisedHandler");
            /*
            if(data.ObjectClassHandle == Som.EncounterOC.Handle)
            {
                RegisterHlaObject(Program.encounter);
            }*/
            #endregion //User Code
        }
        // FdAmb_StopRegistrationForObjectClassAdvisedHandler
        public override void FdAmb_StopRegistrationForObjectClassAdvisedHandler(object sender, HlaDeclarationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_StopRegistrationForObjectClassAdvisedHandler(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_StopRegistrationForObjectClassAdvisedHandler");
            #endregion //User Code
        }
        // FdAmb_TurnInteractionsOffAdvisedHandler
        public override void FdAmb_TurnInteractionsOffAdvisedHandler(object sender, HlaDeclarationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_TurnInteractionsOffAdvisedHandler(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_TurnInteractionsOffAdvisedHandler");
            #endregion //User Code
        }
        // FdAmb_TurnInteractionsOnAdvisedHandler
        public override void FdAmb_TurnInteractionsOnAdvisedHandler(object sender, HlaDeclarationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_TurnInteractionsOnAdvisedHandler(sender, data);

            #region User Code
            //throw new NotImplementedException("FdAmb_TurnInteractionsOnAdvisedHandler");
            #endregion //User Code
        }
        #endregion //Declaration Management Callbacks


        #region Object Management Callbacks
        // FdAmb_ObjectDiscoveredHandler
        public override void FdAmb_ObjectDiscoveredHandler(object sender, HlaObjectEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_ObjectDiscoveredHandler(sender, data);

            #region User Code
            //throw new NotImplementedException("FdAmb_ObjectDiscoveredHandler");

            if(data.ClassHandle == Som.HumanPlayerOC.Handle)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                CHumanPlayerHlaObject newHumanPlayer = new CHumanPlayerHlaObject(data.ObjectInstance);
                newHumanPlayer.Type = Som.HumanPlayerOC;

                Program.humanPlayer = newHumanPlayer;
                Program.joinedPlayers += 1;

                Console.WriteLine("\n>>>> Human Player object discovered\n");
                RequestAttributeValueUpdate(newHumanPlayer, string.Empty);
            }
            else if (data.ClassHandle == Som.AlienPlayerOC.Handle)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                CAlienPlayerHlaObject newAlienPlayer = new CAlienPlayerHlaObject(data.ObjectInstance);
                newAlienPlayer.Type = Som.HumanPlayerOC;

                Program.alienPlayer = newAlienPlayer;
                Program.joinedPlayers += 1;

                Console.WriteLine("\n>>>> Alien Player object discovered\n");
                RequestAttributeValueUpdate(newAlienPlayer, string.Empty);
            }
            Console.ResetColor();
            Console.WriteLine("\n###############\nJoined players: " + Program.joinedPlayers + "\n###############\n");
            #endregion //User Code
        }
        // FdAmb_ObjectRemovedHandler
        public override void FdAmb_ObjectRemovedHandler(object sender, HlaObjectEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_ObjectRemovedHandler(sender, data);

            #region User Code
            Console.ResetColor();
            if (data.ObjectInstance.Handle == Program.humanPlayer.Handle)
            {
                Program.humanPlayer = null;

                Console.WriteLine(">>>> Human Player object was removed.\n");
            }
            else if (data.ObjectInstance.Handle == Program.alienPlayer.Handle)
            {
                Program.alienPlayer = null;

                Console.WriteLine(">>>> Alien Player object was removed.\n");
            }
            Console.WriteLine(">>>>The encounter has ended.\n");
            SendMessage("Encounter ended!");

            Console.ResetColor();
            #endregion //User Code
        }
        // FdAmb_AttributeValueUpdateRequestedHandler
        public override void FdAmb_AttributeValueUpdateRequestedHandler(object sender, HlaObjectEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_AttributeValueUpdateRequestedHandler(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_AttributeValueUpdateRequestedHandler");
            #endregion //User Code
        }
        // FdAmb_ObjectAttributesReflectedHandler
        public override void FdAmb_ObjectAttributesReflectedHandler(object sender, HlaObjectEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_ObjectAttributesReflectedHandler(sender, data);

            #region User Code
            //throw new NotImplementedException("FdAmb_ObjectAttributesReflectedHandler");          

            if (data.ObjectInstance.Handle == Program.humanPlayer.Handle)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(">>>> [Attributes Update] Received human player attributes update...\n");
                if (data.IsValueUpdated(Som.HumanPlayerOC.healthPoints))
                {
                    Program.humanPlayer.healthPoints = data.GetAttributeValue<String>(Som.HumanPlayerOC.healthPoints);
                    Console.WriteLine(">>>> [Attributes Update] Human player healthpoints are now: " + Program.humanPlayer.healthPoints);
                }
            }
            else if (data.ObjectInstance.Handle == Program.alienPlayer.Handle)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(">>>> [Attributes Update] Received alien player attributes update...\n");
                if (data.IsValueUpdated(Som.AlienPlayerOC.healthPoints))
                {
                    Program.alienPlayer.healthPoints = data.GetAttributeValue<String>(Som.AlienPlayerOC.healthPoints);
                    Console.WriteLine(">>>> [Attributes Update] Alien player healthpoints are now: " + Program.alienPlayer.healthPoints);
                }
            }
            Console.ResetColor();
            #endregion //User Code
        }
        // FdAmb_InteractionReceivedHandler
        public override void FdAmb_InteractionReceivedHandler(object sender, HlaInteractionEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_InteractionReceivedHandler(sender, data);

            //Checking the interaction class handle (in case we have different ones)
            if (data.Interaction.ClassHandle == Som.PacketIC.Handle)
            {
                string senderID = ""; 
                string msg = ""; 
                var theTimeStamp = new DateTime();
                bool statusMessage = false;

                // Get parameter values by iterating through the received parameters
                foreach (var thisPar in data.Interaction.Parameters)
                {
                    if (Som.PacketIC.playerID.Handle == thisPar.Handle)
                        senderID = thisPar.GetValue<string>();
                    else if (Som.PacketIC.message.Handle == thisPar.Handle)
                        msg = thisPar.GetValue<string>();
                    else if (Som.PacketIC.timeStamp.Handle == thisPar.Handle)
                        theTimeStamp = thisPar.GetValue<DateTime>();
                    else if (Som.PacketIC.isStatus.Handle == thisPar.Handle)
                        statusMessage = thisPar.GetValue<bool>();
                }
                Console.ResetColor();
                if (senderID == "humanPlayer1")
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("\n\n####################################\n" +
                    "Interaction received:\n sender: " + senderID 
                    + "\nmessage: " + msg 
                    + "\ntimestamp: " + theTimeStamp 
                    + "\nStatus Message: " + statusMessage +
                    "\n####################################\n");

                //Handling attack messages
                if (Program.encounterReady)
                {                   
                    string[] attackDetails = msg.Split(',');
                    int len = attackDetails.Length;
                    //Update player logs
                    if (senderID == "humanPlayer1" && len >= 2)
                    { 
                        Program.humanPlayerLogs.Add(new Attack(attackDetails[0], Int32.Parse(attackDetails[1]), theTimeStamp));

                    }
                    else if(senderID == "alienPlayer1" && len >= 2)
                    {
                        Program.alienPlayerLogs.Add(new Attack(attackDetails[0], Int32.Parse(attackDetails[1]), theTimeStamp));

                    }
                    //Check if players are still alive after the recent attack
                    checkPlayerStatus();
                }
                //Handling ready messages
                else if(Program.joinedPlayers != 2)
                {
                    if (msg == "Human player is ready!")
                    {
                        Console.WriteLine(">>>> Human player is ready");
                    }
                    if (msg == "Alien player is ready!")
                    {
                        Console.WriteLine(">>>> Alien player is ready");
                    }
                }
                else
                {
                    Console.WriteLine("\n>>>> Waiting for players to announce combat readiness before starting the encounter.\n");
                }

                Console.ResetColor();
            }
            #region User Code
            //throw new NotImplementedException("FdAmb_InteractionReceivedHandler");
            #endregion //User Code
        }
        #endregion //Object Management Callbacks


        #region Ownership Management Callbacks
        // FdAmb_AttributeOwnershipAssumptionRequested
        public override void FdAmb_AttributeOwnershipAssumptionRequested(object sender, HlaOwnershipManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_AttributeOwnershipAssumptionRequested(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_AttributeOwnershipAssumptionRequested");
            #endregion //User Code
        }
        // FdAmb_AttributeOwnershipAcquisitionCancellationConfirmed
        public override void FdAmb_AttributeOwnershipAcquisitionCancellationConfirmed(object sender, HlaOwnershipManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_AttributeOwnershipAcquisitionCancellationConfirmed(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_AttributeOwnershipAcquisitionCancellationConfirmed");
            #endregion //User Code
        }
        // FdAmb_AttributeOwnershipUnavailable
        public override void FdAmb_AttributeOwnershipUnavailable(object sender, HlaOwnershipManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_AttributeOwnershipUnavailable(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_AttributeOwnershipUnavailable");
            #endregion //User Code
        }
        // FdAmb_AttributeOwnershipDivestitureNotified
        public override void FdAmb_AttributeOwnershipDivestitureNotified(object sender, HlaOwnershipManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_AttributeOwnershipDivestitureNotified(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_AttributeOwnershipDivestitureNotified");
            #endregion //User Code
        }
        // FdAmb_AttributeOwnershipAcquisitionNotified
        public override void FdAmb_AttributeOwnershipAcquisitionNotified(object sender, HlaOwnershipManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_AttributeOwnershipAcquisitionNotified(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_AttributeOwnershipAcquisitionNotified");
            #endregion //User Code
        }
        // FdAmb_AttributeOwnershipInformed
        public override void FdAmb_AttributeOwnershipInformed(object sender, HlaOwnershipManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_AttributeOwnershipInformed(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_AttributeOwnershipInformed");
            #endregion //User Code
        }
        // FdAmb_AttributeOwnershipReleaseRequestedHandler
        public override void FdAmb_AttributeOwnershipReleaseRequestedHandler(object sender, HlaOwnershipManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_AttributeOwnershipReleaseRequestedHandler(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_AttributeOwnershipReleaseRequestedHandler");
            #endregion //User Code
        }
        // FdAmb_RequestDivestitureConfirmation
        public override void FdAmb_RequestDivestitureConfirmation(object sender, HlaOwnershipManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_RequestDivestitureConfirmation(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_RequestDivestitureConfirmation");
            #endregion //User Code
        }
        #endregion //Ownership Management Callbacks


        #region Time Management Callbacks
        // FdAmb_TimeRegulationEnabled
        public override void FdAmb_TimeRegulationEnabled(object sender, HlaTimeManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_TimeRegulationEnabled(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_TimeRegulationEnabled");
            #endregion //User Code
        }
        // FdAmb_TimeConstrainedEnabled
        public override void FdAmb_TimeConstrainedEnabled(object sender, HlaTimeManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_TimeConstrainedEnabled(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_TimeConstrainedEnabled");
            #endregion //User Code
        }
        // FdAmb_TimeAdvanceGrant
        public override void FdAmb_TimeAdvanceGrant(object sender, HlaTimeManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_TimeAdvanceGrant(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_TimeAdvanceGrant");
            #endregion //User Code
        }
        // FdAmb_RequestRetraction
        public override void FdAmb_RequestRetraction(object sender, HlaTimeManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_RequestRetraction(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_RequestRetraction");
            #endregion //User Code
        }
        #endregion //Time Management Callbacks


        #endregion //Federate Callback Event Handlers
        #endregion //Event Handlers
    }
}
