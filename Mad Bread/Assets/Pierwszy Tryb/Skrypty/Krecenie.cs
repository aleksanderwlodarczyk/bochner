using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Krecenie : MonoBehaviour {

	void Update () 
	{
		transform.Rotate (new Vector3 (15, 30, 0.0f) * Time.deltaTime);
	}
}
