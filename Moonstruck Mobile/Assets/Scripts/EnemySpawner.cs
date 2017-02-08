using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public float width = 10f;
	public float height = 5f;
	public float speed = 1f;
	
	private bool movingRight = false;
	private float xmax;
	private float xmin;

	// Use this for initialization
	void Start () {	
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		xmax = rightEdge.x;
		xmin = leftEdge.x;
		
	}
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	
	// Update is called once per frame
	void Update () {
		if(movingRight){
			transform.position += Vector3.right * speed*Time.deltaTime;
		}else{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		float rightEdgeOfFormation = transform.position.x + (width*0.5f);
		float leftEdgeOfFormation =  transform.position.x - (width*0.5f);
		
		if(leftEdgeOfFormation < xmin){
			movingRight = true;
		}else if(rightEdgeOfFormation > xmax){
			movingRight = false;
		}
		
	}
	
	
}
