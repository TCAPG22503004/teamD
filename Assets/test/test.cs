using UnityEngine;

public class test : MonoBehaviour
{
	[SerializeField] GameObject test1;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		Invoke("Activate", 1f);
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	void Activate() {
		test1.SetActive(true);
		return;
	}
}
