using UnityEngine;

public class PozycjaG1Single : MonoBehaviour
{
    private float stara, dystans, RóżnicaIloraz, różnica, DystansStart, pochodna;
    private int i;
    void Start()
    {
        i = 1;
    }

    void Update()
    {
        if (i == 1) DystansStart = Vector3.Distance(GameObject.FindGameObjectWithTag("Gracz1").transform.position, GameObject.FindGameObjectWithTag("Finish").transform.position);
        i = 2;
        dystans = Vector3.Distance(GameObject.FindGameObjectWithTag("Gracz1").transform.position, GameObject.FindGameObjectWithTag("Finish").transform.position);
        różnica = 620 * (1 - dystans / DystansStart);
        pochodna = różnica - stara;
        stara = różnica;
        transform.Translate(0, pochodna, 0);
    }

}