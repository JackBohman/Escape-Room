using UnityEngine;

public class interactionManager : MonoBehaviour
{
    public bool hasOvenKey = false;
    public bool hasKey = false;
    public float maxDist = 3.0f;
    void Update()
    {
        // 1. Define the ray starting from the center of the camera
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // 2. Perform the Raycast
        if (Physics.Raycast(ray, out hit, maxDist))
        {
            // 3. Check if the object hit has the "Key" tag
            if (hit.collider.CompareTag("Key"))
            {
                // Optional: Show UI text here like "Press E to pick up"

                // 4. Detect the 'E' key press
                if (Input.GetKeyDown(KeyCode.E))
                {
                    InteractWithKey(hit.collider.gameObject);
                }
            }
            if (hit.collider.CompareTag("OvenKey"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("HasKey");
                    InteractWithOvenKey(hit.collider.gameObject);
                }
            }
        }
    }

    void InteractWithKey(GameObject key)
    {
        Debug.Log("Key picked up!");
        Destroy(key); // Or add to inventory logic
        hasKey = true;
        
    }
    void InteractWithOvenKey(GameObject key)
    {
        Debug.Log("Key picked up!");
        Destroy(key); // Or add to inventory logic
        hasOvenKey = true;

    }
}

