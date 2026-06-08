using UnityEngine;

public class spawn : MonoBehaviour
{
	[SerializeField] GameObject[] zombis;

	int limit = 3;
	int nZombi = 0;
	float xrange = 8f;

	int zombiType;
	Transform zombisObj;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		zombiType = zombis.Length;
		zombisObj = GameObject.Find("Zombis").transform;
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

		// position
		float x = Random.Range(-xrange, xrange);

		// type
		int n = Random.Range(0, zombiType);
		GameObject zombi = zombis[n];

		Instantiate(zombi, new Vector2(x, 0), Quaternion.identity, zombisObj);

		return;
	}


	// setter
	public void DecrementNumZombi() {
		if (nZombi > 0) nZombi--;
		return;
	}
}
