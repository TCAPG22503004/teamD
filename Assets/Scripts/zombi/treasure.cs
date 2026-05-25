using UnityEngine;

public class treasure : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void Hit() {

		GameObject go = GameObject.Find("Gun");
		go.GetComponent<Bomb>().IncrementNBomb();

		Destroy(this.gameObject);

		return;
	}
}
