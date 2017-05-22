using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drozdzespawner : MonoBehaviour {

	public float wait;
	public GameObject drozdze_pre;

	private GameObject dr;
	// Use this for initialization
	void Start () {
		DrSpawn ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DrSpawn(){
		StartCoroutine (DrozdzeSpawn ());
	}
	IEnumerator DrozdzeSpawn(){
		if (transform.childCount == 0) {
			dr = Instantiate (drozdze_pre, gameObject.transform.position, gameObject.transform.rotation,gameObject.transform) as GameObject;
		}
		yield return new WaitForSeconds (wait);

		DrSpawn ();

	}
}
