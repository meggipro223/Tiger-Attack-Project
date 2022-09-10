using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {

        StartCoroutine(Destroyer());
	}

    IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(2.4f);
        Destroy(gameObject);
    }
}
