using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    //public GameObject PopUpTemplate;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        //PopUpTemplate.SetActive(true);
        Debug.Log("Mouse is over GameObject.");
        //gameObject.tag = "ActiveCard";
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        //PopUpTemplate.SetActive(false);
        Debug.Log("Mouse is no longer on GameObject.");
        //gameObject.tag = "Untagged";
    }
}