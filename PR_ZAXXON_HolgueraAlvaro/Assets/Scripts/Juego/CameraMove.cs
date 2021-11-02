using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    //Variables necesarias para la opción de suavizado
    [SerializeField] float smoothVelocity = 0.3F;
    [SerializeField] Vector3 camaraVelocity = Vector3.zero;

    float distZ;


    // Start is called before the first frame update
    void Start()
    {
        distZ = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Con este código, conseguimos que siga al objeto pero con suavidad
        //La velocidad de suavizado, cuanto menor sea más brusco será el movimiento
        Vector3 targetPosition = new Vector3(playerPosition.position.x, playerPosition.position.y, playerPosition.transform.position.z - distZ);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity, smoothVelocity);
        
        //Opcional: que la cámara mire al objeto (la cámara no puede ser ortográfica)
        //transform.LookAt(playerPosition);
    }

    public void CambiarDist(float dist)
    {
        distZ = dist;
    }
}
