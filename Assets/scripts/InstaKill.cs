using UnityEngine;
using System.Collections;

public class InstaKill : MonoBehaviour {

public void OnTriggerEnter2D(Collider2D other)
	{

		var _player = other.GetComponent<player>();

	if (_player = null) {
			return;
		} else {
			LevelManager.Instance.KillPlayer();
		}

	}
}
