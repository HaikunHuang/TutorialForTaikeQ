using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainUI : MonoBehaviour 
{
	public Text mission_description;
	public TextPanel tips;

	[Range(0,120)]
	public float tips_delay_time = 60.0f;
	float tips_current_time = 0.0f;

	// Use this for initialization
	void Awake () 
	{
		// tips.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (tips_current_time <= 0.0f)
		{
//			if (tips.isActiveAndEnabled)
//				tips.gameObject.SetActive(false);
			tips.tipsText.text = "";

		}
		else
		{
			tips_current_time -= Time.deltaTime;
		}
	}

	// set tips
	public void SetTips(string note)
	{

		if (note == "")
		{
			// tips.gameObject.SetActive(false);
			tips.tipsText.text = "";
		}
		else
		{
			tips.tipsText.text = note;
			tips_current_time = tips_delay_time;
			// tips.gameObject.SetActive(true);
		}
	}
	
}
