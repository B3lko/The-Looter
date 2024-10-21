using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour{

    //Definir cuantos objetos a encontrar
    //Spawnearlos
    //Controlar el progreso a medida que se agarran
    //

    [SerializeField] int cantJewels;
    [SerializeField] GameObject JewelPrefab;


    private void SpawnJewels(){
        for(int i = 0; i < cantJewels; i++){
            GameObject aux = Instantiate(JewelPrefab, transform.position, transform.rotation);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
