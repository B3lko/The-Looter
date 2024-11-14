using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class SummaryScreen : MonoBehaviour{
    [SerializeField] TextMeshProUGUI endingText;
    [SerializeField] TextMeshProUGUI playTimeText;
    [SerializeField] TextMeshProUGUI collectedKeysText;
    [SerializeField] TextMeshProUGUI collectedKeysText2;
    [SerializeField] TextMeshProUGUI lootedTombsText;
    [SerializeField] TextMeshProUGUI GreatText;
    [SerializeField] Image black2;
    [SerializeField] GameObject nextButton;

    void Start(){
        black2.DOFade(0, 2).OnComplete(() => {
            black2.gameObject.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        });
        PlayTime();
        if(GameData.Instance.hasKeys){
            collectedKeysText.text = GameData.Instance.collectedKeys + " / 4";
        }
        else{
            collectedKeysText.gameObject.SetActive(false);
            collectedKeysText2.gameObject.SetActive(false);
        }
        
        if(GameData.Instance.ending == "05"){
            nextButton.SetActive(false);
            lootedTombsText.text = GameData.Instance.collectedJewels + " / 5";
        }
        else{
            lootedTombsText.text = GameData.Instance.collectedJewels + " / 4";
        }
        if(GameData.Instance.collectedGreat){
            GreatText.text = "yes";
        }
        else{
            GreatText.text = "no";
        }
        endingText.text = GameData.Instance.ending;

        if(endingText.text == "Money"){
            lootedTombsText.text = (GameData.Instance.collectedJewels + 1) + " / 5";
        }
       // collectedItemsText.text = "Objetos recolectados: " + GameData.Instance.collectedItems;
    }

    public void GoMenu(){
        black2.gameObject.SetActive(true);
        black2.DOFade(1, 2).OnComplete(() => {
            SceneManager.LoadScene("MainMenu");
        });

    }

    public void GoNext(){
        black2.gameObject.SetActive(true);
        black2.DOFade(1, 2).OnComplete(() => {
            string nName = "GameScene_G0" + (int.Parse(GameData.Instance.ending) + 1);
            SceneManager.LoadScene(nName);
        });

    }

    private void PlayTime(){
        // Convertir el tiempo total en horas, minutos y segundos
        float playTime = GameData.Instance.playTime;
        int hours = (int)(playTime / 3600);
        int minutes = (int)((playTime % 3600) / 60);
        int seconds = (int)(playTime % 60);
        // Actualizar los textos con los datos recopilados
        if (hours > 0){
            playTimeText.text = string.Format("{0:D2}hs {1:D2}m {2:D2}s", hours, minutes, seconds);
        }
        else{
            playTimeText.text = string.Format("{0:D2}m {1:D2}s", minutes, seconds);
        }
    }
}
