using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneControl : MonoBehaviour {
    public GameObject TitleLabel;
    public GameObject TitleLabel2;
    public GameObject MenuPanel;
	// Use this for initialization
	void Start () {
        StartCoroutine(EnableTitle());
        StartCoroutine(EnableMenu());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator EnableTitle(){
        yield return new WaitForSeconds(3);
        TitleLabel.SetActive(true);
        TitleLabel2.SetActive(true);
    }
    IEnumerator EnableMenu(){
        yield return new WaitForSeconds(10);
        MenuPanel.SetActive(true);
    }
}
