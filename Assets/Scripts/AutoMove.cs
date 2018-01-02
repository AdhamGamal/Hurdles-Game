using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoMove : MonoBehaviour {
	private Rigidbody rb;
	public Text CountText;
	public Text WinText;
	private float count;
	private bool dead;
	void Start(){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		setCountText ();
		WinText.text = "";
		dead = false;
	}
	void FixedUpdate(){
		if (!dead) {
			if (Input.GetKeyDown (KeyCode.Space) && transform.position.y <= 0.5f)
				rb.AddForce (new Vector3 (0, 1, 0) * 400);
			transform.position = transform.position + (new Vector3 (0, 0, 1) * Time.deltaTime * 5);
			count=transform.position.z;
			setCountText ();
		}
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Hurdle"))
		{
			WinText.text = "OOOPS.";
			dead = true;
		}
	}
	void setCountText(){
		CountText.text = "Count : " + ((int)count).ToString ();
		if (count >= 490) {
			WinText.text = "You Win.";
			dead = true;
		}
	}
}
