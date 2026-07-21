using UnityEngine;

public class heroineMovement : MonoBehaviour
{
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

	public void ChangeImage(int n, float m, float l) {

		if (n >= 0 && n < sprite.Length) render.sprite = sprite[n];

		this.transform.position = new Vector3(m, l, 0);

		return;
	}
}
