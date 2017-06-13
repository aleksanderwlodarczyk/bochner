using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager2JedenGracz : MonoBehaviour {  
	public Text timerText, CzasG1, StrataText, wyścigStart,Rekord;
	private NaliczaniePunktów2 naliczaniePunktówSkrypt;
	private int punktyŻebyWygrać,x;
    private bool start;
    private float startTime,t;
    private string seconds,Czas;
	public CanvasGroup WASD;

	public GameObject gracz1p;
	private GameObject gracz1;

	void Awake()
	{
		gracz1 = GameObject.Find (gracz1p.name);
	}

	void Start(){
		StartCoroutine (Odliczanie ());

		GameObject objekt = GameObject.Find ("GameManager");
		naliczaniePunktówSkrypt = objekt.GetComponent<NaliczaniePunktów2> ();

		punktyŻebyWygrać = (Mathf.RoundToInt (GameObject.FindGameObjectsWithTag ("Przedmiot").Length/2));
        x = 0;

	}

	void Update () {


		if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }





        start = GameObject.FindGameObjectWithTag("Gracz1").GetComponent<SterowanieGracz1>().start;

        if (start == true)
        {

            x += 1;
            if (x == 1)
            {
                startTime = Time.time;
            }
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
        if (x > 0 && start == false)
        {
            CanvasGroup Win = GameObject.FindGameObjectWithTag("G1Win").GetComponent<CanvasGroup>();
            Win.alpha = 1.0f;
            CzasG1.text = Czas;
            float strata = t - PlayerPrefs.GetFloat("RekordT2");

            string CzyPobity;
            if (strata < 0)
            {
                strata = Mathf.Abs(strata);
                CzyPobity = "-";
                StrataText.color = Color.green;
            }
            else
            {
                CzyPobity = "+";
                StrataText.color = Color.red;
            }



            if (strata == t)
            {
                StrataText.text = "Pierwszy" + System.Environment.NewLine + "rekord!";
                PlayerPrefs.SetFloat("RekordT2", t);
                PlayerPrefs.SetString("RekordT2String", Czas);
                PlayerPrefs.Save();
            }
            else
            {
                string minutes = ((int)strata / 60).ToString();
                float SecondsNumber = (strata % 60);
                if (SecondsNumber < 10)
                {
                    seconds = "0" + SecondsNumber;
                }
                else seconds = SecondsNumber.ToString();
                string strataczas = CzyPobity + minutes + ":" + seconds.Substring(0, 2) + ":" + seconds.Substring(3, 2);
                StrataText.text = strataczas;

                if (t < PlayerPrefs.GetFloat("RekordT2"))
                {
                    PlayerPrefs.SetFloat("RekordT2", t);
                    PlayerPrefs.SetString("RekordT2String", Czas);
                    PlayerPrefs.Save();
                }
                Rekord.text = PlayerPrefs.GetString("RekordT2String");
            }
            x = 0;
        }

        if (naliczaniePunktówSkrypt.punkty1 >= punktyŻebyWygrać){
			gracz1.GetComponent<SterowanieGracz1> ().start = false;
		}
	}


	IEnumerator Odliczanie(){
		CanvasGroup Canvas1 = GameObject.Find ("WASD").GetComponent<CanvasGroup> ();
		Canvas1.alpha = 1f;
		yield return new WaitForSeconds(1);
		wyścigStart.text = "3";
		yield return new WaitForSeconds(1);
		wyścigStart.text = "2";
		yield return new WaitForSeconds(1);
		wyścigStart.text = "1";
		yield return new WaitForSeconds(1);
		Canvas1.alpha = 0f;
		wyścigStart.text = "START!";
		yield return new WaitForSeconds(0.5f);
		wyścigStart.text = "";
		gracz1.GetComponent<SterowanieGracz1> ().start = true;

	}

}
