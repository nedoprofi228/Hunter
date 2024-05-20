using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObject : MonoBehaviour
{
    public GameObject obj;
    public void DisableThisObject()
    {
        obj.SetActive(false);
    }
    public void EnableGameObject()
    {
        obj.SetActive(true);
    }
}
