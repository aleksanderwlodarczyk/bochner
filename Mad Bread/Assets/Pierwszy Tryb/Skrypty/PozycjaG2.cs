using UnityEngine;

public class PozycjaG2 : MonoBehaviour
{
    private float stara, dystans, RóżnicaIloraz, różnica, DystansStart, pochodna, ratio, k;
    private int i;
    private float x, y, P1, P2; //rozdzielczość
    void Start()
    {
        P1 = Screen.height * Screen.width; // rozdzielczość ekranu
        P2 = 1920 * 1080; //domyślna rozdzielczość
        k = Mathf.Sqrt(P1 / P2);
        ratio = k * 980f;
        i = 1;
    }

    void Update()
    {
        if (i == 1) DystansStart = Vector3.Distance(GameObject.FindGameObjectWithTag("Gracz2").transform.position, GameObject.FindGameObjectWithTag("Finish").transform.position);
        i = 2;
        dystans = Vector3.Distance(GameObject.FindGameObjectWithTag("Gracz2").transform.position, GameObject.FindGameObjectWithTag("Finish").transform.position);
        różnica = ratio * (1 - dystans / DystansStart);
        pochodna = różnica - stara;
        stara = różnica;
        transform.Translate(pochodna, 0, 0);
    }

}