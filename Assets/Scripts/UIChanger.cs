using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIChanger : MonoBehaviour
{
	// this
	TextMeshProUGUI level, chain, capacity, bomb, talk, skill, message, talker;
	GameObject reload, fav;
	Image hp;

	// other object
	int hpMax, favMax;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		// get other component
		level = GameObject.Find("Level").GetComponent<TextMeshProUGUI>();
		chain = GameObject.Find("Chain").GetComponent<TextMeshProUGUI>();
		capacity = GameObject.Find("Capacity").GetComponent<TextMeshProUGUI>();
		bomb = GameObject.Find("Bomb").GetComponent<TextMeshProUGUI>();
		talk = GameObject.Find("Talk").GetComponent<TextMeshProUGUI>();
		skill = GameObject.Find("Space").GetComponent<TextMeshProUGUI>();
		message = GameObject.Find("Message").GetComponent<TextMeshProUGUI>();
		talker = GameObject.Find("Name").GetComponent<TextMeshProUGUI>();

		reload = GameObject.Find("Reload");
		SetReload(false);
		fav = GameObject.Find("FavoriteUI/Current");

		hp = GameObject.Find("HP/Current").GetComponent<Image>();


		// set variant
		playerParameter parameter = GameObject.Find("Parameter").GetComponent<playerParameter>();
		hpMax = parameter.ChangeHP(0);

		Favorite favorite = GameObject.Find("Heroine").GetComponent<Favorite>();
		favMax = favorite.GetDelta();
	}

	// Update is called once per frame
	void Update()
	{
		
	}


	public void SetLevel(int i) {
		level.text = "Lv. " + i.ToString();
		return;
	}
	
	public void SetChain(int i) {
		chain.text = i.ToString() + " chain";
		return;
	}

	public void SetCapacity(string name, int i, int j) {

		// use skill 2
		if (i < 0) {
			capacity.text = name + " " + "infinity";
		}

		else {
			capacity.text = name + " " + i.ToString() + " / " + j.ToString();
		}

		return;
	}

	public void SetBomb(int i) {
		bomb.text = "Bomb: " + i.ToString();
		return;
	}

	public void SetTalk(string c) {
		talk.text = c;
		return;
	}

	public void SetSkill(int i, int j) {

		// skill status
		switch (i) {
			case -1:
				skill.text = "Skill CoolDown";
				break;

			case -2:
				skill.text = "Skill 2 (Infinite bullets)";
				break;

			case -3:
				skill.text = "Skill 3 (Same Key)";
				break;

			case -4:
				skill.text = "Skill 4 (Slow Zombi)";
				break;

			case -5:
				skill.text = "Skill 5 (Stop Zombi)";
				break;

			default:
				skill.text = "Skill " + i.ToString() + " / " + j.ToString();
				break;
		}

		return;
	}

	public void SetMessage(string s) {
		message.text = s;
		return;
	}

	public void SetName(string s) {
		talker.text = s;
		return;
	}

	public void SetReload(bool b) {
		reload.SetActive(b);
		return;
	}

	public void SetHP(int n) {
		float ratio = (float)n / (float)hpMax * 0.75f;
		hp.fillAmount = ratio;
		return;
	}

	public void SetFavorite(float n) {
		float ratio = n / (float)favMax;
		fav.transform.localScale = new Vector3(1, ratio, 1);
		return;
	}
}
