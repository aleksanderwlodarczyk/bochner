﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drożdże : MonoBehaviour {
	public GameObject Gracz1;
	public GameObject Gracz2;
	public float wait;

	void Update () 
	{
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

	IEnumerator Powiększanie (){
		GameObject Gracz1 = GameObject.Find ("Gracz1");
		Gracz1.transform.localScale = new Vector3 (6f, 6f, 11f);
		Gracz1.GetComponent<Rigidbody> ().mass = 10.0f;
		yield return new WaitForSeconds (wait);
		Gracz1.transform.localScale = new Vector3 (5f, 5f, 10f);
		Gracz1.GetComponent<Rigidbody> ().mass = 1.0f;
	}

	IEnumerator Powiększanie2 (){
		GameObject Gracz2 = GameObject.Find ("Gracz2");
		Gracz2.transform.localScale = new Vector3 (6f, 6f, 11f);
		Gracz2.GetComponent<Rigidbody> ().mass = 10.0f;
		yield return new WaitForSeconds (wait);
		Gracz2.transform.localScale = new Vector3 (5f, 5f, 10f);
		Gracz2.GetComponent<Rigidbody> ().mass = 1.0f;
	}

	IEnumerator OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Gracz1") {
			StartCoroutine (Powiększanie ());
			gameObject.transform.localPosition = new Vector3 (transform.position.x, -100, transform.position.z);
			gameObject.transform.localScale = new Vector3 (0, 0, 0);
			yield return new WaitForSeconds (wait);
			gameObject.SetActive (false);
		}

		if (other.gameObject.tag == "Gracz2") {
			StartCoroutine (Powiększanie2 ());
			gameObject.transform.localPosition = new Vector3 (transform.position.x, -100, transform.position.z);
			gameObject.transform.localScale = new Vector3 (0, 0, 0);
			yield return new WaitForSeconds (wait);
			gameObject.SetActive (false);
		}
	}

}
