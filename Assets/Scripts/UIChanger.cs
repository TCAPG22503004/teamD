using UnityEngine;
using TMPro;

public class UIChanger : MonoBehaviour
{
	// this
	TextMeshProUGUI level, chain, capacity, bomb, talk;
	GameObject reload, hp;

	// other object
	playerParameter parameter;
	int hpMax;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		level = GameObject.Find("Level").GetComponent<TextMeshProUGUI>();
		chain = GameObject.Find("Chain").GetComponent<TextMeshProUGUI>();
		capacity = GameObject.Find("Capacity").GetComponent<TextMeshProUGUI>();
		bomb = GameObject.Find("Bomb").GetComponent<TextMeshProUGUI>();
		talk = GameObject.Find("Talk").GetComponent<TextMeshProUGUI>();

		reload = GameObject.Find("Reload");
		SetReload(false);

		hp = GameObject.Find("HP/Current");

		parameter = GameObject.Find("Parameter").GetComponent<playerParameter>();
		hpMax = parameter.ChangeHP(0);
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
		capacity.text = name + " " + i.ToString() + " / " + j.ToString();
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

	public void SetReload(bool b) {
		reload.SetActive(b);
		return;
	}

	public void SetHP(int n) {
		float ratio = (float)n / (float)hpMax;
		hp.transform.localScale = new Vector3(1, ratio, 1);
		return;
	}
}
