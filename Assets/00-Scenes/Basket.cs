using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Get the current Screen position of the mouse from input
        Vector3 mousePos2D = Input.mousePosition; //a

        //The camera's z position sets how far to push the mouse in 3d
        mousePos2D.z = -Camera.main.transform.position.z; //b

        //convert the point from 2d screen place to 3d game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); //c

        //move the x position of this basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter( Collision coll )
    {
        //find out what hits this basket
        GameObject collidedWith = coll.gameObject;
        if ( collidedWith.tag == "Apple" )
        {
            Destroy( collidedWith );
        }
    }
}

