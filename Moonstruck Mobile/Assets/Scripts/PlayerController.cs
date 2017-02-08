using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject explosion;
	public float movementSpeed = 15f;
	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate = 0.2f;
	
	private MoveLeft moveLeft;
	private MoveRight moveRight;
	private float timer = 0.0f;
	private float padding = 0.75f;
	float xmax;
	float xmin;
	
	private ChangeLevel changeLevel;
	private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		changeLevel = GameObject.FindObjectOfType<ChangeLevel>();
		moveLeft = GameObject.FindObjectOfType<MoveLeft>();
		moveRight = GameObject.FindObjectOfType<MoveRight>();
		playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
	
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;
	}
	
	
	
	void Fire(){
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
	
		Vector3 offset = new Vector3 (0, 0.6f, 0);
		GameObject beam = Instantiate(projectile, transform.position + offset, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
		timer += Time.deltaTime;
		if(timer > 0.2f)
		{
			Fire();
			timer -= 0.2f;
		}
		
	
		
		//restrict player to game space
		float newX = Mathf.Clamp(transform.position.x, xmin , xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);	
	}
	
	public void MoveLeft(){
		transform.position += Vector3.left * movementSpeed * Time.deltaTime;
	}
	
	public void MoveRight(){
		transform.position += Vector3.right * movementSpeed * Time.deltaTime;
	}
	
	
	void Explosion(){
		Instantiate(explosion, transform.position, Quaternion.identity);
		
	}
	
	
	
	
	
	void OnTriggerEnter2D(Collider2D col){
		Projectile missile = col.gameObject.GetComponent<Projectile>();
		if(missile){
			missile.Hit();
			playerHealth.Hurt(missile.GetDamage ());
			
				if(PlayerHealth.health <= 0){
					changeLevel.LoserScreen();
					Explosion();
				
					playerHealth.myText.text = "DEAD!";
					moveLeft.DestroyLeft();
					moveRight.DestroyRight();
					
					Destroy(gameObject);	
				}
			
		}
	}
	
	
	
	
}
