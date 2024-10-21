using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombController : MonoBehaviour{
    private string name;

    public void SetName(string newName){
        name = newName;
    } 
    public string GetName(){
        return name;
    } 


}
