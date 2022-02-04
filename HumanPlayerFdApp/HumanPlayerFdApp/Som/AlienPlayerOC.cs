// **************************************************************************************************
//		CAlienPlayerOC
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
  public class CAlienPlayerOC : HlaObjectClass
  {
    #region Declarations
    public HlaAttribute healthPoints;
    public HlaAttribute attacks;
    public HlaAttribute playerID;
    #endregion //Declarations
    
    #region Constructor
    public CAlienPlayerOC() : base()
    {
      // Initialize Class Properties
      Name = "HLAobjectRoot.AlienPlayer";
      ClassPS = PSKind.PublishSubscribe;
      
      // Create Attributes
      // healthPoints
      healthPoints = new HlaAttribute("healthPoints", PSKind.PublishSubscribe);
      Attributes.Add(healthPoints);
      // attacks
      attacks = new HlaAttribute("attacks", PSKind.PublishSubscribe);
      Attributes.Add(attacks);
      // playerID
      playerID = new HlaAttribute("playerID", PSKind.PublishSubscribe);
      Attributes.Add(playerID);
    }
    #endregion //Constructor
  }
}
