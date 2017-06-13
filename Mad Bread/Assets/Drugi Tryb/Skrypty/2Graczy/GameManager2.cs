using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour {
	public Text wyścigStart;
	private NaliczaniePunktów naliczaniePunktówSkrypt;
	private int punktyŻebyWygrać;
	public CanvasGroup WASD, Strzalki;


	public GameObject gracz1p;
	public GameObject gracz2p;

	private GameObject gracz1;
	private GameObject gracz2;

    public CanvasGroup G1Win, G2Win, RekordG1, RekordG2;
    public Text G1Czas, G1Punkty, G2Czas, G2Punkty, timerText, RekordG1Text, RekordG2Text;
    private int x,y;
    private bool start;
    private float startTime,t,SecondsNumber,minutes;
    private string Czas,seconds;

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
        x = 0;
        y = 0;

	}

	void Update () {
		if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}

        start = GameObject.FindGameObjectWithTag("Gracz1").GetComponent<SterowanieGracz1>().start;

        if(start==true&&y==0)
        {
            y = 1;
            startTime = Time.time;
        }
        if (y == 1)
        {
            t = Time.time - startTime;
            if (t > 600) startTime = 600;
            string minutes = ((int)t / 60).ToString();
            float SecondsNumber = (t % 60);
            if (SecondsNumber < 10)
            {
                seconds = "0" + SecondsNumber;
            }
            else seconds = SecondsNumber.ToString();
            Czas = minutes + ":" + seconds.Substring(0, 2) + ":" + seconds.Substring(3, 2);
            timerText.text = Czas;
        }



        if (naliczaniePunktówSkrypt.punkty1 >= punktyŻebyWygrać && x==0){
            x = 1;
            G1Win.alpha = 1;
            G1Czas.text=Czas;
            G2Punkty.text = naliczaniePunktówSkrypt.punkty2.ToString() + "/22";
			gracz1.GetComponent<SterowanieGracz1> ().start = false;
			gracz2.GetComponent<SterowanieGracz2> ().start = false;
            if (t < PlayerPrefs.GetFloat("RekordT2") || PlayerPrefs.GetFloat("RekordT2") == 0)
            {
                PlayerPrefs.SetFloat("RekordT2", t);
                PlayerPrefs.SetString("RekordT2String", Czas);
                PlayerPrefs.Save();
                RekordG1.alpha = 1.0f;
            }
            RekordG1Text.text = PlayerPrefs.GetString("RekordT2String");
        }
		if(naliczaniePunktówSkrypt.punkty2 >= punktyŻebyWygrać && x==0){
            x = 1;
            G2Win.alpha = 1;
            G2Czas.text = Czas;
            G1Punkty.text = naliczaniePunktówSkrypt.punkty1.ToString() + "/22";
            gracz1.GetComponent<SterowanieGracz1> ().start = false;
			gracz2.GetComponent<SterowanieGracz2> ().start = false;
            if (t < PlayerPrefs.GetFloat("RekordT2") || PlayerPrefs.GetFloat("RekordT2") == 0)
            {
                PlayerPrefs.SetFloat("RekordT2", t);
                PlayerPrefs.SetString("RekordT2String", Czas);
                PlayerPrefs.Save();
                RekordG2.alpha = 1.0f;
            }
            RekordG2Text.text = PlayerPrefs.GetString("RekordT2String");
        }
	}


	IEnumerator Odliczanie(){
		CanvasGroup Canvas1 = GameObject.Find ("WASD").GetComponent<CanvasGroup> ();
		Canvas1.alpha = 1f;
		CanvasGroup Canvas2 = GameObject.Find ("Strzalki").GetComponent<CanvasGroup> ();
		Canvas2.alpha = 1f;
		yield return new WaitForSeconds(1);
		wyścigStart.text = "3";
		yield return new WaitForSeconds(1);
		wyścigStart.text = "2";
		yield return new WaitForSeconds(1);
		wyścigStart.text = "1";
		yield return new WaitForSeconds(1);
		Canvas1.alpha = 0f;
		Canvas2.alpha = 0f;
		wyścigStart.text = "START!";
		yield return new WaitForSeconds(0.5f);
		wyścigStart.text = "";
		gracz1.GetComponent<SterowanieGracz1> ().start = true;
		gracz2.GetComponent<SterowanieGracz2> ().start = true;

	}

}
