using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using Random = UnityEngine.Random;

/*******
 * choose a mission and place the player at the Awake seesion.
 * *******/


[Serializable]
public class Mission
{
	public string start_portal;
	public GData.LocationType destination;
	[Multiline (5)] public string comment;
}

public class MissionSystem : MonoBehaviour 
{
	// static public GData.LocationType destination;
	static public bool randomly = true;
	
	//[SerializeField]
	//public Mission[] missions;

	List<String> startPoint;
	List<GData.LocationType> endPoint;

	[SerializeField]
	public Mission current_mission;
	public Mission Get_Current_Mission()
	{
		if (current_mission == null)
		{
			Awake();
		}
		return current_mission;
	}

	// mission done?
	bool isCompleted = false ;
	public bool IsCompleted()
	{
		return isCompleted;
	}

	void Awake()
	{
		startPoint = new List<string>();
		endPoint = new List<GData.LocationType>();

		// find all the start point and endpoint
		Portal_Sensor[] pSensors = GameObject.FindObjectsOfType<Portal_Sensor>();
		foreach(Portal_Sensor p in pSensors)
		{
			// startpoint
			if (!startPoint.Contains(p.name))
			{
				startPoint.Add(p.name);
			}

			// endpoint
			foreach(GData.LocationType lo in p.locations)
			{
				if (!endPoint.Contains(lo))
				{
					endPoint.Add(lo);
				}
			}
		}
	}

	public void Random_Destination()
	{
		// randomly choose a mission
		// current_mission = missions[Random.Range(0,missions.Length)]; 

		current_mission = new Mission();
		current_mission.start_portal = startPoint[Random.Range(0,startPoint.Count)];

		// the destination can not be the start point's location
		List<GData.LocationType> locs 
			= new List<GData.LocationType>(GameObject.FindObjectOfType<PortalSystem>().
			                               Get_Protals()[current_mission.start_portal].locations);
		Debug.Log("Locs : " + locs.Count);
		current_mission.destination = endPoint[Random.Range(0,endPoint.Count)];
		while(locs.Contains(current_mission.destination))
		{
			current_mission.destination = endPoint[Random.Range(0,endPoint.Count)];
		}


		current_mission.comment = "Find a way to " + current_mission.destination.ToString();
		current_mission.comment = current_mission.comment.Replace("_", " ");

		// place the player
		PortalSystem sys = GameObject.FindObjectOfType<PortalSystem>();
		sys.Place_Player(current_mission.start_portal);

	}

	
	// **********************************************************************************
	// Called by sensor
	// **********************************************************************************
	public void Mission_Complete()
	{
		isCompleted = true;
		Debug.Log("Mission_Complete!");
	}
	



}
