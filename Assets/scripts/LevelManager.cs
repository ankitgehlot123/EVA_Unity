using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {
	public int BonusCutoffSeconds;
	public int BonusSecondMultiplier;
	public int CurrentTimeBonus {
		get { 
			var secondDifference = (int)(BonusCutoffSeconds - RunningTime.TotalSeconds);
			return Mathf.Max (0, secondDifference) * BonusSecondMultiplier;
		}
	}
	public static LevelManager Instance {get; private set;}
	private DateTime _started;
	public player Player{ get ; private set;}
	public CameraControl Camera {get; private set;}
	public TimeSpan RunningTime {
		get{return DateTime.UtcNow-_started;}
	}

	private List<checkpoint> _checkpoints;
	private int  _currentCheckpointIndex;

	public checkpoint DebugSpawn;
	
	private int _savedPoints;

	 

	public void Awake()
	{
		Instance = this ;
	}
	public void Start()
	{
		_checkpoints = FindObjectsOfType<checkpoint>().OrderBy(t => t.transform.position.x).ToList();
		_currentCheckpointIndex = _checkpoints.Count > 0 ? 0 : -1  ;
		Player = FindObjectOfType<player>();
		Camera = FindObjectOfType<CameraControl>();
	    
	    _started = DateTime.UtcNow;
#if UNITY_EDITOR
		if(DebugSpawn != null)
		{
			DebugSpawn.SpawnPlayer(Player);
		}else if (_currentCheckpointIndex != -1)
		{
			_checkpoints[_currentCheckpointIndex].SpawnPlayer(Player);
		}

#else
		if (_currentCheckpointIndex != null)
		{
			_checkpoints[_currentCheckpointIndex].SpawnPlayer(Player);
		}
#endif
	}
	public void Update()
	{
		var isAtLastCheckpoint = _currentCheckpointIndex + 1 == _checkpoints.Count;

		if(isAtLastCheckpoint)
			return;

		var DistancFromNextCheckpoint = _checkpoints[_currentCheckpointIndex + 1].transform.position.x - Player.transform.position.x;
	if (DistancFromNextCheckpoint >= 0)
			return;


		_checkpoints[_currentCheckpointIndex].playerLeftCheckpoint();
		_currentCheckpointIndex++;
		_checkpoints[_currentCheckpointIndex].PlayerHitCheckpoint();
			GameManager.Instance.AddPoints(CurrentTimeBonus);
		_savedPoints = GameManager.Instance.Points;
		_started = DateTime.UtcNow;
	}
	public  void KillPlayer()
	{  
		StartCoroutine(KillPlayerCo());
	}

	private IEnumerator KillPlayerCo()
	{
		Player.kill ();
		Camera.isFollowing = false;
		yield  return new WaitForSeconds (2f);


		Camera.isFollowing = true;

		if (_currentCheckpointIndex != -1)
			_checkpoints [_currentCheckpointIndex].SpawnPlayer (Player);


		_started = DateTime.UtcNow;
		GameManager.Instance.ResetPoints (_savedPoints);
	}	
}
