using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMenuController : MonoBehaviour
{
    public float rotationSpeed = 5f; // Velocidad de rotación
    public float maxRotationX = 15f; // Máxima rotación en el eje X
    public float maxRotationY = 15f; // Máxima rotación en el eje Y

    private void Update()
    {
        // Obtener la posición del cursor en la pantalla
        Vector3 mousePosition = Input.mousePosition;

        // Obtener el centro de la pantalla
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        
        // Calcular la diferencia entre la posición del cursor y el centro de la pantalla
        Vector3 offset = mousePosition - screenCenter;

        // Normalizar el offset
        offset.x = offset.x / (Screen.width / 2);
        offset.y = offset.y / (Screen.height / 2);
        
        // Calcular las rotaciones basadas en el offset
        float rotationX = Mathf.Clamp(-offset.y * rotationSpeed, -maxRotationX, maxRotationX);
        float rotationY = Mathf.Clamp(offset.x * rotationSpeed, -maxRotationY, maxRotationY);
        
        // Aplicar la rotación a la cámara
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }
}
