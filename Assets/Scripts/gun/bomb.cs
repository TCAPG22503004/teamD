using UnityEngine;

public class Bomb : MonoBehaviour
{
	int nBomb = 0;

	Gun gun;
	playerParameter player;
	UIChanger ui;
	Variant variant;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		gun = this.GetComponent<Gun>();
		player = GameObject.Find("Parameter").GetComponent<playerParameter>();
		ui = GameObject.Find("UIChanger").GetComponent<UIChanger>();
		variant = GameObject.Find("Variant").GetComponent<Variant>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}


	public void IncrementNBomb() {

		if (nBomb >= 5) return;

		nBomb++;

		ui.SetBomb(nBomb, true);

		return;
	}

	public void UseBomb() {

		variant.Bomb = 1;

		// kill all enemys
		GameObject[] gos = GameObject.FindGameObjectsWithTag("enemy");
		
		foreach (GameObject go in gos) {
			try {
				go.GetComponent<Zombi>().Damage(999);
			}
			catch {
				continue;
			}
		}


		// update chain & nBomb

		int chain = player.ChainReset();
		ui.SetChain(chain);

		nBomb--;
		ui.SetBomb(nBomb, false);

		return;
	}

	public int GetNBomb() {
		return nBomb;
	}
}
