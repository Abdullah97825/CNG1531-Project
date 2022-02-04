// **************************************************************************************************
//		CEncounterHlaObject
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
/// This is a wrapper class for local data structures. This class is extended from the object model of RACoN API
/// </summary>

// System
using System;
using System.Collections.Generic; // for List
// Racon
using Racon;
using Racon.RtiLayer;
// Application
using EncounterSimulator.Som;
using EncounterFdApp.LocalData;

namespace EncounterSimulator.Som
{
    public class CEncounterHlaObject : HlaObject
    {
        #region Declarations
        // TODO: Declare your local object structure here
        // Your_LocalData_Type Data;
        public string encounterName;
        #endregion //Declarations

        #region Constructor
        public CEncounterHlaObject(HlaObjectClass _type) : base(_type)
        {
            // TODO: Instantiate local data here
            // var Data = new Your_LocalData_Type();
            encounterName = "";
        }
        // Copy constructor - used in callbacks
        public CEncounterHlaObject(HlaObject _obj) : base(_obj)
        {
            // TODO: Instantiate local data here
            // var Data = new Your_LocalData_Type();
            encounterName = "";
        }
        #endregion //Constructor
    }
}
