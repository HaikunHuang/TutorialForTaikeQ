using UnityEngine;
using System.Collections;

// ****************************************************************************************************************
// base class
// ****************************************************************************************************************
public class DataBase : ScriptableObject {

	// tips message;
	public string tips = "";

	// Use this for initialization
	virtual public void StartFunc (string filePath) 
	{
		//Debug.Log("Need to override.");
	}

	virtual public void StartFunc (string filePath, GameObject goArrow, GameObject goUser)
	{
		//Debug.Log("Need to override.");
	}
	
	// Update is called once per frame
	virtual public void FixedUpdateFunc () 
	{
		//Debug.Log("Need to override.");
	}

	virtual public void Done(string filePath)
	{
		//Debug.Log("Need to override.");
	}
}
