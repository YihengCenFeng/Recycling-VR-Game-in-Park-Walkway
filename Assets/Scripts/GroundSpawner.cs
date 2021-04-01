using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnGround(bool spawnObstacle)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if(spawnObstacle)
        {
            if (Random.Range(0, 2) == 1)
                FindObjectOfType<GroundTile>().SpawnObstacle();
        }
    }

    private void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            if(i<1)
                SpawnGround(false);
            else
                SpawnGround(true);
        }
    }
}
