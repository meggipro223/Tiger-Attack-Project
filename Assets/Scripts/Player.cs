using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player instance;
    public Rigidbody2D myBody;

	// Use this for initialization
	void Start () {

        MakeInstance();
        myBody = GetComponent<Rigidbody2D>();
	}

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "fox")
        {
            target.gameObject.SetActive(false);
            GameplayController.instance.killedFoxes += 1;
            GameplayController.instance.numberCounter += 1;
            GameplayController.instance.counterText.text = GameplayController.instance.numberCounter.ToString();
        }

        if(target.gameObject.tag == "breakableBrick")
        {
            target.gameObject.SetActive(false);
        }
    }


}
