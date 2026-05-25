using UnityEngine;

public class zombi : MonoBehaviour
{
	// zombi parameter
	[SerializeField] int hp;
	[SerializeField] int attack;
	[SerializeField] float speed;

	// treasure
	[SerializeField] GameObject treasure;
	float ratioTreasure = 0.1f;

	// other class
	spawn spawner;
	playerParameter parameter;
	UIChanger ui;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		spawner = GameObject.Find("Spawner").GetComponent<spawn>();
		parameter = GameObject.Find("Parameter").GetComponent<playerParameter>();
		ui = GameObject.Find("UIChanger").GetComponent<UIChanger>();
	}

	// Update is called once per frame
	void Update()
	{
		Movement();
	}
	

	/* ---------------
		move
	------------------ */

	void Movement() {
		
		this.transform.localScale += this.transform.localScale * speed * Time.deltaTime;
		
		if (this.transform.localScale.x > 3f) Attack();

		return;
	}


	/* ------------------
		attack
	--------------------- */

	void Attack() {

		int hp = parameter.ChangeHP(-attack);
		ui.SetHP(hp);

		spawner.DecrementNumZombi();
		Destroy(this.gameObject);

		return;
	}

	
	/* ------------------
		damage
	--------------------- */

	public void Damage(int n) {

		hp -= n;

		if (hp <= 0) Death();

		return;
	}

	void Death() {
	
		spawner.DecrementNumZombi();

		SpawnTreasure();

		Destroy(this.gameObject);

		return;
	}

	void SpawnTreasure() {

		if (Random.value < ratioTreasure) {
			Instantiate(treasure, this.transform.position, Quaternion.identity);
		}
	}
}
