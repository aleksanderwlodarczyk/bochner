
using UnityEngine;

public class bagietki : MonoBehaviour
{
    public GameObject Gracz1, Gracz2;
    public CanvasGroup Bagietki1, Bagietki2;

    public CanvasGroup Bagietka1_1, Bagietka1_2, Bagietka1_3, Bagietka1_4, Bagietka1_5, Bagietka1_6, Bagietka1_7, Bagietka1_8, Bagietka1_9, Bagietka1_10, Bagietka1_11, Bagietka1_12, Bagietka1_13, Bagietka1_14, Bagietka1_15, Bagietka1_16, Bagietka1_17, Bagietka1_18, Bagietka1_19, Bagietka1_20, Bagietka1_21, Bagietka1_22,
        Bagietka2_1, Bagietka2_2, Bagietka2_3, Bagietka2_4, Bagietka2_5, Bagietka2_6, Bagietka2_7, Bagietka2_8, Bagietka2_9, Bagietka2_10, Bagietka2_11, Bagietka2_12, Bagietka2_13, Bagietka2_14, Bagietka2_15, Bagietka2_16, Bagietka2_17, Bagietka2_18, Bagietka2_19, Bagietka2_20, Bagietka2_21, Bagietka2_22;

    private NaliczaniePunktów naliczaniePunktówSkrypt;

    private int x = 0;

    void Start ()
    {
        GameObject objekt = GameObject.Find("GameManager");
        naliczaniePunktówSkrypt = objekt.GetComponent<NaliczaniePunktów>();
    }
	
	void Update ()
    {
        if(x==0 && Gracz1.GetComponent<SterowanieGracz1>().start == true && Gracz2.GetComponent<SterowanieGracz2>().start == true)
        {
            x = 1;
            Bagietki1.GetComponent<CanvasGroup>().alpha = 1;
            Bagietki2.GetComponent<CanvasGroup>().alpha = 1;
        }

        int pktb1 = naliczaniePunktówSkrypt.punkty2;
        int pktb2 = naliczaniePunktówSkrypt.punkty1;

        

        if(pktb1 >= 1)
        {
            Bagietka1_1.alpha = 0;
        }
        if (pktb1 >= 2)
        {
            Bagietka1_2.alpha = 0;
        }
        if (pktb1 >= 3)
        {
            Bagietka1_3.alpha = 0;
        }
        if (pktb1 >= 4)
        {
            Bagietka1_4.alpha = 0;
        }
        if (pktb1 >= 5)
        {
            Bagietka1_5.alpha = 0;
        }
        if (pktb1 >= 6)
        {
            Bagietka1_6.alpha = 0;
        }
        if (pktb1 >= 7)
        {
            Bagietka1_7.alpha = 0;
        }
        if (pktb1 >= 8)
        {
            Bagietka1_8.alpha = 0;
        }
        if (pktb1 >= 9)
        {
            Bagietka1_9.alpha = 0;
        }
        if (pktb1 >= 10)
        {
            Bagietka1_10.alpha = 0;
        }
        if (pktb1 >= 11)
        {
            Bagietka1_11.alpha = 0;
        }
        if (pktb1 >= 12)
        {
            Bagietka1_12.alpha = 0;
        }
        if (pktb1 >= 13)
        {
            Bagietka1_13.alpha = 0;
        }
        if (pktb1 >= 14)
        {
            Bagietka1_14.alpha = 0;
        }
        if (pktb1 >= 15)
        {
            Bagietka1_15.alpha = 0;
        }
        if (pktb1 >= 16)
        {
            Bagietka1_16.alpha = 0;
        }
        if (pktb1 >= 17)
        {
            Bagietka1_17.alpha = 0;
        }
        if (pktb1 >= 18)
        {
            Bagietka1_18.alpha = 0;
        }
        if (pktb1 >= 19)
        {
            Bagietka1_19.alpha = 0;
        }
        if (pktb1 >= 20)
        {
            Bagietka1_20.alpha = 0;
        }
        if (pktb1 >= 21)
        {
            Bagietka1_21.alpha = 0;
        }
        if (pktb1 >=22)
        {
            Bagietka1_22.alpha = 0;
        }


        if (pktb2 >= 1)
        {
            Bagietka2_1.alpha = 0;
        }
        if (pktb2 >= 2)
        {
            Bagietka2_2.alpha = 0;
        }
        if (pktb2 >= 3)
        {
            Bagietka2_3.alpha = 0;
        }
        if (pktb2 >= 4)
        {
            Bagietka2_4.alpha = 0;
        }
        if (pktb2 >= 5)
        {
            Bagietka2_5.alpha = 0;
        }
        if (pktb2 >= 6)
        {
            Bagietka2_6.alpha = 0;
        }
        if (pktb2 >= 7)
        {
            Bagietka2_7.alpha = 0;
        }
        if (pktb2 >= 8)
        {
            Bagietka2_8.alpha = 0;
        }
        if (pktb2 >= 9)
        {
            Bagietka2_9.alpha = 0;
        }
        if (pktb2 >= 10)
        {
            Bagietka2_10.alpha = 0;
        }
        if (pktb2 >= 11)
        {
            Bagietka2_11.alpha = 0;
        }
        if (pktb2 >= 12)
        {
            Bagietka2_12.alpha = 0;
        }
        if (pktb2 >= 13)
        {
            Bagietka2_13.alpha = 0;
        }
        if (pktb2 >= 14)
        {
            Bagietka2_14.alpha = 0;
        }
        if (pktb2 >= 15)
        {
            Bagietka2_15.alpha = 0;
        }
        if (pktb2 >= 16)
        {
            Bagietka2_16.alpha = 0;
        }
        if (pktb2 >= 17)
        {
            Bagietka2_17.alpha = 0;
        }
        if (pktb2 >= 18)
        {
            Bagietka2_18.alpha = 0;
        }
        if (pktb2 >= 19)
        {
            Bagietka2_19.alpha = 0;
        }
        if (pktb2 >= 20)
        {
            Bagietka2_20.alpha = 0;
        }
        if (pktb2 >= 21)
        {
            Bagietka2_21.alpha = 0;
        }
        if (pktb2 >= 22)
        {
            Bagietka2_22.alpha = 0;
        }

    }
}
