using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	[SerializeField]
	private GameObject[] itemsArray;

	[SerializeField]
	private GameObject questItemViewPrefab;
	[SerializeField]
	private float max_X = 0;
	[SerializeField]
	private float max_Z = 0;
	[SerializeField]
	private QuestItemsListView questItemsListView;


	[SerializeField]
	private GameObject player;

	private int _currentItem;

	void Start () {
		itemsArray = Shuffle (itemsArray);
		SetQuestItems ();
		RandomPosition(player);
		_currentItem = 0;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public bool TryOpenItem (int itemId) {

		if (_currentItem == itemId) {
			_currentItem++;
			CheckIsLastItem (_currentItem);
			return true;
		} else {
			CloseItems ();
			return false;
		}

	}

	private void CheckIsLastItem (int currentItem) {
		if (currentItem == itemsArray.Length) {
			Invoke ("RestartLvl", 2f);
		}
	}

	void RestartLvl () {
		SceneManager.LoadScene (0);
	}

	private void CloseItems () {
		for (int i = 0; i < itemsArray.Length; i++) {
			itemsArray[i].GetComponent<QuestItem> ().CloseItem ();
		}
		_currentItem = 0;
	}

	public static T[] Shuffle<T> (T[] arr) {
		for (int i = arr.Length - 1; i >= 1; i--) {
			int j = Random.Range (0, i + 1);
			T tmp = arr[j];
			arr[j] = arr[i];
			arr[i] = tmp;
		}

		return arr;
	}

	private Vector3 RandomPosition (GameObject go) {
		return new Vector3 (Random.Range (-max_X, max_X), go.transform.position.y, Random.Range (-max_Z, max_Z));
	}

	private void SetQuestItems () {

		for (int i = 0; i < itemsArray.Length; i++) {
			itemsArray[i].transform.position = RandomPosition (itemsArray[i]);

			QuestItem questItem = itemsArray[i].GetComponent<QuestItem> ();
			questItem.itemId = i;

			GameObject newUiQuestItem = Instantiate (questItemViewPrefab) as GameObject;
			newUiQuestItem.GetComponent<QuestItemView> ().SetImage (questItem.itemIcon);
			questItemsListView.AddItem(newUiQuestItem);
		}

	}
}