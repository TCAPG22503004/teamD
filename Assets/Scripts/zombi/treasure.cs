using UnityEngine;

public class treasure : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		SetIndex();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	void SetIndex() {

		SpriteRenderer sprite = this.transform.GetChild(0).GetComponent<SpriteRenderer>();

		// get num of treasure
		int up = GameObject.Find("Spawner").transform.GetSiblingIndex();
		int down = GameObject.Find("---- Environment ----").transform.GetSiblingIndex();

		// set position and order in layer
		this.transform.SetSiblingIndex(down);
		sprite.sortingOrder = -(down - up);


		return;
	}

	public void Hit() {

		GameObject go = GameObject.Find("Gun");
		go.GetComponent<Bomb>().IncrementNBomb();

		Destroy(this.gameObject);

		return;
	}
}
