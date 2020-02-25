using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {

	public Dialog dialog;  // attaches the Dialog variable to this script

	public void TriggerDialog(){
	
		FindObjectOfType<DialogManager> ().StartDialog (dialog);
	
	}
}
