using UnityEngine;
using System.Collections;

public class backgroundParallex : MonoBehaviour {

	public Transform[] Backgrounds;
	public float ParallexScale;
	public float ParallexReductionFactor;
	public float Smoothing;

	private Vector3 _lastPosition ;

	public void Start(){
	
		_lastPosition = transform.position;	
	
	
	}

	public void Update(){

		var parallex = ( _lastPosition.x - transform.position.x)*ParallexScale;

		for(var i = 0; i < Backgrounds.Length;i++)
		{
			var backgroundTargetPosition = Backgrounds[i].position.x + parallex*(i * ParallexReductionFactor + 1);
                Backgrounds[i].position = Vector3.Lerp(
				Backgrounds[i].position, 
			    new Vector3( backgroundTargetPosition , Backgrounds[i].position.y  , Backgrounds[i].position.z),
				Smoothing*Time.deltaTime);
		}

		_lastPosition = transform.position;

	
	}
}
