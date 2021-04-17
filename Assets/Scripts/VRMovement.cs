using UnityEngine;
using UnityEngine.SceneManagement;

public class VRMovement : MonoBehaviour
{
    public Transform vrCamera;
    private Vector3 direction;
    public float speed = 5f;
    public float jumpForce = 1.0f;
    private float gravity= -9.81f;
    public float toggleAngle = 10f;
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
        moveForward = true;

        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90f)
            moveForward = false;

        if (moveForward)
            cc.SimpleMove(forward * speed);

        if (vrCamera.eulerAngles.x <= 360 - toggleAngle && vrCamera.eulerAngles.x > 270f)
            direction.y = jumpForce * -1.0f * gravity;
        
        direction.y += gravity * Time.deltaTime;
        cc.Move(direction * Time.deltaTime);

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
