using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameController : MonoBehaviour{

    //Definir cuantos objetos a encontrar
    //Spawnearlos
    //Controlar el progreso a medida que se agarran

    public Image black;

    //
    [SerializeField] GameObject Door1;
    [SerializeField] GameObject Door2;
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerSpawn;
    [SerializeField] GameObject dog;
    [SerializeField] GameObject keeper;
    [SerializeField] GameObject cam;
    [SerializeField] Button btnMenu;
    [SerializeField] int cantJewels;
    [SerializeField] GameObject[] JewelPrefabs;
    public GameObject book;
    private int currentJewels = 0;
    private bool winner = false;
    [SerializeField] AudioSource musicAmbience;
    [SerializeField] TextMeshProUGUI text;
    private bool isPause = false;
    public AudioMixer audioMixer;



    public void StopMusic(){
        musicAmbience.Stop();
    }

    public void AddJewel(){
        currentJewels += 1;
        text.gameObject.SetActive(true);
        text.text = "collected jewelry: " + currentJewels + " / 4";
        if(currentJewels == gameObject.GetComponent<NameLoader>().GetBooks()){
            text.text = "collected jewelry: " + currentJewels + " / 4" + "\n" + "escape with the car!";
            winner = true;
            Door1.GetComponent<DoorController>().SetState(2);
            Door2.GetComponent<DoorController>().SetState(2);
        }
        DOVirtual.DelayedCall(3, () => {
            text.gameObject.SetActive(false);
        });
    }

    public bool GetWinner(){
        return winner;
    }

    public void GoMenu(){
        SceneManager.LoadScene("MainMenu");
    }




    void Start(){
        //Debug.Log("PlayTImeeee: " +  GameData.Instance.playTime);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.transform.position = playerSpawn.transform.position;
        musicAmbience.DOFade(1, 3);
        black.DOFade(0, 3).OnComplete(() => {
            black.gameObject.SetActive(false);
            Color color;
            color = black.color;
            color.a = 1;
            black.color = color;
        });
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
                //Instantiate(JewelPrefabs[0], matchingTomb.transform.parent.transform.GetChild(0).transform.position, Quaternion.identity, matchingTomb.transform.parent);
                int jewelIndex = Random.Range(0, 4);
                GameObject newJewel = Instantiate(JewelPrefabs[jewelIndex], matchingTomb.transform.parent.GetChild(0).position, Quaternion.identity, matchingTomb.transform.parent);
                if(!matchingTomb.GetComponent<TombController>().isWall){
                    newJewel.transform.SetSiblingIndex(7);
                    if(jewelIndex == 0){
                        newJewel.transform.localPosition = new Vector3(-0.761f, 1.35f, 0);
                        newJewel.transform.localRotation = Quaternion.Euler(0, -90, 0);
                    }
                    else if(jewelIndex == 2){
                        newJewel.transform.localPosition = new Vector3(0, 1.312f, 0.2f);
                        newJewel.transform.localRotation = Quaternion.Euler(280, 90, 0);
                    }
                    else if(jewelIndex == 3){
                        newJewel.transform.localPosition = new Vector3(0.25f, 1.25f, 0f);
                        newJewel.transform.localRotation = Quaternion.Euler(90, 0, 0);
                    }
                }
                else{
                    newJewel.transform.parent = newJewel.transform.parent.transform.GetChild(0);
                    if(jewelIndex == 0){
                        newJewel.transform.localPosition = new Vector3(0, 0.04f, -0.785f);
                        newJewel.transform.localRotation = Quaternion.Euler(180, 0, 0);
                    }
                    else if(jewelIndex == 2){
                        newJewel.transform.localPosition = new Vector3(0, 0.09f, 0.2f);
                        newJewel.transform.localRotation = Quaternion.Euler(-90, 0, 0);
                    }
                    else if(jewelIndex == 3){
                        newJewel.transform.localPosition = new Vector3(0.25f, 0.05f, 0f);
                        newJewel.transform.localRotation = Quaternion.Euler(90, 0, 0);
                    }
                }
            }
        }
    }


    void Update(){
        if(!isPause){
            //GameData.Instance.UpdatePlayTime(Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.C)){
            SceneManager.LoadScene("SummaryScene");
        }
        if(Input.GetKeyDown(KeyCode.P)){
            SetPause();
        }
    }

    public void SetPause(){
        if(dog.activeSelf){
            dog.GetComponent<DogController>().SetPause();
        }
        if(keeper.activeSelf){
            keeper.GetComponent<KeeperController>().SetPause();
        }
        cam.GetComponent<CameraController>().SetPause();
        player.GetComponent<PlayerController>().SetPause();
        isPause = !isPause;
        if(isPause){    
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else{
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
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


    /*private void LoadSettings(){
        // Cargar sensibilidad del mouse
        float savedMouseSensitivity = PlayerPrefs.GetFloat(MouseSensitivityKey, 1.0f);
        mouseSensitivitySlider.value = savedMouseSensitivity;

        // Cargar volumen de efectos de sonido (SFX)
        float savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 1.0f);
        sfxVolumeSlider.value = savedSFXVolume;

        // Cargar volumen de la música
        float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 1.0f);
        musicVolumeSlider.value = savedMusicVolume;
    }*/
}
