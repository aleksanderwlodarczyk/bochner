using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedometerGracz1 : MonoBehaviour {

	static float minAngle = 32.0f;
	static float maxAngle = -209.0f;
	static float maxAngleBack = -28.0f;
	static SpeedometerGracz1 thisSpeedo;

	// Use this for initialization
	void Start () {
		thisSpeedo = this;

	}

	public static void ShowSpeed (float speed, float min, float max)
	{
		float ang = Mathf.Lerp (minAngle, maxAngle, Mathf.InverseLerp (min, max+15, speed));
		float ang2 = Mathf.Lerp (minAngle, maxAngleBack, Mathf.InverseLerp (min-10, max-30, speed));
		if(speed>=0.0f){
			thisSpeedo.transform.eulerAngles = new Vector3 (0, 0, ang);
		}
		else{
			thisSpeedo.transform.eulerAngles = new Vector3 (0, 0, -ang2);
		}
	}


}
