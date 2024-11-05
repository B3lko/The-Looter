using UnityEngine;

public class BookPositioner : MonoBehaviour
{
    public Transform cameraTransform; // Arrastra aquí la cámara principal desde el editor
    public float distanceFromCamera = 1.0f; // Ajusta la distancia al libro

    private Vector3 initialRotation;

    void Start()
    {
        // Guarda la rotación inicial para mantener la orientación constante
        initialRotation = transform.eulerAngles;
    }

    void Update()
    {
        // Calcula la posición del libro frente a la cámara
        transform.position = cameraTransform.position + cameraTransform.forward * distanceFromCamera;

        // Mantén la rotación inicial para que no cambie con la cámara
        transform.rotation = Quaternion.Euler(initialRotation);
    }
}
