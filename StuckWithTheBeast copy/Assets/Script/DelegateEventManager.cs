using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateEventManager : MonoBehaviour {
    public delegate void Looking();
    public static event Looking OnOver;
    public static event Looking OnOut;

    public delegate void PlayChildAnimation();
    public static event PlayChildAnimation ChildAnimPlay;
    public static DelegateEventManager instance;
    // Use this for initialization
    void Awake() {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Over() {
        if(OnOver != null){
            OnOver();
        }
    }

    public void Out() {
        if (OnOut != null) {
            OnOut();
        }
    }

    public void ChildPlay() {
        if (ChildAnimPlay != null) {
            ChildAnimPlay();
        }
    }
}
