using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{

    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float BodySpeed = 5;
    public int Gap = 10;

    public GameObject BodyPrefab;
    public GameObject FoodPrefab;
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
    }

    // Update is called once per frame
    void Update()
    {
        //move forward
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        //steer
        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        //store position
        PositionsHistory.Insert(0, transform.position);

        //movement
        int index = 0;
        foreach (var body in BodyParts){
            Vector3 point = PositionsHistory[Mathf.Min(index * Gap, PositionsHistory.Count -1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;
            body.transform.LookAt(point);
            index++;
        }
    }

   private void OnTriggerEnter(Collider other)
   {
    if (other.gameObject.CompareTag("Enemy"))
    {
        //other.gameObject.SetActive(false);
        Destroy(other.gameObject);
        GrowSnake();
        //Instantiate(FoodPrefab, new Vector3(Random.Range(-10.0f, 10.0f)))
    }
 
   }



    private void GrowSnake()
    {
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }
}
