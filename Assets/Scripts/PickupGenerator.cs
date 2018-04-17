using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGenerator : MonoBehaviour {

	private GameObject pickupGroup;
	private int seconds;
	private int count = 1;

	private GameObject player;
	private PlayerController playercontrol;

	// Use this for initialization
	void Start () {

		player = GameObject.Find("Player");
		playercontrol = player.GetComponent<PlayerController>();
		
		pickupGroup = GameObject.Find("Pickups");
		for (int x = 0; x < 25; x++) {
			CreatePickup();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (playercontrol.gameover) {
			// print("game over");
		} else {
			seconds = Mathf.RoundToInt(Time.realtimeSinceStartup);
			if (seconds - count >= 0){
				CreatePickup();
				count += 3;
			}
			// print(seconds.ToString());
			// print(count.ToString());
		}
		
	}

	void CreatePickup () {
		GameObject i = Instantiate(Resources.Load("Pickup")) as GameObject;
		i.transform.SetParent(pickupGroup.transform);
	}
}
