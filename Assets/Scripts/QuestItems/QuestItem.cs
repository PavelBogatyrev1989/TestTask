using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestItem : MonoBehaviour {

	public Sprite itemIcon;
	public GameObject fireworksOfHappinessPrefab;
	public GameObject cloudOfHopelessnessPrefab;
	public int itemId;

	public bool isOpened = false;

	private GameObject _particle;

	public void OpenItem () {
		if (!isOpened) {
			bool result = FindObjectOfType<GameController> ().TryOpenItem (itemId);
			if (result) {
				_particle = Instantiate (fireworksOfHappinessPrefab, new Vector3 (transform.position.x, 0.2f, transform.position.z), Quaternion.Euler(-90f, 0f, 0f));
				_particle.transform.SetParent(transform);
				isOpened = true;
			} else {
				_particle = Instantiate (cloudOfHopelessnessPrefab, new Vector3 (transform.position.x, 0.2f, transform.position.z), Quaternion.Euler(-90f, 0f, 0f));
				_particle.transform.SetParent(transform);
			}
		}

	}

	public void CloseItem () {
		isOpened = false;
		if (_particle != null) {
			Destroy (_particle);
		}
	}

	

}