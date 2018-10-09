using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnim : StateMachineBehaviour {

	//OnStateMachineEnter is called when entering a statemachine via its Entry Node
	override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash){
	animator.SetInteger("AttackID", Random.Range(0,2));
	}

}
