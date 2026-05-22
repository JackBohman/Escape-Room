using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class ExitDoor : MonoBehaviour
	{

		public Animator openandclose;
		public bool open;
		public Transform Player;
		public Camera playerCam;
		
        private bool hasKey;
        private GameObject intman;

        void Start()
		{
			open = false;
		}

        private void Update()
        {
            interactionManager intman = playerCam.GetComponent<interactionManager>();

            hasKey = (intman.hasKey);
        }

        void OnMouseOver()
		{
			Debug.Log(hasKey);
			{
				if (Player && hasKey)
				{
					float dist = Vector3.Distance(Player.position, transform.position);
					if (dist < 15)
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
			openandclose.Play("Opening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}