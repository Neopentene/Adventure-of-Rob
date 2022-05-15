using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithResolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = 1.5f;
        float y = x, z = x;
        Vector3 scale = new Vector3(x, y, z);
        gameObject.transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
