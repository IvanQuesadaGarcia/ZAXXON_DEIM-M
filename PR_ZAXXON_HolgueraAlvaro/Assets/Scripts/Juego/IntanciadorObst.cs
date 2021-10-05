using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntanciadorObst : MonoBehaviour
{
    //Creo variables para poder acceder a un script (componente) externo
    [SerializeField] GameObject obst; //GameObject que tiene el script
    [SerializeField] Transform initPos; //Variable que contendrá ese script

    //el intervalo para la corrutina, dependerá de la velocidad
    float intervalo;
    
    void Start()
    {
        
        intervalo = 1f; //El intervalo de momento es fijo, ya cambiará
        //Inicio la Corrutina que instancia los prefabsa
        StartCoroutine("CrearObstaculos");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Corrutina que instancia prefabs siguiendo los intervalos
    IEnumerator CrearObstaculos()
    {
        while(true)
        {
            //Creo un Vector3 que indicará la posición de instanciación
            //El valor X es random, el Z el del objeto de referencia
            Vector3 instPos = new Vector3(Random.Range(-10f, 10f), 0f, initPos.position.z);
            //Instancio el prefab
            Instantiate(obst, instPos, Quaternion.identity);
            yield return new WaitForSeconds(intervalo);

        }
    }
}
