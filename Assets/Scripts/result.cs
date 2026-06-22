using UnityEngine;

public class Result : MonoBehaviour
{
	[SerializeField] int clearTime;

	GameObject gameover, gameclear;
	Gun gun;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		gameover = GameObject.Find("Canvas/GameOver");
		gameover.SetActive(false);

		gameclear = GameObject.Find("Canvas/GameClear");
		gameclear.SetActive(false);

		gun = GameObject.Find("Gun").GetComponent<Gun>();


		// set timer
		Invoke("GameClear", clearTime);
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	void StopGame() {

		gun.SetCanShoot(false);

		Time.timeScale = 0f;

		return;
	}


	public void GameOver() {

		StopGame();

		gameover.SetActive(true);

		return;
	}

	public void GameClear() {

		StopGame();

		gameclear.SetActive(true);		

		return;
	}

	public int GetTime() {
		return clearTime;
	}
}
