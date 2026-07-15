using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

//Purpose: to manage when the player chooses a specific nail style and polish 
//Usage: Put this on a gamemanager game object 
public class NailDesignManager : MonoBehaviour
{
    public int currentShape; // they are ints bc they refer to the index of each array which is just numbers 
    public int currentPolish; // most recently chosen options
    public Image nailDisplay; //this is a display board, what are we showing the player? 
    public NailShapeOptions[] nailShapes; //referencing my custom class that holds data i ask them to hold 
    // Start is called before the first frame update
    public GameObject finalDesignPanel;
    public GameObject L_handPanel;
    public Transform finalDPanel; //da bones

    public GameObject R_handPanel;

    //sound 
    public AudioSource audioSource;
    public AudioClip mouseClickSFX;
    public AudioClip sparkleSFX;
    public AudioClip bloopSFX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) //everytime you click with the mouse this sound should play
        {
            audioSource.PlayOneShot(mouseClickSFX);
        }
    }
    public void ChooseNailShape(int newNailShape) // search for the current shape and polish selected - click on nail shape 
    {// when i choose a nail shape, i can click through them as many times as i want and it will replace the shape i previously chose with the new one 
       
       currentShape = newNailShape; // current shape will be determined by our index 
       nailDisplay.sprite = nailShapes[currentShape].polishType[currentPolish]; //reference each individual nail shape within the index and replace the sprite with that
       
        
    }
    public void ChooseNailPolish(int newNailPolish) // when you click on a nail polish
    {
       
       currentPolish = newNailPolish; // current shape will be determined by our index 
        nailDisplay.sprite = nailShapes[currentShape].polishType[currentPolish];
        
    }
    public void DesignReady()
    {   
        audioSource.PlayOneShot(sparkleSFX);
        finalDesignPanel.gameObject.SetActive(true);
        R_handPanel = Instantiate(L_handPanel, transform.localPosition, Quaternion.identity);// instatiate new hand 
       
        L_handPanel.transform.SetParent(finalDPanel); 
        R_handPanel.transform.SetParent(finalDPanel); 
        //grab the position of the handpanel and center it in the final design panel 
        L_handPanel.GetComponent<RectTransform>().localPosition = new Vector3(-328.61f, -50f, 0f); //#s grabbed from placing it and copying info 
        L_handPanel.GetComponent<RectTransform>().rotation = Quaternion.Euler(0f, 0f, 6.797f);
       
        R_handPanel.GetComponent<RectTransform>().localPosition = new Vector3(357f, 23f, 1f);
        R_handPanel.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 0f);
        R_handPanel.GetComponent<RectTransform>().rotation = Quaternion.Euler(0f, 180f, -7.763f); //euler is specific to UI elements 
        
    }
    public void ReturntoMain()
    {
        audioSource.PlayOneShot(bloopSFX);
        SceneManager.LoadScene("Title");
    }
}
