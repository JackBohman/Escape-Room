using UnityEngine;

public class PadlockUse : MonoBehaviour

{
    public float maxDist = 3.0f;
    public GameObject padlock;
    public GameObject player;
    public GameObject playerCam;
    public GameObject padlockCamera;

    public bool inputLocked = false;
    private bool isPadlockActive = false;

    void Update()
    {
        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * maxDist, Color.purple);
        // 1. If the padlock view is already open, pressing E should close it and stop
        if (isPadlockActive && Input.GetKeyDown(KeyCode.E))
        {
            TogglePadlock(false);
            return; // Exit Update so we don't accidentally re-trigger the raycast logic
        }
        // 2. Define the ray starting from the center of the camera
        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        RaycastHit hit;

        // 3. Perform the Raycast
        if (Physics.Raycast(ray, out hit, maxDist))
        {
            //Debug.Log("PADTOUCH");
            if (hit.collider.CompareTag("Padlock"))
            {
                TogglePadlock(true);
                return;
            }
        }
        if (isPadlockActive)
        {
            inputLocked = true;
        }
    }
    void TogglePadlock(bool state)
    {
        isPadlockActive = state;
        Debug.Log("Padlock toggled: " + state);
        padlockCamera.SetActive(state);

    }

}