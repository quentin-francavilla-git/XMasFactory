using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderItemsDisplay : MonoBehaviour
{
    public int itemIndex;
    public Sprite bear;
    public Sprite buzz;
    public Sprite robot;
    public OrdersList list;

    private void Update() {
        // Debug.Log(list.ordersList.Count);
        if (list.ordersList.Count >= itemIndex) {
            gameObject.GetComponent<Image>().enabled = true;
            switch (list.ordersList[itemIndex - 1])
            {
                case OrdersList.Orders.Bear:
                    gameObject.GetComponent<Image>().sprite = bear;
                    break;
                case OrdersList.Orders.Buzz:
                    gameObject.GetComponent<Image>().sprite = buzz;
                    break;
                case OrdersList.Orders.Robot:
                    gameObject.GetComponent<Image>().sprite = robot;
                    break;
                default:
                    break;
            }
        } else {
            gameObject.GetComponent<Image>().enabled = false;
        }
    }
}
