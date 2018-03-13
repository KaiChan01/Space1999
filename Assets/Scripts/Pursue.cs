using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : SteeringBehaviors
{

	// Use this for initialization
	void Start () {
        boid = GetComponent<Boid>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override Vector3 calculate()
    {
        //Leader should be the target
        vector3 toTarget = target - transform.position;
        float distance = toTarget.magnitude;
        float time = distance / maxSpeed;

        Vector3 newTarget = time * target.velocity;
        return boid.seekforce(newTarget);
    }
}
