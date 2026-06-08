using UnityEngine;

public class treasure_counter : MonoBehaviour
{
	int cumulative = 0;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void IncrementTreasure() {

		cumulative++;

		return;
	}

	public int GetCumulative() {

		return cumulative;
	}
}
