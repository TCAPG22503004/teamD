using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
	Vector3 screenPos, worldPos;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update()
	{
		screenPos = Input.mousePosition;
		worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 10f));
		this.transform.position = worldPos;
	}
}
