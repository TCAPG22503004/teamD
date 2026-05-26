using UnityEngine;

public class GunInfo : MonoBehaviour
{
	[SerializeField] gunParameter[] gunList;
	int current;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Awake()
	{
		current = gunList.Length - 1;
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public gunParameter ChangeGun(int nBullet) {

		// change nBullet information
		gunList[current].NBullet = nBullet;

		// change current number
		if (current < gunList.Length - 1) {
			current++;
		}
		else {
			current = 0;
		}

		// return gun information
		return gunList[current];
	}
}

[System.Serializable] public struct gunParameter {
	public string name;
	public int attack;
	public int capacity;
	public float cooltime;
	public float reloadtime;

	// private
	int nBullet;
	public int NBullet {
		get {
			return nBullet;
		}
		set {
			if (value < 0) {
				nBullet = 0;
			}
			else if (value > capacity) {
				nBullet = capacity;
			}
			else {
				nBullet = value;
			}
		}
	}
};

