using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public GameObject gracz1p;
	public GameObject gracz2p;

	private GameObject gracz1;
	private GameObject gracz2;
	private Vector3 pozycja1 = new Vector3 (16f,1.3f,-21f);
	private Vector3 pozycja2 = new Vector3 (25f,1.3f,-21f);
	// Use this for initialization
	void Start () {
		gracz1 = GameObject.Find ("Gracz1");
		gracz2 = GameObject.Find ("Gracz2");
	}
	
	// Update is called once per frame
	void Update () {
		
		StartCoroutine (UstawPozycje ());

		if (gracz1.transform.position.y < -3f || Input.GetKey(KeyCode.R))
			Resp (gracz1,1);
		if (gracz2.transform.position.y < -3f || Input.GetKey(KeyCode.Plus))
			Resp (gracz2,2);
	
	}


	IEnumerator UstawPozycje()
	{
		if (gracz1.GetComponent<SterowanieGracz1>().naTrasie) 
		{
			pozycja1 = new Vector3 (gracz1.transform.position.x,2f,gracz1.transform.position.z);

		}
		if (gracz2.GetComponent<SterowanieGracz2>().naTrasie) 
		{
			pozycja2 = new Vector3 (gracz2.transform.position.x,2f,gracz2.transform.position.z);

		}

		yield return new WaitForSeconds (3);

	}


	public void Resp(GameObject gracz, int n)
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
	



