using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {
    public GameObject MenuPanel;
    public int ClickLevelBtn=0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void Level1_Btn_Click(){
        //SceneManager.LoadScene("Level1");
        ClickLevelBtn = 1;
        GameObject.Find("Main Camera").GetComponent<CameraActivity>().cameraSpeed_forward=3;
        MenuPanel.SetActive(false);
    }
    public void Level2_Btn_Click()
    {
        ClickLevelBtn = 2;
        GameObject.Find("Main Camera").GetComponent<CameraActivity>().cameraSpeed_forward = 3;
        MenuPanel.SetActive(false);
    }

    public void Retry_Btn_Click(){
        //string levelName=GameObject.FindWithTag("level").transform.name;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //switch(levelName){
        //    case "Level1": SceneManager.LoadScene("Level1");break;
        //    case "Level2": SceneManager.LoadScene("Level2");break;
        //}
    }
    public void Menu_Btn_Click(){
        SceneManager.LoadScene("Level0");
    }
}
