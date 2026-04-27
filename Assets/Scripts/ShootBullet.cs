using UnityEngine;

public class ShootBullet : MonoBehaviour
{
	[SerializeField] GameObject bullet;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0)) Instantiate(bullet, this.transform.position, Quaternion.identity);
	}
}
