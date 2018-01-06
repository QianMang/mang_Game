using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public GameObject LandCube_7_5;
    public GameObject LandCube_6_5;
    public GameObject LandCube_5_5;
    public GameObject LandCube_4_5;
    GameObject LandCube_X_5;
    public GameObject LandCube;
    public GameObject Character;
    public GameObject Audience_1;
    public GameObject Audience_2;
    public GameObject Audience_3;
   // GameObject gameCamera;
    public GameObject left_arrow;
    public GameObject right_arrow;
    public GameObject up_arrow;
    public GameObject down_arrow;
    public GameObject Block;

    //the limit of first land initiate
    public int rightLimit;

    //the width of land (from 4-7)
    public int landWidth;

    //the probability
    public int arrow_probability;
    public int block_probability;
    public int audience_probability;

    //create the scene every x unit
    private int createlimit_unit = 5;
    private int createTime = 3;

    public enum GameState
    {
        gaming=1,
        gameover=2,
    }
    private GameState state = new GameState();

    //for the DFS search
    int[,] searchArray = new int[9, 7];//1~n;0;999
    int lastCorrectPlace;
    bool SearchEndFlag;
    int orderOfRoad;

    [HideInInspector]
    public int rightIndex_x;
    [HideInInspector]
    public int rightIndex_y;
    [HideInInspector]
    public int rightIndex_z;

    // Use this for initialization
    void Awake()
    {
        state = GameState.gaming;//start game
        initiateDifficulty();
        JudgePrefeb();
       // InitiateCamera();

        InitiateLand();
       // InitiateCharacter();

        InitiateCorrectPlace();
        StartCoroutine(CreateNewScene(createTime));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CreateNewScene(float time)
    {
        while (true)
        {
            //Debug.Log("create new scene");
            CreateNewLand();
            CreateObject();
            yield return new WaitForSeconds(time);
        }
    }

    void initiateDifficulty(){
        Debug.Log(GameObject.Find("Difficulty control").GetComponent<Difficulty_control>().difficulty);
        switch(GameObject.Find("Difficulty control").GetComponent<Difficulty_control>().difficulty){
            case Difficulty_control.Difficulty.easy: landWidth=4;break;
            case Difficulty_control.Difficulty.medium: landWidth = 5; break;
            case Difficulty_control.Difficulty.hard: landWidth = 6; break;
            case Difficulty_control.Difficulty.very_hard: landWidth = 7; break;
        }
    }

    void JudgePrefeb(){
        switch(landWidth){
            case 4:LandCube_X_5 = LandCube_4_5; break;
            case 5:LandCube_X_5 = LandCube_5_5; break;
            case 6:LandCube_X_5 = LandCube_6_5;break;
            case 7:LandCube_X_5 = LandCube_7_5;break;
            default:break;
        }
    }

    void InitiateCamera()
    {

       
    }


    //void InitiateLand()
    //{
    //    //start at x=-10
    //    rightIndex_x = -10;
    //    rightIndex_y = 0;

    //    for (; rightIndex_x <= rightLimit; rightIndex_x++)
    //    {
    //        for (rightIndex_z = 0; rightIndex_z <= landWidth + 1;)
    //        {
    //            if (rightIndex_z == 0 || rightIndex_z == landWidth + 1)
    //            {
    //                GameObjectPool.GetInstance().Object_Instantiate(LandCube, rightIndex_x, 1, rightIndex_z);
    //            }
    //            GameObjectPool.GetInstance().Object_Instantiate(LandCube, rightIndex_x, rightIndex_y, rightIndex_z);
    //            rightIndex_z++;
    //        }
    //    }
    //}

    void InitiateLand(){
        //start at x=-10
        rightIndex_x = -10;
        //rightIndex_y = 0;
        for (; rightIndex_x <= rightLimit;){
            GameObjectPool.GetInstance().Object_Instantiate(LandCube_X_5, rightIndex_x, 0, 0);
            rightIndex_x += 5;
        }
    }


    void InitiateCharacter()
    {
        Character.transform.localPosition = new Vector3(0, 0.5f, landWidth - 1);
    }

    void InitiateCorrectPlace()
    {
        lastCorrectPlace = Random.Range(1, landWidth);
        //Debug.Log(lastCorrectPlace);
    }

    //void CreateNewLand()
    //{

    //    //newCameraPosition_x = gameCamera.transform.position.x;


    //    for (int i = 1; i <= createlimit_unit; i++)
    //    {
    //        for (rightIndex_z = 0; rightIndex_z <= landWidth + 1; rightIndex_z++)
    //        {
    //            //create wall
    //            if (rightIndex_z == 0 || rightIndex_z == landWidth + 1)
    //            {
    //                GameObjectPool.GetInstance().Object_Instantiate(LandCube, rightIndex_x, 1, rightIndex_z);
    //            }
    //            //create land
    //            GameObjectPool.GetInstance().Object_Instantiate(LandCube, rightIndex_x, rightIndex_y, rightIndex_z);


    //        }
    //        rightIndex_x++;
    //    }
    //    //lastCameraPosition_x = Mathf.Floor(newCameraPosition_x);

    //}

    void CreateNewLand(){
        GameObjectPool.GetInstance().Object_Instantiate(LandCube_X_5, rightIndex_x, 0, 0);
        rightIndex_x += 5;
    }



    //the gameobject on the land like arrow
    void CreateObject()
    {
        ResetSceneArray();
        CreateCorrectRoad();
        CreateOthers();
    }

    void ResetSceneArray()
    {
        //Debug.Log("Start Reset");
        for (int i = 0; i <= 8; i++)
        {
            for (int j = 0; j <= 6; j++)
            {
                //border
                if (i == 0 || i == landWidth+1 || j == 0 || j == 6)
                    searchArray[i, j] = 999;
                else
                    searchArray[i, j] = 0;
            }
        }
        searchArray[lastCorrectPlace, 1] = 1;
        SearchEndFlag = false;
        orderOfRoad = 0;
    }



    void CreateOthers()
    {
        int objectRandom;
        int position_x = rightIndex_x - createlimit_unit;
        int position_z = landWidth;
        for (int i = 1; i <= landWidth;i++){
            for (int j = 1; j <= 5;j++){
                if (searchArray[i, j] == 0) {
                    objectRandom = Random.Range(0, 100);
                    if(objectRandom<=block_probability){
                        GameObjectPool.GetInstance().Object_Instantiate(Block, position_x, 1, position_z);
                    }else if(objectRandom<=arrow_probability){
                        objectRandom=Random.Range(1,5);
                        if(objectRandom==1){
                            GameObjectPool.GetInstance().Object_Instantiate(right_arrow, position_x, 1, position_z);
                        }else if(objectRandom==2){
                            GameObjectPool.GetInstance().Object_Instantiate(left_arrow, position_x, 1, position_z);
                        }else if(objectRandom == 3){
                            GameObjectPool.GetInstance().Object_Instantiate(up_arrow, position_x, 1, position_z);
                        }else if(objectRandom==4){
                            GameObjectPool.GetInstance().Object_Instantiate(down_arrow, position_x, 1, position_z);
                        }
                    }
                    //else blank
                }
                position_x++;
            }
            position_x = rightIndex_x - createlimit_unit;
            position_z--;

        }
        //create audience
        position_x = rightIndex_x - createlimit_unit;
        position_z = landWidth;
        for (int i = 0; i <= 4;i++){
            objectRandom = Random.Range(0, 100);
            if (objectRandom <= audience_probability)
            {
                objectRandom = Random.Range(1, 4);
                switch (objectRandom)
                {
                    case 1: GameObjectPool.GetInstance().Object_Instantiate(Audience_1, position_x + i, 1.5f, position_z + 1);break;
                    case 2: GameObjectPool.GetInstance().Object_Instantiate(Audience_2, position_x + i, 1.5f, position_z + 1); break;
                    case 3: GameObjectPool.GetInstance().Object_Instantiate(Audience_3, position_x + i, 1.5f, position_z + 1); break;
                }
            }
        }

    }







    void CreateCorrectRoad(){
        SearchRoad_DFS(lastCorrectPlace,1);
        CreateRoad();

    }

    void CreateRoad(){
        int position_x = rightIndex_x - createlimit_unit;
        int position_z = landWidth + 1 - lastCorrectPlace;
        int i = lastCorrectPlace;
        int j = 1;
        orderOfRoad = 1;
        int objectRandom;
        while(true){
            objectRandom = Random.Range(0, 100);
            if(searchArray[i,j+1]==orderOfRoad+1){
                if (objectRandom <= arrow_probability)
                    GameObjectPool.GetInstance().Object_Instantiate(right_arrow, position_x, 1, position_z);
                position_x = position_x+1;
                //position_z = position_z;
                j = j+1;
                orderOfRoad++;
                continue;
            }else if (searchArray[i, j-1] == orderOfRoad+1){
                if (objectRandom <= arrow_probability)
                    GameObjectPool.GetInstance().Object_Instantiate(left_arrow, position_x, 1, position_z);
                position_x = position_x-1;
                j = j-1;
                orderOfRoad++;
                continue;
            }else if (searchArray[i-1, j] == orderOfRoad + 1){
                if (objectRandom <= arrow_probability)
                    GameObjectPool.GetInstance().Object_Instantiate(up_arrow, position_x, 1, position_z);
                position_z = position_z+1;
                i = i-1;
                orderOfRoad++;
                continue;
            }else if (searchArray[i+1, j] == orderOfRoad + 1){
                if (objectRandom <= arrow_probability)
                    GameObjectPool.GetInstance().Object_Instantiate(down_arrow, position_x, 1, position_z);
                position_z = position_z-1;
                i = i+1;
                orderOfRoad++;
                continue;
            }
            if(j==createlimit_unit){
                lastCorrectPlace = i;
                break;
            }

        }


    } 
    //Dfs path find
    void SearchRoad_DFS(int i,int j){
        orderOfRoad++;
        searchArray[i, j] = orderOfRoad;
        if(j==createlimit_unit){
            SearchEndFlag = true;
            return;
        }

        switch(Random.Range(1,5)){
            case 1:{//first up
                    if(searchArray[i-1,j]==0){
                        SearchRoad_DFS(i-1,j);
                        if (SearchEndFlag == true) return;
                    }
                    if (searchArray[i + 1, j] == 0){
                        SearchRoad_DFS(i + 1, j);
                        if (SearchEndFlag == true) return;
                    }
                    if (searchArray[i , j-1] == 0){
                        SearchRoad_DFS(i , j-1);
                        if (SearchEndFlag == true) return;
                    }
                    if (searchArray[i , j+1] == 0){
                        SearchRoad_DFS(i, j+1);
                        if (SearchEndFlag == true) return;
                    }
                    break; 
                }
            case 2:{//first down
                    if(searchArray[i + 1, j]==0){
                        SearchRoad_DFS(i + 1,j);
                        if (SearchEndFlag == true) return;
                    }
                    if (searchArray[i - 1, j] == 0){
                        SearchRoad_DFS(i - 1, j);
                        if (SearchEndFlag == true) return;
                    }
                    if (searchArray[i , j-1] == 0){
                        SearchRoad_DFS(i , j-1);
                        if (SearchEndFlag == true) return;
                    }
                    if (searchArray[i , j+1] == 0){
                        SearchRoad_DFS(i, j+1);
                        if (SearchEndFlag == true) return;
                    }
                    break; 
                }
            case 3:{//first right
                    if (searchArray[i, j + 1] == 0){
                        SearchRoad_DFS(i, j + 1);
                        if (SearchEndFlag == true) return;
                    }
                    if (searchArray[i - 1, j] == 0){
                        SearchRoad_DFS(i - 1, j);
                        if (SearchEndFlag == true) return;
                    }
                    if (searchArray[i + 1, j] == 0){
                        SearchRoad_DFS(i + 1, j);
                        if (SearchEndFlag == true) return;
                    }
                    if (searchArray[i, j - 1] == 0){
                        SearchRoad_DFS(i, j - 1);
                        if (SearchEndFlag == true) return;
                    }

                    break; 
                }
            case 4:{//first left
                    if (searchArray[i, j - 1] == 0){
                        SearchRoad_DFS(i, j - 1);
                        if (SearchEndFlag == true) return;
                    }
                    if (searchArray[i, j + 1] == 0){
                        SearchRoad_DFS(i, j + 1);
                        if (SearchEndFlag == true) return;
                    }
                    if (searchArray[i - 1, j] == 0){
                        SearchRoad_DFS(i - 1, j);
                        if (SearchEndFlag == true) return;
                    }
                    if (searchArray[i + 1, j] == 0){
                        SearchRoad_DFS(i + 1, j);
                        if (SearchEndFlag == true) return;
                    }
                   

                    break;
                }      
        }
        searchArray[i, j] = 0;
        orderOfRoad--;
    }

    public int GetCreateLimit_unit(){
        return createlimit_unit;
    }
    public int GetCreateTime(){
        return createTime;
    }

    public GameState GetState(){
        return state;
    }
    public void ChangeState(){
        state = GameState.gameover; 
    } 

}
