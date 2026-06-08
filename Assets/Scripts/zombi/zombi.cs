using UnityEngine;

public class Zombi : MonoBehaviour
{
	// zombi parameter
	[SerializeField] int hp;
	[SerializeField] int attack;
	[SerializeField] float speed;
	float initSpeed;
	SpriteRenderer sprite;

	// treasure
	[SerializeField] GameObject treasure;
	float ratioTreasure = 0.1f;
	Transform treasureObj;

	// other class
	spawn spawner;
	playerParameter parameter;
	UIChanger ui;
	Skill skill;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		sprite =  this.transform.GetChild(0).GetComponent<SpriteRenderer>();

		treasureObj = GameObject.Find("Treasures").transform;

		spawner = GameObject.Find("Spawner").GetComponent<spawn>();
		parameter = GameObject.Find("Parameter").GetComponent<playerParameter>();
		ui = GameObject.Find("UIChanger").GetComponent<UIChanger>();
		skill = GameObject.Find("Skill").GetComponent<Skill>();

		SetSpeed();
	}

	// Update is called once per frame
	void Update()
	{
		Movement();
	}


	/* ---------------
		init
	------------------ */
	void SetSpeed() {

		initSpeed = speed;

		float d = skill.GetDelta();

		// change speed if skill 4 or 5 is triggered
		StartSkill(d);

		return;
	}
	

	/* ---------------
		move
	------------------ */

	void Movement() {
		
		this.transform.localScale += Vector3.one * speed * Time.deltaTime;
		sprite.sortingOrder = (int)(this.transform.localScale.x * 10);
		
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
			Instantiate(treasure, this.transform.position, Quaternion.identity, treasureObj);
		}
	}


	/* ------------------------
		skill(4, 5)
	--------------------------- */

	public void StartSkill(float d) {

		speed *= d;

		return;
	}

	public void EndSkill() {

		speed = initSpeed;

		return;
	}
}
