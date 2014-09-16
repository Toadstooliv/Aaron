using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position;
	}

	void Update () {
		//transform.RotateAround(Vector3.zero,Vector3.up, 10*Time.deltaTime);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//transform.RotateAround (Vector3.zero, Vector3.up, 10 * Time.deltaTime);
		transform.position = player.transform.position + offset;
	}
}
