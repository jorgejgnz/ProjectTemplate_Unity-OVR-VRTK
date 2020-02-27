using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class TriggerActionCallBack : UnityEvent<GameObject>
{
}

[RequireComponent(typeof(Collider))]
public class TriggerAction : MonoBehaviour
{
    [Tooltip("Empty colliderToDetect -> Detect everything")]
    public Collider colliderToDetect;

    [Tooltip("Empty returnGameObject -> Return collider game object")]
    public GameObject returnGameObject;

    public TriggerActionCallBack onEnter;
    public TriggerActionCallBack onStay;
    public TriggerActionCallBack onExit;

    private void OnTriggerEnter(Collider other)
    {
        if (colliderToDetect != null)
        {
            if (other == colliderToDetect && returnGameObject == null) onEnter.Invoke(other.gameObject);
            if (other == colliderToDetect && returnGameObject != null) onEnter.Invoke(returnGameObject);
        }
        else
        {
            if (returnGameObject == null) onEnter.Invoke(other.gameObject);
            else onEnter.Invoke(returnGameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (colliderToDetect != null)
        {
            if (other == colliderToDetect && returnGameObject == null) onStay.Invoke(other.gameObject);
            if (other == colliderToDetect && returnGameObject != null) onStay.Invoke(returnGameObject);
        }
        else
        {
            if (returnGameObject == null) onStay.Invoke(other.gameObject);
            else onStay.Invoke(returnGameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (colliderToDetect != null)
        {
            if (other == colliderToDetect && returnGameObject == null) onExit.Invoke(other.gameObject);
            if (other == colliderToDetect && returnGameObject != null) onExit.Invoke(returnGameObject);
        }
        else
        {
            if (returnGameObject == null) onExit.Invoke(other.gameObject);
            else onExit.Invoke(returnGameObject);
        }
    }
}
