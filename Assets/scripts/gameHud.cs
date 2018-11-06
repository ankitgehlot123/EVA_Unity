using UnityEngine;
using System.Collections;

public class gameHud : MonoBehaviour {

	public GUISkin Skin;

	public void OnGUI()
	{
		GUI.skin = Skin;
		GUILayout.BeginArea (new Rect(0,0,Screen.width,Screen.height));
		{
			GUILayout.BeginVertical(Skin.GetStyle("GameHud"));
			{
				GUILayout.Label(string.Format("Points: [0]",GameManager.Instance.Points),Skin.GetStyle("PointsText"));
				var time=LevelManager.Instance.RunningTime;
				GUILayout.Label(string.Format(
					"[0.00]: [1.00] with [2] bonus",
				    time.Minutes+(time.Hours*60),
					time.Seconds,
				    LevelManager.Instance.CurrentTimeBonus),Skin.GetStyle("TimeText"));
			}
			GUILayout.EndVertical();
		}
		GUILayout.EndArea ();


}
}
