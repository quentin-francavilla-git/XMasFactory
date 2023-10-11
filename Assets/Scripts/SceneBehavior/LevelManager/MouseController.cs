using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private GameObject selectedObject;
    private Utils utils;

    private void Awake()
    {
        utils = new Utils();
    }

    // Update is called once per frame
    private void Update()
    {
        CatchMouseEvent();
    }

    private void CatchMouseEvent()
    {
        if (Input.GetMouseButtonUp(0)) {
            UpdateSelection();
        }
    }

    private void UpdateSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo)) {
            GameObject obj = utils.GetParentFromTag(hitInfo.transform.gameObject, hitInfo.transform.gameObject.tag);

            SelectObject(obj);
        } else {
            ClearSelection();
        }
    }

    private void SelectObject(GameObject obj)
    {
        Debug.Log("Objsect: " + obj.name + " (tag: " + obj.tag + ")");
        // If Order launch GoTo
        if (selectedObject && (selectedObject.tag == "Player" && obj.tag == "Furnitures")) {
            ElfController controller = selectedObject.GetComponent<ElfController>();

            // if (controller)
            //     controller.GoTo(obj.transform.position);
        }
        // Update Selection
        selectedObject = obj;
    }

    private void ClearSelection()
    {
        selectedObject = null;
        Debug.Log("RESET");
    }

    public GameObject getSelectedObject(){return (selectedObject);}
}
