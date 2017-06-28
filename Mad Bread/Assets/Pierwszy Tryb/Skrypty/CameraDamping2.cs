using UnityEngine;
using System.Collections;

public class CameraDamping2 : MonoBehaviour
{
    // The target we are following
    public Transform target;
    // The distance in the x-z plane to the target
    public float distance;
    // the height we want the camera to be above the target
    public float height;
    // How much we dump
    public float heightDamping = 0.1f;
    public float rotationDamping = 0.1f;

    //Drożdże
    public bool bigger, smaller;
    private float min, max;

    void Start()
    {
        // Early out if we don't have a target
        if (!target)
            return;

        transform.position = target.position;
        min = distance;
        max = distance + 10f;
    }

    void Update()
    {
        if (bigger == true)
        {
            StartCoroutine(Bigger());
        }

        if (smaller == true)
        {
            StartCoroutine(Smaller());
        }
        // Calculate the current rotation angles
        var wantedRotationAngle = target.eulerAngles.y;
        var wantedHeight = target.position.y + height;

        var currentRotationAngle = transform.eulerAngles.y;
        var currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * (1 - Mathf.Exp(-20 * Time.deltaTime)));

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * (1 - Mathf.Exp(-20 * Time.deltaTime)));

        // Convert the angle into a rotation
        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        // Set the rotation
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, target.transform.eulerAngles.z);

        // Set the height of the camera
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        // Always look at the target
        transform.LookAt(target);
    }
    IEnumerator Bigger()
    {

        bigger = false;
        do
        {
            distance += 0.1f;
            height += 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        while (distance < max);
    }

    IEnumerator Smaller()
    {
        smaller = false;
        do
        {
            distance -= 0.1f;
            height -= 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        while (distance > min);
    }
}