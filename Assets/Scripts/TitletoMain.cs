using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitletoMain : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bloopSFX;
    public AudioClip mouseClicking;
    public GameObject creditsPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            audioSource.PlayOneShot(mouseClicking);
        }
    }
    public void PlayGame()
    {
        audioSource.PlayOneShot(bloopSFX);
        SceneManager.LoadScene("MainGame");
    }
    public void Credits()
    {
        audioSource.PlayOneShot(bloopSFX);
        creditsPanel.SetActive(true);
    }
    public void ExitCredits()
    {
        audioSource.PlayOneShot(bloopSFX);
        creditsPanel.SetActive(false);
    }


}
