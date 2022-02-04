// **************************************************************************************************
//		CPacketIC
//
//		generated
//			by		: 	Simulation Generator (SimGe) v.0.3.3
//			at		: 	Thursday, February 3, 2022 10:01:30 PM
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
  public class CPacketIC : HlaInteractionClass
  {
    #region Declarations
    public HlaParameter timeStamp;
    public HlaParameter message;
    public HlaParameter playerID;
    public HlaParameter isStatus;
    #endregion //Declarations
    
    #region Constructor
    public CPacketIC() : base()
    {
      // Initialize Class Properties
      Name = "HLAinteractionRoot.Packet";
      ClassPS = PSKind.PublishSubscribe;
      
      // Create Parameters
      // timeStamp
      timeStamp = new HlaParameter("timeStamp");
      Parameters.Add(timeStamp);
      // message
      message = new HlaParameter("message");
      Parameters.Add(message);
      // playerID
      playerID = new HlaParameter("playerID");
      Parameters.Add(playerID);
      // isStatus
      isStatus = new HlaParameter("isStatus");
      Parameters.Add(isStatus);
    }
    #endregion //Constructor
  }
}
