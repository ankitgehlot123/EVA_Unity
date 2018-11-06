using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
public class platformpath : MonoBehaviour {

	public Transform[] points;

public IEnumerator<Transform> GetPathsEnumerator()

	{
		if ( points.Length == null  || points.Length < 1  )
		{
			yield break;
		}
		var direction= 1;
		var index = 0;
		while(true)
		{
			yield return points[index];
			if (points.Length == 1)
			{
				continue;
			}
			if (index<= 0)
			{
				direction =1;

			}
			else if(index >= points.Length - 1 )
			{
				direction = -1;
			}
			index = index + direction;
		}

	}


	void OnDrawGizmos()
	{ var Points = points.Where(t => t != null).ToList();

		if ( points == null || points.Length < 2 )
			return;

		if(Points.Count < 2)
			return;

		for(var i = 1;i < Points.Count;i++)
		{
			Gizmos.DrawLine(Points[i - 1].position,Points[i].position  );
		}
	}
}
