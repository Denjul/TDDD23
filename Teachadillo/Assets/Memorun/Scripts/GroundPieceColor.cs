using UnityEngine;
using System.Collections;

public class GroundPieceColor : MonoBehaviour {

	public Renderer rend;
	private int color;
	void Start() {
		rend = GetComponent<Renderer>();
		//rend.material.shader = Shader.Find("MKDemoMat1View1");
	}
	void Update() {
		float shininess = Mathf.PingPong(Time.time, 5000.0F);

		//rend.material.SetColor("_MKGlowTexColor", Color.red);
		color = GameObject.Find ("unitychan").GetComponent<PlayerControl> ().colorOnGround;
		switch (color) {
		case 0:

			rend.material.SetColor("_MKGlowTexColor", Color.magenta);
			rend.material.SetColor("_MKGlowColor", Color.magenta);
			break;
		case 1:
			rend.material.SetColor("_MKGlowTexColor", Color.red);
			rend.material.SetColor("_MKGlowColor", Color.red);
			break;
		case 2:
			rend.material.SetColor("_MKGlowTexColor", Color.green);
			rend.material.SetColor("_MKGlowColor", Color.green);
			break;
		case 3:
			rend.material.SetColor("_MKGlowTexColor", Color.blue);
			rend.material.SetColor("_MKGlowColor", Color.blue);
			break;
		case 4:
			rend.material.SetColor("_MKGlowTexColor", Color.yellow);
			rend.material.SetColor("_MKGlowColor", Color.yellow);
			break;


		}
		rend.material.SetFloat("_MKGlowTexStrength", 0.75f);
	}
}

