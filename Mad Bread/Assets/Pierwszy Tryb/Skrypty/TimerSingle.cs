using UnityEngine.UI;
using UnityEngine;

using System.Collections;

public class TimerSingle : MonoBehaviour
{
    public Text timerText, CzasG1, Rekord,StrataText;
    private float startTime;
    private bool start = GameObject.FindGameObjectWithTag("Gracz1").GetComponent<SterowanieGracz1>().start;
    private int x = 0;
    private string Czas, seconds;
    private float t;


    void Start()
    {

    }

    void Update()
    {
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
            float strata = t - PlayerPrefs.GetFloat("Rekord");

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
                PlayerPrefs.SetFloat("Rekord", t);
                PlayerPrefs.SetString("RekordString", Czas);
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

                if (t < PlayerPrefs.GetFloat("Rekord"))
                {
                    PlayerPrefs.SetFloat("Rekord", t);
                    PlayerPrefs.SetString("RekordString", Czas);
                    PlayerPrefs.Save();
                }
                Rekord.text = PlayerPrefs.GetString("RekordString");
            }
            x = 0;
        }

    }
}