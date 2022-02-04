// **************************************************************************************************
//		FederateSom
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
  public class FederateSom : Racon.ObjectModel.CObjectModel
  {
    #region Declarations
    #region SOM Declaration
    public EncounterSimulator.Som.CHumanPlayerOC HumanPlayerOC;
    public EncounterSimulator.Som.CAlienPlayerOC AlienPlayerOC;
    public EncounterSimulator.Som.CEncounterOC EncounterOC;
    public EncounterSimulator.Som.CPacketIC PacketIC;
    #endregion
    #endregion //Declarations
    
    #region Constructor
    public FederateSom() : base()
    {
      // Construct SOM
      HumanPlayerOC = new EncounterSimulator.Som.CHumanPlayerOC();
      AddToObjectModel(HumanPlayerOC);
      AlienPlayerOC = new EncounterSimulator.Som.CAlienPlayerOC();
      AddToObjectModel(AlienPlayerOC);
      EncounterOC = new EncounterSimulator.Som.CEncounterOC();
      AddToObjectModel(EncounterOC);
      PacketIC = new EncounterSimulator.Som.CPacketIC();
      AddToObjectModel(PacketIC);
    }
    #endregion //Constructor
  }
}
