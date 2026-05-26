using UnityEngine;

public class Shoot : MonoBehaviour
{
	int currentGun, nBullet, nBomb;
	bool isSkill2 = false;

	Reticle reticle;
	Gun gun;
	GunInfo gunInfoClass;
	gunParameter gunInfo;
	playerParameter player;
	UIChanger ui;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		reticle = this.GetComponent<Reticle>();
		gun = this.GetComponent<Gun>();
		gunInfoClass = GameObject.Find("GunList").GetComponent<GunInfo>();
		player = GameObject.Find("Parameter").GetComponent<playerParameter>();
		ui = GameObject.Find("UIChanger").GetComponent<UIChanger>();

		gunInfo = gunInfoClass.ChangeGun(999);
		nBullet = gunInfo.capacity;
		Invoke("Init", 0.1f);
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	// set default capacity (after load component)
	void Init() {
		ui.SetCapacity(gunInfo.name, nBullet, gunInfo.capacity);
	}


	/* ------------------
		shoot
	--------------------- */
	public void ShootBullet() {

		bool isChain = reticle.GetIsTarget();

		// hit enemy or heroine?
		if (isChain) {

			RaycastHit2D hit = reticle.GetTargetInfo();

			if (hit.collider != null) {
			
				// enemy
				if (hit.collider.tag == ("enemy")) {
					hit.collider.gameObject.GetComponent<Zombi>().Damage(gunInfo.attack);
				}
	
				// treasure
				else if (hit.collider.tag == ("treasure")) {
					hit.collider.gameObject.GetComponent<treasure>().Hit();
				}
			}
		}


		// update chain
		int chain;

		if (isChain) {
			chain = player.ChainIncrement();
		}
		else {
			chain = player.ChainReset();
		}

		ui.SetChain(chain);


		// update bullet

		if (isSkill2 == false) {

			nBullet--;

			ui.SetCapacity(gunInfo.name, nBullet, gunInfo.capacity);
		}


		// interval
		CoolDown();

		return;
	}



	/* -----------------
		reload
	-------------------- */
	public void Reload() {

		ui.SetReload(true);
		
		gun.SetCanShoot(false);

		Invoke("EndReload", gunInfo.reloadtime);
		
		return;
	}

	void EndReload() {

		ui.SetReload(false);

		nBullet = gunInfo.capacity;
		ui.SetCapacity(gunInfo.name, nBullet, gunInfo.capacity);

		gun.SetCanShoot(true);

		return;
	}



	/* --------------------
		cool time
	----------------------- */

	void CoolDown() {

		gun.SetCanShoot(false);

		Invoke("EndCoolDown", gunInfo.cooltime);

		return;
	}

	void EndCoolDown() {

		gun.SetCanShoot(true);

		return;
	}


	/* ---- etc ---- */
	public void ChangeGun() {
		gunInfo = gunInfoClass.ChangeGun(nBullet);
		nBullet = gunInfo.NBullet;

		// set ui
		if (isSkill2) {
			ui.SetCapacity(gunInfo.name, -1, -1);
		}
		else {
			ui.SetCapacity(gunInfo.name, nBullet, gunInfo.capacity);
		}
		return;
	}


	public int GetNBullet() {
		return nBullet;
	}


	public void StartSkill2(int t) {

		isSkill2 = true;

		ui.SetCapacity(gunInfo.name, -1, -1);

		Invoke("EndSkill2", t);

		return;
	}

	public void EndSkill2() {

		isSkill2 = false;

		nBullet = gunInfo.capacity;

		ui.SetCapacity(gunInfo.name, nBullet, gunInfo.capacity);

		return;
	}
}
