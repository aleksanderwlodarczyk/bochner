using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn2 : MonoBehaviour {

	public GameObject gracz1p;
	public GameObject gracz2p;

	private GameObject gracz1;
	private GameObject gracz2;

	private Vector3 pozycja1 = new Vector3 (16f,1.3f,-21f);
	private Vector3 pozycja2 = new Vector3 (25f,1.3f,-21f);

	public float gracz1X, gracz1Y, gracz1Z, gracz2X, gracz2Y, gracz2Z;

	void Start () {
		gracz1 = gracz1p;
		gracz2 = gracz2p;
	}

	void OnCollisionEnter (Collision other){
		if (other.gameObject.tag == "Gracz1") 
				Resp (gracz1, 1);

		if (other.gameObject.tag == "Gracz2")
				Resp (gracz2, 2);
	}

	void Update(){
		StartCoroutine (UstawPozycje());
		if (Input.GetKey (KeyCode.R)) {
			RespOD (gracz1, 1);
		}
		if (Input.GetKey (KeyCode.KeypadPlus)) {
			RespOD (gracz2, 2);
		}
	}

	IEnumerator UstawPozycje()
	{
		if (gracz1.GetComponent<SterowanieGracz1>().naTrasie) 
		{
			pozycja1 = new Vector3 (gracz1.transform.position.x,17f,gracz1.transform.position.z);

		}
		if (gracz2.GetComponent<SterowanieGracz2>().naTrasie) 
		{
			pozycja2 = new Vector3 (gracz2.transform.position.x,17f,gracz2.transform.position.z);

		}

		yield return new WaitForSeconds (3);

	}

	void Resp(GameObject gracz, int n)
	{
		if (n == 1) 
		{
			gracz1.GetComponent<SterowanieGracz1> ().speed = 0.0f;
			gracz1.transform.rotation = new Quaternion (0, 0, 0, 0);
			gracz1.transform.position = new Vector3 (gracz1X, gracz1Y, gracz1Z);

		}
		if (n == 2)
		{
			gracz2.GetComponent<SterowanieGracz2> ().speed = 0.0f;
			gracz2.transform.position = new Vector3 (gracz2X, gracz2Y, gracz2Z);
			gracz2.transform.rotation = new Quaternion (0, 0, 0, 0);
		}

	}

	public void RespOD(GameObject gracz, int n)
	{
		if (n == 1) 
		{
			GameObject.Find ("Gracz1").GetComponent<SterowanieGracz1> ().speed = 0.0f;
			gracz1.transform.position = pozycja1;
			gracz1.GetComponent<SterowanieGracz1> ().start = true;
			gracz1.transform.rotation = new Quaternion (0f, gracz1.transform.rotation.y, 0f, 1f);

		}
		if (n == 2)
		{
			GameObject.Find ("Gracz2").GetComponent<SterowanieGracz2> ().speed = 0.0f;
			gracz2.transform.position = pozycja2;
			gracz2.GetComponent<SterowanieGracz2> ().start = true;
		}

	}
}




