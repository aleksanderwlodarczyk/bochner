using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    public Text timerText, G1Czas, G2Czas, G1_2Czas, G2_2Czas, Rekord1, Rekord2;
    public CanvasGroup RekordG1, RekordG2;
    private float startTime,t,t1,t2;
    private bool start1 = GameObject.FindGameObjectWithTag("Gracz1").GetComponent<SterowanieGracz1>().start;
    private bool start2 = GameObject.FindGameObjectWithTag("Gracz2").GetComponent<SterowanieGracz2>().start;
    private int x = 0, y=0, z1=0, z2=0;
    public string CzasG1, CzasG2;
    private string Czas, seconds;


    void Start ()
    {
        
	}
	
	void Update ()
    {
        start1 = GameObject.FindGameObjectWithTag("Gracz1").GetComponent<SterowanieGracz1>().start;
        start2 = GameObject.FindGameObjectWithTag("Gracz2").GetComponent<SterowanieGracz2>().start;
            if (start1 == true || start2 == true)
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
            if (x > 0 && y != 1 && z1 != 1 && start1 == false)
            {
                z1 = 1;
                CzasG1 = Czas;
                t1 = t;
                y = 1;
            }
            if (x > 0 && y != 2 && z2 != 1 && start2 == false)
            {
                z2 = 1;
                CzasG2 = Czas;
                t2 = t;
                y = 2;
            }
            if (x > 0 && start1 == false && start2 == false)
            {
                if (y == 2)
                {
                    CanvasGroup Win = GameObject.FindGameObjectWithTag("G1Win").GetComponent<CanvasGroup>();
                    Win.alpha = 1.0f;
                    G1Czas.text = CzasG1;
                    G2Czas.text = CzasG2;
                    if (t1 < PlayerPrefs.GetFloat("Rekord") || PlayerPrefs.GetFloat("Rekord") == 0)
                    {
                        PlayerPrefs.SetFloat("Rekord", t1);
                        PlayerPrefs.SetString("RekordString", CzasG1);
                        PlayerPrefs.Save();
                        RekordG1.alpha = 1.0f;
                    }
                    Rekord1.text = PlayerPrefs.GetString("RekordString");
            }
                if (y == 1)
                {
                    CanvasGroup Win = GameObject.FindGameObjectWithTag("G2Win").GetComponent<CanvasGroup>();
                    Win.alpha = 1.0f;
                    G1_2Czas.text = CzasG1;
                    G2_2Czas.text = CzasG2;
                    if (t2 < PlayerPrefs.GetFloat("Rekord") || PlayerPrefs.GetFloat("Rekord") == 0)
                    {
                        PlayerPrefs.SetFloat("Rekord", t2);
                        PlayerPrefs.SetString("RekordString", CzasG2);
                        PlayerPrefs.Save();
                        RekordG2.alpha = 1.0f;
                    }
                    Rekord2.text = PlayerPrefs.GetString("RekordString");
                 }
        }
        
	}
}
