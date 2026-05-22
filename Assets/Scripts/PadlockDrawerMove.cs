using System.Collections;
using UnityEngine;

public class PadlockDrawerMove : MonoBehaviour
{
    public Animator pull_01;
    public bool open = false;
    public Transform player;

    [Header("Padlock Setup")]
    public GameObject padlock;          // The physical padlock GameObject on the drawer
    public PadlockUse padlockScript;    // Drag the GameObject with the PadlockUse script here

    public float maxInteractionDist = 3.0f;

    void OnMouseOver()
    {
        // 1. Safety check for player assignment
        if (player == null) return;

        // 2. Prevent click-through if the player is currently looking at the padlock UI/Camera
        if (padlockScript != null && padlockScript.inputLocked)
        {
            return;
        }

        // 3. Prevent opening if the physical padlock is still active/locked on the drawer
        if (padlock != null && padlock.activeInHierarchy)
        {
            return;
        }

        // 4. Distance and Input check
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist <= maxInteractionDist)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!open)
                    StartCoroutine(Opening());
                else
                    StartCoroutine(Closing());
            }
        }
    }

    IEnumerator Opening()
    {
        Debug.Log("Opening the drawer...");
        pull_01.Play("openpull_01");
        open = true;
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator Closing()
    {
        Debug.Log("Closing the drawer...");
        pull_01.Play("closepush_01");
        open = false;
        yield return new WaitForSeconds(0.5f);
    }
}