using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // Prefab for instantiating apples
    public GameObject applePrefab;

    //speed at which the Apple Tree Moves
    public float speed = 1f;

    // Distance where Apple Tree turns around

    public float leftAndRightEdge = 10f;

    //chance that Apple Tree will change direction
    public float chanceToChangeDirection = 0.1f;

    //Rate at which apples will be instantiated
    public float secondsBetweenAppleDrops =1f;
    // Start is called before the first frame update
    void Start()
    {
        // Dropping apples every second
    }

    // Update is called once per frame
    void Update()
    {
       //Basic Movement
       Vector3 pos = transform.position;
       pos.x += speed * Time.deltaTime;
       transform.position = pos;
       //Changing Direction 
     if ( pos.x < -leftAndRightEdge ) {
        speed = Mathf.Abs(speed); //Move Right
     } else if (pos.x > leftAndRightEdge ) {
        speed = -Mathf.Abs(speed); //Move left
     }
    }
}
