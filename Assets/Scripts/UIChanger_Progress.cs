using UnityEngine;
using UnityEngine.UI;

public class UIChanger_Progress : MonoBehaviour
{
	[SerializeField] Image[] images;
	[SerializeField] float timeStartBlink;
	[SerializeField] float blinkSpeed;

	int target = 0;
	int len;
	float dt, color;
	bool isBlinking;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		// set dt
		len = images.Length;
		int totalTime = GameObject.Find("Init").GetComponent<Init>().GetTime();
		dt = (float)totalTime / (float) len;

		// start function
		InvokeRepeating("ChangeTarget", dt, dt);

		// current image
		isBlinking = false;
		Invoke("StartBlink", timeStartBlink);
	}

	// Update is called once per frame
	void Update()
	{
		if (isBlinking) ChangeColor();
	}

	void ChangeTarget() {

		// black old target
		images[target].color = new Color(0, 0, 0);

		// next image or finish(to avoid IndexOutOfRange)
		if (target + 1 < len) {
			target++;
			isBlinking = false;
			Invoke("StartBlink", timeStartBlink);
		}
		else {
			CancelInvoke("ChangeTarget");
		}

		return;
	}

	void ChangeColor() {

		// delta
		float d = blinkSpeed * Time.deltaTime;

		// is in range?
		if ((color + d >= 0) && (color + d <= 1)) {
			color += d;
		}
		else {
			blinkSpeed *= -1;
		}

		// change 
		images[target].color = new Color(color, color, color);

		return;
	}

	void StartBlink() {
		isBlinking = true;
		return;
	}
}
