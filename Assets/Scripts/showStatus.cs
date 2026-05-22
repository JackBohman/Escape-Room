using UnityEngine;

public class showStatus : MonoBehaviour // Renamed to PascalCase (Standard C#)
{
    public float maxDist = 3.0f;
    public GameObject doorUI; // Renamed for clarity
    public Camera playerCam;

    private bool hasKey;
    private bool hasOvenKey;
    private GameObject intman;

    private bool isTextActive = false;

    void Update() {
        interactionManager intman = playerCam.GetComponent<interactionManager>();

        hasKey = (intman.hasKey);
        //Debug.Log("Haskey: " + hasKey);
        hasOvenKey = (intman.hasOvenKey);
    
    //Debug.DrawRay(transform.position, transform.forward * maxDist, Color.red);
        // 1. If the note is already open, pressing E should close it and stop

        // 2. Define the ray starting from the center of the camera
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // 3. Perform the Raycast
        if (Physics.Raycast(ray, out hit, maxDist))
        {
            //Debug.Log("HasOvenKey: " + hasOvenKey);
            if (hit.collider.CompareTag("Door") && hasKey == false)
            {
                Debug.Log("Door is Locked");
                ToggleNote(true);
                return;
            } 
            if (hit.collider.CompareTag("Oven") && hasOvenKey == false)
            {
                ToggleNote(true);
                return;
            }
            else
            {
                ToggleNote(false);
                return;
            }
        }
    }

    void ToggleNote(bool state)
    {
        isTextActive = state;
        doorUI.SetActive(state);

        // Optional: Pause time or unlock cursor when reading
        // Time.timeScale = state ? 0f : 1f;
        // Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
        // Cursor.visible = state;
    }
}