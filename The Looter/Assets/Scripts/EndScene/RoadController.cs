using UnityEngine;
using DG.Tweening;

public class RoadController : MonoBehaviour{
    public float roadLength = 80f; // Longitud de cada segmento de carretera
    public float speed = 20f; // Velocidad de desplazamiento constante

    private Vector3 startPosition; // Posición inicial de cada segmento
    private Vector3 endPosition; // Posición final de cada segmento

    private void Start()
    {
        RenderSettings.skybox.SetFloat("_Rotation", 10);
        // Define la posición inicial y la posición final de cada segmento
        startPosition = transform.position;
        endPosition = new Vector3(startPosition.x, startPosition.y, startPosition.z + roadLength);

        // Inicia el movimiento del segmento
        MoveRoad();
    }

    private void MoveRoad()
    {
        transform.position = startPosition; // Reinicia la posición al punto de inicio

        // Mueve el segmento hacia la posición final con velocidad constante
        transform.DOMoveZ(endPosition.z, roadLength / speed)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                MoveRoad(); // Reinicia el movimiento cuando llega al final
            });
    }
}
