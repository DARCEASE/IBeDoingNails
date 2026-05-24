using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitletoMain : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bloopSFX;
    public AudioClip mouseClicking;
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
}
