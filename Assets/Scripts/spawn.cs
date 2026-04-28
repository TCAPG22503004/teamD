using UnityEngine;

public class spawn : MonoBehaviour
{
	[SerializeField] GameObject zombi;
	float xrange = 4.5f;
	float y = -0.5f;
	float z = 6.5f;
	int limit = 3;
	int nZombi = 0;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (nZombi < limit) {
			nZombi++;
			Invoke("SpawnZombi", 1f);
		}
	}

	void SpawnZombi() {
		float x = Random.Range(-xrange, xrange);
		Instantiate(zombi, new Vector3(x, y, z), Quaternion.identity);

		return;
	}


	// setter
	public void DecrementNumZombi() {
		if (nZombi > 0) nZombi--;
		return;
	}
}
