using System.Collections;
using UnityEngine;



public class PadlockDrawerMove : MonoBehaviour
{

    public Animator pull_01;
    public bool open;
    public Transform Player;
    public GameObject padlock;

    void Start()
    {
        open = false;
    }

    void OnMouseOver()
    {
        {
            Debug.Log(padlock.activeSelf);
            if (Player && (padlock.activeInHierarchy == false))
            {
                Debug.Log(padlock.activeInHierarchy + " = " + padlock.activeSelf);
                float dist = Vector3.Distance(Player.position, transform.position);
                if (dist < 10)
                {
                    if (open == false)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            StartCoroutine(opening());
                        }
                    }
                    else
                    {
                        if (open == true)
                        {
                            if (Input.GetMouseButtonDown(0))
                            {
                                StartCoroutine(closing());
                            }
                        }

                    }

                }
            }

        }

    }

    IEnumerator opening()
    {
        print("you are opening the door");
        pull_01.Play("openpull_01");
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing()
    {
        print("you are closing the door");
        pull_01.Play("closepush_01");
        open = false;
        yield return new WaitForSeconds(.5f);
    }


}
