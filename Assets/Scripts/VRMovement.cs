using UnityEngine;
using UnityEngine.SceneManagement;

public class VRMovement : MonoBehaviour
{
    public Transform vrCamera;
    public float speed = 8f;
    public float toggleAngle = 20f;
    bool moveForward;
    bool alive = true;

    private CharacterController cc;

    void Start()
    {
        // get CharaterController component
        cc = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forward = vrCamera.TransformDirection(Vector3.forward);

        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90f)
            moveForward = false;
        else
            moveForward = true;

        if(moveForward)
            cc.SimpleMove(forward * speed);
    }

    private void Update()
    {
        if (transform.position.y < -5)
            Die();
    }

    public void Die()
    {
        alive = false;

        // Restart the game after 2 seconds
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
