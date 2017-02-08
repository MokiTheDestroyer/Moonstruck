using UnityEngine;
using System.Collections;

public class MoveRight : MonoBehaviour {

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<PlayerController>();
	}
	
	void OnMouseDrag(){
		player.MoveRight();
	}
	
	public void DestroyRight(){
		Destroy(gameObject);
	}
	
}
