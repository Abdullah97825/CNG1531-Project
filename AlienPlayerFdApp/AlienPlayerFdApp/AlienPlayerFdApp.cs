// **************************************************************************************************
//		CAlienPlayerFdApp
//
//		generated
//			by		: 	Simulation Generator (SimGe) v.0.3.3
//			at		: 	Tuesday, January 4, 2022 8:12:38 AM
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
    public partial class CAlienPlayerFdApp : Racon.CGenericFederate
    {
        #region Declarations
        public EncounterSimulator.Som.FederateSom Som;
        private CSimulationManager simulationManager;
        #endregion //Declarations

        #region Constructor
        public CAlienPlayerFdApp() : base(RTILibraryType.HLA1516e_OpenRti)
        {
            // Create and Attach Som to federate
            Som = new EncounterSimulator.Som.FederateSom();
            SetSom(Som);
        }

        public CAlienPlayerFdApp(CSimulationManager manager) : base(RTILibraryType.HLA1516e_OpenRti)
        {
            // Create and Attach Som to federate
            Som = new EncounterSimulator.Som.FederateSom();
            SetSom(Som);
            simulationManager = manager;
        }
        #endregion //Constructor

        public bool SendMessage(string msg)  
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n######### Sending message now #########");
            // initialize interaction 
            HlaInteraction message = new Racon.RtiLayer.HlaInteraction(Som.PacketIC, "Packet");

            try
            {
                // Add Values
                message.AddParameterValue(Som.PacketIC.playerID, "alienPlayer1");
                message.AddParameterValue(Som.PacketIC.message, msg); // String - may not be used
                message.AddParameterValue(Som.PacketIC.timeStamp, DateTime.Now);

                if (msg == "Alien player is ready!")
                {
                    message.AddParameterValue(Som.PacketIC.isStatus, true);
                }

                Console.WriteLine("Sender: alienPlayer1\nMessage: " + msg);
                Console.WriteLine("#######################################\n");
                Console.ResetColor();
                return SendInteraction(message, "");
            }
            catch (Exception)
            {
                return false;
            }
            // end send special message to federation

        }

        public void updateValues()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n>>>> Updating attributes...");
            Program.encapsulatedAlienPlayerObject.AddAttributeValue(Som.AlienPlayerOC.healthPoints, Program.alienPlayer.healthPoints);
            UpdateAttributeValues(Program.encapsulatedAlienPlayerObject, Tags.updateReflectTag);
            Console.ResetColor();
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
            //throw new NotImplementedException("FdAmb_FederationExecutionsReported");
            #endregion //User Code
        }
        // FdAmb_OnSynchronizationPointRegistrationConfirmedHandler
        public override void FdAmb_OnSynchronizationPointRegistrationConfirmedHandler(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_OnSynchronizationPointRegistrationConfirmedHandler(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_OnSynchronizationPointRegistrationConfirmedHandler");
            #endregion //User Code
        }
        // FdAmb_OnSynchronizationPointRegistrationFailedHandler
        public override void FdAmb_OnSynchronizationPointRegistrationFailedHandler(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_OnSynchronizationPointRegistrationFailedHandler(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_OnSynchronizationPointRegistrationFailedHandler");
            #endregion //User Code
        }
        // FdAmb_SynchronizationPointAnnounced
        public override void FdAmb_SynchronizationPointAnnounced(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_SynchronizationPointAnnounced(sender, data);

            #region User Code
            //throw new NotImplementedException("FdAmb_SynchronizationPointAnnounced");
            bool validInput = false;
            string input = "";
            do
            {
                Console.WriteLine(">>>> Enter (1) to announce combat readiness: ");
                input = Console.ReadLine();

                if (input == "1")
                {
                    Program.simulationManager.federate.SynchronizationPointAchieved(data.Label, true);
                    validInput = true;
                }
                else
                    Console.WriteLine(">>>> Invalid input.\n\n");
            } while (!validInput);
            #endregion //User Code
        }
        // FdAmb_FederationSynchronized
        public override void FdAmb_FederationSynchronized(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_FederationSynchronized(sender, data);

            #region User Code
            //throw new NotImplementedException("FdAmb_FederationSynchronized");
            Console.WriteLine("Federation is synchronized, all players are ready for combat.");
            Program.readyForCombat = true;
            #endregion //User Code
        }
        // FdAmb_InitiateFederateSaveHandler
        public override void FdAmb_InitiateFederateSaveHandler(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_InitiateFederateSaveHandler(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_InitiateFederateSaveHandler");
            #endregion //User Code
        }
        // FdAmb_FederationSaved
        public override void FdAmb_FederationSaved(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_FederationSaved(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_FederationSaved");
            #endregion //User Code
        }
        // FdAmb_FederationSaveStatusResponse
        public override void FdAmb_FederationSaveStatusResponse(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_FederationSaveStatusResponse(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_FederationSaveStatusResponse");
            #endregion //User Code
        }
        // FdAmb_ConfirmFederationRestorationRequestHandler
        public override void FdAmb_ConfirmFederationRestorationRequestHandler(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_ConfirmFederationRestorationRequestHandler(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_ConfirmFederationRestorationRequestHandler");
            #endregion //User Code
        }
        // FdAmb_FederationRestoreBegun
        public override void FdAmb_FederationRestoreBegun(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_FederationRestoreBegun(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_FederationRestoreBegun");
            #endregion //User Code
        }
        // FdAmb_InitiateFederateRestoreHandler
        public override void FdAmb_InitiateFederateRestoreHandler(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_InitiateFederateRestoreHandler(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_InitiateFederateRestoreHandler");
            #endregion //User Code
        }
        // FdAmb_FederationRestored
        public override void FdAmb_FederationRestored(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_FederationRestored(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_FederationRestored");
            #endregion //User Code
        }
        // FdAmb_FederationRestoreStatusResponse
        public override void FdAmb_FederationRestoreStatusResponse(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_FederationRestoreStatusResponse(sender, data);

            #region User Code
            throw new NotImplementedException("FdAmb_FederationRestoreStatusResponse");
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
            if (data.ObjectClassHandle == Som.AlienPlayerOC.Handle)
            {
                RegisterHlaObject(Program.encapsulatedAlienPlayerObject);
            }
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
            //throw new NotImplementedException("FdAmb_TurnInteractionsOffAdvisedHandler");
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

            if (data.ClassHandle == Som.HumanPlayerOC.Handle)
            {
                CHumanPlayerHlaObject newHumanPlayer = new CHumanPlayerHlaObject(data.ObjectInstance);
                newHumanPlayer.Type = Som.HumanPlayerOC;

                Program.humanPlayerObject = newHumanPlayer;

                Console.WriteLine(">>>> Human Player object discovered\n");
                RequestAttributeValueUpdate(newHumanPlayer, string.Empty);
            }
            #endregion //User Code
        }
        // FdAmb_ObjectRemovedHandler
        public override void FdAmb_ObjectRemovedHandler(object sender, HlaObjectEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_ObjectRemovedHandler(sender, data);

            #region User Code
            //throw new NotImplementedException("FdAmb_ObjectRemovedHandler");
            if (data.ObjectInstance.Handle == Program.humanPlayerObject.Handle)
            {
                Program.humanPlayerObject = null;

                Console.WriteLine(">>>> Human Player object was removed.\n");
            }
            #endregion //User Code
        }
        // FdAmb_AttributeValueUpdateRequestedHandler
        public override void FdAmb_AttributeValueUpdateRequestedHandler(object sender, HlaObjectEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_AttributeValueUpdateRequestedHandler(sender, data);

            #region User Code
            //throw new NotImplementedException("FdAmb_AttributeValueUpdateRequestedHandler");
            updateValues();
            #endregion //User Code
        }
        // FdAmb_ObjectAttributesReflectedHandler
        public override void FdAmb_ObjectAttributesReflectedHandler(object sender, HlaObjectEventArgs data)
        {
            // Call the base class handler 
            base.FdAmb_ObjectAttributesReflectedHandler(sender, data);

            #region User Code
            if (data.ObjectInstance.Handle == Program.humanPlayerObject.Handle)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(">>>> [Attributes Update] Received human player attributes update...\n");
                if (data.IsValueUpdated(Som.HumanPlayerOC.healthPoints))
                {
                    Program.humanPlayerObject.healthPoints = data.GetAttributeValue<String>(Som.HumanPlayerOC.healthPoints);
                    Console.WriteLine(">>>> [Attributes Update] Human player healthpoints are now: " + Program.humanPlayerObject.healthPoints);
                }
                Console.ResetColor();
            }
            #endregion //User Code
        }
        // FdAmb_InteractionReceivedHandler
        public override void FdAmb_InteractionReceivedHandler(object sender, HlaInteractionEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_InteractionReceivedHandler(sender, data);

            #region User Code
            //throw new NotImplementedException("FdAmb_InteractionReceivedHandler");

            //Checking the interaction class handle (in case we have different ones)
            if (data.Interaction.ClassHandle == Som.PacketIC.Handle)
            {
                string senderID = ""; // sender id. we use this later.
                string msg = ""; //may never be used bc we are rethinking coordinates.
                var theTimeStamp = new DateTime();
                bool statusMessage = false;

                // get parameter values by iterating through parameter set
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

                if (senderID == "humanPlayer1")
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (senderID == "encounter1")
                    Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("##################\n" +
                    "Interaction received:\n sender: " + senderID 
                    + "\nmessage: " + msg 
                    + "\ntimestamp: " + theTimeStamp 
                    + "\nStatus Message: " + statusMessage 
                    +"\n##################");
                Console.ResetColor();

                //Handling attack messages
                if (senderID == "humanPlayer1")
                {
                    if (!statusMessage)
                    {
                        string[] attackDetails = msg.Split(',');

                        Program.alienPlayer.healthPoints = (Int32.Parse(Program.alienPlayer.healthPoints) - Int32.Parse(attackDetails[1])).ToString();
                        updateValues();
                        Console.WriteLine("\n>>>>New alien player HP: " + Program.alienPlayer.healthPoints);

                        //checkPlayerStatus();
                    }
                }
                else if(senderID == "encounter1")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    if (msg == "Encounter ended!")
                    {
                        Console.WriteLine(">>>>Encounter has ended...");
                        Program.encounterOngoing = false;
                    }
                    Console.ResetColor();
                }
                #endregion //User Code
            }
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
