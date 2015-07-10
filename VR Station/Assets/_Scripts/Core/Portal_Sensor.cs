using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// ref name is gameobject's name
[RequireComponent(typeof(Collider))]
public class Portal_Sensor : Sensor 
{
	[SerializePrivateVariables]
	public List<GData.LocationType> locations;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider other) 
	{
		// if recoder session
		if (GData.playMode == GData.PlayMode.Recoder)
		{
			User_Object uo = other.gameObject.GetComponent<User_Object>();
			if (uo)
			{

                // if the destination match the mission
				MissionSystem mSys = GameObject.FindObjectOfType<MissionSystem>();

				if (locations.Contains(mSys.Get_Current_Mission().destination))
				{
					Debug.Log("Location: " + name + ", dest: " + mSys.Get_Current_Mission().destination.ToString());
					mSys.Mission_Complete();
				}
			}
		}
	}
}
