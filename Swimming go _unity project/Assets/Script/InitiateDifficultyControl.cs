using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateDifficultyControl : MonoBehaviour {

    public GameObject prefab;          // 这是个预制，直接拖拽赋值  
    GameObject clone;                  // 用来接收预制的克隆体  
    static bool isHaveClone = false;   // 静态变量，所有脚本共用，也就是保证预制只能被克隆一次，不会出现多个角色  
  
    // Use this for initialization  
    void Start () {  
        if (!isHaveClone)  
        {  
            clone = Instantiate(prefab);  
            isHaveClone = true;
            DontDestroyOnLoad(clone);  
        }         
    }  
	// Update is called once per frame
	void Update () {
		
	}
}
