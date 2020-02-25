using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	public GameObject myPlayer;   // public var that refers to the game object we want to follow player
	public GameObject dialogPanel; // var to hold panel
	private Vector3 offset;   // private var that determines the camera distance from the player


	// Use this for initialization
	void Start()
	{
		offset = transform.position - myPlayer.transform.position; // define a point a certain distance from player
		dialogPanel.SetActive(false);
	}

	// Update is called once per frame
	void LateUpdate()
	{

		if (myPlayer.transform.position.y > -15)
		{ // if player is still on the screen and hasn't fallen
			transform.position = myPlayer.transform.position + 0.2f * offset;  // have the camera relocate to point near robot
		}
		else
		{

			myPlayer.transform.position = new Vector2(0.5f, 1f); // put player back on first ledge

		}
	}
}
