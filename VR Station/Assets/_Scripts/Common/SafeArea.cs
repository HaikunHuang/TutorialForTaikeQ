using UnityEngine;
using System.Collections;

public class SafeArea : Sensor {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) 
	{
		Escalators_Object es = other.gameObject.GetComponent<Escalators_Object>();
		if (es)
		{
			other.gameObject.transform.parent = null;
		}

		Elevator_Object el = other.gameObject.GetComponent<Elevator_Object>();
		if (el)
		{
			other.gameObject.transform.parent = null;
		}
	}
}
