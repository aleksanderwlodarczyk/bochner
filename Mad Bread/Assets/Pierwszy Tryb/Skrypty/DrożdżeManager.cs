using System.Collections;
using UnityEngine;

public class DrożdżeManager : MonoBehaviour
{
    public GameObject Gracz1;
    public GameObject Gracz2;
    public float wait;
    public int enlarged1, enlarged2;
    public bool powiekszanie1, powiekszanie2;
    public static float FirstMass;
    public bool pomniejszaniecz2_1, pomniejszaniecz2_2;

    void Start()
    {
        enlarged1 = 0;
        enlarged2 = 0;
        FirstMass = GameObject.Find("Gracz1").GetComponent<Rigidbody>().mass;
    }

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        if (powiekszanie1 == true)
        {
            powiekszanie1 = false;
            enlarged1 += 1;
            GameObject Gracz1 = GameObject.Find("Gracz1");
            Gracz1.transform.localScale = new Vector3(9f, 9f, 14f);
            Gracz1.GetComponent<Rigidbody>().mass = 3 * FirstMass;
            GameObject.FindGameObjectWithTag("Camera1").GetComponent<CameraDamping>().bigger = true;
            StartCoroutine(Smaller1());
            pomniejszaniecz2_1 = true;

        }
        if (pomniejszaniecz2_1 == true)
        {
            if (enlarged1 == 0)
            {
                GameObject.FindGameObjectWithTag("Camera1").GetComponent<CameraDamping>().smaller = true;
                Gracz1.transform.localScale = new Vector3(5f, 5f, 10f);
                Gracz1.GetComponent<Rigidbody>().mass = FirstMass;
                pomniejszaniecz2_1 = false;
            }
        }

        if (powiekszanie2 == true)
        {
            powiekszanie2 = false;
            enlarged2 += 1;
            GameObject Gracz2 = GameObject.Find("Gracz2");
            Gracz2.transform.localScale = new Vector3(9f, 9f, 14f);
            Gracz2.GetComponent<Rigidbody>().mass = 3 * FirstMass;
            GameObject.FindGameObjectWithTag("Camera2").GetComponent<CameraDamping2>().bigger = true;
            StartCoroutine(Smaller2());
            pomniejszaniecz2_2 = true;

        }
        if (pomniejszaniecz2_2 == true)
        {
            if (enlarged2 == 0)
            {
                GameObject Gracz2 = GameObject.Find("Gracz2");
                GameObject.FindGameObjectWithTag("Camera2").GetComponent<CameraDamping2>().smaller = true;
                Gracz2.transform.localScale = new Vector3(5f, 5f, 10f);
                Gracz2.GetComponent<Rigidbody>().mass = FirstMass;
                pomniejszaniecz2_2 = false;
            }
        }
    }

    IEnumerator Smaller1()
    {
        yield return new WaitForSeconds(wait);
        enlarged1 -= 1;
    }

    IEnumerator Smaller2()
    {
        yield return new WaitForSeconds(wait);
        enlarged2 -= 1;
    }
}
