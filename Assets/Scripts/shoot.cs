using UnityEngine;

public class shoot : MonoBehaviour
{
	[SerializeField] GameObject bullet;
	Ray ray;
	GameObject spawner;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		spawner = GameObject.Find("Spawner");
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0)) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			DrawBullet();
			ShootBullet();
		}
	}


	// bullet (caution! this object is only appearance, collision detection is other function.)
	void DrawBullet() {

		// get world position
		Vector3 mousePos, worldPos;
		mousePos = Input.mousePosition;
		mousePos.z = 5f;
		worldPos = Camera.main.ScreenToWorldPoint(mousePos);

		// create bullet
		Instantiate(bullet, worldPos, Quaternion.identity);

		return;
	}


	// collision detection
	void ShootBullet() {

		// kill enemy
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit)) {
			if (hit.collider.tag ==("enemy")) {
				Destroy(hit.collider.gameObject);
				spawner.GetComponent<spawn>().DecrementNumZombi();
			}
		}

		return;
	}


	// getter
	public Ray GetRay() {
		return ray;
	}
}
