using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public GameObject character;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.W)){
            character.GetComponent<Character>().MoveToUp();
        }else if(Input.GetKeyDown(KeyCode.S)){
            character.GetComponent<Character>().MoveToDown();
        }else if(Input.GetKeyDown(KeyCode.A)){
            character.GetComponent<Character>().MoveToLeft();
        }else if (Input.GetKeyDown(KeyCode.D)){
            character.GetComponent<Character>().MoveToRight();
        }

	}
}
