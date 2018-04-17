using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Reference the Unity Analytics namespace
using UnityEngine.Analytics;

public class PlayerController : MonoBehaviour {

	public Text countText;
	public Text ohNo;
	private Rigidbody rb;
	public float speed;

	private bool didCustomFire = false;

	private int count;

	private Vector3 targetScale;

	public bool gameover = false;

	void Start () {
		count = 0;
		SetCountText();

		rb = GetComponent<Rigidbody>();

		targetScale = transform.localScale;
		
	}

	void Update () {
		transform.localScale = Vector3.Lerp (transform.localScale, targetScale, 0.5f * Time.deltaTime);
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
		rb.AddForce(movement * speed);

		if (Mathf.Abs(transform.position.x) > 11 || Mathf.Abs(transform.position.z) > 11) {
			
			// Only fire the gameover event once
			if (!gameover) {
				ohNo.text = "☹ Oh no! ☹";

				AnalyticsEvent.GameOver("game_over", new Dictionary<string, object> {
					{ "score", count }
				});
				gameover = true;
			};

			
		}

	}

	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.CompareTag("pickup")){
			count++;
			// transform.position = transform.position + new Vector3(0, 0.5f ,0);
			targetScale += new Vector3(0.1f,0.1f,0.1f);
			other.gameObject.SetActive(false);

			SetCountText();

		if (count == 50 && !gameover && !didCustomFire) {
			Analytics.CustomEvent("fifty_score", new Dictionary<string, object> {
				{ "score", count }
			});
			didCustomFire = true;
		}			

			
		}
	}

	void SetCountText() {
		countText.text = "Score: " + count.ToString();
	}
}
