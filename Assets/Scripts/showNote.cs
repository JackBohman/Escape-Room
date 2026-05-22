using UnityEngine;

public class showNote : MonoBehaviour
{
    public float maxDist = 3.0f;
    public GameObject noteUI; // Renamed for clarity
    public GameObject OvenNote;

    private bool isNoteActive = false;
    private bool isOvenNoteActive = false;

    void Update()
    {
        //Debug.DrawRay(transform.position, transform.forward * maxDist, Color.red);
        // 1. If the note is already open, pressing E should close it and stop
        if (isNoteActive && Input.GetKeyDown(KeyCode.E))
        {
            ToggleNote(false);
            return; // Exit Update so we don't accidentally re-trigger the raycast logic
        } else
        if (isOvenNoteActive && Input.GetKeyDown(KeyCode.E))
        {
            ToggleOvenNote(false);
            return;
        }

        // 2. Define the ray starting from the center of the camera
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // 3. Perform the Raycast
        if (Physics.Raycast(ray, out hit, maxDist))
        {
            if (hit.collider.CompareTag("Note"))
            {
                // 4. Detect the 'E' key press to OPEN
                if (Input.GetKeyDown(KeyCode.E) && isNoteActive == false)
                {
                    ToggleNote(true);
                }

            }
            if (hit.collider.CompareTag("OvenNote"))
            {
                // 4. Detect the 'E' key press to OPEN
                if (Input.GetKeyDown(KeyCode.E) && isOvenNoteActive == false)
                {
                    ToggleOvenNote(true);
                }
            }
        }
    }

    void ToggleNote(bool state)
    {
        isNoteActive = state;
        noteUI.SetActive(state);

        // Optional: Pause time or unlock cursor when reading
        // Time.timeScale = state ? 0f : 1f;
        // Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
        // Cursor.visible = state;
    }
    void ToggleOvenNote(bool state)
    {
        isOvenNoteActive = state;
        OvenNote.SetActive(state);
    }
}