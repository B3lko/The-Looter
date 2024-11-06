using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class LockPuzzleController : MonoBehaviour{
    public Image Background;
    public Image cross1;
    public Image cross2;
    public GameObject Lock;
    public TextMeshProUGUI positionAText;
    public TextMeshProUGUI positionBText;
    public TextMeshProUGUI positionCText;
    public TextMeshProUGUI WrongText;
    public GameObject player;
    private int positionA = 0;
    private int positionB = 0;
    private int positionC = 0;
    public bool isActive = false;

    private int correctA = 1; // Código correcto para la posición A
    private int correctB = 5; // Código correcto para la posición B
    private int correctC = 9; // Código correcto para la posición C

    public Transform parentObject; // Objeto padre que contiene los hijos con textos 3D
    private List<Transform> childTexts = new List<Transform>();
    [SerializeField] AudioSource open;

    private void Start(){
        correctA = Random.Range(0, 10);
        correctB = Random.Range(0, 10);
        correctC = Random.Range(0, 10);


        foreach (Transform child in parentObject){
            if (child.GetComponent<TextMeshPro>() != null){
                childTexts.Add(child);
                child.gameObject.SetActive(false); // Desactiva todos los textos al inicio
            }
        }

        ActivateThreeTexts();


        UpdateUI();
    }

    public void ActivatePuzzleMode(){
        isActive = true;
        cross1.gameObject.SetActive(false);
        cross2.gameObject.SetActive(false);
        //player.GetComponent<PlayerController>().offBookFlash();
        Background.gameObject.SetActive(true);
        Lock.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        player.GetComponent<PlayerController>().SetMove(false);
    }

    public void Leave(){
        isActive = false;
        cross1.gameObject.SetActive(true);
        cross2.gameObject.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<PlayerController>().SetMove(true);
        Background.gameObject.SetActive(false);
        Lock.SetActive(false);
    }

    public void IncreasePositionA()
    {
        positionA = (positionA + 1) % 10;
        UpdateUI();
    }

    public void DecreasePositionA(){
        positionA = (positionA - 1 + 10) % 10;
        UpdateUI();
    }

    public void IncreasePositionB(){
        positionB = (positionB + 1) % 10;
        UpdateUI();
    }

    public void DecreasePositionB(){
        positionB = (positionB - 1 + 10) % 10;
        UpdateUI();
    }

    public void IncreasePositionC(){
        positionC = (positionC + 1) % 10;
        UpdateUI();
    }

    public void DecreasePositionC(){
        positionC = (positionC - 1 + 10) % 10;
        UpdateUI();
    }

    private void UpdateUI(){
        positionAText.text = positionA.ToString();
        positionBText.text = positionB.ToString();
        positionCText.text = positionC.ToString();
    }

    public void CheckCode(){
        if (positionA == correctA && positionB == correctB && positionC == correctC){
            Leave();
            open.Play();
            transform.parent.transform.DOLocalRotateQuaternion(Quaternion.Euler(90, 0, 0), 2f).OnComplete(() => {});
            transform.parent.transform.DOScaleZ(0.1f, 2);
            transform.parent.transform.DOLocalMoveY(-1.046f,2);
            gameObject.tag = "Untagged";
            Debug.Log("Código correcto! Candado desbloqueado.");
            // Aquí puedes añadir la lógica para desbloquear el candado
        }
        else{
            WrongText.gameObject.SetActive(true);
            WrongText.gameObject.transform.DOScaleZ(1,2).OnComplete(() => {
                WrongText.gameObject.SetActive(false);
            });
            Debug.Log("Código incorrecto.");
        }
    }



    private void ActivateThreeTexts(){
        // Selecciona tres textos aleatorios sin repetir
        List<Transform> selectedTexts = new List<Transform>();

        while (selectedTexts.Count < 3 && childTexts.Count > 0){
            int randomIndex = Random.Range(0, childTexts.Count);
            Transform randomChild = childTexts[randomIndex];

            if (!selectedTexts.Contains(randomChild)){
                selectedTexts.Add(randomChild);
                childTexts.RemoveAt(randomIndex); // Elimina para evitar repetición
            }
        }

        // Asigna los valores de la clave correcta (A, B, C) a los textos seleccionados
        selectedTexts[0].GetComponent<TextMeshPro>().text = $"A{correctA}";
        selectedTexts[1].GetComponent<TextMeshPro>().text = $"B{correctB}";
        selectedTexts[2].GetComponent<TextMeshPro>().text = $"C{correctC}";

        // Activa solo los tres textos seleccionados
        foreach (Transform textTransform in selectedTexts){
            textTransform.gameObject.SetActive(true);
        }
    }
}
