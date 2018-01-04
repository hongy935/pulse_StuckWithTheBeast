using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshAnimator : MonoBehaviour {
    [SerializeField]
    private int m_FrameRate;
    [SerializeField]
    private MeshRenderer m_ScreenMesh;
    [SerializeField]
    private Texture[] m_AnimTextures;

    private float  m_FrameRateWait;
    public int m_CurrentTextureIndex;
    public bool m_Playing;

    [SerializeField]
    ChildAnimation[] ChildAnimation;
    // Use this for initialization
    private void Awake() {
        m_FrameRateWait = 1f / m_FrameRate;
      //  Debug.Log(m_FrameRateWait);
    }

    void OnEnable() {
      //  Debug.Log("subscribe"+gameObject.transform.parent.gameObject.name);
        DelegateEventManager.OnOut -= HandleOut;
        DelegateEventManager.OnOver += HandleOver;
       
    }

    void OnDisable() {
      //  Debug.Log("desubscribe");
        m_CurrentTextureIndex = 0;
        DelegateEventManager.OnOut += HandleOut;
        DelegateEventManager.OnOver -= HandleOver;
     
    }

	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void HandleOver()
    {
      
        // When the user looks at the VRInteractiveItem the textures should start playing.
        m_Playing = true;
        PlaySound();
        StartCoroutine(PlayTextures());
    }


    private void HandleOut()
    {
        //  Debug.Log("Stop");
        // When the user looks away from the VRInteractiveItem the textures should no longer be playing.
        SoundManager.instance.StopSound();
        m_Playing = false;

    }

    private void PlaySound() {
        float volum = SoundManager.instance.returnVolumClip(gameObject.transform.parent.gameObject);
        AudioClip clip = SoundManager.instance.returnAudioClip(gameObject.transform.parent.gameObject);
        SoundManager.instance.PlaySound(clip, volum);
    }

    private IEnumerator PlayTextures()
    {
       
        while (m_Playing)
        {

           // Debug.Log("playing");
            // Set the texture of the mesh renderer to the texture indicated by the index of the textures array.
            m_ScreenMesh.material.mainTexture = m_AnimTextures[m_CurrentTextureIndex];
            
            for (int i = 0; i < ChildAnimation.Length; i++)
            {
                if (ChildAnimation[i].TriggerIndex == m_CurrentTextureIndex) {
                    ChildAnimation[i].PalyAnimation();
                }
            }
            
            // Then increment the texture index (looping once it reaches the length of the textures array.
            if (m_CurrentTextureIndex <= m_AnimTextures.Length - 2)
            {
                m_CurrentTextureIndex++;
            }
            else {

                break; }

            // Wait for the next frame.
              yield return new WaitForSeconds( m_FrameRateWait);
        }
    }
   }
