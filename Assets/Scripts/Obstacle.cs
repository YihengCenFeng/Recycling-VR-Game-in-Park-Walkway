using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" || other.transform.parent.name == "TrashBinHolder")
        {
            FindObjectOfType<VRMovement>().Die();
            FindObjectOfType<AudioManager>().PlaySound("Incorrect");
        }
    }
}
