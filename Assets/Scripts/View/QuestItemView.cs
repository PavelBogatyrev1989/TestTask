using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestItemView : MonoBehaviour {

	public void SetImage (Sprite im) {
		GetComponent<Image> ().sprite = im;
	}

	
}