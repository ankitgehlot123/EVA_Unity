using UnityEngine;
using System.Collections;

public class checkpoint : MonoBehaviour {

	// Use this for initialization
	public void Start () {
	
	}
	public void PlayerHitCheckpoint()
	{

	}
	public IEnumerator PlayerHitCheckpointCo(int Bonus)
	{
		yield break;

	}

	public void playerLeftCheckpoint()
	{

	}
	public void SpawnPlayer(player _player)
	{
		_player.ReSpawnAt(transform);
	}
	public void AssignObjectToCheckpoint()
	{

	}
	// Update is called once per frame
	void Update () {
	
	}
}
