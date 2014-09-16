using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	private int collected;
	public GUIText countText;
	public GUIText winText;
	public int cyanide;
	private float boost;
	public int boosth;
	private Vector3 point;
	public GUIText boostxt;

	void Start(){
		collected = 0;
		SetCountText();
		boost = (float)boosth/100;
		SetboostText ();
		point = new Vector3(0,0,0);
		}
	void FixedUpdate ()
	{
				float moveHorizontal = Input.GetAxis ("Horizontal");
				float moveVertical = Input.GetAxis ("Vertical");
				bool jump = Input.GetButton ("Jump");
				float jumpforce = 0;
				if (jump) {
						if (boost>0.01) {
								jumpforce = 20;
								boost -= Time.deltaTime;
								SetboostText();
						}
				} else {
						jumpforce = 0;
			if (gameObject.rigidbody.GetRelativePointVelocity (point).y <= 2) {
				//gameObject.rigidbody.GetRelativePointVelocity (point).y == 0
								if (boost<(float)boosth/100) {
										boost += Time.deltaTime;
										SetboostText();
								}
								
						}
				}


				Vector3 movement = new Vector3 (moveHorizontal*speed*Time.deltaTime, jumpforce, moveVertical*speed*Time.deltaTime);

		rigidbody.AddForce(movement);
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Pickup"){
			other.gameObject.SetActive(false);
			collected++;
			SetCountText();
		}
	}

	void SetCountText(){
			countText.text = "Count: " + collected.ToString ();
			if (collected >= cyanide) {
						winText.text = "you ate all the cyanide and died... grats";
			speed = 0;
				} else {
						winText.text = "";
				}
		}
	void SetboostText(){
		int boostp = (int)(boost*100);
		boostxt.text = "Boost: " + boostp.ToString ();
	}
}

//Destroy(other.gameObject);
//gameObject.tag = "Player";
//gameObject.SetActive(false);