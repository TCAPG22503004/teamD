using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

public class Talk : MonoBehaviour
{
	// message
	[SerializeField] TextAsset csv;
	string[,] message;
	int[] pause;
	int num = 0;
	int length;

	// input
	string[] keyList = {"w", "a", "s", "d"};
	string c;

	// other
	bool isSkill3 = false;
	UIChanger ui;
	heroineMovement heroine;
	Variant variant;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		ui = GameObject.Find("UIChanger").GetComponent<UIChanger>();
		heroine = GameObject.Find("Heroine").GetComponent<heroineMovement>();
		variant = GameObject.Find("Variant").GetComponent<Variant>();

		ReadCSV();
		Invoke("Init", 0.03f);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.anyKeyDown) {
			string key = Input.inputString;

			if (c == key) {
				Success();
			}
			else if (keyList.Contains(key)) {
				variant.Miss = 1;
			}
		}
	}


	// load text
	void ReadCSV() {

		// read
		string path = AssetDatabase.GetAssetPath(csv);
		StreamReader sr = new StreamReader(path);
		string file = sr.ReadToEnd();
		sr.Close();

		// split
		string[] text = file.Split('\n');
		length = text.Length;
		message = new string[length, 2];

		for (int i = 0; i < length; i++) {
			string[] row = text[i].Split(',');
			message[i, 0] = row[0];
			message[i, 1] = row[1];
		}

		return;
	}


	// key
	void Success() {

		// display next message
		num++;
		if (num >= length) num = 0;

		ui.SetMessage(message[num, 1]);


		// movement
		heroine.Move();
		int n = int.Parse(message[num, 0]);
		heroine.ChangeImage(n);

		
		// change key
		if (isSkill3 == true) return;

		c = keyList[Random.Range(0, keyList.Length)];
		ui.SetTalk(c);

		return;
	}

	void Init() {
		ui.SetMessage(message[num, 1]);

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
