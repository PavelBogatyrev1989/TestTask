using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Animator))]
public class PlayerController : MonoBehaviour {

	Animator animator;
	[SerializeField]
	private float _mouseSpeed;
	private bool _isStay;
	public bool IsStay { get { return _isStay; } }
	void Awake () {
		animator = GetComponent<Animator> ();
	}

	

	void Update () {

		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");

		transform.Rotate (0, Input.GetAxis ("Mouse X") * _mouseSpeed, 0);

		animator.SetFloat ("HorDir", x);
		animator.SetFloat ("VertDir", z);
		animator.SetBool ("LMB", Input.GetMouseButton (0));
		animator.SetBool ("RMB", Input.GetMouseButton (1));

		if (x == 0f && z == 0f) {
			_isStay=true;
			animator.SetBool ("Movement", false);
		} else {
			_isStay=false;
			animator.SetBool ("Movement", true);
		}

	}

	private void StartAttack () {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, 1) && !hit.collider.isTrigger ) {
			if(hit.collider.CompareTag ("Vase")){
				hit.collider.GetComponent<QuestItem>().OpenItem ();
			}
		}
	}

}