using UnityEngine;
using System.Collections;

public class LastFormation : MonoBehaviour {
	
	public GameObject enemyPrefab;
	
	

	void Start(){
		SpawnEnemies();
		
	}
	
	void SpawnEnemies(){
		foreach(Transform child in transform){
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
			
		
	}
	
	void Update(){
		if(AllMembersDead()){
			Destroy(gameObject);
		}
	}
	
	
	
	bool AllMembersDead(){
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount > 0){
				return false;
			}
		}
		return true;
	}
}
