using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour{
    [SerializeField] GameObject keyPosition;
    private List<GameObject> keyPositions = new List<GameObject>();

    void Start(){
        foreach (GameObject child in keyPosition.transform){
            keyPositions.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
