using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour {

	private PlayerController player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<PlayerController>();
	}
	
	void OnMouseDrag(){
		player.MoveLeft();
	}
	
	public void DestroyLeft(){
		Destroy(gameObject);
	}

}