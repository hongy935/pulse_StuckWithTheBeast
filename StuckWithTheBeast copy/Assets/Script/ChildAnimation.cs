using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildAnimation : MonoBehaviour
{
    [SerializeField]
    private int child_FrameRate;
    [SerializeField]
    private MeshRenderer m_ScreenMesh;
    [SerializeField]
    private Texture[] m_AnimTextures;

    private float m_FrameRateWait;
    public int m_CurrentTextureIndex;

    [SerializeField]
    public int TriggerIndex;

    private bool m_Playing;
    private void Awake()
    {
        m_FrameRateWait =1f / child_FrameRate;
        Debug.Log(m_FrameRateWait);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void PalyAnimation() {
        m_Playing = true;
        this.GetComponent<MeshRenderer>().enabled = true;
        StartCoroutine(PlayChildTextures());      
    }

    private void StopPlayAnimation() {
        m_CurrentTextureIndex = 0;
        m_Playing = false;
        this.GetComponent<MeshRenderer>().enabled = false;
    }

    void OnDisable() {
  
        StopPlayAnimation();
    }

    private IEnumerator PlayChildTextures()
    {
        while (m_Playing)
        {
             //Debug.Log("playing");
            // Set the texture of the mesh renderer to the texture indicated by the index of the textures array.
            m_ScreenMesh.material.mainTexture = m_AnimTextures[m_CurrentTextureIndex];

            //Then increment the texture index (looping once it reaches the length of the textures array.

            if (m_CurrentTextureIndex <= m_AnimTextures.Length - 2)
            {
                m_CurrentTextureIndex++;
            }
       

            //m_CurrentTextureIndex = (m_CurrentTextureIndex + 1) % m_AnimTextures.Length;

            // Wait for the next frame.
            yield return new WaitForSeconds( m_FrameRateWait);
        }
    }
}
