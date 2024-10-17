using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour{
    private List<string> stringList = new List<string>();

    public void AddString(string newString){
        stringList.Add(newString);
        Debug.Log("Agregado: " + newString);
    }
}
