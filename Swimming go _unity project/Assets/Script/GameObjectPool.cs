using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour {
    //object dictionary
    Dictionary<string, List<GameObject>> poolDic=new Dictionary<string, List<GameObject>>();  
	private GameObjectPool(){}
	private static GameObjectPool instance;
	public static GameObjectPool GetInstance(){
		if (instance == null) {
			instance  = new GameObject("GameObjectPool").AddComponent<GameObjectPool>();
		}
		return instance;
	}
	//take object from pool
    public GameObject Object_Instantiate(GameObject newObject,float x,float y,float z){
		Vector3 newPosition=new Vector3(x,y,z);
        string dic_str = newObject.name.Split(' ')[0] + "(Clone)";//key string
		//if there is no key value in dictionary, then add this key value
        if(!poolDic.ContainsKey(dic_str))
            poolDic.Add (dic_str, new List<GameObject> ()); 
        //if the pool is empty, then instantiate a gameobject,else take the object
        if (poolDic[dic_str].Count == 0){
            return Instantiate(newObject, newPosition, Quaternion.identity) as GameObject;
        }else{
            GameObject obj = poolDic[dic_str][0];
            obj.SetActive(true);
            poolDic[dic_str].Remove(obj); //remove the object
            obj.transform.position = newPosition;
            return obj;
        }
	}
	//add object to pool
	public void Object_Disable(GameObject disableObject){
		disableObject.SetActive(false);
        string dic_str = disableObject.name;
        poolDic[dic_str].Add(disableObject);
	}
}
