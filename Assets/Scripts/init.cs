using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
	[SerializeField] int clearTime = 30;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		// set frame rate
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;

		// set timer
		Invoke("Result", clearTime);
	}

	// Update is called once per frame
	void Update()
	{
		// exit editor
		if (Input.GetKeyDown(KeyCode.Escape)) {
			# if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			# endif
		}
	}

	public void Result() {

		SceneManager.LoadScene("result", LoadSceneMode.Single);

		return;
	}

	public int GetTime() {
		return clearTime;
	}
}
