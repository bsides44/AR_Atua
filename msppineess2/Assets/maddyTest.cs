using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;


public class maddyTest : MonoBehaviour {
	Vector3 wind;
	public string weatherString;
	public Match match;
	public object dir_obj;
	public object dirLettersObj;
	public string dirLettersString;
	public string wind_dir;
	public object kph_obj;
	public string wind_kph;
	public object kphNumsObj;
	public string kphNumsString;
	public string[] kphSplit;	
	public int kphNumsInt;

	//the API
	private const string URL = "http://api.wunderground.com/api/d5a02b585b94a99a/conditions/q/New_Zealand/Wellington.json";


	// void Start () {
		
	// }

	// Update is called once per frame    
    void Update() {
		// Debug.Log(Time.frameCount);
		if (Time.frameCount % 200 == 0) {
		wind1();
		}
		if (Time.frameCount % 300 == 0) {
		wind2();
		}
		if (Time.frameCount % 500 == 0) {
		wind3();
		}
		if (Time.frameCount % 700 == 0) {
		wind4();
		}
		// if (Time.frameCount % 1000 == 0) {
		// StartCoroutine(LoadWind());
		// }

}

IEnumerator LoadWind() {
	//JSON parsing didn't work due to yield,  we import the API data as a string using www.text. 
		var windDirRegex = "(\"wind_dir\":\".*?\\w??\\W)";
		var windKphRegex = "(\"wind_kph\":\\d+.\\d)";
		var dirRegex = "([NESW])";
		var kphRegex = "(\\d+(?:\\D\\d))"; 

	//www lets us get data from an API, www.text stringifies it
		WWW www = new WWW(URL);
		yield return www;

		// current_observation = JsonUtility.FromJson<CurrentObservation>(www.text);
		weatherString = www.text;

	//we need the direction of the wind as a string, Regex.Match returns an object
		match = Regex.Match(weatherString, windDirRegex);
		dir_obj = match;
		wind_dir = dir_obj.ToString();
		match = Regex.Match(wind_dir, dirRegex);
		dirLettersObj = match;
		dirLettersString = dirLettersObj.ToString();

	//we need the kph as an integer
		match = Regex.Match(weatherString, windKphRegex);
		kph_obj = match;
		wind_kph = kph_obj.ToString();
		match = Regex.Match(wind_kph, kphRegex);
		kphNumsObj = match;
		kphNumsString = kphNumsObj.ToString();
	//if the wind is 0 the string is empty - regex can't find the number because there's no decimal in it 
		try {
		kphSplit = kphNumsString.Split('.');
		kphNumsInt = int.Parse(kphSplit[0]);
		} catch {
			kphNumsInt = 0;
		} //if string.split throws an error just set kph to 0

	//the integer and string are passed to the If statement, triggering wind actions.

	//wind direction
		if (dirLettersString == ("N")) {
			if (25 == 0) {
				wind = new Vector3(0.0f, 0.0f, 0.0f);
				transform.GetComponent<Cloth>().externalAcceleration = wind;
				Debug.Log("No wind");
			}
			if (25 > 0 && 25 < 10 ) {
				wind = new Vector3(0.0f, 0.0f, -10.0f);
				transform.GetComponent<Cloth>().externalAcceleration = wind;
				Debug.Log("LOW wind");
			}
			if (25 > 10 && 25 < 20) {
				wind = new Vector3(0.0f, 0.0f, -100.0f);
				transform.GetComponent<Cloth>().externalAcceleration = wind;
				Debug.Log("High wind");
			}
			if (25 > 20) {
				wind = new Vector3(0.0f, 0.0f, -500.0f);
				transform.GetComponent<Cloth>().externalAcceleration = wind;
				// wind2 = new Vector3(0.0f, 0.0f, 0.0f);
				// await Task.Delay(1000);
				// transform.GetComponent<Cloth>().externalAcceleration = wind2;
				// await Task.Delay(1000);
				// transform.GetComponent<Cloth>().externalAcceleration = wind;
				// Debug.Log("Gale wind");
			}
			Debug.Log("NORTH");
		}
		if (dirLettersString == ("E")) {
			if (kphNumsInt == 0) {
				wind = new Vector3(0.0f, 0.0f, 0.0f);
				Debug.Log("No wind");
			}
			if (kphNumsInt > 0 && kphNumsInt < 10 ) {
				wind = new Vector3(-10.0f, 0.0f, 0.0f);
				transform.GetComponent<Cloth>().externalAcceleration = wind;
				Debug.Log("LOW wind");
			}
			if (kphNumsInt > 10 && kphNumsInt < 20) {
				wind = new Vector3(-100.0f, 0.0f, 0.0f);
				transform.GetComponent<Cloth>().externalAcceleration = wind;
				Debug.Log("High wind");
			}
			if (kphNumsInt > 20) {
				wind = new Vector3(-500.0f, 0.0f, 0.0f);
				transform.GetComponent<Cloth>().externalAcceleration = wind;
				Debug.Log("Gale wind");
			}
			Debug.Log("EAST");
		}
		if (dirLettersString == ("S")) {
			if (kphNumsInt == 0) {
				wind = new Vector3(0.0f, 0.0f, 0.0f);
				Debug.Log("No wind");
			}
			if (kphNumsInt > 0 && kphNumsInt < 10 ) {
				wind = new Vector3(0.0f, 0.0f, 10.0f);
				transform.GetComponent<Cloth>().externalAcceleration = wind;
				Debug.Log("LOW wind");
			}
			if (kphNumsInt > 10 && kphNumsInt < 20) {
				wind = new Vector3(0.0f, 0.0f, 100.0f);
				transform.GetComponent<Cloth>().externalAcceleration = wind;
				Debug.Log("High wind");
			}
			if (kphNumsInt > 20) {
				wind = new Vector3(0.0f, 0.0f, 500.0f);
				transform.GetComponent<Cloth>().externalAcceleration = wind;
				Debug.Log("Gale wind");
			}
			Debug.Log("SOUTH");
		}
		if (dirLettersString == ("W")) {
			if (kphNumsInt == 0) {
				wind = new Vector3(0.0f, 0.0f, 0.0f);
				Debug.Log("No wind");
			}
			if (kphNumsInt > 0 && kphNumsInt < 10 ) {
				wind = new Vector3(10.0f, 0.0f, 0.0f);
				transform.GetComponent<Cloth>().externalAcceleration = wind;
				Debug.Log("LOW wind");
			}
			if (kphNumsInt > 10 && kphNumsInt < 20) {
				wind = new Vector3(100.0f, 0.0f, 0.0f);
				transform.GetComponent<Cloth>().externalAcceleration = wind;
				Debug.Log("High wind");
			}
			if (kphNumsInt > 20) {
				wind = new Vector3(500.0f, 0.0f, 0.0f);
				transform.GetComponent<Cloth>().externalAcceleration = wind;
				Debug.Log("Gale wind");
			}
			Debug.Log("WEST");
		}
	}

	public void wind1() {
		//wind direction
		wind = new Vector3(0.0f, 0.0f, -10.0f);
		transform.GetComponent<Cloth>().externalAcceleration = wind;
		Debug.Log("Low North");
	}
	public void wind2() {
		wind = new Vector3(-100.0f, 0.0f, 0.0f);
		transform.GetComponent<Cloth>().externalAcceleration = wind;
		Debug.Log("High East");
	}
	public void wind3() {
		wind = new Vector3(0.0f, 0.0f, 500.0f);
		transform.GetComponent<Cloth>().externalAcceleration = wind;
		Debug.Log("Gale South");
	}
	public void wind4() {
		wind = new Vector3(0.0f, 0.0f, 0.0f);
		transform.GetComponent<Cloth>().externalAcceleration = wind;
		Debug.Log("No West");
	}
	
}

