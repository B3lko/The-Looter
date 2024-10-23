using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour{

    //Definir cuantos objetos a encontrar
    //Spawnearlos
    //Controlar el progreso a medida que se agarran


    //
    [SerializeField] GameObject Door1;
    [SerializeField] GameObject Door2;
    [SerializeField] int cantJewels;
    [SerializeField] GameObject JewelPrefab;
    public GameObject book;
    private int currentJewels = 0;
    private bool winner = false;

    public void AddJewel(){
        currentJewels += 1;
        if(currentJewels == gameObject.GetComponent<NameLoader>().GetBooks()){
            winner = true;
            Door1.GetComponent<DoorController>().SetState(2);
            Door2.GetComponent<DoorController>().SetState(2);
        }
    }

    public bool GetWinner(){
        return winner;
    }


    void Start(){
                // Obtener los componentes TextMeshPro en el objeto "book"
        TextMeshPro[] bookTexts = book.GetComponentsInChildren<TextMeshPro>();
        // Iterar sobre cada texto en el libro
        foreach (TextMeshPro bookText in bookTexts){
            //Debug.Log(bookText.text);
            string nameToMatch = bookText.text; // Obtener el nombre del texto
            // Buscar la tumba que tiene el mismo nombre
            GameObject matchingTomb = FindMatchingTomb(nameToMatch);
            // Si encontramos la tumba correspondiente, instanciar el prefab
            if (matchingTomb != null){
                Debug.Log("masdasdsa");
                ///Instantiate(JewelPrefab, matchingTomb.transform.Find("Coffin1").transform.position, Quaternion.identity, matchingTomb.transform);
                //Instantiate(JewelPrefab, matchingTomb.transform.GetChild(0).transform.position, Quaternion.identity, matchingTomb.transform);
                Instantiate(JewelPrefab, matchingTomb.transform.parent.transform.GetChild(0).transform.position, Quaternion.identity, matchingTomb.transform.parent);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     // Método para encontrar la tumba que tiene el mismo nombre
    private GameObject FindMatchingTomb(string nameToMatch)
    {
        // Obtener todas las tumbas en la escena (asumiendo que tienen un tag específico)
        GameObject[] allTombs = GameObject.FindGameObjectsWithTag("Tomb"); // Asegúrate de que las tumbas tengan el tag "Tomb"

        // Iterar sobre las tumbas para encontrar la que tiene el nombre correspondiente
        foreach (GameObject tomb in allTombs)
        {
            var nameScript = tomb.GetComponent<TombController>(); // Obtener el script con el nombre
            if (nameScript != null && nameScript.GetName() == nameToMatch)
            {
                return tomb; // Retornar la tumba que coincide
            }
        }

        return null; // No se encontró ninguna tumba que coincida
    }


    private void SpawnJewels(){

        for(int i = 0; i < cantJewels; i++){
            GameObject aux = Instantiate(JewelPrefab, transform.position, transform.rotation);

        }
    }
}
