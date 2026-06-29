using UnityEngine;

public class heroineMovement : MonoBehaviour
{
	float xrange = 8f;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void Move() {

		float x = Random.Range(-xrange, xrange);

		this.transform.position = new Vector3(x, 0, 0);

		return;
	}
}
