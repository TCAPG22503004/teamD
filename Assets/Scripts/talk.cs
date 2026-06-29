using UnityEngine;

public class Talk : MonoBehaviour
{
	// message
	string[] message = {"aaa", "bbb", "ccc", "ddd", "eee"};
	int num = -1;

	// input
	string[] keyList = {"w", "a", "s", "d"};
	string c;

	// other
	bool isSkill3 = false;
	UIChanger ui;
	heroineMovement heroine;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		ui = GameObject.Find("UIChanger").GetComponent<UIChanger>();
		heroine = GameObject.Find("Heroine").GetComponent<heroineMovement>();
		Invoke("Success", 0.1f);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.anyKeyDown && c == Input.inputString) Success();
	}

	void Success() {

		// movement

		heroine.Move();


		// display next message

		num++;
		if (num >= message.Length) num = 0;

		ui.SetMessage(message[num]);

		
		// change key

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
