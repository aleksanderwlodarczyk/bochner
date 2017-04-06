using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour {
	public GUIText wyścigStart;
	public GUIText koniec;
	private NaliczaniePunktów naliczaniePunktówSkrypt;
	private int punktyŻebyWygrać;


	public GameObject gracz1p;
	public GameObject gracz2p;

	private GameObject gracz1;
	private GameObject gracz2;

	void Awake()
	{
		gracz1 = GameObject.Find (gracz1p.name);
		gracz2 = GameObject.Find (gracz2p.name);
	}

	void Start(){
		StartCoroutine (Odliczanie ());

		GameObject objekt = GameObject.Find ("GameManager");
		naliczaniePunktówSkrypt = objekt.GetComponent<NaliczaniePunktów> ();

		punktyŻebyWygrać = (Mathf.RoundToInt (GameObject.FindGameObjectsWithTag ("Przedmiot").Length / 2));

	}

	void Update () {
		if (Input.GetKey (KeyCode.R)) {
			SceneManager.LoadScene ("DrugiTrybScena");
		}
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}

		if(naliczaniePunktówSkrypt.punkty1 >= punktyŻebyWygrać){
			koniec.text = "Wygrał gracz 1!";
			gracz1.GetComponent<SterowanieGracz1> ().start = false;
			gracz2.GetComponent<SterowanieGracz2> ().start = false;
		}
		if(naliczaniePunktówSkrypt.punkty2 >= punktyŻebyWygrać){
			koniec.text = "Wygrał gracz 2!";
			gracz1.GetComponent<SterowanieGracz1> ().start = false;
			gracz2.GetComponent<SterowanieGracz2> ().start = false;
		}
	}


	IEnumerator Odliczanie(){
		yield return new WaitForSeconds(1);
		wyścigStart.text = "3";
		yield return new WaitForSeconds(1);
		wyścigStart.text = "2";
		yield return new WaitForSeconds(1);
		wyścigStart.text = "1";
		yield return new WaitForSeconds(1);
		wyścigStart.text = "START!";
		yield return new WaitForSeconds(0.5f);
		wyścigStart.text = "";
		gracz1.GetComponent<SterowanieGracz1> ().start = true;
		gracz2.GetComponent<SterowanieGracz2> ().start = true;

	}

}
