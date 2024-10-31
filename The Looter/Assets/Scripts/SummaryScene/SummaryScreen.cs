using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SummaryScreen : MonoBehaviour{
    [SerializeField] TextMeshProUGUI playTimeText;
    [SerializeField] TextMeshProUGUI collectedKeysText;
    [SerializeField] TextMeshProUGUI lootedTombsText;
    [SerializeField] TextMeshProUGUI GreatText;

    void Start(){
        PlayTime();
        collectedKeysText.text = "collected keys: " + GameData.Instance.collectedKeys + " / 4";
        lootedTombsText.text = "looted tombs: " + GameData.Instance.collectedJewels + " / 8";
        if(GameData.Instance.collectedGreat){
            GreatText.text = "great stolen gem: yes";
        }
        else{
            GreatText.text = "great stolen gem: no";
        }
       // collectedItemsText.text = "Objetos recolectados: " + GameData.Instance.collectedItems;
    }

    private void PlayTime(){
        // Convertir el tiempo total en horas, minutos y segundos
        float playTime = GameData.Instance.playTime;
        int hours = (int)(playTime / 3600);
        int minutes = (int)((playTime % 3600) / 60);
        int seconds = (int)(playTime % 60);
        // Actualizar los textos con los datos recopilados
        if (hours > 0){
            playTimeText.text = "game time: " + string.Format("{0:D2}hs {1:D2}m {2:D2}s", hours, minutes, seconds);
        }
        else{
            playTimeText.text = "game time: " + string.Format("{0:D2}m {1:D2}s", minutes, seconds);
        }
    }
}
