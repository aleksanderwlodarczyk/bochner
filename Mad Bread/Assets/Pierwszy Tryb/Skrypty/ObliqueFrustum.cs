using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Component;

public class ObliqueFrustum : MonoBehaviour {
	
	public float hor = 0f;
	public float ver = 0.6f;


	// Use this for initialization
	void Start () {
		SetObliqueness(hor, ver);
	}
	
	// Update is called once per frame
	void Update () {
		SetObliqueness(hor, ver);
	}

	void SetObliqueness(float horizObl, float vertObl)
	{
    Matrix4x4 mat = Camera.main.projectionMatrix;
    mat[0, 2] = horizObl;
    mat[1, 2] = vertObl;
    Camera.main.projectionMatrix = mat;
	
}

}
