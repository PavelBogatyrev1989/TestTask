using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskItem : QuestItem {

	bool isActivated = true;
	bool isCompleted = false;
	float startAngle = 0f;
	float currentAngle = 0f;
	float additiveAngle = 0f;
	float completeness = 0f;

	private void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player")) {
			if (!isCompleted) {
				isActivated = true;

				startAngle = FindAngleToPlayer (other.gameObject);
				currentAngle = startAngle;
				additiveAngle = 0f;
				completeness = 0f;
			}
		}
	}

	private void OnTriggerStay (Collider other) {
		if (other.CompareTag ("Player")) {
			if (!isCompleted && isActivated) {
				float newAngle = FindAngleToPlayer (other.gameObject);

				float diff = newAngle - currentAngle;

				if (Mathf.Abs (diff) > 180) {
					diff += (-360f) * Mathf.Sign (diff);
				}

				additiveAngle += diff;

				currentAngle = newAngle;
				completeness = additiveAngle / 360f;

				if (Mathf.Abs (completeness) >= 1) {
					OpenItem();
				}
			}
		}
	}

	private void OnTriggerExit (Collider other) {
		if (other.CompareTag ("Player")) {
			isActivated = false;
			additiveAngle = 0f;
		}
	}


	private float FindAngleToPlayer (GameObject go) {
		return Mathf.Atan2 (Vector3.Dot (Vector3.up, Vector3.Cross (go.transform.position - transform.position, transform.position)), Vector3.Dot (go.transform.position - transform.position, transform.position)) * Mathf.Rad2Deg;
	}
}