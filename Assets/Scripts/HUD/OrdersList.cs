using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdersList : MonoBehaviour
{
    public enum Orders
    {
        Bear, Buzz, Robot, None
    }

    public List<Orders> ordersList;
    
    private float TimeT;

    void Start()
    {
        ordersList = new List<Orders>();
    }

    void Update()
    {
        TimeT += Time.deltaTime;

        if (TimeT >= 5f && ordersList.Count < 5) {
            ordersList.Add(getRandomOrder());
            TimeT = 0;
            gameObject.GetComponent<OrdersDisplay>().onChangeTicketTotal(ordersList.Count);
        }
    }

    private Orders getRandomOrder()
    {
        int rand = Random.Range(1,3);
        switch (rand)
        {
            case 1:
                return(Orders.Bear);
            case 2:
                return(Orders.Buzz);
            case 3:
                return(Orders.Robot);
            default:
                return (Orders.None);
        }
    }
}
