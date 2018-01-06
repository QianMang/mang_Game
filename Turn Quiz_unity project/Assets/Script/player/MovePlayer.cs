using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
	[HideInInspector]
	public bool IsStart = false;
	float moveIndex;
	Vector3 startFingerPos,nowFingerPos;
	bool startPosFlag=true;
	float startTime,endTime;
	[HideInInspector]
	public bool levelFlag = true;
	int direction=0;
	bool direction_up = true;
	bool direction_down=true;
	bool direction_left=true;
	bool direction_right=true;
	// Use this for initialization
	void Start () {
		Invoke ("start_after_3s",4.5f);
	}
	void start_after_3s()
	{
		IsStart = true;
	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1 && IsStart==true) {
			if (Input.GetTouch (0).phase == TouchPhase.Began && startPosFlag == true) {

				//Debug.Log("======开始触摸=====");

				startFingerPos = Input.GetTouch (0).position;
				startTime = Time.time;
				startPosFlag = false;

			}

			if (Input.GetTouch (0).phase == TouchPhase.Ended) {

				//Debug.Log("======释放触摸=====");

				startPosFlag = true;
				endTime = Time.time;


				nowFingerPos = Input.GetTouch (0).position;

				float xMoveDistance = Mathf.Abs (nowFingerPos.x - startFingerPos.x);

				float yMoveDistance = Mathf.Abs (nowFingerPos.y - startFingerPos.y);
				print (xMoveDistance);
				print (yMoveDistance);

				if (xMoveDistance > yMoveDistance) {

					if (nowFingerPos.x - startFingerPos.x > 0) {

						//Debug.Log("=======沿着X轴-方向移动=====");

						direction = 1; //沿着X轴+方向移动

					} else {

						//Debug.Log("=======沿着X轴+方向移动=====");

						direction = -1; //沿着X轴-方向移动

					}

				} else if(xMoveDistance < yMoveDistance){

					if (nowFingerPos.y - startFingerPos.y > 0) {

						//Debug.Log("=======沿着Y轴正方向移动=====");

						direction = 2; //沿着Y轴正方向移动

					} else {

						//Debug.Log("=======沿着Y轴负方向移动=====");

						direction = -2; //沿着Y轴负方向移动

					}

				}
				if (endTime - startTime >= 1.5f) {         //超时
					direction=0;
				}
			}
		}

		if (direction==1) {      //上下左右判断
			print ("right");
			if (check (transform.position + Vector3.right)&&direction_right==true) 
			{
				transform.Translate (Vector2.right);
				if(GameObject.Find("Camera_PlayTween")!=null)
					GameObject.Find ("Main Camera").GetComponent<MoveCamera> ().MoveCamera_check ();
				turn_01wall ();//
				turn_01ArrowWall();
			}
			direction = 0;
		} else if (direction==2) {
			print ("up");
			if (check (transform.position + Vector3.up)&&direction_up==true)
			{
				transform.Translate (Vector2.up);
				if(GameObject.Find("Camera_PlayTween")!=null)
					GameObject.Find ("Main Camera").GetComponent<MoveCamera> ().MoveCamera_check ();
				turn_01wall();//
				turn_01ArrowWall();
			}
			direction = 0;
		} else if (direction==-2) {
			print ("down");
			if (check (transform.position + Vector3.down)&&direction_down==true)
			{
				transform.Translate (Vector2.down);
				if(GameObject.Find("Camera_PlayTween")!=null)
					GameObject.Find ("Main Camera").GetComponent<MoveCamera> ().MoveCamera_check ();
				turn_01wall();
				turn_01ArrowWall ();
			}
			direction = 0;
		} else if (direction==-1) {
			print ("left");
			if (check (transform.position + Vector3.left)&&direction_left==true) 
			{
				transform.Translate (Vector2.left);
				if(GameObject.Find("Camera_PlayTween")!=null)
					GameObject.Find ("Main Camera").GetComponent<MoveCamera> ().MoveCamera_check ();
				turn_01wall();//
				turn_01ArrowWall();
			}
			direction = 0;
		}
		direction = 0;

			


	}


	bool check(Vector3 v)
	{
		float index = GameObject.Find ("Main Camera").GetComponent<LevelInfo> ().Level [(int)(10f - v.y), (int)(6f + v.x)];
		if (index== 0f || index==9f)
			return true;
		else
			return false;
	}



	void turn_01wall()//
	{
		GameObject[] zeroOne_WallList = GameObject.FindGameObjectsWithTag ("01wall");
		for (int i = 0; i < zeroOne_WallList.Length; i++) {
			zeroOne_WallList [i].GetComponent<Wall_turn_zeroOrOne> ().wall_zeroOrOne_turn ();
		}

	}
	void turn_01ArrowWall()
	{
		GameObject[] arrow_WallList = GameObject.FindGameObjectsWithTag ("01arrowWall");
		for (int i = 0; i < arrow_WallList.Length; i++) {
			arrow_WallList [i].GetComponent<Arrow_wall_turn> ().arrow_wall_turn ();

		}

	}

	public void setDirectionBool(int directionNum)   //arrow_wall   调用
	{
		if (directionNum == 2) {//up
			direction_down=!direction_down;
			direction_right=!direction_right;
			direction_left=!direction_left;
		} else if (directionNum == -2) {//down
			direction_up=!direction_up;
			direction_right=!direction_right;
			direction_left=!direction_left;
		} else if (directionNum == 1) { //right
			direction_up=!direction_up;
			direction_down=!direction_down;
			direction_left=!direction_left;
		} else if (directionNum == -1) {//left
			direction_up=!direction_up;
			direction_down=!direction_down;
			direction_right=!direction_right;
		}

	}
	public void setAllDirectionBool()  //item_wormhole
	{
		direction_down=!direction_down;
		direction_right=!direction_right;
		direction_left=!direction_left;
		direction_up=!direction_up;
	}

}
