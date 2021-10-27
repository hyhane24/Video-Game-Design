using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : MonoBehaviour
{
    
    public int vel = 1;
    public int velT = 10;
    public Rigidbody body;

    private void Start() {
        body = this.GetComponent<Rigidbody>();

        for (int i=0; i < 200; i++){
        int flyX = Random.Range(vel, velT);
        int flyy = Random.Range(vel, velT);
        int flyz = Random.Range(vel, velT);
        body.velocity = new Vector3(flyX, flyy, flyz);
        
        }
    }   
}
