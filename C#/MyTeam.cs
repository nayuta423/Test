using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MyTeam : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public bool isOn;
    public GameObject myInstance;
    public float clonePositionX;

    public float cloneY;
    public int cost;
        

    private void Update()
    {
        if(isOn&& Input.GetMouseButtonDown(0) && GameManager.instance.money >= cost)
        {
            GameObject myPrefab = Instantiate(myInstance, new Vector3(clonePositionX,cloneY,0), myInstance.transform.rotation);
            myPrefab.GetComponent<CharacterContoller>().isAlly = true;
            GameManager.instance.money -= cost;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        // èàóùÇµÇΩÇ¢ì‡óe
        isOn = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOn = false;
    }
}
