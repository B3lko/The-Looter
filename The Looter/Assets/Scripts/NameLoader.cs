using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameLoader : MonoBehaviour{
    private PeopleList peopleData;
    private List<string> selectedNames = new List<string>();
    public TextMeshPro[] bookTexts;

    void Start(){
        LoadNamesFromJson();
        AssignNamesToTombs();
        AssignNamesToBook();
    }

    void LoadNamesFromJson(){
        TextAsset jsonFile = Resources.Load<TextAsset>("Names");
        if (jsonFile != null){peopleData = JsonUtility.FromJson<PeopleList>(jsonFile.text);}
        else{Debug.LogError("No se pudo cargar el archivo names.json");}
    }

    void AssignNamesToTombs(){
        GameObject[] tombObjects = GameObject.FindGameObjectsWithTag("Tomb");
        List<string> allNames = new List<string>();
        foreach (var person in peopleData.people){
            allNames.Add(person.Name); // Guardar los nombres completos del JSON
        }

        // Barajar la lista de nombres para obtenerlos en un orden aleatorio
        ShuffleList(allNames);

        // Asignar nombres únicos y aleatorios a las tumbas
        for (int i = 0; i < tombObjects.Length; i++){
            if (i < allNames.Count){
                tombObjects[i].GetComponent<TombController>().SetName(allNames[i]);
                selectedNames.Add(allNames[i]);
            }
        }
    }

    void AssignNamesToBook(){
        // Barajar los nombres seleccionados para obtener 8 aleatorios para el book
        ShuffleList(selectedNames);
        // Asegurarse de que hay al menos 8 nombres seleccionados
        for (int i = 0; i < bookTexts.Length && i < selectedNames.Count; i++){
            // Asignar el nombre a los TextMeshPro del book
            bookTexts[i].text = selectedNames[i];
        }
    }

    // Método para barajar una lista (usando Fisher-Yates Shuffle)
    void ShuffleList(List<string> list){
        for (int i = list.Count - 1; i > 0; i--){
            int rnd = Random.Range(0, i + 1);
            string temp = list[i];
            list[i] = list[rnd];
            list[rnd] = temp;
        }
    }
}

[System.Serializable]
public class Person
{
    public string Name; // Aquí está el nombre completo (Nombre y Apellido)
}

[System.Serializable]
public class PeopleList
{
    public Person[] people;
}


