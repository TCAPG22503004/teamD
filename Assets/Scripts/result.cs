using UnityEngine;

public class Result : MonoBehaviour
{
	GameObject gameover;
	Gun gun;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		gameover = GameObject.Find("Canvas/GameOver");
		gameover.SetActive(false);

		gun = GameObject.Find("Gun").GetComponent<Gun>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void GameOver() {

		gun.SetCanShoot(false);

		Time.timeScale = 0f;

		gameover.SetActive(true);

		return;
	}
}
