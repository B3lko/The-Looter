using System.Collections;
using UnityEngine;
using DG.Tweening;

public class RainController : MonoBehaviour
{
    public GameObject objeto2;
    public float minIntervalo = 5.0f;  // Tiempo mínimo entre lluvia
    public float maxIntervalo = 15.0f; // Tiempo máximo entre lluvia
    public float fadeDuration = 3.0f;  // Duración del fade

    private float tiempoRestante;
    private bool isRaining = false;
    private bool isPaused = false;

    private void Start()
    {
        // Configuramos el tiempo inicial aleatorio
        SetRandomInterval();
    }

    private void Update()
    {
        if (isPaused) return;

        // Cuenta regresiva
        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            if (isRaining)
            {
                StopRain();
            }
            else
            {
                StartRain();
            }

            // Establecemos un nuevo intervalo de tiempo aleatorio para la próxima vez
            SetRandomInterval();
        }
    }

    private void StartRain()
    {
        isRaining = true;

        // Activamos el sistema de partículas y aplicamos el fade-in en el audio
        var particleSystem = GetComponent<ParticleSystem>();
        if (particleSystem != null) particleSystem.Play();

        var audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0f;
        audioSource.Play();
        audioSource.DOFade(1f, fadeDuration);

        // Fade-out en el audio del objeto2
        var audioSource2 = objeto2.GetComponent<AudioSource>();
        audioSource2.DOFade(0f, fadeDuration).OnComplete(() => {
            audioSource2.Stop();
        });
    }

    private void StopRain()
    {
        isRaining = false;

        // Detenemos el sistema de partículas y aplicamos el fade-out en el audio
        var particleSystem = GetComponent<ParticleSystem>();
        if (particleSystem != null) particleSystem.Stop();

        var audioSource = GetComponent<AudioSource>();
        audioSource.DOFade(0f, fadeDuration).OnComplete(() => {
            audioSource.Stop();
        });

        // Fade-in en el audio del objeto2
        var audioSource2 = objeto2.GetComponent<AudioSource>();
        audioSource2.volume = 0f;
        audioSource2.Play();
        audioSource2.DOFade(1f, fadeDuration);
    }

    private void SetRandomInterval()
    {
        // Genera un tiempo aleatorio entre el mínimo y el máximo intervalo
        tiempoRestante = Random.Range(minIntervalo, maxIntervalo);
    }

    public void SetPause(bool pause)
    {
        isPaused = pause;
    }

    public void Dest(){
        Destroy(gameObject);
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class RainController : MonoBehaviour{
    //public GameObject objeto1;
    public GameObject objeto2;
    public float intervalo = 10.0f;

    private Coroutine toggleCoroutine;
    private bool isPaused = false;

    private void Start()
    {
        toggleCoroutine = StartCoroutine(ToggleCoroutine());
    }

    private IEnumerator ToggleCoroutine()
    {
        while (true)
        {
            GetComponent<ParticleSystem>().Play();//objeto1.SetActive(true);
            GetComponent<AudioSource>().volume = 0f;
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().DOFade(1f, 3f);
            objeto2.GetComponent<AudioSource>().DOFade(0f, 3f).OnComplete(() => {
                objeto2.GetComponent<AudioSource>().Stop();
            });

            yield return new WaitForSeconds(intervalo);

            GetComponent<AudioSource>().DOFade(0f, 3f).OnComplete(() => {
                GetComponent<AudioSource>().Stop();
            });
            GetComponent<ParticleSystem>().Stop();//objeto1.SetActive(true);
            objeto2.GetComponent<AudioSource>().volume = 0f;
            objeto2.GetComponent<AudioSource>().Play();
            objeto2.GetComponent<AudioSource>().DOFade(1f, 3f);


            yield return new WaitForSeconds(intervalo);
        }
    }

    public void SetPause(bool pause)
    {
        isPaused = pause;

        if (isPaused)
        {
            if (toggleCoroutine != null)
            {
                StopCoroutine(toggleCoroutine);
            }
        }
        else
        {
            if (toggleCoroutine == null)
            {
                toggleCoroutine = StartCoroutine(ToggleCoroutine());
            }
        }
    }
}
*/