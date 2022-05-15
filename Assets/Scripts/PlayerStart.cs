using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    public float x = 0, y = 0;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = new Vector3(x, y, 0);
        gameObject.transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
