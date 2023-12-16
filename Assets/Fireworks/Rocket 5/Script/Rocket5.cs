﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket5 : MonoBehaviour
{
    bool lit =false;
    public Rigidbody rig;
    public ConstantForce cf;
    public Transform IsKinematic;

    IEnumerator Fire()

    {
        //Wait for 3 secs.
        yield return new WaitForSeconds(3);

        //Game object will turn off
        GameObject.Find("MeshRenderer5").SetActive(false);

        rig.isKinematic = true;
        cf.enabled = false;


    }

void Update()
    {
        if(lit == true){
            StartCoroutine(Fire());
        }
    }
}
