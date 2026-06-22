using UnityEngine;

public class init : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		// set frame rate
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;

		// set time scale (gameover: 0)
		Time.timeScale = 1f;
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
}
