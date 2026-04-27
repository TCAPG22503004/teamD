using UnityEngine;

public class ZombiMovement : MonoBehaviour
{
	[SerializeField] float speed = 1f;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		this.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
		if (this.transform.position.z < 0) Destroy(this.gameObject);
	}
}
