using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItemsListView : MonoBehaviour {
	private List<GameObject> _items;

	void Start () {
		if (_items == null) {
			_items = new List<GameObject> { };
		}
	}
	public void AddItem (GameObject obj) {
		_items.Add (obj);
		obj.transform.SetParent (transform, false);
	}
}