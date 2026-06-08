using UnityEngine;

public class treasure : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		SetLayer();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	void SetLayer() {

		// count treasure 
		treasure_counter tc = GameObject.Find("Treasures").GetComponent<treasure_counter>();
		tc.IncrementTreasure();
		int n = tc.GetCumulative();
		
		// set layer
		SpriteRenderer sprite = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
		sprite.sortingOrder = -n;

		return;
	}

	public void Hit() {

		GameObject go = GameObject.Find("Gun");
		go.GetComponent<Bomb>().IncrementNBomb();

		Destroy(this.gameObject);

		return;
	}
}
