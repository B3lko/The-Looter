using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour{
    [SerializeField] GameObject keyPosition;
    [SerializeField] GameObject keyPrefab;
    private List<GameObject> keyPositions = new List<GameObject>();
    private int cantKeys = 4;

    void Start(){ 

        foreach (Transform child in keyPosition.transform)
    {
        keyPositions.Add(child.gameObject); // Agregamos el GameObject de cada hijo a la lista
    }

    if (keyPositions.Count >= cantKeys)
    {
        // Seleccionar posiciones aleatorias
        List<int> selectedIndices = new List<int>();
        while (selectedIndices.Count < cantKeys)
        {
            int randomIndex = Random.Range(0, keyPositions.Count);
            if (!selectedIndices.Contains(randomIndex))
            {
                selectedIndices.Add(randomIndex);
            }
        }
        // Instanciar las llaves en las posiciones seleccionadas
        foreach (int index in selectedIndices)
        {
            Instantiate(keyPrefab, keyPositions[index].transform.position, Quaternion.identity);
        }
    }
    else
    {
        Debug.LogWarning("No hay suficientes posiciones para las llaves.");
    }

    }

}
