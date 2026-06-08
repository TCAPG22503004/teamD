using UnityEngine;

public class Skill : MonoBehaviour
{
	[SerializeField] int nSkillMax;
	[SerializeField] int duration;
	[SerializeField] int cooldown;
	[SerializeField] float skill4Speed;
	[SerializeField] float skill5Speed;
	
	int skill;
	int nSkill;
	bool usingSkill = false;

	playerParameter parameter;
	Shoot shoot;
	Talk talk;
	UIChanger ui;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		parameter = GameObject.Find("Parameter").GetComponent<playerParameter>();
		shoot = GameObject.Find("Gun").GetComponent<Shoot>();
		talk = GameObject.Find("Key").GetComponent<Talk>();
		ui = GameObject.Find("UIChanger").GetComponent<UIChanger>();

		nSkill = nSkillMax;
		Invoke("Init", 0.1f);
	}

	// set ui after loading
	void Init() {
		ui.SetSkill(nSkill, nSkillMax);
		return;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) {
			UseSkill();
		}
	}

	void UseSkill() {

		// set boolean
		if (usingSkill) return;
		usingSkill = true;

		// set num
		if (nSkill <= 0) return;
		nSkill--;

		// use skill
		skill = parameter.GetLevel();
		switch (skill) {
			case 2:
				shoot.StartSkill2(duration);
				break;

			case 3:
				talk.StartSkill3(duration);
				break;

			case 4:
				StartSkillZombi();
				break;

			case 5:
				StartSkillZombi();
				break;

			default:
				usingSkill = false;
				nSkill++;
				break;
		}
		
		ui.SetSkill(-skill, -skill);

		// set end function
		Invoke("EndSkill", duration);

		return;
	}

	void EndSkill() {

		skill = 0;

		ui.SetSkill(-1, -1);

		Invoke("EndSkillCooldown", cooldown);

		return;
	}


	void EndSkillCooldown() {

		usingSkill = false;

		ui.SetSkill(nSkill, nSkillMax);

		return;
	}




	/* -----------------
		zombi
	--------------------*/

	// called function (because "invoke" cannot have arguments)

	void StartSkillZombi() {

		SkillZombi(true);

		Invoke("EndSkillZombi", duration);

		return;
	}

	void EndSkillZombi() {

		SkillZombi(false);

		return;
	}


	// skill

	void SkillZombi(bool isStart) {

		GameObject[] zombis = GameObject.FindGameObjectsWithTag("enemy");

		foreach (GameObject zombi in zombis) {

			// start skill
			if (isStart) {

				float d = skill4Speed;
				if (skill == 5) d = skill5Speed;

				zombi.GetComponent<Zombi>().StartSkill(d);
			}

			// end
			else {
				zombi.GetComponent<Zombi>().EndSkill();

			}
		}

		return;
	}


	// called from zombi
	public float GetDelta() {

		if (usingSkill == false) return 1;
		
		switch (skill) {
			case 4:
				return skill4Speed;

			case 5:
				return skill5Speed;

			default:
				return 1;
		}
	}
}
