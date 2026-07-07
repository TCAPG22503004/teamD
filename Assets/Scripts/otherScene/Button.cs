using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunc : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void LoadGameScene() {

		SceneManager.LoadScene("game");

		return;
	}

	public void LoadTitleScene() {

		SceneManager.LoadScene("title");

		return;
	}

	public void QuitGame() {

		# if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;

		# else
		Application.Quit();

		# endif

		return;
	}
}
