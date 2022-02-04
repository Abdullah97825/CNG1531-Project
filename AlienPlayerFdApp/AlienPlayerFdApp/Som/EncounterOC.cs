// **************************************************************************************************
//		CEncounterOC
//
//		generated
//			by		: 	Simulation Generator (SimGe) v.0.3.3
//			at		: 	Wednesday, February 2, 2022 11:09:00 PM
//		compatible with		: 	RACoN v.0.0.2.5
//
//		copyright		: 	(C) 
//		email			: 	
// **************************************************************************************************
/// <summary>
/// This class is extended from the object model of RACoN API
/// </summary>

// System
using System;
using System.Collections.Generic; // for List
// Racon
using Racon;
using Racon.RtiLayer;
// Application
using EncounterSimulator.Som;


namespace EncounterSimulator.Som
{
  public class CEncounterOC : HlaObjectClass
  {
    #region Declarations
    public HlaAttribute alienPlayer;
    public HlaAttribute humanPlayer;
    public HlaAttribute logs;
    public HlaAttribute encounterID;
    #endregion //Declarations
    
    #region Constructor
    public CEncounterOC() : base()
    {
      // Initialize Class Properties
      Name = "HLAobjectRoot.Encounter";
      ClassPS = PSKind.PublishSubscribe;
      
      // Create Attributes
      // alienPlayer
      alienPlayer = new HlaAttribute("alienPlayer", PSKind.PublishSubscribe);
      Attributes.Add(alienPlayer);
      // humanPlayer
      humanPlayer = new HlaAttribute("humanPlayer", PSKind.PublishSubscribe);
      Attributes.Add(humanPlayer);
      // logs
      logs = new HlaAttribute("logs", PSKind.PublishSubscribe);
      Attributes.Add(logs);
      // encounterID
      encounterID = new HlaAttribute("encounterID", PSKind.PublishSubscribe);
      Attributes.Add(encounterID);
    }
    #endregion //Constructor
  }
}
