using UnityEngine;
using System.Collections;

public class CutScenes : MonoBehaviour {
	public float time;
	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		Invoke("BeginLevel", time);
	}
	
	void BeginLevel(){
		levelManager.LoadNextLevel();
	}
	
}
