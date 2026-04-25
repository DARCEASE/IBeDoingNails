using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
//purpose: to be used as a variable type, this is a container for other objects (polishes)
//usage: this is a variable type that im referencing, i dont need to put this on an object/works behind the scenes


public class NailShapeOptions 
{
     public string shapeName; // square,oval,almond using text not gameobjects
     public Sprite[] polishType; //individual polish objects, regardless of shape

   
}
