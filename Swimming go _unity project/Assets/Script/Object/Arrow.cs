using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : ObjectManager {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log(this.tag);
        if (this.tag == "down") {
            other.GetComponent<Character>().DownIsEnabled();
        }else if(this.tag == "up"){
            other.GetComponent<Character>().UpIsEnabled();
        }else if (this.tag == "left"){
            other.GetComponent<Character>().LeftIsEnabled();
        }else if (this.tag == "right"){
            other.GetComponent<Character>().RightIsEnabled();
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    other.GetComponent<Character>().EnableAllDirection();
    //}
}
