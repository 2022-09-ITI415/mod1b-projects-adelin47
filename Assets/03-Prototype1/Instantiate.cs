using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject Food;
    // Start is called before the first frame update
    void Start()
    {
          Instantiate(Food, new Vector3(-20.0f, 20.0f), Quaternion.identity);  
    }



    // Update is called once per frame
    void Update()
    {
    }
}
