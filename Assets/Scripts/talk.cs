using UnityEngine;

public class talk : MonoBehaviour
{
	string[] keyList = {"w", "a", "s", "d"};
	string c;
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
		if (Input.anyKeyDown) {
			if (c == Input.inputString) {
				ChangeKey();
			}
		}
	}

	void ChangeKey() {
		
		c = keyList[Random.Range(0, keyList.Length)];

		ui.SetTalk(c);

		return;
	}
}
