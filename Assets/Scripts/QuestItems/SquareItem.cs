using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareItem : QuestItem {

	void OnCollisionStay (Collision collisionInfo) {
		if (!isOpened) {
			PlayerController pc = collisionInfo.gameObject.GetComponent<PlayerController> ();
			if (pc != null) {
				if (pc.IsStay) {
					OpenItem ();
					isOpened = true;
				}
			}
		}
	}
}