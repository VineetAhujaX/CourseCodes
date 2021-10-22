using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//
//PointerEventData eventData
public class Clone : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
   public GameObject Object1; // This you assign in the inspector
    GameObject Object1clone;
   public void OnBeginDrag(PointerEventData eventData)
    {
       Object1clone = Instantiate(Object1, transform.position, transform.rotation);
    }

   public void OnDrag(PointerEventData eventData)
    {
        Object1clone.transform.position= eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
    }
}
