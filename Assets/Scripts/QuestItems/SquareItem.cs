using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareItem : QuestItem {

bool isCompleted = false;

void OnCollisionEnter(Collision collisionInfo)
{
	isCompleted = false;
}
	void OnCollisionStay (Collision collisionInfo) {
		if (!isCompleted) {
			PlayerController pc = collisionInfo.gameObject.GetComponent<PlayerController> ();
			if (pc != null) {
				if (pc.IsStay) {
					OpenItem ();
					isCompleted = true;
				}
			}
		}
	}



}