using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrdersDisplay : MonoBehaviour
{
    public Image emptyTicket;

    public void onChangeTicketTotal(int ticketTotal) {
        float newWidth = 288 * ticketTotal;
        emptyTicket.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);
    }
}
