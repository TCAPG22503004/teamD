using UnityEngine;

public class Talk : MonoBehaviour
{
	string[] keyList = {"w", "a", "s", "d"};
	string c;
	bool isSkill3 = false;
	UIChanger ui;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		ui = GameObject.Find("UIChanger").GetComponent<UIChanger>();
		Invoke("ChangeKey", 0.1f);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.anyKeyDown && c == Input.inputString) ChangeKey();
	}

	void ChangeKey() {
		
		if (isSkill3 == true) return;

		c = keyList[Random.Range(0, keyList.Length)];
		ui.SetTalk(c);

		return;
	}

	// skill
	public void StartSkill3(int t) {
		isSkill3 = true;
		Invoke("EndSkill3", t);
		return;
	}

	void EndSkill3() {
		isSkill3 = false;
		return;
	}
}
