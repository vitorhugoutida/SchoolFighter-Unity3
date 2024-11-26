using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Animator transition;
    public float transitionTime = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Se pressionar qualquer tecla
        if (Input.GetKeyDown(KeyCode.Return)) {

            // Mudar cena
            StartCoroutine(CarregarFase("Fase1"));
        }


    }

    // Corrotina - Coroutine

    IEnumerator CarregarFase(string nomeFase)
    {
        // Iniciar a animação 
        transition.SetTrigger("Start");

        // Esperar o tempo de animação

        yield return new WaitForSeconds(transitionTime);

        //Carregar a cena 
        SceneManager.LoadScene(nomeFase);

    }
}
