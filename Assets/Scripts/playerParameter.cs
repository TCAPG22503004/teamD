using UnityEngine;

public class playerParameter : MonoBehaviour
{
	// level
	int level = 3;

	public int LevelUp() {
		level++;
		return level;
	}
	
	public int LevelDown() {
		level--;
		return level;
	}

	public int GetLevel() {
		return level;
	}


	// chain
	int chain = 0;

	public int ChainIncrement() {
		chain++;
		return chain;
	}

	public int ChainReset() {
		chain = 0;
		return chain;
	}


	// hp
	int hp = 100;

	public int ChangeHP(int n) {
		hp += n;
		return hp;
	}


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
