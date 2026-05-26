using UnityEngine;

public class Skill : MonoBehaviour
{
	int nSkillMax = 5;
	int nSkill;
	int duration = 15;
	int cooldown = 10;
	
	int skill;
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
				break;

			case 5:
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
}
