using UnityEngine;

public class Favorite : MonoBehaviour
{
	[SerializeField] int delta;

	float fav;
	playerParameter parameter;
	UIChanger ui;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		parameter = GameObject.Find("Parameter").GetComponent<playerParameter>();
		ui = GameObject.Find("UIChanger").GetComponent<UIChanger>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void ChangeFav(float n) {

		// change value
		fav += n;

		// is change level?
		if (fav > delta){
			LevelUp();
		}
		else if (fav < 0) {
			LevelDown();
		}

		// reflect ui
		ui.SetFavorite(fav);

		return;
	}


	void LevelUp() {

		int level = parameter.LevelUp();
		ui.SetLevel(level);

		fav = 0;

		return;
	}

	void LevelDown() {

		// get level
		int level = parameter.LevelDown();

		// is level -1?
		if (level < 0) {
			level = parameter.LevelUp();
			fav = 0;
		}

		else {
			fav = delta - 1;
		}

		// ui
		ui.SetLevel(level);

		return;
	}

	public int GetDelta() {
		return delta;
	}
}
