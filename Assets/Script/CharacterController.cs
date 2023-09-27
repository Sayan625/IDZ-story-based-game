using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CharacterController : MonoBehaviour
{
    public GameObject segment;
    public List<GameObject> body;
    public Vector3 direction;
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            direction.z = 0.1f;
        if (Input.GetKey(KeyCode.DownArrow))
            direction.z = -0.1f;
        if (Input.GetKey(KeyCode.LeftArrow))
            direction.x = -0.1f;
        if (Input.GetKey(KeyCode.RightArrow))
            direction.x = 0.1f;

        transform.position += transform.forward * direction.z;
        transform.position += transform.right * direction.x;

        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 120 * Time.deltaTime);
        }

        direction = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.Space))
            Eat();

    }

    void Eat()
    {
        if (body.Count < 5) { 
        GameObject bodyPart = Instantiate(segment);
        bodyPart.transform.parent = transform;
            bodyPart.transform.localScale = body.Last().transform.localScale - Vector3.one * 0.1f;
        bodyPart.transform.position = body.Last().transform.position- new Vector3(0, 0, 0.4f);
        body.Add(bodyPart);
        
        }
    }
}
