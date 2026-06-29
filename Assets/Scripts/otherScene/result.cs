using UnityEngine;
using TMPro;

public class result : MonoBehaviour
{
	Variant variant;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		variant = GameObject.Find("Variant").GetComponent<Variant>();

		SetResultText();
		SetBulletText();
		SetBombText();
		SetMissText();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	void SetResultText() {

		TextMeshProUGUI text = GameObject.Find("ResultText").GetComponent<TextMeshProUGUI>();

		if (variant.IsClear) {
			text.text = "Stage Clear";
		}
		else {
			text.text = "Game Over";
		}

		return;
	}

	void SetBulletText() {

		TextMeshProUGUI text = GameObject.Find("Bullet").GetComponent<TextMeshProUGUI>();

		int n = variant.Hit;
		int m = variant.Total;

		text.text = $"hit / total {n} / {m}";

		return;
	}

	void SetBombText() {

		TextMeshProUGUI text = GameObject.Find("Bomb").GetComponent<TextMeshProUGUI>();

		int n = variant.Bomb;

		text.text = $"Bomb: {n}";

		return;
	}

	void SetMissText() {

		TextMeshProUGUI text = GameObject.Find("Miss").GetComponent<TextMeshProUGUI>();

		int n = variant.Miss;

		text.text = $"Typing Miss: {n}";

		return;
	}
}
