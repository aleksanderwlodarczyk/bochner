using UnityEngine;

public class PozycjaG2 : MonoBehaviour
{
    private float stara, dystans, RóżnicaIloraz, różnica, DystansStart, pochodna;
    private int i;
    void Start()
    {
        i = 1;
    }

    void Update()
    {
        if (i == 1) DystansStart = Vector3.Distance(GameObject.FindGameObjectWithTag("Gracz2").transform.position, GameObject.FindGameObjectWithTag("Finish").transform.position);
        i = 2;
        dystans = Vector3.Distance(GameObject.FindGameObjectWithTag("Gracz2").transform.position, GameObject.FindGameObjectWithTag("Finish").transform.position);
        różnica = 1000 * (1 - dystans / DystansStart);
        pochodna = różnica - stara;
        stara = różnica;
        transform.Translate(pochodna, 0, 0);
    }

}