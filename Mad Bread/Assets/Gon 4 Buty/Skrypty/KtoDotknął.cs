using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KtoDotknął : MonoBehaviour {
	public bool dotknąłGracz1, dotknąłGracz2, gracz1Dotyka, gracz2Dotyka;
	private NaliczaniePunktów naliczaniePunktówSkrypt;
	public static int następnyNumerek;
	public int numerek;

	void Awake (){
		numerek = następnyNumerek;
		następnyNumerek++;
	}

	void Start (){
		GameObject objekt = GameObject.Find ("GameManager");
		naliczaniePunktówSkrypt = objekt.GetComponent<NaliczaniePunktów> ();
	}

	void Update (){
		if (Input.GetKey (KeyCode.R))
			następnyNumerek = 0;
	}

	void OnCollisionEnter (Collision other){
		if (other.gameObject.tag == "Gracz1") {
			gracz1Dotyka = true;
		}

		if (other.gameObject.tag == "Gracz2") {
			gracz2Dotyka = true;
		}

		if (other.gameObject.tag == "Gracz1") {
			dotknąłGracz1 = true;
			dotknąłGracz2 = false;
		}

		if (other.gameObject.tag == "Gracz2") {
			dotknąłGracz1 = false;
			dotknąłGracz2 = true;;
		}


		if (other.gameObject.tag == "Respawner") {
			Destroy (gameObject);
			if (dotknąłGracz1 == true) {
				naliczaniePunktówSkrypt.punkty1 = naliczaniePunktówSkrypt.punkty1 + 1;
			}

			if (dotknąłGracz2 == true) {
				naliczaniePunktówSkrypt.punkty2 = naliczaniePunktówSkrypt.punkty2 + 1;
			}
		}

		if (other.gameObject.tag == ("Przedmiot")) {

				for (int i = 0; i < naliczaniePunktówSkrypt.tablicaNumerków.Length; i++) {
					if (naliczaniePunktówSkrypt.tablicaNumerków [i] == naliczaniePunktówSkrypt.tablicaNumerków [numerek]) {

					if (gracz1Dotyka == true) {
						other.gameObject.GetComponent<KtoDotknął> ().dotknąłGracz1 = true;
						other.gameObject.GetComponent<KtoDotknął> ().dotknąłGracz2 = false;
					}

					if (gracz2Dotyka == true) {
						other.gameObject.GetComponent<KtoDotknął> ().dotknąłGracz1 = false;
						other.gameObject.GetComponent<KtoDotknął> ().dotknąłGracz2 = true;
					}

					if (dotknąłGracz1 == true) {
						other.gameObject.GetComponent<KtoDotknął> ().dotknąłGracz1 = true;
						other.gameObject.GetComponent<KtoDotknął> ().dotknąłGracz2 = false;
					}

					if (dotknąłGracz2 == true) {
						other.gameObject.GetComponent<KtoDotknął> ().dotknąłGracz1 = false;
						other.gameObject.GetComponent<KtoDotknął> ().dotknąłGracz2 = true;
					}
				}
			}
		}

	}

	void OnCollisionExit (Collision other){
		if (other.gameObject.tag == "Gracz1")
			gracz1Dotyka = false;

		if (other.gameObject.tag == "Gracz2")
			gracz2Dotyka = false;
	}
}

