using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Purpose: to manage when the player chooses a specific nail style and polish 
//Usage: Put this on a gamemanager game object 
public class NailDesignManager : MonoBehaviour
{
    public GameObject[] NailShape;
    public GameObject[] OvalPolish;
    public GameObject[] SquarePolish;
    public GameObject[] AlmondPolish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChooseNailShape(int i)
    {
        NailShape[i].gameObject.SetActive(true);
    }
}
