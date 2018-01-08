using UnityEngine;
using System.Collections;

public class ScrollUV : MonoBehaviour {
	public Vector2 direction = new Vector2(1,0);
	public float   speed = 1;
	public Renderer rend;
	void Start(){
		rend = GetComponent<Renderer> ();

	}
	void Update () {
		
		rend.material.mainTextureOffset+= direction * speed * Time.deltaTime;
	}
}
