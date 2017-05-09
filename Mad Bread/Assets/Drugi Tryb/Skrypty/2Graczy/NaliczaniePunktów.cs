using UnityEngine.UI;
using UnityEngine;

public class NaliczaniePunktów : MonoBehaviour {
	public Text iloscPunktow1, iloscPunktow2;
	public int punkty1, punkty2;
	public int[] tablicaNumerków;
	public KtoDotknął[] skrypty;
	private int punktyŻebyWygrać;

	void Start (){
		punkty1 = 0;
		punkty2 = 0;

		tablicaNumerków = new int[GameObject.FindGameObjectsWithTag ("Przedmiot").Length];
		punktyŻebyWygrać = (Mathf.RoundToInt (GameObject.FindGameObjectsWithTag ("Przedmiot").Length / 2));

		skrypty = Object.FindObjectsOfType (typeof(KtoDotknął)) as KtoDotknął[];
		GameObject.FindGameObjectsWithTag ("Przedmiot");
		for (int i = 0; i < tablicaNumerków.Length; i++){
			tablicaNumerków [i] = skrypty [i].numerek;
		}


	}

	void Update (){
		iloscPunktow1.text = (punktyŻebyWygrać-punkty1).ToString();
		iloscPunktow2.text = (punktyŻebyWygrać-punkty2).ToString();
	}
}
