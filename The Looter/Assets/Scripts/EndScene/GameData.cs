using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour{
    // Instancia Singleton
    public static GameData Instance { get; private set; }

    // Variables para almacenar datos de la partida
    public float playTime;
    public int collectedItems;
    public int collectedKeys;
    public int collectedJewels;
    public bool collectedGreat = false;

    void Awake(){
        // Asegurarnos de que solo haya una instancia de GameData
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject); // No destruir al cambiar de escena
        }
        else{
            Destroy(gameObject);
        }
    }


    // Método para resetear los datos al inicio de una partida nueva
    public void ResetData(){
        playTime = 0f;
        collectedItems = 0;
    }

    // Método para actualizar el tiempo de juego
    public void UpdatePlayTime(float deltaTime){
        playTime += deltaTime;
    }

    // Método para recolectar un objeto
    public void CollectItem(){
        collectedItems++;
    }
    public void CollectKey(){
        collectedKeys++;
    }
    public void CollectJewel(){
        collectedJewels++;
    }

    public void CollectGreat(){
        collectedGreat = true;
    }
}
