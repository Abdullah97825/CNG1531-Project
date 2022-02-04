// **************************************************************************************************
//		CSimulationManager
//
//		generated
//			by		: 	Simulation Generator (SimGe) v.0.3.3
//			at		: 	Monday, December 27, 2021 9:52:10 PM
//		compatible with		: 	RACoN v.0.0.2.5
//
//		copyright		: 	(C) 
//		email			: 	
// **************************************************************************************************
/// <summary>
/// The Simulation Manager manages the (multiple) federation execution(s) and the (multiple instances of) joined federate(s).
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
    public class CSimulationManager
    {
        #region Declarations
        // Communication layer related structures
        public CHumanPlayerFdApp federate; //Application-specific federate 

        // Local data structures
        // TODO: user-defined data structures are declared here
        public CHumanPlayerHlaObject humanPlayer;
        public CAlienPlayerHlaObject alienPlayer;
        #endregion //Declarations

        #region Constructor
        public CSimulationManager()
        {
            // Initialize the application-specific federate
            federate = new CHumanPlayerFdApp(this);
            // Initialize the federation execution
            federate.FederationExecution.Name = "EncounterSimulator";
            federate.FederationExecution.FederateType = "NewFederate";
            federate.FederationExecution.ConnectionSettings = "rti://127.0.0.1";
            // Handle RTI type variation
            initialize();

            
        }
        #endregion //Constructor

        #region Methods
        // Handles naming variation according to HLA specification
        private void initialize()
        {
            string file;
            string filePath;
            switch (federate.RTILibrary)
            {
                case RTILibraryType.HLA13_DMSO:
                case RTILibraryType.HLA13_Portico:
                case RTILibraryType.HLA13_OpenRti:
                    federate.Som.HumanPlayerOC.Name = "objectRoot.HumanPlayer";
                    federate.Som.HumanPlayerOC.PrivilegeToDelete.Name = "privilegeToDelete";
                    federate.Som.AlienPlayerOC.Name = "objectRoot.AlienPlayer";
                    federate.Som.AlienPlayerOC.PrivilegeToDelete.Name = "privilegeToDelete";
                    federate.Som.EncounterOC.Name = "objectRoot.Encounter";
                    federate.Som.EncounterOC.PrivilegeToDelete.Name = "privilegeToDelete";
                    federate.Som.PacketIC.Name = "interactionRoot.Packet";
                    //federate.FederationExecution.FDD = @"C:\Abood\Metu NCC\Masters\2nd-Semester\CNG1531\Project\EncounterSimulation\EncounterFdApp\EncounterFdApp\Som\EncounterSimulatorFOM.fed";
                    file = "EncounterSimulatorFOM.fed";
                    filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\..\Som\EncounterSimulatorFOM.fed"));
                    federate.FederationExecution.FDD = @filePath;
                    break;
                case RTILibraryType.HLA1516e_Portico:
                case RTILibraryType.HLA1516e_OpenRti:
                    federate.Som.HumanPlayerOC.Name = "HLAobjectRoot.HumanPlayer";
                    federate.Som.HumanPlayerOC.PrivilegeToDelete.Name = "HLAprivilegeToDeleteObject";
                    federate.Som.AlienPlayerOC.Name = "HLAobjectRoot.AlienPlayer";
                    federate.Som.AlienPlayerOC.PrivilegeToDelete.Name = "HLAprivilegeToDeleteObject";
                    federate.Som.EncounterOC.Name = "HLAobjectRoot.Encounter";
                    federate.Som.EncounterOC.PrivilegeToDelete.Name = "HLAprivilegeToDeleteObject";
                    federate.Som.PacketIC.Name = "HLAinteractionRoot.Packet";
                    //federate.FederationExecution.FDD = @"C:\Abood\Metu NCC\Masters\2nd-Semester\CNG1531\Project\EncounterSimulation\EncounterFdApp\EncounterFdApp\Som\EncounterSimulatorFOM.xml";
                    file = "EncounterSimulatorFOM.xml";
                    filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\..\Som\EncounterSimulatorFOM.xml"));
                    federate.FederationExecution.FDD = @filePath;
                    break;
            }
        }
        #endregion //Methods
    }
}
