using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aragorn {
	public class ScrollingBackground : MonoBehaviour {
		public Camera CAMERA;
		/// <summary>
		/// Scrolling speed
		/// </summary>
		public Vector2 SPEED = new Vector2(0, 10);

		/// <summary>
		/// Moving direction
		/// </summary>
		private Vector2 direction = new Vector2(0, -1);

		// 3 - Get all the children
		void Start()
		{
		}

		private int SortByPositionY(SpriteRenderer renderer1, SpriteRenderer renderer2) {
			return renderer1.transform.position.y.CompareTo (renderer2.transform.position.y);
		}

		void Update()
		{
			// Movement
			Vector3 movement = new Vector3(
				SPEED.x * direction.x,
				SPEED.y * direction.y,
				0);

			movement *= Time.deltaTime;
			//transform.Translate(movement);

			for (int indexChildren = 0; indexChildren < transform.childCount; indexChildren++) {
				Transform child = transform.GetChild(indexChildren);

				SpriteRenderer renderer = child.GetComponent<SpriteRenderer> ();

				if (!renderer.isVisible) {
					if ((child.position.y + renderer.bounds.min.y) < CAMERA.transform.position.y) {
						if (indexChildren + 1 >= transform.childCount) {
							
						}
						else {
						}
					}
				}
			}
			/*
		
			// Get the first object.
			// The list is ordered from left (x position) to right.
			SpriteRenderer firstChild = backgroundPart.FirstOrDefault();

			if (firstChild != null) {
				// Check if the child is already (partly) before the camera.
				// We test the position first because the IsVisibleFrom
				// method is a bit heavier to execute.
				if (firstChild.transform.position.x < Camera.main.transform.position.x) {
					// If the child is already on the left of the camera,
					// we test if it's completely outside and needs to be
					// recycled.
					if (firstChild.IsVisibleFrom(Camera.main) == false) {
						// Get the last child position.
						SpriteRenderer lastChild = backgroundPart.LastOrDefault();

						Vector3 lastPosition = lastChild.transform.position;
						Vector3 lastSize = (lastChild.bounds.max - lastChild.bounds.min);

						// Set the position of the recyled one to be AFTER
						// the last child.
						// Note: Only work for horizontal scrolling currently.
						firstChild.transform.position = new Vector3(lastPosition.x + lastSize.x, firstChild.transform.position.y, firstChild.transform.position.z);

						// Set the recycled child to the last position
						// of the backgroundPart list.
						backgroundPart.Remove(firstChild);
						backgroundPart.Add(firstChild);
					}
				}
			}
			*/
		}
	}
}
