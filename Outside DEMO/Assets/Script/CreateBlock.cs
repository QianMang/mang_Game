using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour {
	public GameObject Block_1;
	public GameObject Block_2;
	public int BlockLimit=10;
	public float Gap=20f;
	public float XyLimit = 1.6f;
	int BlockNum=0;
	public int randomLimit=10;
	string level;
	System.Random random=new System.Random(System.DateTime.Today.Millisecond);
	// Use this for initialization
	void Start () {
		level = GameObject.FindGameObjectWithTag ("level").name;
	}
	
	// Update is called once per frame
	void Update () {
		switch(level){
		case "Level0":
			//createOnePyramidBlock_level0 ();
			break;
		case "Level2":
			if (BlockNum <= BlockLimit) {
				createOneCubeBlock_level2 ();
			}
			break;
		}
	}
	void createOnePyramidBlock_level0(){
		if (Random.Range (0, 1000) <= 10) {
			float newX = Random.Range (-XyLimit, XyLimit);
			float newY = Random.Range (-XyLimit, XyLimit);
			float newZ = this.transform.position.z + Gap;
			Vector3 newPosition = new Vector3 (newX, newY, newZ);
			Vector3 startRotate = new Vector3 (Random.Range (0, 360), Random.Range (0, 360), Random.Range (0, 360));
			Quaternion rotation = Quaternion.Euler (startRotate);
			GameObject newBlock = Instantiate (Block_2, newPosition, rotation);
		}


	}
	void createOneCubeBlock_level2(){
		if (random.Next (0, 100) < randomLimit) {
			Quaternion rotation = Quaternion.Euler(Vector3.zero);
			GameObject newBlock;
			float newX=random.Next((int)(-XyLimit*10),(int)(XyLimit*10))/10.0f;
			float newY=random.Next((int)(-XyLimit*10),(int)(XyLimit*10f))/10.0f;
			float newZ = this.transform.position.z + Gap;
			Vector3 newPosition = new Vector3 (newX, newY, newZ);

			newBlock = Instantiate (Block_1, newPosition, rotation);
			BlockNum++;
		}

	}
	public void destroyBlock(){
		BlockNum--;

	}
}
