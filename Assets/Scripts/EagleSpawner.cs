using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour {

    public float gap = 20;
    public float followers = 2;
    public GameObject prefab;

	// Use this for initialization
	void Start () {
		
	}

    void Awake()
    {
        GameObject leader;
        leader = GameObject.Instantiate(prefab);
        Vector3 leaderPosition = leader.transform.position = this.transform.position;
        leader.transform.rotation = Quaternion.Euler(0, 0, 0);
        leader.AddComponent<SeekTarget>();

        for (int i = 0; i < followers/2; i++)
        {
            GameObject newFollower1 = GameObject.Instantiate(prefab);
            GameObject newFollower2 = GameObject.Instantiate(prefab);
            newFollower1.AddComponent<Pursue>();
            newFollower2.AddComponent<Pursue>();
            Vector3 position1;
            Vector3 position2;
            position1 = new Vector3(leaderPosition.x - (gap * (i+1)), leaderPosition.y, leaderPosition.z - (gap * (i+1)));
            position2 = new Vector3(leaderPosition.x + (gap * (i + 1)), leaderPosition.y, leaderPosition.z - (gap * (i+1)));
            newFollower1.transform.position = position1;
            newFollower2.transform.position = position2;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
