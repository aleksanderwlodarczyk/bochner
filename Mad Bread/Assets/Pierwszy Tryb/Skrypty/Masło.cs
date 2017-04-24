using UnityEngine;
using System.Collections;

public class Masło : MonoBehaviour
{
    public float wait = 3.0f;
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    IEnumerator Boost()
    {
        GameObject Gracz1 = GameObject.Find("Gracz1");
        SterowanieGracz1 sterowanie1 = Gracz1.GetComponent<SterowanieGracz1>();
        sterowanie1.MaxSpeed = 45.0f;
        sterowanie1.speed = 45.0f;
        yield return new WaitForSeconds(wait);
        sterowanie1.MaxSpeed = 30.0f;
        if (sterowanie1.speed > sterowanie1.MaxSpeed)
        {
            sterowanie1.speed = sterowanie1.MaxSpeed;
        }
    }

    IEnumerator Boost2()
    {
        GameObject Gracz2 = GameObject.Find("Gracz2");
        SterowanieGracz2 sterowanie2 = Gracz2.GetComponent<SterowanieGracz2>();
        sterowanie2.MaxSpeed = 45.0f;
        sterowanie2.speed = 45.0f;
        yield return new WaitForSeconds(wait);
        sterowanie2.MaxSpeed = 30.0f;
        if (sterowanie2.speed > sterowanie2.MaxSpeed)
        {
            sterowanie2.speed = sterowanie2.MaxSpeed;
        }
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        CanvasGroup Canvas1 = GameObject.Find("Plomien1").GetComponent<CanvasGroup>();
        CanvasGroup Canvas2 = GameObject.Find("Plomien2").GetComponent<CanvasGroup>();
        if (other.gameObject.tag == "Gracz1")
        {
            Canvas1.alpha = 1f;
            Canvas1.interactable = true;
            Canvas1.blocksRaycasts = true;
            StartCoroutine(Boost());
            gameObject.transform.localPosition = new Vector3(transform.position.x, -100, transform.position.z);
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(wait);
            Canvas1.alpha = 0f;
            Canvas1.interactable = false;
            Canvas1.blocksRaycasts = false;
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Gracz2")
        {
            Canvas2.alpha = 1f;
            Canvas2.interactable = true;
            Canvas2.blocksRaycasts = true;
            StartCoroutine(Boost2());
            gameObject.transform.localPosition = new Vector3(transform.position.x, -100, transform.position.z);
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(wait);
            Canvas2.alpha = 0f;
            Canvas2.interactable = false;
            Canvas2.blocksRaycasts = false;
            Destroy(gameObject);
        }
    }
}

