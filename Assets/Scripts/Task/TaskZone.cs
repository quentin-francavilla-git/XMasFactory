using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskZone : MonoBehaviour
{
    private void OnColliderEnter(Collider other) {
        Debug.Log("boom");
        // if (other.gameObject.tag == "TaskZone") {
        //     agent.isStopped = true;
        // }
    }
}
