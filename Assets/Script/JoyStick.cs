using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class JoyStick : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    public Image joyStickBg;
    public Image joyStick;

    public Vector3 inputVector;
    public Vector2 localPoint;


    public void OnPointerDown(PointerEventData e)
    {
        joyStickBg.gameObject.SetActive(true);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(this.GetComponent<RectTransform>(), e.position, e.pressEventCamera, out localPoint);
        localPoint.x += this.GetComponent<RectTransform>().sizeDelta.x / 2;
        localPoint.y += this.GetComponent<RectTransform>().sizeDelta.y / 2;


        joyStickBg.rectTransform.anchoredPosition = localPoint;

    }

    public void OnDrag(PointerEventData e)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joyStickBg.rectTransform, e.position, e.pressEventCamera, out pos))
        {
            pos.x = pos.x / joyStickBg.rectTransform.sizeDelta.x;
            pos.y = pos.y / joyStickBg.rectTransform.sizeDelta.y;

            inputVector = new Vector3(pos.x * 2 + 1, pos.y * 2 - 1);
            inputVector = inputVector.magnitude > 1 ? inputVector.normalized : inputVector;

        }

        joyStick.rectTransform.anchoredPosition = new Vector2(inputVector.x*joyStickBg.rectTransform.sizeDelta.x/2, inputVector.y * joyStickBg.rectTransform.sizeDelta.y/2 );

    }

    public void OnPointerUp(PointerEventData e)
    {
        inputVector = Vector3.zero;
        joyStick.rectTransform.anchoredPosition = Vector3.zero;
        joyStickBg.gameObject.SetActive(false);



    }



    public float Horizontal() {
        return inputVector.x!=0? inputVector.x: Input.GetAxis("Horizontal");
    }

    public float Vertical(){
        return inputVector.y!= 0 ? inputVector.y : Input.GetAxis("Vertical");

    }
}
