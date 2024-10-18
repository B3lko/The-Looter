using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour{
    private List<string> stringList = new List<string>();
    [SerializeField] GameObject Door1;
    [SerializeField] GameObject Door2;

    public void AddString(string newString){
        stringList.Add(newString);
        Debug.Log("Agregado: " + newString);
        if(stringList.Count == 3){
            Door1.GetComponent<DoorController>().SetState(2);
            Door2.GetComponent<DoorController>().SetState(2);
        }
    }
}
