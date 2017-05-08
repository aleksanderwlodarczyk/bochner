using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KtoDotknął2 : MonoBehaviour {
	public bool dotknąłGracz1, gracz1Dotyka;
	private NaliczaniePunktów2 naliczaniePunktówSkrypt;
	public static int następnyNumerek;
	public int numerek;

	void Awake (){
		numerek = następnyNumerek;
		następnyNumerek++;
	}

	void Start (){
		GameObject objekt = GameObject.Find ("GameManager");
		naliczaniePunktówSkrypt = objekt.GetComponent<NaliczaniePunktów2> ();
	}

	void Update (){
		if (Input.GetKey (KeyCode.R))
			następnyNumerek = 0;
	}

	void OnCollisionEnter (Collision other){
		if (other.gameObject.tag == "Gracz1") {
			gracz1Dotyka = true;
		}

		if (other.gameObject.tag == "Gracz1") {
			dotknąłGracz1 = true;
		}

		if (other.gameObject.tag == "Respawner") {
			Destroy (gameObject);
			if (dotknąłGracz1 == true) {
				naliczaniePunktówSkrypt.punkty1 = naliczaniePunktówSkrypt.punkty1 + 1;
			}
		}

		if (other.gameObject.tag == ("Przedmiot")) {

				for (int i = 0; i < naliczaniePunktówSkrypt.tablicaNumerków.Length; i++) {
					if (naliczaniePunktówSkrypt.tablicaNumerków [i] == naliczaniePunktówSkrypt.tablicaNumerków [numerek]) {

					if (gracz1Dotyka == true) {
						other.gameObject.GetComponent<KtoDotknął> ().dotknąłGracz1 = true;
					}

					if (dotknąłGracz1 == true) {
						other.gameObject.GetComponent<KtoDotknął> ().dotknąłGracz1 = true;
					}
				}
			}
		}

	}

	void OnCollisionExit (Collision other){
		if (other.gameObject.tag == "Gracz1")
			gracz1Dotyka = false;
	}
}

