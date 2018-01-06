using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public GameObject RetryBtn;
    public GameObject MenuBtn;
    public GameObject GameoverScoreText;

    //in the Menu scene
    public GameObject DifficutyBtn;
    public GameObject StartBtn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameOverUI(){
        RetryBtn.SetActive(true);
        MenuBtn.SetActive(true);
        GameoverScoreText.SetActive(true);
        GameoverScoreText.GetComponent<Text>().text="Your Score: "+GameObject.Find("Main Camera").GetComponent<ScoreManager>().GetScore().ToString();

    }

    public void RetryBtnClick(){
        SceneManager.LoadScene("GameScene");
    }


    public void StartBtnClick(){
        StartBtn.SetActive(false);
        DifficutyBtn.SetActive(true);
    }
    public void DifficultyBtnClick(GameObject sender){
        switch(sender.GetComponent<Text>().text){
            case "Easy": GameObject.Find("Difficulty control").GetComponent<Difficulty_control>().difficulty=Difficulty_control.Difficulty.easy;break;
            case "Medium":GameObject.Find("Difficulty control").GetComponent<Difficulty_control>().difficulty = Difficulty_control.Difficulty.medium; break;
            case "Hard":GameObject.Find("Difficulty control").GetComponent<Difficulty_control>().difficulty = Difficulty_control.Difficulty.hard; break;
            case "Very hard":GameObject.Find("Difficulty control").GetComponent<Difficulty_control>().difficulty = Difficulty_control.Difficulty.very_hard; break;
        }
        SceneManager.LoadScene("GameScene");
    }

    public void MenuBtnClick(){
        SceneManager.LoadScene("StartMenu");
    }
}
