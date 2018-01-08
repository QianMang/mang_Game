using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnergyBall : MonoBehaviour {
	public GameObject energyBall;
	public int EnergyLimit=2;
	public float Gap=20f;
	public float XyLimit = 1.6f;
	int EnergyNum=0;
	public int randomLimit=10;



	System.Random random=new System.Random(System.DateTime.Today.Millisecond);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (EnergyNum < EnergyLimit) {
			createOneEnergyBall ();
		}
	}

	void createOneEnergyBall(){
		if (random.Next (0, 100) < randomLimit) {
			Quaternion rotation = Quaternion.Euler(Vector3.zero);
			GameObject newEnergyBall;
			float newX=random.Next((int)(-XyLimit*10),(int)(XyLimit*10))/10.0f;
			float newY=random.Next((int)(-XyLimit*10),(int)(XyLimit*10f))/10.0f;
			float newZ = this.transform.position.z + Gap;
			Vector3 newPosition = new Vector3 (newX, newY, newZ);

			newEnergyBall = Instantiate (energyBall, newPosition, rotation);
			EnergyNum++;
		}
	}

	public void destroyEnergyBall(){
		EnergyNum--;
	}
}
