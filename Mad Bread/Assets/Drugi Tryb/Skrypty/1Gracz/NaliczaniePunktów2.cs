using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaliczaniePunktów2 : MonoBehaviour {
	public GUIText iloscPunktow1;
	public int punkty1;
	public int[] tablicaNumerków;
	public KtoDotknął2[] skrypty;
	private int punktyŻebyWygrać;

	void Start (){
		punkty1 = 0;

		tablicaNumerków = new int[GameObject.FindGameObjectsWithTag ("Przedmiot").Length];
		punktyŻebyWygrać = (Mathf.RoundToInt (GameObject.FindGameObjectsWithTag ("Przedmiot").Length));

		skrypty = Object.FindObjectsOfType (typeof(KtoDotknął2)) as KtoDotknął2[];
		GameObject.FindGameObjectsWithTag ("Przedmiot");
		for (int i = 0; i < tablicaNumerków.Length; i++){
			tablicaNumerków [i] = skrypty [i].numerek;
		}


	}

	void Update (){
		iloscPunktow1.text = "Punkty: " + punkty1.ToString () + "/" + punktyŻebyWygrać.ToString();
	}
}
