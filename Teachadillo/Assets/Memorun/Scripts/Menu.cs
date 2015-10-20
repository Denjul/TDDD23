using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

		public GUISkin myskin;
		public string gameLevel;
		public string optionsLevel;
		
		private void OnGUI()
		{
			GUI.skin=myskin;
			
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "PLAY")){
				Application.LoadLevel("Game");
			}
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "EXIT")){
				Application.Quit();	
			}
		}
	}

