using UnityEngine;
using System.Collections;

public class GameManager{
	private static GameManager _instance;
	public static GameManager Instance {get { return _instance ?? (_instance=new GameManager());}}
	public int Points {get;private set;}
	private GameManager()
	{

	}
	public void Reset()
	{
		Points = 0;
	}
	public void ResetPoints(int points)
	{
		Points = points;
	}
	public void AddPoints(int pointsToAdd)
	{
		Points += pointsToAdd;
	}

}
