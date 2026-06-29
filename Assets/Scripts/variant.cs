using UnityEngine;
using UnityEngine.SceneManagement;

public class Variant : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		// check whether already exist
		GameObject[] gos = GameObject.FindGameObjectsWithTag("variant");
		if (gos.Length > 1) Destroy(this.gameObject);

		// not exist yet
		DontDestroyOnLoad(this.gameObject);
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	// clear flag
	bool isClear = true;
	public bool IsClear {
		get { return isClear; }
		set { isClear = value; }
	}

	// bullet
	int hit, total;
	public int Hit {
		get { return hit; }
		set { hit++; }
	}
	public int Total {
		get { return total; }
		set { total++; }
	}

	// bomb
	int bomb;
	public int Bomb {
		get { return bomb; }
		set { bomb++; }
	}

	// typing
	int miss;
	public int Miss {
		get { return miss; }
		set { Miss++; }
	}
}
