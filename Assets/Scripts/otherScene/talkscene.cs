using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
using System.Linq;
using TMPro;

public class TalkScene : MonoBehaviour
{
	// text
	[SerializeField] TextAsset csv;
	string[,] message;
	int num = 0;
	int length;

	// other object
	[SerializeField] Sprite[] sprites;
	SpriteRenderer heroine;
	TextMeshProUGUI talker, textBox;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		heroine = GameObject.Find("Heroine").GetComponent<SpriteRenderer>();
		talker = GameObject.Find("Name").GetComponent<TextMeshProUGUI>();
		textBox = GameObject.Find("Message").GetComponent<TextMeshProUGUI>();

		ReadCSV();
		Invoke("ChangeInfo", 0.03f);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) {

			num++;

			if (num >= length) {
				SceneManager.LoadScene("game");
			}
			else {
				ChangeInfo();
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
		message = new string[length, 3];

		for (int i = 0; i < length; i++) {
			string[] row = text[i].Split(',');
			for (int j = 0; j < 3; j++) {
				message[i, j] = row[j].Replace('\t', '\n');
			}
		}

		return;
	}


	void ChangeInfo() {

		// heroine
		int n = int.Parse(message[num, 1]);
		if (n >= 0) {
			heroine.sprite = sprites[n];
		}
		else {
			heroine.sprite = null;
		}

		// ui
		talker.text = message[num, 0];
		textBox.text = message[num, 2];

		return;
	}
}