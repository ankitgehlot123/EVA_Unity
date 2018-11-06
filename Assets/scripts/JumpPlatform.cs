using UnityEngine;
using System.Collections;

public class JumpPlatform : MonoBehaviour {

	public float JumpMangnitude = 2f;
	public void ControllerEnter2D(CharacterController2D  controller)
	{
		controller.SetVerticalForce(JumpMangnitude);
	}
}
