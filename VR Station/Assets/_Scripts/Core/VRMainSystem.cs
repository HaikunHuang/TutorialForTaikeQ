using UnityEngine;
using UnityEngine.VR;
using System.Collections;

// *****************************************************************************************************************
// This is the main system, manager the data collect and virtual path
// *****************************************************************************************************************
public class VRMainSystem : MonoBehaviour 
{
	string dataFolder = "";

	// the data path for next record or replay
	string dataPath;

	// database
	DataBase db;

	// Mission system
	MissionSystem missionSys;

	// done
	bool done = false;

	// playmode
	GData.PlayMode playMode = GData.PlayMode.Read_From_GData;

	// arrow
	public GameObject arrow,userArrow;

	// main UI
	MainUI mainUI;

	float speedUp_For_Virtual_Path = 3.0f;

	void Awake()
	{

	}

	// Use this for initialization
	void Start () 
	{
		dataFolder = Application.dataPath+"/" + GData.dataResultsPath;
		Debug.Log("dataFolder:"+dataFolder);

		// setup play mode
		if (playMode == GData.PlayMode.Read_From_GData)
		{
			playMode = GData.playMode;
		}
		else
		{
			GData.playMode = playMode;
		}

		missionSys = GameObject.FindObjectOfType<MissionSystem>();

		mainUI = GameObject.FindObjectOfType<MainUI>();

		// according to the play mode, select a data collecter
		switch (playMode)
		{
		case GData.PlayMode.Free_Style:
		{
			db = ScriptableObject.CreateInstance<DataBase>();

			mainUI.mission_description.text 
				= "<size=24><b>Mission Description:</b></size>\n" +
					"        Free Looking.";

			string str = "<b>Free Looking</b>\n" ;
				//+ "Please go back to Main Menu by Ctrl + U.";
			mainUI.SetTips(str);
            }
			break;

		}

	}

	void Update()
	{
		// back to main menu
		if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
		    && Input.GetKey(KeyCode.U))
		{
			if (GData.playMode == GData.PlayMode.Virtual_Path 
			    || GData.playMode == GData.PlayMode.Replayer)
			{
				Application.LoadLevel("DataAnalyzeMenu");
			}
			else
			{
				Application.LoadLevel("MainMenu");
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (!missionSys.IsCompleted())
		{
			db.FixedUpdateFunc();
		}
		else
		{
			if (!done)
			{
				done = true;

				// show something here.
				switch (playMode)
				{
				case GData.PlayMode.Free_Style:
				{

				}
					break;
				}
			}
		}
	}
}


