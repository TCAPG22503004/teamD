using UnityEngine;

public class BulletController : MonoBehaviour
{
	[SerializeField] float force;
	Rigidbody rb;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		rb = GetComponent<Rigidbody>();
//		Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 10f))
		rb.AddForce(0, 0, force);
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	void OnCollisionEnter(Collision c) {
		if (c.gameObject.tag == "enemy") Destroy(c.gameObject);
		Destroy(this.gameObject);
	}
}
