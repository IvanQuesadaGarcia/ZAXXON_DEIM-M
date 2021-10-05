using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour
{

    //Game object con el prefab
    [SerializeField] GameObject ladrillo;
    //Variable Transform de referencia
    [SerializeField] Transform initPos;
    //La separación será variable
    float separacion;

    // Start is called before the first frame update
    void Start()
    {

        separacion = 1.1f;

        //Las posición inicial es la del objeto de referencia
        Vector3 newPos = initPos.position;
        Vector3 despl = new Vector3(separacion,0f,0f);

        //Bucle para instanciar ladrillos
        for(int n = 0; n < 10; n++)
        {

            Instantiate(ladrillo, newPos, Quaternion.identity);
            newPos = newPos + despl;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
