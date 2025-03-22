using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using level1model;
public class RelayControl: MonoBehaviour
{
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ¼ì²âÊó±ê×ó¼üµã»÷
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                CatItem catItem = hit.collider.GetComponentInParent<CatItem>();

                if (catItem != null)
                {
                    
                    ExecuteEvents.Execute(catItem.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                }
                else
                {
                   
                    Debug.Log("Miss£¬time +5");
                    Level1Model.Instance.time += 5f;
                }
            }
            else
            {
                
                Debug.Log("Miss£¬time +5");
                Level1Model.Instance.time += 5f;
            }
        }
    }
}
