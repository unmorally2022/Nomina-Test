using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCounter : MonoBehaviour
{
    float TimeCounter = 0;
    public void init()
    {
        TimeCounter = 0;
    }

    private void FixedUpdate()
    {
        TimeCounter += Time.deltaTime;
        if (TimeCounter > 2.0f) {
            gameObject.SetActive(false);
        }
    }
}
