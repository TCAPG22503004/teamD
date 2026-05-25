using UnityEngine;

public class Gun : MonoBehaviour
{
	// variant
	int chain;
	bool canShoot = true;

	// other class
	Shoot shoot;
	Bomb bomb;
	

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		shoot = this.GetComponent<Shoot>();
		bomb = this.GetComponent<Bomb>();
	}

	// Update is called once per frame
	void Update()
	{
		// bullet
		if (Input.GetMouseButtonDown(0) && canShoot) {

			if (shoot.GetNBullet() > 0) {
				shoot.ShootBullet();
			}
			else {
				shoot.Reload();
			}
		}


		// bomb
		if (Input.GetMouseButtonDown(1)) {

			if (bomb.GetNBomb() > 0) {
				bomb.UseBomb();
			}
		}


		// change gun
		if (Input.GetKeyDown(KeyCode.Tab) && canShoot) {

			shoot.ChangeGun();

		}
	}

	// getter & setter
	public void SetCanShoot(bool b) {
		canShoot = b;
		return;
	}

	public bool GetCanShoot() {
		return canShoot;
	}
}
