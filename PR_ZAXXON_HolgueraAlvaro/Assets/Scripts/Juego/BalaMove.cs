using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMove : MonoBehaviour
{

    [SerializeField] float balistica;
    // Start is called before the first frame update
    void Start()
    {
        balistica = 55f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * balistica);
        float posz = transform.position.z;
        if(posz >= 120f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
            //Destruyo también la bala
            Destroy(gameObject);
        }
    }
}
