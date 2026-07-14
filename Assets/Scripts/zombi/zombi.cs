using UnityEngine;

public class Zombi : MonoBehaviour
{
	// zombi parameter
	[SerializeField] int hp;
	[SerializeField] int attack;
	[SerializeField] float speed;
	[SerializeField] float maxScale;
	[SerializeField] float flipInterval;
	float initSpeed;
	int rotSign = 1;

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
	zombi_horizontal horizon;

	// (damage : change?)
	Transform head, body;
	SpriteRenderer spriteHead, spriteBody;
	Color color;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		treasureObj = GameObject.Find("Treasures").transform;

		spawner = GameObject.Find("Spawner").GetComponent<spawn>();
		parameter = GameObject.Find("Parameter").GetComponent<playerParameter>();
		ui = GameObject.Find("UIChanger").GetComponent<UIChanger>();
		skill = GameObject.Find("Skill").GetComponent<Skill>();
		init = GameObject.Find("Init").GetComponent<Init>();
		variant = GameObject.Find("Variant").GetComponent<Variant>();
		horizon = this.GetComponent<zombi_horizontal>();

		head = this.transform.Find("Head");
		body = this.transform.Find("Body");
		spriteHead = head.GetComponent<SpriteRenderer>();
		spriteBody = body.GetComponent<SpriteRenderer>();
		color = body.GetComponent<Renderer>().material.color;

		SetSpeed();

		InvokeRepeating("Flip", flipInterval, flipInterval);
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
		int n = (int)(this.transform.localScale.x * 10);

		spriteHead.sortingOrder = n;
		spriteBody.sortingOrder = n;

		if (this.transform.localScale.x > maxScale) Attack();

		return;
	}


	void Flip() {

		Vector3 r = new Vector3(0f, (float)180 * rotSign, 0f);
		rotSign *= -1;

		this.transform.Rotate(r);

		// horizontal
		if (horizon) horizon.SwitchDirection();

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
		body.GetComponent<Renderer>().material.color = Color.red;
		Invoke("ResetColor", 0.1f);

		return;
	}

	void ResetColor() {

		body.GetComponent<Renderer>().material.color = color;

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
