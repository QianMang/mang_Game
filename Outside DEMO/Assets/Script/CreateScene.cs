using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScene : MonoBehaviour {
	public GameObject cube;
	public GameObject pyramid1;
	public GameObject pyramid2;
	public float xLimit = 4f;
	//public float yLimit = 4f;
	public float zLimit = 20f;
	float randomCenter=0;
	float randomThreshold=0;
	public int maxCubeNum = 100;
	int cubeNum=0;//场景中cube的数量
	float rotateSpeedLimit=50f;
	float cameraPositionZ=0;
	float gap=0;
	int level;
	// Use this for initialization
	System.Random random=new System.Random(System.DateTime.Today.Millisecond);
	void Start () {
		chooseLevel ();
		randomThreshold = zLimit;
		cameraPositionZ=this.transform.position.z;
		switch(level){
		case 0:   //level1不需要初始化场景 
//			for (int i = 0; i <= maxCubeNum; i++) {
//				createOnePyramid_level1 ();
//			}
			break;
		case 1:
			for (int i = 0; i <= maxCubeNum; i++) {
				createOneCube_level1 ();

			}
			break;
		case 2:
			for (int i = 0; i <= maxCubeNum; i++) {
				createOneCube_level2 ();

			}
			break;
		}
		if (level != 0) {
			gap = randomCenter + randomThreshold - cameraPositionZ;
			randomThreshold = zLimit / maxCubeNum;
		} else {    //第一关中与摄像机的距离及随机生成范围
			gap = 80;
			randomThreshold = 30;
		}
	}
	
	// Update is called once per frame
	void Update () {
		cameraPositionZ=this.transform.position.z;
		randomCenter = cameraPositionZ + gap;
		if (cubeNum < maxCubeNum+20) {
			switch(level){
			case 0:
				int p = Random.Range (1, 100);
				if (p <= 9) {
					createOnePyramid_level0 ();
				}
				break;
			case 1:
				createOneCube_level1 ();
				break;
			case 2:
				createOneCube_level2 ();
				break;
			}

		}
	}

	void chooseLevel(){
		string levelName = GameObject.FindGameObjectWithTag ("level").name;
		if (levelName == "Level2") {
			level = 2;

		} else if (levelName == "Level1") {
			level = 1;
		}else if (levelName == "Level3") {
			level = 3;
		}else if (levelName == "Level4") {
			level = 4;
		}


	}
	//level0
	void createOnePyramid_level0(){
		float newZPosition = Random.Range(randomCenter-randomThreshold,randomCenter+randomThreshold);
		float newXPosition = Random.Range (-xLimit, xLimit);
		float newYPosition = -40;    //三角体初始y坐标，从下往上
		while (newXPosition <= 5 && newXPosition >= 5) {
			newXPosition = Random.Range (-xLimit, xLimit);
		}
		Vector3 startRotate = new Vector3 (Random.Range (0, 360), Random.Range (0, 360), Random.Range (0, 360));
		Quaternion rotation = Quaternion.Euler (startRotate);
		GameObject newPyramid;
		Vector3 newLocation = new Vector3 (newXPosition, newYPosition, newZPosition);
		int pyramidType = Mathf.FloorToInt(Random.Range (0, 2));
		switch(pyramidType){
		case 0:
			newPyramid = Instantiate (pyramid1, newLocation, rotation) as GameObject;
			break;
		case 1:
			newPyramid = Instantiate (pyramid2, newLocation, rotation) as GameObject;
			break;
		}
		cubeNum++;
	}
	//level1
	void createOneCube_level1 (){
		float newZPosition = Random.Range(randomCenter-randomThreshold,randomCenter+randomThreshold);
		float newXPosition = Random.Range (-xLimit, xLimit);
		float newYPosition=Random.Range (-xLimit, xLimit);
		while ((newXPosition <= xLimit - 5 && newXPosition >= -xLimit + 5) && (newYPosition <= xLimit - 5 && newYPosition >= -xLimit + 5)) {
			newXPosition = Random.Range (-xLimit, xLimit);
			newYPosition=Random.Range (-xLimit, xLimit);
		}
		Quaternion rotation = Quaternion.Euler(Vector3.zero);
		GameObject newCube;
		Vector3 newLocation = new Vector3 (newXPosition, newYPosition, newZPosition);
		newCube = Instantiate (cube,newLocation,rotation) as GameObject;
		cubeNum++;
	}
	void createOneCube_level2(){
		float newZPosition = random.Next((int)(randomCenter-randomThreshold), (int)(randomCenter+randomThreshold));
		float newXPosition = random.Next((int)-xLimit, (int)xLimit);
		float newYPosition = (float)System.Math.Sqrt(System.Convert.ToDouble(xLimit * xLimit - newXPosition * newXPosition));
		float newYPositionPositive = random.Next(-10, 10);//y轴正负
		Quaternion rotation = Quaternion.Euler(Vector3.zero);
		GameObject newCube;
		if (newYPositionPositive <= 0) {
			Vector3 newLocation = new Vector3 (newXPosition, newYPosition, newZPosition);
			newCube = Instantiate (cube,newLocation,rotation) as GameObject;
		} else {
			Vector3 newLocation = new Vector3 (newXPosition, -newYPosition, newZPosition);
			newCube = Instantiate (cube,newLocation,rotation) as GameObject;
		}
		float rotateSpeed = random.Next ((int)-rotateSpeedLimit, (int)rotateSpeedLimit);
		while(rotateSpeed<=8&&rotateSpeed>=-8)
			rotateSpeed = random.Next ((int)-rotateSpeedLimit, (int)rotateSpeedLimit);
		newCube.GetComponent<CubeActivity> ().setRotateSpeed (rotateSpeed);
		cubeNum++;
	}

	public void destroyCube(){
		cubeNum--;

	}
}
