using UnityEngine;
using TMPro;

public class BookController : MonoBehaviour{
    private TextMeshProUGUI[] textMeshPro;

    // Start is called before the first frame update
    void Start(){
        textMeshPro = GetComponentsInChildren<TextMeshProUGUI>();
        // Imprimir los nombres de los componentes encontrados
        foreach (TextMeshProUGUI text in textMeshPro){
            Debug.Log("Texto encontrado: " + text.text);
        }
    }


    public void fede(string name){
        foreach (TextMeshProUGUI text in textMeshPro){
                Debug.Log("ACA2");
            if (text.text == name){
                Debug.Log("ACA");
                string content = text.text;
                text.text = $"<s>{content}</s>";
            }   
        }
    }


}
