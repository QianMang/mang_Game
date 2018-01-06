using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLandModel : MonoBehaviour {
    public GameObject LandCube;
    public int landWidth;
    public string model;
    GameObject newLandCube;
    //Vector3 v=new Vector3.zero;
	// Use this for initialization
	void Start () {
        
        int rightIndex_x = 0;
        int rightIndex_y = 0;
        int rightIndex_z = 0;
        for (; rightIndex_x <= 4; rightIndex_x++)
        {
            for (rightIndex_z = 0; rightIndex_z <= landWidth + 1;)
            {
                if (rightIndex_z == 0 || rightIndex_z == landWidth + 1)
                {
                    Vector3 v = new Vector3(rightIndex_x, 1, rightIndex_z);
                    newLandCube=Instantiate(LandCube, v, Quaternion.identity);
                    newLandCube.transform.parent=GameObject.Find(model).transform;
                }
                Vector3 v2 = new Vector3(rightIndex_x, 0, rightIndex_z);
                newLandCube =Instantiate(LandCube, v2, Quaternion.identity);
                newLandCube.transform.parent = GameObject.Find(model).transform;
                rightIndex_z++;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
