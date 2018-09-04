using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Vector3 finishPos = Vector3.zero;
    public float speed = 0.5f;

    Vector3 startPos;
    float trackPercent = 0;  //how far between start and finish
    int direction = 1;


	void Start () 
	{
		startPos = transform.position;
	}
	
	void Update ()
	{
	    trackPercent += direction * speed * Time.deltaTime;
	    float x = (finishPos.x - startPos.x) * trackPercent * startPos.x;
	    float y = (finishPos.y - startPos.y) * trackPercent * startPos.y;
	    transform.position = new Vector3(x, y, startPos.z);
	}
}
