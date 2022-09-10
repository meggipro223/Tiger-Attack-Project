using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowerr : MonoBehaviour {

    public static PlayerThrowerr instance;

    public Transform target;
    public Transform throwPoint;
    public GameObject player;
    public float timeToHilt;

    public bool isWorking;

	// Use this for initialization
	void Start () {
        MakeInstance();
        isWorking = true;
	}

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Throw();
        }
	}

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    public bool Throw()
    {
        if (isWorking)
        {
            target.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float xDistance;
            xDistance = target.position.x - throwPoint.position.x;

            float yDistance;
            yDistance = target.position.y - throwPoint.position.y;

            float throwAngle;
            throwAngle = Mathf.Atan((yDistance + 1f) / xDistance);

            float totalVelocity = xDistance / Mathf.Cos(throwAngle) * (timeToHilt * Time.deltaTime);

            float xVel, yVel;
            xVel = totalVelocity * Mathf.Cos(throwAngle);
            yVel = totalVelocity * Mathf.Sin(throwAngle);

            Player.instance.myBody.velocity = new Vector2(xVel, yVel);

          
        }

        return true;
    }
}
