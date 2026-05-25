using UnityEngine;

public class Reticle : MonoBehaviour
{
	// define by user
	[SerializeField] Texture2D black, red, gray;
	bool isTarget = false, isGray = false, isRed = true;
	
	// need to change cursor
	Vector2 mouse;
	RaycastHit2D hit;
	Vector2 hotSpot = new Vector2(240, 240);
	CursorMode mode = CursorMode.Auto;

	// other class
	Gun gun;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		gun = this.GetComponent<Gun>();
	}

	// Update is called once per frame
	void Update()
	{
		// cannot shoot
		if (gun.GetCanShoot() == false) {

			// check already changed
			if (isGray == false) {
				isGray = true;
				Cursor.SetCursor(gray, hotSpot, mode);
			}
		}

		else {
			// set isTarget
			mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			hit = Physics2D.Raycast(mouse, Vector2.zero);
			isTarget = (hit.collider != null && hit.collider.tag != "Untagged");

			// change after cooldown
			if (isGray) {
				isGray = false;
				isRed = isTarget;
				ChangeCursor();
			}

			// change when need
			else if (isTarget != isRed) {
				isRed = !isRed;
				ChangeCursor();
			}
		}
	}

	void ChangeCursor() {

		if (isRed) {
			Cursor.SetCursor(red, hotSpot, mode);
		}
		else {
			Cursor.SetCursor(black, hotSpot, mode);
		}

		return;
	}

	public bool GetIsTarget() {
		return isTarget;
	}

	public RaycastHit2D GetTargetInfo() {
		return hit;
	}
}
