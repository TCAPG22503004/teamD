using UnityEngine;

public class heroineMovement : MonoBehaviour
{
	float xrange = 8f;

	[SerializeField] Sprite[] sprite;
	SpriteRenderer render;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		render = this.transform.Find("Image").gameObject.GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void Move() {

		float x = Random.Range(-xrange, xrange);

		this.transform.position = new Vector3(x, 0, 0);

		return;
	}

	public void ChangeImage(int n) {

		if (n >= 0 && n < sprite.Length) {
			render.sprite = sprite[n];
		}
		else {
			render.sprite = null;
		}

		return;
	}
}
