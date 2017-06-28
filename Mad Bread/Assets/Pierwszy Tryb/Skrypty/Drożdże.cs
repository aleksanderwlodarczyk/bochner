using System.Collections;
using UnityEngine;

public class Drożdże : MonoBehaviour {
	public GameObject Gracz1;
	public GameObject Gracz2;
	public float wait;

    private void Start()
    {
        Gracz1 = GameObject.Find("Gracz1");
        Gracz2 = GameObject.Find("Gracz2");
    }

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

	IEnumerator OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Gracz1") {
            GameObject.Find("DrożdżeManager").GetComponent<DrożdżeManager>().powiekszanie1 = true;
			gameObject.transform.localPosition = new Vector3 (transform.position.x, -100, transform.position.z);
			gameObject.transform.localScale = new Vector3 (0, 0, 0);
			yield return new WaitForSeconds (wait);
			Destroy(gameObject);
		}

		if (other.gameObject.tag == "Gracz2") {
            GameObject.Find("DrożdżeManager").GetComponent<DrożdżeManager>().powiekszanie2 = true;
            gameObject.transform.localPosition = new Vector3 (transform.position.x, -100, transform.position.z);
			gameObject.transform.localScale = new Vector3 (0, 0, 0);
			yield return new WaitForSeconds (wait);
			Destroy(gameObject);
		}
	}
}
