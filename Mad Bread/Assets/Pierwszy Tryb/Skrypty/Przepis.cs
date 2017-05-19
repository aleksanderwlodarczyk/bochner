using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Przepis : MonoBehaviour {
	public GameObject Gracz1;
	public GameObject Gracz2;
	public CanvasGroup Przepis1, Przepis2;
	public float wait;

	void Update () 
	{
		transform.Rotate (new Vector3 (0, 15, 0) * 5*Time.deltaTime);
	}
		
	IEnumerator OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "Gracz1") 
		{
			CanvasGroup Canvas1 = GameObject.Find ("Przepis2").GetComponent<CanvasGroup> ();
			Canvas1.alpha = 1f;
			gameObject.transform.localPosition = new Vector3(transform.position.x, -100, transform.position.z);
			yield return new WaitForSeconds (wait);
			Canvas1.alpha = 0f;
			Destroy (gameObject);
		}
		if (other.gameObject.tag == "Gracz2") {
			CanvasGroup Canvas2 = GameObject.Find ("Przepis1").GetComponent<CanvasGroup> ();
			Canvas2.alpha = 1f;
			gameObject.transform.localPosition = new Vector3(transform.position.x, -100, transform.position.z);
			yield return new WaitForSeconds (wait);
			Canvas2.alpha = 0f;
			Destroy (gameObject);
		}
	}
	

}
