using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitGameScript : MonoBehaviour
{
    /*---------------------------
    //------VARIABLES GLOBALES
    ------------------------------*/
    public float spaceshipSpeed;

    //Variable que indica el nivel
    public int levelGame;

    //Puntuaci�n
    static float score;

    //Energ�a
    [SerializeField] float energy;

    //Velocidad m�xima
    [SerializeField] float maxSpeed;

    //�Estoy vivo?
    public bool alive;

    //UI
    [SerializeField] Text scoreText;
    [SerializeField] Text levelText;
    [SerializeField] Text speedText;
    [SerializeField] Slider energySlider;
    [SerializeField]  Button retryButton;
    //GameOverCanvas
    GameObject GameOver;
    Canvas GameOverCanvas;


    // Start is called before the first frame update
    void Start()
    {
        spaceshipSpeed = 35f;
        levelGame = 0;
        energy = 100f;

        maxSpeed = 200f;
        alive = true;

        //Asigno las variables de mi men� GameOver
        GameOver = GameObject.Find("GameOverCanvas");
        GameOverCanvas = GameOver.GetComponent<Canvas>();
        GameOverCanvas.enabled = false;

        //Obtengo la escena en la que estoy y si es la de juego pongo el score a 0
        int y = SceneManager.GetActiveScene().buildIndex;
        if(y== 1)
        {
            score = 0;
        }
        
        ;

        float tiempoPasado = Time.time;

        scoreText.text = score + " mts.";
    }

    // Update is called once per frame
    void Update()
    {
        if(spaceshipSpeed < maxSpeed && alive == true)
        {
            spaceshipSpeed += 0.001f;
        }

        UpdateUI();
        
    }

    void UpdateUI()
    {
        float tiempo = Time.time;
        //print(Mathf.Round(tiempo));
        if(spaceshipSpeed != 0)
        {
            score = Mathf.Round(tiempo) * spaceshipSpeed;
        }
        
        scoreText.text = Mathf.Round(score) + " mts.";
        levelText.text = "NIVEL: " + levelGame.ToString();
        if (score > 500 && score < 1000)
        {
            levelGame = 1;
        }
        else if (score > 1000)
        {
            levelGame = 2;
        }

        //Actualizo la energ�a
        energySlider.value = energy;
        float speedMetric = (spaceshipSpeed * 3600) / 1000;
        speedText.text = speedMetric + " km/h";
    }

    //Morirse
    public void Morir()
    {
        print("Me he muerto");
        alive = false;
        spaceshipSpeed = 0f;
        IntanciadorObst instanciadorObst =  GameObject.Find("InstanciadorObst").GetComponent<IntanciadorObst>();
        instanciadorObst.SendMessage("Parar");
        //Desactivo el Grupo que contiene la nave
        GameObject.Find("NaveGrupo").SetActive(false);

        Invoke("MostrarGameOver", 2f);
        

        //SceneManager.LoadScene(2);
    }

    void MostrarGameOver()
    {
        //Muestro el men� GameOver
        GameOverCanvas.enabled = true;
        //Selecciono el bot�n de volver
        
        retryButton.Select();
    }

    public void Chocar(GameObject other)
    {
        print("Me he chocado con :" + other.tag);
        energy -= 50;
        if(energy <= 0)
        {
            Morir();
        }
        else
        {
            Destroy(other);
        }
    }

    public void Invec()
    {

        Invoke("PararInvenc", 2f);
    }

    void PararInvenc()
    {

    }
}
