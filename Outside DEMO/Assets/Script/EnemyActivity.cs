using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivity : MonoBehaviour {
	
	bool isDestroyed=false;
	bool canBeDestroyed=false;  
	GameObject camera;
	public GameObject laser;
	float attack_probability=20;
	public int PathIndex;//路线   1：圆周 2：对角线移动 3：square形运动
	public int Diagonal_direction;//对角线路线的方向 1：向右上 2：向左上 3：向左下 4：右下//suiji
	public int Square_direction;//1:left,2:down,3:right,4:up

	public float distance=11f;
	System.Random random=new System.Random(System.DateTime.Today.Millisecond);
	//enemy运动属性
	float circleSpeed=70f;
	float diagonalSpeed=3f;
	float SquareSpeed=3f;
	float StartSpeed=1;//
	float enemySpeed=0.2f;
	float enemyLimitX=2;

	// Use this for initialization
	void Start () {
		
		camera= GameObject.Find ("Main Camera");



	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isDestroyed == false) {
			if (this.transform.position.z - camera.transform.position.z >= distance && canBeDestroyed == false) {
				setCanBeDetroyed ();

			}
			if (canBeDestroyed == true) {
			
				shootLaser ();
				switch (PathIndex) {
				case 1:
					enemyPath_Circle (circleSpeed, 0, 0);
					break;
				case 2:
					enemyPath_Diagonal (diagonalSpeed, enemyLimitX);
					break;
				case 3:
					enemyPath_Square (SquareSpeed, enemyLimitX);
					break;
				}
				this.gameObject.transform.Translate (0, 0, enemySpeed, Space.World);
			} else {
				this.transform.Translate (0, 0, StartSpeed);

			}
		}
	}
	//运动过程中初始化，createEnemy调用
	public void initialize (int pathIndex,int createMode) {       
		PathIndex=pathIndex;
		if (PathIndex == 2||PathIndex==3) {
			enemyPath_initialize ();
		}
		if (createMode == 2) {   //四个敌人，调低发射激光概率
			
			attack_probability=8;
		}
	}

	void OnMouseDown(){
		if (isDestroyed == false) {
			Destroy (this.transform.Find ("entity").gameObject);
			this.transform.Find ("Particle die").GetComponent<ParticleSystem> ().Play ();
			isDestroyed = true;
            GameObject.Find("Main Camera").GetComponent<ScoreAndHealth>().ChangeScore(1);
			Invoke ("destroyWholeThing", 1f);
		}
	}
	//销毁父物体
	void destroyWholeThing(){   
		Destroy (this.gameObject);
		GameObject.Find ("Main Camera").GetComponent<CreateEnemy> ().destroyEnemy ();
	}

	//路线初始化准备工作
	void enemyPath_initialize(){
		if (PathIndex == 2) {
			if (this.transform.position.x > 0 && this.transform.position.y > 0) {
				Diagonal_direction = 3;
			}else if (this.transform.position.x < 0 && this.transform.position.y > 0) {
				Diagonal_direction = 4;
			}else if (this.transform.position.x < 0 && this.transform.position.y < 0) {
				Diagonal_direction = 1;
			}else if (this.transform.position.x > 0 && this.transform.position.y < 0) {
				Diagonal_direction = 2;
			}
		}else if (PathIndex == 3) {

			if (this.transform.position.x > 0 && this.transform.position.y > 0) {
				Square_direction = 1;
			}else if (this.transform.position.x < 0 && this.transform.position.y > 0) {
				Square_direction = 2;
			}else if (this.transform.position.x < 0 && this.transform.position.y < 0) {
				Square_direction = 3;
			}else if (this.transform.position.x > 0 && this.transform.position.y < 0) {
				Square_direction = 4;
			}

		}

	}

	 //圆运动
	void enemyPath_Circle(float speed,float centerX,float centerY){
		Vector3 centerPoint = new Vector3 (centerX, centerY, this.transform.position.z);
		transform.RotateAround(centerPoint, Vector3.forward, speed * Time.deltaTime);

	}
	//对角线运动
	void enemyPath_Diagonal(float speed,float limit){
		

		Vector3 targetPoint=Vector3.zero;
		switch (Diagonal_direction) {
		case 1:
			targetPoint = new Vector3 (limit, limit, this.transform.position.z);
			break;
		case 2:
			targetPoint = new Vector3 (-limit, limit, this.transform.position.z);
			break;
		case 3:
			targetPoint = new Vector3 (-limit, -limit, this.transform.position.z);
			break;
		case 4:
			targetPoint = new Vector3 (limit, -limit, this.transform.position.z);
			break;
		}
		transform.position=Vector3.MoveTowards (this.transform.position, targetPoint, Time.deltaTime*speed);
		//变向
		if (this.transform.position.x >= limit || this.transform.position.x <= -limit) {
			switch (Diagonal_direction) {
			case 1:
				Diagonal_direction = 3;
				break;
			case 2:
				Diagonal_direction = 4;
				break;
			case 3:
				Diagonal_direction = 1;
				break;
			case 4:
				Diagonal_direction = 2;
				break;
			}
		}
	}

	void enemyPath_Square(float speed,float limit){
		Vector3 targetPoint=Vector3.zero;
		switch (Square_direction) {
		case 1:
			targetPoint = new Vector3 (-limit, limit, this.transform.position.z);
			break;
		case 2:
			targetPoint = new Vector3 (-limit, -limit, this.transform.position.z);
			break;
		case 3:
			targetPoint = new Vector3 (limit, -limit, this.transform.position.z);
			break;
		case 4:
			targetPoint = new Vector3 (limit, limit, this.transform.position.z);
			break;
		}
		transform.position=Vector3.MoveTowards (this.transform.position, targetPoint, Time.deltaTime*speed);
		if (this.transform.position.x == limit && this.transform.position.y == limit) {
			Square_direction = 1;
		}else if (this.transform.position.x == -limit && this.transform.position.y == limit) {
			Square_direction = 2;
		}else if (this.transform.position.x == -limit && this.transform.position.y == -limit) {
			Square_direction = 3;
		}else if (this.transform.position.x == limit && this.transform.position.y == -limit) {
			Square_direction = 4;
		}
	}

	//射laser
	void shootLaser(){
		
		GameObject newLaser;
		float probability =  Random.Range (0, 1000);
		if (probability <= attack_probability) {
			int shootPointZ =  Random.Range(5, 8);
			Vector3 relativePos = camera.transform.position+Vector3.forward*shootPointZ - this.transform.position;
			Quaternion rotation = Quaternion.LookRotation(relativePos);
			newLaser = Instantiate (laser, this.transform.position, rotation) as GameObject;
		}


	}
	//到达运动点之前不能被射击 
	void setCanBeDetroyed(){
		canBeDestroyed = true;

	}


}
