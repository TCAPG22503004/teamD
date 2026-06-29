using UnityEngine;

public class Shoot : MonoBehaviour
{
	[SerializeField] int headRatio;
	[SerializeField] float dFav;

	int currentGun, nBullet, nBomb;
	bool isSkill2 = false;

	Reticle reticle;
	Gun gun;
	GunInfo gunInfoClass;
	gunParameter gunInfo;
	playerParameter player;
	UIChanger ui;
	Favorite favorite;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		reticle = this.GetComponent<Reticle>();
		gun = this.GetComponent<Gun>();
		gunInfoClass = GameObject.Find("GunList").GetComponent<GunInfo>();
		player = GameObject.Find("Parameter").GetComponent<playerParameter>();
		ui = GameObject.Find("UIChanger").GetComponent<UIChanger>();
		favorite = GameObject.Find("Heroine").GetComponent<Favorite>();

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

				// hit data
				GameObject parent = hit.collider.transform.parent.gameObject;
				string tag = hit.collider.tag;
			
				// enemy
				if (tag == "enemy") {
					Zombi zombi = parent.GetComponent<Zombi>();

					if (hit.collider.name == "Head") {
						zombi.Damage(gunInfo.attack * headRatio);
					}
					else {
						zombi.Damage(gunInfo.attack);
					}
				}
	
				// treasure
				else if (tag == "treasure") {
					parent.GetComponent<treasure>().Hit();
				}


				// heroine
				else if (tag == "heroine") {
					parent.GetComponent<Favorite>().ChangeFav(-dFav);
					isChain = false;
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


		// update favorite
		float d;
		if (chain < 3) {
			d = 0;
		}
		else if (chain >= 30) {
			d = 1.2f;
		}
		else {
			d = (1.2f - 1f) / (30f - 3f) * (chain - 3f) + 1f;
		}

		favorite.ChangeFav(dFav * d);


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
