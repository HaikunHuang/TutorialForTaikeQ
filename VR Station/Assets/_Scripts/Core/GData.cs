using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GData 
{
	static public string dataResultsPath = "DataResults";

	// 
	public enum LocationType
	{
		Bus_Stop,
		Boston_University,
		Fenway_Park,
		Commonwealth_Avenue,
		Beacon_St,
		Boston_College,
		Cleveland_Circle,
		Riverside,
		Government_Center,
		North_Station,
		Lechmere,

		Blandford_St,
		Boston_University_East,
		Boston_University_Central,
		Boston_University_West,
		St_Paul_St,
		Pleasant_St,
		Babcock_St,
		Packards_Corner,
		Harvard_Ave,
		Griggs_St,
		Allston_St,
		Waren_St,
		Washington_St,
		Sutherland_Rd,
		Chishwick_Rd,
		Chestnut_Hill_Ave,
		South_St,

		St_Marys_St,
		Hawes_St,
		Kent_St,
		Coolidge_Corner,
		Summit_Ave,
		Brandon_Hall,
		Fairbanks_St,
		Washington_Sq,
		Tappan_St,
		Dean_Rd,
		Englewood_Ave,

		Fenway,
		Longwood,
		Brookline_Village,
		Brookline_Hills,
		Beaconsfield,
		Reservoir,
		Chestnut_Hill,
		Newton_Centre,
		Newton_Highlands,
		Eliot,
		Waban,
		Woodland,

		Haymarket,
		Park_Street,
		Boylston,
		Arlington,
		copley,
		Science_Park



	}


	// play mode
	public enum PlayMode
	{
		Read_From_GData,
		Free_Style,
		Recoder,
		Replayer,
		Virtual_Path
	}

	static public PlayMode playMode = PlayMode.Free_Style;

	// VR
	static public bool VR_Mode = false;

	// replayer file path
	static public string replayer_filePath 
		= "/Users/haikunhuang/Unity3D/VR Attention 2015 Summer/Assets/DataResults/results/Kenmore-0.txt";

	// the interal of place the arrow
	static public int interal_of_arrow = 25;

	// next scene
	static public string next_scene = "";

	// filter
	static public string filter_startPoint = "";
	static public string filter_endPoint = "";



}
