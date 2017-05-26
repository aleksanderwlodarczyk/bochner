using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public Text WyścigStart;


	public GameObject gracz1p;
	public GameObject gracz2p;

	private GameObject gracz1;
	private GameObject gracz2;

	private Respawn respScript = new Respawn();
    void Awake()
	{
		gracz1 = GameObject.Find (gracz1p.name);
		gracz2 = GameObject.Find (gracz2p.name);
	}

	void Start(){
		StartCoroutine (Odliczanie ());
	}

	void Update () {
		if (Input.GetKey (KeyCode.Y)) {
			SceneManager.LoadScene ("Generator");
		}
		if (Input.GetKey (KeyCode.Escape)) {
			SceneManager.LoadScene ("Menu");
		}

		if(GameObject.Find ("LiniaMety").GetComponent<CzyKtosWygral> ().WygralGracz1 == true){
			
			gracz1.GetComponent<SterowanieGracz1> ().start = false;
			
		}
		if(GameObject.Find ("LiniaMety").GetComponent<CzyKtosWygral> ().WygralGracz2 == true){
			
			gracz2.GetComponent<SterowanieGracz2> ().start = false;
		}
	}


	IEnumerator Odliczanie(){
		yield return new WaitForSeconds(1);
		WyścigStart.text = "3";
		yield return new WaitForSeconds(1);
		WyścigStart.text = "2";
		yield return new WaitForSeconds(1);
		WyścigStart.text = "1";
		yield return new WaitForSeconds(1);
		WyścigStart.text = "START!";
		yield return new WaitForSeconds(0.5f);
		WyścigStart.text = "";
		gracz1.GetComponent<SterowanieGracz1> ().start = true;
		gracz2.GetComponent<SterowanieGracz2> ().start = true;

	}

}
