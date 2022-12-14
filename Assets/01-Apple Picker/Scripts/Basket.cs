using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamicaly")]
    public Text scoreGT;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
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

            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();

            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}

