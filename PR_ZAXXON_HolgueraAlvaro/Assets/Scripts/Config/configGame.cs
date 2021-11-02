using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class configGame : MonoBehaviour
{
    public static float volumeMusic;
    public static int dif;

    private void Update()
    {
        volumeMusic = transform.position.z;
    }
}
