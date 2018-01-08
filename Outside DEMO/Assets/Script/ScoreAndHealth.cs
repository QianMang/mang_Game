using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScoreAndHealth : MonoBehaviour {
    bool isAlive=true;
    int score;
    int life;
    public GameObject ScoreLabel;
    public GameObject LifeLabel;
    public GameObject GameoverPanel; 
	// Use this for initialization
	void Start () {
        score = 0;
        life = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void ChangeScore(int s){
        if(isAlive == true)
            score = score + s;
        ScoreLabel.GetComponent<UILabel>().text=score.ToString();
    }
    public void ChangeLife(int l){
        
        life = life - l;
        if (life >= 100)
            life = 100;
        if (life <= 0 )
        {
            GameoverPanel.SetActive(true);
            life = 0;
            isAlive = false;
        }
        LifeLabel.GetComponent<UILabel>().text=life.ToString();

    }
}
