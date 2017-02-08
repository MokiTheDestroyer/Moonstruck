using UnityEngine;
using System.Collections;

public class BossBehaviour : MonoBehaviour {

	public GameObject explosion;
	public float laserSpeed;
	public float health = 100f;
	public GameObject projectile;
	public float shotsPerSecond = 0.8f;
	public int scoreValue;
	
	
	private ScoreKeeper scoreKeeper;
	
	void Start(){
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	
	IEnumerator ChangeColor(){
		transform.GetComponent<Renderer>().material.color = Color.red;
		yield return new WaitForSeconds(0.02f);
		transform.GetComponent<Renderer>().material.color = Color.white;
	}
	
	
	void OnTriggerEnter2D(Collider2D col){
		Projectile missile = col.gameObject.GetComponent<Projectile>();
		if(missile){
	
			StartCoroutine(ChangeColor ());
	
			health -= missile.GetDamage();
			missile.Hit();
			if(health <= 0){
				Explosion();
				scoreKeeper.Score(scoreValue);
				Destroy(gameObject);
			}
		}
	}
	
	void Explosion(){
		Instantiate(explosion, transform.position, Quaternion.identity);
		
	}
	
	void Update(){
		float probability = shotsPerSecond *Time.deltaTime;
		if(Random.value < probability){
			Fire ();
		}
		
		
	}
	
	void Fire(){
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
	
		Vector3 startPosition1 = transform.position + new Vector3(0, -0.6f, 0);
		GameObject beam1 = Instantiate(projectile, startPosition1, Quaternion.identity) as GameObject;
		beam1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -laserSpeed, 0);
		
		Vector3 startPosition2 = transform.position + new Vector3(1, -0.6f, 0);
		GameObject beam2 = Instantiate(projectile, startPosition2, Quaternion.identity) as GameObject;
		beam2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -laserSpeed, 0);
		
		Vector3 startPosition3 = transform.position + new Vector3(-1, -0.6f, 0);
		GameObject beam3 = Instantiate(projectile, startPosition3, Quaternion.identity) as GameObject;
		beam3.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -laserSpeed, 0);
		
		
	}
}
