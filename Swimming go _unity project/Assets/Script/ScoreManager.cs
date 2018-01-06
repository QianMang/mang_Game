using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    private int score=0;
    private int maxDistance;
	// Use this for initialization
	void Start () {
        maxDistance = (int)GameObject.Find("Character").transform.position.x;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CaculateScore(int Distance){
        if(maxDistance<Distance)
            score++;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(100, 50, 200, 200), "SCORE:" + score.ToString());
    }

    public int GetScore(){
        return score;
    }
}
