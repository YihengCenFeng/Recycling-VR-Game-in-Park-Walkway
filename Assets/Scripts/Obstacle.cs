using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private bool hasEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasEntered && (other.gameObject.name == "Player" || other.transform.parent.name == "TrashBinHolder"))
        {
            hasEntered = true;
            GameManager.inst.LoseLife();
            FindObjectOfType<AudioManager>().PlaySound("Incorrect");
        }
    }
}
