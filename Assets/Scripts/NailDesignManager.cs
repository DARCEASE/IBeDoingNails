using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        finalDesignPanel.gameObject.SetActive(true);
    }
    public void ReturntoMain()
    {
        SceneManager.LoadScene("Title");
    }
}
