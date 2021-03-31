using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnGround(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if(spawnItems)
        {
            if (Random.Range(0, 2) == 1)
                temp.GetComponent<GroundTile>().SpawnCanCola();
            else
                temp.GetComponent<GroundTile>().SpawnApple();

            if (Random.Range(0, 2) == 1)
                temp.GetComponent<GroundTile>().SpawnObstacle();
        }
    }

    private void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            if (i < 1)
                SpawnGround(false);
            else
                SpawnGround(true);
        }
    }
}
