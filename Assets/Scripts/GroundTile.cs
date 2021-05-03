using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject obstaclePrefab;
    public GameObject[] blueTrashPrefab;
    public GameObject[] greenTrashPrefab;
    public GameObject[] brownTrashPrefab;

    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnGround(true);
        Destroy(gameObject, 5);
    }

    public void SpawnObstacle()
    {
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(4, 7);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstacle at the position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnObject()
    {
        int objectSpawnIndex = Random.Range(0, 3);
        GameObject temp;
        int randomTrashIndex = Random.Range(0, 3);

        if (objectSpawnIndex == 0)
            temp = Instantiate(blueTrashPrefab[randomTrashIndex], transform);
        else if (objectSpawnIndex == 1)
            temp = Instantiate(greenTrashPrefab[randomTrashIndex], transform);
        else
            temp = Instantiate(brownTrashPrefab[randomTrashIndex], transform);

        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );

        if (point != collider.ClosestPoint(point))
            point = GetRandomPointInCollider(collider);

        point.y = 1.65f;
        return point;
    }
}
