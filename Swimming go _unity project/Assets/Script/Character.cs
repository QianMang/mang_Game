using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character: MonoBehaviour {
    bool canBeLeft = true;
    bool canBeRight = true;
    bool canBeUp = true;
    bool canBeDown = true;

   
    GameObject[] BlockArray;// = GameObject.FindGameObjectsWithTag("block");
    Vector3 BlockPosition;
    Vector3 CharacterPosition;

    int landWidth;

    public GameObject Camera;
    public AudioSource wrong;
    public int deathDistance;

	// Use this for initialization
	void Start () {
        BlockArray = GameObject.FindGameObjectsWithTag("block");
        landWidth = Camera.GetComponent<GameManager>().landWidth;

	}
	
	// Update is called once per frame
	void Update () {
        //Game Over
        if(Camera.transform.position.x-this.transform.position.x>=deathDistance && Camera.GetComponent<GameManager>().GetState()==GameManager.GameState.gaming){
            Camera.GetComponent<GameManager>().ChangeState();
            Camera.GetComponent<UIManager>().GameOverUI();
            DisableDirection();
            //Destroy(this.gameObject);
        }

	}


    public void MoveToRight(){
        if (canBeRight == true)
        {
            GameObject.Find("Main Camera").GetComponent<ScoreManager>().CaculateScore((int)this.transform.position.x);
            EnableAllDirection();
            this.transform.Translate(Vector3.back);
            //this.transform.eulerAngles = new Vector3 (0,270,0); 
            CheckBlock();

        }
        else
            wrong.Play();
    }
    public void MoveToLeft(){
        if (canBeLeft == true)
        {
            EnableAllDirection();
            this.transform.Translate(Vector3.forward);
            //this.transform.eulerAngles = new Vector3 (0,90,0); 
            CheckBlock();
        }else
            wrong.Play();
    }
    public void MoveToUp(){
        if (canBeUp == true){
            
            EnableAllDirection();
            this.transform.Translate(Vector3.right);
           // this.transform.eulerAngles = new Vector3 (0,180,0); 
            CheckBlock();
        }else
            wrong.Play();
    }
    public void MoveToDown(){
        if (canBeDown == true){
            
            EnableAllDirection();
            this.transform.Translate(Vector3.left);
            //this.transform.eulerAngles = new Vector3 (0,0,0); 
            CheckBlock();
        }else
            wrong.Play();
    }



    public void LeftIsEnabled(){
        if(canBeLeft==false)
            DisableDirection();
        else{
            DisableDirection();
            canBeLeft = true;
        }

    }

    public void RightIsEnabled()
    {
        if(canBeRight==false)
            DisableDirection();
        else{
            DisableDirection();
            canBeRight = true;
        }

    }
    public void UpIsEnabled()
    {
        if (canBeUp == false)
            DisableDirection();
        else{
            DisableDirection();
            canBeUp = true;
        }
    }
    public void DownIsEnabled()
    {
        if (canBeDown == false)
            DisableDirection();
        else{
            DisableDirection();
            canBeDown = true;
        }
    }

    void DisableDirection(){
        canBeLeft = false;
        canBeRight = false;
        canBeUp = false;
        canBeDown = false;
    }

    public void EnableAllDirection(){
        canBeLeft = true;
        canBeRight = true;
        canBeUp = true;
        canBeDown = true;
    }

    void CheckBlock(){
        BlockArray = GameObject.FindGameObjectsWithTag("block");
        CharacterPosition = this.transform.position;
        for (int i = 0; i < BlockArray.Length;i++){
            BlockPosition = BlockArray[i].transform.position;
            if((int)BlockPosition.x==(int)CharacterPosition.x+1 && (int)BlockPosition.z==(int)CharacterPosition.z){
                canBeRight = false;
            }else if ((int)BlockPosition.x == (int)CharacterPosition.x-1 && (int)BlockPosition.z == (int)CharacterPosition.z){
                canBeLeft = false;
            }else if ((int)BlockPosition.x == (int)CharacterPosition.x && (int)BlockPosition.z == (int)CharacterPosition.z+1){
                canBeUp = false;
            }else if ((int)BlockPosition.x == (int)CharacterPosition.x && (int)BlockPosition.z == (int)CharacterPosition.z-1){
                canBeDown = false;
            }
            if((int)CharacterPosition.z == landWidth){
                canBeUp = false;
            }else if((int)CharacterPosition.z == 1){
                canBeDown = false;
            }
        }
    }


}
