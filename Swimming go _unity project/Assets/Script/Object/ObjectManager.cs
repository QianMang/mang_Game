using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    float disableTime=20;
    // Use this for initialization
    void Start()
    {

    }

    private void OnEnable()
    {
        StartCoroutine(DelayDisable(disableTime));

    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator DelayDisable(float time)
    {
        yield return new WaitForSeconds(time);
        GameObjectPool.GetInstance().Object_Disable(gameObject);



    }
}
