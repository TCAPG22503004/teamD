using UnityEngine;

public class Bomb : MonoBehaviour
{
	int nBomb = 0;

	Gun gun;
	playerParameter player;
	UIChanger ui;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		gun = this.GetComponent<Gun>();
		player = GameObject.Find("Parameter").GetComponent<playerParameter>();
		ui = GameObject.Find("UIChanger").GetComponent<UIChanger>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}


	public void IncrementNBomb() {

		nBomb++;

		ui.SetBomb(nBomb);

		return;
	}

	public void UseBomb() {

		// kill all enemys

		GameObject[] gos = GameObject.FindGameObjectsWithTag("enemy");
		
		foreach (GameObject go in gos) {
			go.GetComponent<zombi>().Damage(999);
		}


		// update chain & nBomb

		int chain = player.ChainReset();
		ui.SetChain(chain);

		nBomb--;
		ui.SetBomb(nBomb);

		return;
	}

	public int GetNBomb() {
		return nBomb;
	}
}
