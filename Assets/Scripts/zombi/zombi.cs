using UnityEngine;

public class Zombi : MonoBehaviour
{
	// zombi parameter
	[SerializeField] int hp;
	[SerializeField] int attack;
	[SerializeField] float speed;
	float initSpeed;
	SpriteRenderer sprite1, sprite2;

	// treasure
	[SerializeField] GameObject treasure;
	float ratioTreasure = 0.1f;
	Transform treasureObj;

	// other class
	spawn spawner;
	playerParameter parameter;
	UIChanger ui;
	Skill skill;
	Init init;
	Variant variant;

	// (damage : change?)
	Transform child1, child2;
	Color color;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		sprite1 =  this.transform.Find("Head").GetComponent<SpriteRenderer>();
		sprite2 =  this.transform.Find("Square").GetComponent<SpriteRenderer>();

		treasureObj = GameObject.Find("Treasures").transform;

		spawner = GameObject.Find("Spawner").GetComponent<spawn>();
		parameter = GameObject.Find("Parameter").GetComponent<playerParameter>();
		ui = GameObject.Find("UIChanger").GetComponent<UIChanger>();
		skill = GameObject.Find("Skill").GetComponent<Skill>();
		init = GameObject.Find("Init").GetComponent<Init>();
		variant = GameObject.Find("Variant").GetComponent<Variant>();

		child1 = this.transform.Find("Head");
		child2 = this.transform.Find("Square");
		color = child1.GetComponent<Renderer>().material.color;

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
		sprite1.sortingOrder = (int)(this.transform.localScale.x * 10) + 1;
		sprite2.sortingOrder = (int)(this.transform.localScale.x * 10);
		
		if (this.transform.localScale.x > 3f) Attack();

		return;
	}


	/* ------------------
		attack
	--------------------- */

	void Attack() {

		int hp = parameter.ChangeHP(-attack);
		if (hp <= 0) {
			hp = parameter.ChangeHP(-hp);	// set hp 0 (to UI)
			variant.IsClear = false;
			init.Result();
		}
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

		// (change?)
		child1.GetComponent<Renderer>().material.color = Color.red;
		child2.GetComponent<Renderer>().material.color = Color.red;
		Invoke("ResetColor", 0.1f);

		return;
	}

	void ResetColor() {

		child1.GetComponent<Renderer>().material.color = color;
		child2.GetComponent<Renderer>().material.color = color;

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
