using UnityEngine;

public class bulletMovement : MonoBehaviour
{
	[SerializeField] float speed;
	Ray ray;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		GameObject go = GameObject.Find("Gun");
		ray = go.GetComponent<shoot>().GetRay();
	}

	// Update is called once per frame
	void Update()
	{
		// movement
		this.transform.Translate(ray.direction * speed * Time.deltaTime);
		if (this.transform.position.z > 100f) Destroy(this.gameObject);
	}
}
