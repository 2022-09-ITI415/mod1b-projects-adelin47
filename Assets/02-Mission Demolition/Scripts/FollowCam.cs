using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    static public GameObject POI; // the static point of interest

    [Header("Set in Inspector")]
    public float        easing = 0.05f;
    public Vector2      minXY = Vector2.zero;

    [Header("Set Dynamically")]
    public float        camZ; // the desired z pos of the camera

    void Awake() {
        camZ = this.transform.position.z;
    }

    void FixedUpdate(){
        //if there's only one line following an if, it doesn't need braces
        // if (POI == null) return; //return if there is no poi
        //get the possition of the poi
        //Vector3 destination = POI.transform.position;
        Vector3 destination;
        //if there is not POI, return ToString p (000)
        if (POI == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            //get the position of the poi
            destination = POI.transform.position;
            //if poi is a projectile, check to see if its at rest
            if (POI.tag == "Projectile")
            {
                //if it is sleeping (that is not moving)
                if (POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    //return to default view
                    POI = null;
                    // in the next update
                    return;
                }
            }
        }
        //limit the x and y to minimun values
        destination.x = Mathf.Max( minXY.x, destination.x);
        destination.y = Mathf.Max( minXY.y, destination.y);
        //interpolate from the current camera position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing);
        //Force destination.z to be camZ to keep the camera far enough away
        destination.z = camZ;
        //Set the camera to the destination
        transform.position = destination;
        //set the orthographicSize of the camera to keep ground view
        Camera.main.orthographicSize = destination.y + 10;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
