using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

	private float rotSpeed;

	private Collider coll;

	private float gameWidth = 8.0f;

	void Start() {
		coll = GetComponent<Collider>();
		coll.enabled = false;		
		
		float x;
		float z;

		GameObject player = GameObject.Find("Player");
		float mag = 0.0f;
		while (mag < 9.0f || mag > 100.0f) {
			x = Random.Range(-1*gameWidth, gameWidth);
			z = Random.Range(-1*gameWidth, gameWidth);
			transform.position = new Vector3(x, 0.5f, z);
			mag = (transform.position - player.transform.position).sqrMagnitude;
		}		
		coll.enabled = true;

		float r = Random.Range(0.0f, 1.0f);
		float g = Random.Range(0.0f, 1.0f);
		float b = Random.Range(0.0f, 1.0f);

		Renderer rend = GetComponent<Renderer>();
        rend.material.color = new Color(r, g, b, 1.0f);

		rotSpeed = 0;
		while (Mathf.Abs(rotSpeed) < 30){
			rotSpeed = Random.Range(-75,75);
		}

		
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, rotSpeed, 0) * Time.deltaTime, Space.World);
	}
}
