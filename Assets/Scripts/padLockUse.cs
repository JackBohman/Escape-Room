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

        // 1. If the padlock view is already open, pressing E closes it
        if (isPadlockActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TogglePadlock(false);
            }
            return; // Exit early so we don't raycast while looking at the UI/padlock close-up
        }

        // 2. Define and perform the Raycast (only happens if padlock is NOT active)
        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDist))
        {
            if (hit.collider.CompareTag("Padlock"))
            {
                // 3. Require the player to press E to actually open it
                if (Input.GetKeyDown(KeyCode.E))
                {
                    TogglePadlock(true);
                }
            }
        }
    }

    void TogglePadlock(bool state)
    {
        isPadlockActive = state;
        inputLocked = state; // Keeps your input lock synced perfectly with the padlock state

        Debug.Log("Padlock toggled: " + state);
        padlockCamera.SetActive(state);

        // Optional: If you want to disable the main camera or player movement when true, do it here
    }
}