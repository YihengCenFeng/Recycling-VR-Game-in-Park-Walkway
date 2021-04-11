using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnGround(bool spawnItem)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if(spawnItem)
        {
            if (Random.Range(0, 3) == 1)
                FindObjectOfType<GroundTile>().SpawnObstacle();

            FindObjectOfType<GroundTile>().SpawnObject();
        }
    }

    private void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            if(i<1)
                SpawnGround(false);
            else
                SpawnGround(true);
        }
    }
}
