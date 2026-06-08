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
	Shoot shoot;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		gun = this.GetComponent<Gun>();
		shoot = this.GetComponent<Shoot>();
	}

	// Update is called once per frame
	void Update()
	{
		// cannot shoot
		if (gun.GetCanShoot() == false || shoot.GetNBullet() == 0) {

			// check already changed
			if (isGray == false) {
				isGray = true;
				Cursor.SetCursor(gray, hotSpot, mode);
			}
		}

		else {
			// set isTarget
			SetIsTarget();
			

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

	void SetIsTarget() {

		// raycasthit
		mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D[] hits = Physics2D.RaycastAll(mouse, Vector2.zero);

		// get most forward object
		hit = new RaycastHit2D();
		int forward = -99999;
		foreach (RaycastHit2D h in hits) {
			try {
				// get order
				int order = h.collider.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder;

				// is the most forward?
				if (order > forward) {
					forward = order;
					hit = h;
				}
			}
			catch {
				continue;
			}
		}

		// set is target
		isTarget = (hit.collider != null && hit.collider.tag != "Untagged");

		return;
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
