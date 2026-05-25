using UnityEngine;

public class skill : MonoBehaviour
{
	int duration;
	bool canUseSkill;

	playerParameter parameter;
	Shoot shoot;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		parameter = GameObject.Find("Parameter").GetComponent<playerParameter>();
		shoot = GameObject.Find("Gun").GetComponent<Shoot>();
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
		if (canUseSkill == false) return;
		canUseSkill = false;

		int level = parameter.GetLevel();


		// use skill
		switch (level) {
			case 1:
				return;

			case 2:
				shoot.StartSkill();
				Invoke("EndSkill2", 1f);
				return;

			case 3:
				return;

			case 4:
				return;

			case 5:
				return;
		}

		return;
	}

	void EndSkillCooldown() {

		canUseSkill = true;

		return;
	}

	void EndSkill2() {

		shoot.EndSkill();

		return;
	}
}
