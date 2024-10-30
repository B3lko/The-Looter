using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorIndexer : MonoBehaviour{

    void Start(){
        AssignRandomNames();
    }

    private void AssignRandomNames(){
        // Obtén todas las puertas que son hijos directos de este objeto
        List<GameObject> doors = new List<GameObject>();
        foreach (Transform child in transform){
            doors.Add(child.gameObject);
        }

        // Crea una lista con los números del 1 al 4
        List<int> numbers = new List<int> { 1, 2, 3, 4 };
        
        // Mezcla los números aleatoriamente
        Shuffle(numbers);
        
        // Asigna a cada puerta un nombre "Key" + número único de la lista mezclada
        for (int i = 0; i < doors.Count && i < numbers.Count; i++){
            string doorName = "Key" + numbers[i];
            doors[i].GetComponent<DoorLockedKey>().SetName(doorName); // Asegúrate de que cada puerta tenga el método SetName()
            doors[i].name = doorName; // Cambia el nombre en el Inspector para referencia
            Debug.Log("nueva puerta:" + doorName);
        }
    }

    // Método para mezclar la lista de números
    private void Shuffle(List<int> list){
        for (int i = 0; i < list.Count; i++){
            int randomIndex = Random.Range(0, list.Count);
            int temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
