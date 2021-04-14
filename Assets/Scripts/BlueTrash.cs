using UnityEngine;

public class BlueTrash : MonoBehaviour
{
    public float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        // check that the object we collided with is a trash bin
        if (other.gameObject.name == "Player" || other.transform.parent.name != "TrashBinHolder")
            return;

        // add to the player's score
        if (other.transform.name == "TrashBinBlue")
        {
            GameManager.inst.IncrementScore();
            FindObjectOfType<AudioManager>().PlaySound("Correct");
        } else {
            GameManager.inst.DecrementScore();
            FindObjectOfType<AudioManager>().PlaySound("Incorrect");
        }

        // destroy this coin object
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
