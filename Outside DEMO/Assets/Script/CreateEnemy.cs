using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour {
	GameObject camera;
	public GameObject enemy;
	float limitX = 2;
	public float createProbabilityLimit=20;
	int enemyNum=0;
	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera");

	}
	
	// Update is called once per frame
	void Update () {
		if (enemyNum == 0) {
			float createProbability = Random.Range (0, 1000);
			if (createProbability < createProbabilityLimit) {
				createNewEnemies ();
			}
		}

	}
	void createNewEnemies(){
		int createMode = Random.Range (1, 4);
		float newPositionX = 0;
		float newPositionY = 0;
		float newPositionZ = camera.transform.position.z - 10f;
		Vector3[] newPosition={Vector3.zero,Vector3.zero,Vector3.zero,Vector3.zero};

		GameObject newEnemy;
		int pathIndex;

		switch (createMode) {// 生成敌人的不同方式
		case 1://生成一个敌人
			while (newPositionX == 0 && newPositionY == 0) {
				newPositionX = Random.Range (-limitX, limitX+1);
				newPositionY = Random.Range (-limitX, limitX+1);
			}
			pathIndex =Mathf.FloorToInt( Random.Range (1f, 4f));

			newPosition[0] = new Vector3 (newPositionX, newPositionY, newPositionZ);
			newEnemy = Instantiate (enemy, newPosition[0], Quaternion.identity) as GameObject;
			newEnemy.GetComponent<EnemyActivity> ().initialize (pathIndex,createMode);
			enemyNum++;
			break;
		case 2://生成4个敌人做圆周运动
			pathIndex = 1;
			newPositionX = limitX;
			newPositionY = limitX;
			newPosition [0] = new Vector3 (newPositionX, newPositionY, newPositionZ);
			newPosition [1] = new Vector3 (-newPositionX, newPositionY, newPositionZ);
			newPosition [2] = new Vector3 (-newPositionX, -newPositionY, newPositionZ);
			newPosition [3] = new Vector3 (newPositionX, -newPositionY, newPositionZ);
			for (int i = 0; i <= 3; i++) {

				newEnemy = Instantiate (enemy, newPosition [i], Quaternion.identity) as GameObject;
				newEnemy.GetComponent<EnemyActivity> ().initialize (pathIndex, createMode);
				
			}
			enemyNum = 4;
			break;
		case 3://生成两个敌人做square运动
			pathIndex = 3;
			newPositionX = limitX;
			newPositionY = limitX;
			newPosition [0] = new Vector3 (newPositionX, newPositionY, newPositionZ);
			newPosition [1] = new Vector3 (-newPositionX, -newPositionY, newPositionZ);
			for (int i = 0; i <= 1; i++) {

				newEnemy = Instantiate (enemy, newPosition [i], Quaternion.identity) as GameObject;
				newEnemy.GetComponent<EnemyActivity> ().initialize (pathIndex, createMode);

			}
			enemyNum = 2;
			break;
		case 4:
			break;
		case 5:
			break;
		}

	}

	public void destroyEnemy(){
		enemyNum--;

	}


}
