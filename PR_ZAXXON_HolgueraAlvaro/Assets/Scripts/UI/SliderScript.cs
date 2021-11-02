using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{

    bool loaded;

    [SerializeField] Slider sliderInv;
    // Start is called before the first frame update
    void Start()
    {
        sliderInv.value = 0f;
        loaded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(loaded == false)
        {
            sliderInv.value += 10f * Time.deltaTime;
            if (sliderInv.value >= 100f)
            {
                loaded = true;
            }
        }

        if(Input.GetKeyDown("space") && loaded == true)
        {
            sliderInv.value = 0;
            loaded = false;
        }
        
    }
}
