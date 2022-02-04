// **************************************************************************************************
//		CPacketIC
//
//		generated
//			by		: 	Simulation Generator (SimGe) v.0.3.3
//			at		: 	Monday, January 24, 2022 2:51:58 PM
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
    public HlaParameter isStatus;
    public HlaParameter timeStamp;
    public HlaParameter message;
    public HlaParameter playerID;
    #endregion //Declarations
    
    #region Constructor
    public CPacketIC() : base()
    {
      // Initialize Class Properties
      Name = "HLAinteractionRoot.Packet";
      ClassPS = PSKind.PublishSubscribe;
      
      // Create Parameters
      // isStatus
      isStatus = new HlaParameter("isStatus");
      Parameters.Add(isStatus);
      // timeStamp
      timeStamp = new HlaParameter("timeStamp");
      Parameters.Add(timeStamp);
      // message
      message = new HlaParameter("message");
      Parameters.Add(message);
      // playerID
      playerID = new HlaParameter("playerID");
      Parameters.Add(playerID);
    }
    #endregion //Constructor
  }
}
