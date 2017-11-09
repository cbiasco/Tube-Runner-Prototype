using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    private static ObstacleController instance;

    public bool running = true;

    [SerializeField]
    private GameObject obstaclePrefab;

    private Vector2 spawnRange = new Vector2(1f, 3f);
    
    public static ObstacleController Instance
    {
        get { return instance; }
    }

    public void SpawnObstacles()
    {
        running = true;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() {
        StartCoroutine(SpawnObstacle(Random.Range(spawnRange.x, spawnRange.y)));
	}

    IEnumerator SpawnObstacle(float spawnTime)
    {
        for (; running == true ;)
        {
            yield return new WaitForSeconds(spawnTime);

            float angle = Random.Range(0f, 360f);

            GameObject newObstacle = Instantiate(obstaclePrefab);
            newObstacle.transform.parent = gameObject.transform;
            newObstacle.transform.position = new Vector3(0f, -333f, -9f);
            newObstacle.transform.RotateAround(Vector3.zero, Vector3.up, angle);
        }
    }
}
