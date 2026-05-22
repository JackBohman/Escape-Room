using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;

namespace SojaExiles

{
	public class opencloseDoor1 : MonoBehaviour
	{

		public Animator openandclose1;
		public bool open;
		public Transform Player;




		void Start()
		{
			
		}



        void OnMouseOver()
		{
			{
				if (Player)
				{
					Debug.Log("Detected");
					float dist = Vector3.Distance(Player.position, transform.position);
					if (dist < 15)
					{
						Debug.Log("Close");
						if (open == false)
						{
							Debug.Log("Opening");
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
			openandclose1.Play("Opening 1");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			openandclose1.Play("Closing 1");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}