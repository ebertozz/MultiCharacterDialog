using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacTalk : MonoBehaviour
{


    DialogTrigger dialogTrigger;
    public GameObject dialogPanel;
    

    // Start is called before the first frame update
    void Start()
    {
        dialogTrigger = GetComponent<DialogTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startTalking()
    {
        
        dialogPanel.SetActive(true);
        dialogTrigger.TriggerDialog();

    }
}
