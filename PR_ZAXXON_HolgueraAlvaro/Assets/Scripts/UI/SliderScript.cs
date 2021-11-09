using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{

    bool loaded;
    //Velocidad de carga
    [SerializeField] float chargingSpeed;

    [SerializeField] Slider sliderInv;
    // Start is called before the first frame update
    void Start()
    {
        sliderInv.value = 0f;
        loaded = false;
        chargingSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        CargarDisparo();

        
        
    }

    void CargarDisparo()
    {
        if (loaded == false)
        {
            sliderInv.value += chargingSpeed * Time.deltaTime;
            if (sliderInv.value >= 100f)
            {
                loaded = true;
            }
        }

        if (Input.GetButtonDown("Fire1") && loaded == true)
        {
            sliderInv.value = 0;
            loaded = false;
            GameObject.Find("Nave").GetComponent<NaveMove>().SendMessage("Disparar");
        }
    }
}
