using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CharacterController : MonoBehaviour
{
    public GameObject segment;
    public List<GameObject> body;
    public GameObject[] bodyParts;
    public Vector3 direction;
    bool ismoving;
    public JoyStick joyStick;
    public int count;
    void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow)) { 
        
        //    direction.z = 0.1f;
        //    //direction.x = 0;
        //    ismoving = true;
        //}
        //else if (Input.GetKey(KeyCode.DownArrow)) { 
        //    ismoving = true;
        //    direction.z = -0.1f;
        //    //direction.x = 0;

        //}
        //else if (Input.GetKey(KeyCode.LeftArrow)) { 
        //    ismoving = true;
        //direction.x = -0.1f;
        //    //direction.z = 0;

        //}
        //else if (Input.GetKey(KeyCode.RightArrow)) { 
        //    ismoving = true;
        //direction.x = 0.1f;
        //    //direction.z = 0;

        //}

        if (Mathf.Abs(joyStick.Horizontal()) > 0 || Mathf.Abs(joyStick.Vertical()) > 0)
            ismoving = true;
        else
            ismoving = false;

        direction = new Vector3(joyStick.Horizontal(), 0, joyStick.Vertical()).normalized;
        if (ismoving) {

            transform.forward = direction;
            //transform.position += direction;
            transform.position += transform.forward*0.05f;
            //transform.position += transform.right* direction.x;
        }
        //if (direction != Vector3.zero)
        //transform.eulerAngles = new Vector3(0,Mathf.Atan2(direction.x,direction.z)*Mathf.Rad2Deg,0);


        //{
        //Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

        //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 120 * Time.deltaTime);
        //}

        //direction = Vector3.zero;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("grass"))
            Eat();
    }
    void Eat()
    {
        //if (body.Count < 5) { 
        //GameObject bodyPart = Instantiate(segment);
        //    bodyPart.transform.parent = transform;
        //    bodyPart.transform.localScale = body.Last().transform.localScale - Vector3.one * 0.1f;
        //    bodyPart.transform.position = body.Last().transform.position- new Vector3(0, 0, 0.4f);
        //    body.Add(bodyPart);
        
        //}
        if (!bodyParts[bodyParts.Length - 1].activeSelf) {
            count++;
            bodyParts[count].SetActive(true);
        }
    }
}
