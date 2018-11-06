using UnityEngine;
using System.Collections;

public class ControllerState2D {
	public bool IsCollidingRight  {get; set;}
	public bool IsCollidingLeft   {get; set;}
	public bool IsCollidingAbove  {get; set;}
	public bool IsCollidingBelow  {get; set;}
	public bool IsMovingDownSlope {get; set;}
	public bool IsMovingUpSlope   {get; set;}
	public bool IsGrounded        {get{return IsCollidingBelow;}}
	public float SlopeAngle       {get; set;}
	public bool hasCollision {get { return IsCollidingRight || IsCollidingLeft || IsCollidingAbove || IsCollidingBelow;}}
    
	public void Reset()
	{
		IsMovingUpSlope   =
		IsMovingDownSlope =
	    IsCollidingRight  =
		IsCollidingLeft   =
		IsCollidingAbove  =
		IsCollidingBelow  =false;
		SlopeAngle = 0;

	}
public override string ToString ()
	{
		return string.Format ("[controller: IsCollidingRight={0}, IsCollidingLeft={1}, IsCollidingAbove={2}, IsCollidingBelow={3}, IsMovingDownSlope={4}, IsMovingUpSlope={5}, SlopeAngle={6}}]", IsCollidingRight, IsCollidingLeft, IsCollidingAbove, IsCollidingBelow, IsMovingDownSlope, IsMovingUpSlope, SlopeAngle);
	}

}
