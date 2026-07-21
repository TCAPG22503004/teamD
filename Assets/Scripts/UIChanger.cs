using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIChanger : MonoBehaviour
{
	// this
	TextMeshProUGUI level, chain, capacityNow, capacityMax, talk, skill, message, talker, hpPercent;
	GameObject reload;
	Transform fav, bomb;
	RawImage gun;
	Image hp;

	// other object
	int hpMax, favMax;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		// get other component
		level = GameObject.Find("Level").GetComponent<TextMeshProUGUI>();
		chain = GameObject.Find("Chain").GetComponent<TextMeshProUGUI>();
		capacityNow = GameObject.Find("Capacity/Current").GetComponent<TextMeshProUGUI>();
		capacityMax = GameObject.Find("Capacity/Max").GetComponent<TextMeshProUGUI>();
		talk = GameObject.Find("Talk").GetComponent<TextMeshProUGUI>();
		skill = GameObject.Find("Space").GetComponent<TextMeshProUGUI>();
		message = GameObject.Find("Message").GetComponent<TextMeshProUGUI>();
		talker = GameObject.Find("Name").GetComponent<TextMeshProUGUI>();
		hpPercent = GameObject.Find("HP/Percent").GetComponent<TextMeshProUGUI>();

		reload = GameObject.Find("Reload");
		SetReload(false);

		fav = GameObject.Find("FavoriteUI/Current").transform;
		bomb = GameObject.Find("Bomb").transform;

		gun = GameObject.Find("Capacity/Gun").GetComponent<RawImage>();
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

	public void SetCapacity(int i, int j, Texture2D img) {

		// current
		// use skill 2
		if (i < 0) {
			capacityNow.text = "infinity";
		}

		else {
			capacityNow.text = i.ToString();
		}

		// other
		capacityMax.text = j.ToString();

		gun.texture = img;

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

		float ratio = (float)n / (float)hpMax;
		hp.fillAmount = ratio * 0.75f;

		hpPercent.text = (ratio * 100).ToString("f0") + "%";

		return;
	}

	public void SetFavorite(float n) {
		float ratio = n / (float)favMax;
		fav.localScale = new Vector3(1, ratio, 1);
		return;
	}

	public void SetBomb(int n, bool isPlus) {

		int m = isPlus ? (n-1) : n;
		Color c = isPlus ? Color.green : Color.gray;

		Image img = bomb.GetChild(m).gameObject.GetComponent<Image>();
		img.color = c;

		return;
	}
}
