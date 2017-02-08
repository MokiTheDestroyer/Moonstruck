using UnityEngine;
using System.Collections;

public class FormationSplitter : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject NextFormation1;
	public GameObject NextFormation2;
	
	
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
			GameObject newFormation1 = Instantiate(NextFormation1, new Vector3 (0, -0.5f, 0), Quaternion.identity) as GameObject;
			newFormation1.transform.parent = GameObject.Find("FormationMaster").transform;
			
			GameObject newFormation2 = Instantiate(NextFormation2, new Vector3(0, 2.5f, 0) , Quaternion.identity) as GameObject;
			newFormation2.transform.parent = GameObject.Find("FormationMaster").transform;
			
			
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
