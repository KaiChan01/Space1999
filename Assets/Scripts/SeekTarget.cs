using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekTarget : SteeringBehaviors {

    public Boid boid;

    //Testing
    public Vector3 target;

	// Use this for initialization
	void Start () {
        boid = GetComponent<Boid>();
        target = new Vector3(93, 3, -5 + 1000);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override Vector3 calculate()
    {
        Vector3 desired = target - transform.position;
        desired = desired.normalized;
        desired *= boid.maximumSpeed;
        return desired - boid.velocity;
    }
}
