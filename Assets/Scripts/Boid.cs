using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

    public int mass;
    public int maximumSpeed;

    public Vector3 force = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;
    public Vector3 velocity = Vector3.zero;

    private List<SteeringBehaviors> steeringBehav = new List<SteeringBehaviors>();

	// Use this for initialization
	void Start () {
		SteeringBehaviors [] steeringBev = GetComponents<SteeringBehaviors>();
        foreach(SteeringBehaviors steering in steeringBev)
        {
            steeringBehav.Add(steering);
        }
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, velocity+ transform.position);
    }

    Vector3 seekForce(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired = desired.normalized;
        desired *= maximumSpeed;
        return desired - velocity;
    }

    Vector3 calculate()
    {
        Vector3 calcForce = Vector3.zero;
        foreach(SteeringBehaviors steer in steeringBehav)
        {
            if(steer.isActiveAndEnabled)
            {
                calcForce = steer.calculate();
            }
        }

        return calcForce;
    }
	
	// Update is called once per frame
	void Update () {
        force = calculate();
        acceleration = force / mass;
        velocity = acceleration * Time.deltaTime;

        Vector3.ClampMagnitude(velocity, maximumSpeed);
        transform.LookAt(transform.position + velocity);

        if (velocity.magnitude > 0.00001f)
        {
            velocity *= 0.99f;
        }

        transform.position += velocity;
	}
}
