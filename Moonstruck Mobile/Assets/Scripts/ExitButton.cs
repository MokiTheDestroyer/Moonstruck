using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

	private LevelManager levelmanager;
	
	void Start () {
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnMouseDown(){
		levelmanager.LoadLevel("LoseScreen");
	}
}
