using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {

	private LevelManager levelManager;
	
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(AllMembersDead()){
			Debug.Log ("wtf");
			Invoke("NextLevel", 3f);
		}	
	}
	
	
	
	void NextLevel(){
		levelManager.LoadNextLevel();
	}
	
	bool AllMembersDead(){
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount > 0){
				return false;
			}
		}
		return true;
	}
	
	public void YouLose(){
		levelManager.LoadLevel("LoseScreen");
	}
	
	public void LoserScreen(){
		Invoke("YouLose", 3.5f);
	}
	
}
