using UnityEngine;

public class zombi_horizontal : MonoBehaviour
{
	[SerializeField] float speedHorizontal;
	[SerializeField] float switchTime;

	Vector2 v;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		v.x = speedHorizontal;
		InvokeRepeating("SwitchDirection", 0f, switchTime);
	}

	// Update is called once per frame
	void Update()
	{
		this.transform.Translate(v * Time.deltaTime);
	}

	public void SwitchDirection() {

		v.x *= -1;

		return;
	}
}
