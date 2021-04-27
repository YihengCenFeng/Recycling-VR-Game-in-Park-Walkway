using UnityEngine;
using UnityEngine.Events;

public class GazeInteraction : MonoBehaviour
{
    public float gazeTime = 2f;
    public UnityEvent GVRClick;
    private bool gazedAt;
    public float gvrTimer;

    // Update is called once per frame
    void Update()
    {
        if (gazedAt)
        {
            gvrTimer += Time.deltaTime;

        }

        if (gvrTimer > gazeTime)
        {
            GVRClick.Invoke();
            gvrTimer = 0;
        }
    }

    public void Enter()
    {
        gazedAt = true;
    }

    public void Exit()
    {
        gazedAt = false;
        gvrTimer = 0;
    }

}
