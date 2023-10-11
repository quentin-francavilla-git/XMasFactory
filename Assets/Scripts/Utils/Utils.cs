using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public GameObject GetParentFromTag(GameObject obj, string tag)
    {
        /*
        Return the closest parent from the root tagged as [tag]

        Args:
            obj (GameObject): object from which to start the backward research.
            tag (string): tag to focus on.
        */

        if (obj == null)
            return (null);

        Transform current = obj.transform;
        Transform parent = obj.transform.parent;

        while (parent && parent.tag == tag)
        {
            current = current.transform.parent;
            parent = parent.transform.parent;
        }
        return (current.gameObject);
    }

}
