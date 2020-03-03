using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	public Text speakerName;
	public Text convoContent;
	public GameObject dialogPanel;

	private Queue<string> sentences;
	private Queue<AudioClip> myAudioClips;


	// Use this for initialization
	void Start() {
		sentences = new Queue<string>();
		myAudioClips = new Queue<AudioClip>();
	}

	public void StartDialog(Dialog dialog) {  //method called at start of a conversation
		Debug.Log("talk to " + dialog.name); // check to make sure this works
		speakerName.text = dialog.name;

		// first need to clear out any previous conversation that might linger in sentences array
		sentences.Clear();

		// then loop through the array and line up each sentence currently in it to prepare 
		foreach (string sentence in dialog.sentences) {

			sentences.Enqueue(sentence); // put each in the queue

		}

        foreach(AudioClip myClip in dialog.audioClips)
        {
			myAudioClips.Enqueue(myClip);
        }

		DisplayNextSentence();
		
	}

	public void DisplayNextSentence() {

		// first check to see if we are at the end of convo and if so call end method

		if (sentences.Count == 0) { // if array is empty

			EndConvo(); // call end method
			return;     // leave the function
		}
		string sentence = sentences.Dequeue();  // otherwise pull sentence out of the queue
		convoContent.text = sentence;
		//Debug.Log ("line is" + sentence); // display it

		PlayDialogAudio();

	}

	public void PlayDialogAudio()
    {
		AudioClip myClip = myAudioClips.Dequeue();
		AudioSource myAudio = GetComponent<AudioSource>();
		myAudio.clip = myClip;
		myAudio.Play();

	}

	public void EndConvo (){
		Debug.Log ("reached end of convo");
		dialogPanel.SetActive (false);
	
	}
}
