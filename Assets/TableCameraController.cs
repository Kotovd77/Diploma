using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCameraController : MonoBehaviour {

	public Camera tableCamera;
	public GameObject yRotationAnchor; 
	public Quaternion rotationY,rotationZ;
	public float sensetivity;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1)) {
			rotationY = Quaternion.AngleAxis (Input.GetAxis ("Mouse Y") * sensetivity , Vector3.right);
			rotationZ = Quaternion.AngleAxis (Input.GetAxis ("Mouse X") * sensetivity , Vector3.up);
			yRotationAnchor.transform.rotation *= rotationY;
			transform.rotation *= rotationZ;
			tableCamera.transform.Translate(Input.GetAxis("Mouse ScrollWheel") * Vector3.forward);
		}
			
		//defaultPosition = Time.deltaTime;
	}
}
