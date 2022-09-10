using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour {

    public GameObject explosion;
    private GameObject[] foxes;
    private Animator anim;

    // Use this for initialization
    void Start()
    {

        foxes = GameObject.FindGameObjectsWithTag("fox");
        anim = GameObject.Find("+1").GetComponent<Animator>();

    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            anim.Play("+1 Effect");
            Instantiate(explosion, transform.position, Quaternion.identity);
            
        }
    }
        
  } // class

