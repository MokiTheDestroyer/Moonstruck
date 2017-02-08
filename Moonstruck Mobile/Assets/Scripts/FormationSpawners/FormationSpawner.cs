using UnityEngine;
using System.Collections;

public class FormationSpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject NextFormation;


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
			GameObject newFormation = Instantiate(NextFormation, transform.position, Quaternion.identity) as GameObject;
			newFormation.transform.parent = GameObject.Find("FormationMaster").transform;
			
			
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
