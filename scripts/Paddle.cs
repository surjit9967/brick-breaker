using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenwidthinunits = 20f;
    [SerializeField] float Minx = 1f;
    [SerializeField] float Maxx = 15f;
           
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenwidthinunits;
        Vector2 paddlePoss = new Vector2(transform.position.x,transform.position.y);
        paddlePoss.x = Mathf.Clamp(mousePosInUnits, Minx, Maxx);
        transform.position = paddlePoss;
    }
}
