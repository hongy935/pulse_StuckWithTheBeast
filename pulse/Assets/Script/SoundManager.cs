using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;
    public List<ExtendedSound> BackgourndMusic = new List<ExtendedSound>();
    public AudioSource sources;

    public AudioClip returnAudioclips;
    public float ReturnVolume;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
        // Use this for initialization
        void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public void PlaySound(AudioClip _impact,float _volum)
    {
        Debug.Log(_impact.name);
        sources.clip = _impact;
        sources.PlayOneShot(_impact, _volum);
    //   Debug.Log("PlayingSound");
    }
   public void StopSound() {
        sources.Stop();
    }


    public AudioClip returnAudioClip(GameObject _target)
    {
        foreach (ExtendedSound item in BackgourndMusic)
        {
            if (item.target == _target) {
                returnAudioclips = item.clip;
            }      
        }
        return returnAudioclips;
    }

    public float returnVolumClip(GameObject _target)
    {
        foreach (ExtendedSound item in BackgourndMusic)
        {
            if (item.target == _target)
            {
                ReturnVolume = item.volum;
            }
        }
        return ReturnVolume;
    }
}

[System.Serializable]
public class ExtendedSound
{
    public string name;
    public float volum=1;
    public float pitch = 1;
    public AudioClip clip;
    public GameObject target;

 
}
