using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRayCast : MonoBehaviour {
    bool LookingEnter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        camRayCast();

    }


    void camRayCast() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            if (!LookingEnter)
            {
                LookingEnter = true;
                OnLookingEnter();
            }
            OnLooking();
        }
        else {
            if (LookingEnter) {
                LookingEnter = false;
                OnLookingExit();
            }
          
        }
    }

    void OnLookingEnter() {
        DelegateEventManager.instance.Over();
        Debug.Log("Looking Enter");
    }

    void OnLooking() {
        Debug.Log("OnLooking");
      
    }

    void OnLookingExit() {
        Debug.Log("Looking Exit");
        DelegateEventManager.instance.Out();
    }
}
