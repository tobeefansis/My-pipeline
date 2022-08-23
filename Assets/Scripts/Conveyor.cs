using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Conveyor : MonoBehaviour
{
    [SerializeField] private Transform movingTarget;
    [SerializeField] private float speed = 1.5f;
    private Vector3 worldMovingVelocity;

    private void Awake()
    {
        worldMovingVelocity = (movingTarget.position - transform.position).normalized* speed;
        foreach (var componentsInChild in GetComponentsInChildren<Collider>())
        {
            componentsInChild.hasModifiableContacts = true;
        }
    }
    private void OnEnable()
    {
        ContactsListener.RegisterModifier(GetComponent<Rigidbody>().GetInstanceID(), ContactModifier);
    }
    private void OnDisable()
    {
        ContactsListener.UnregisterModifier(GetComponent<Rigidbody>().GetInstanceID());
    }
    private void ContactModifier(int body1, int body2, ModifiableContactPair pair)
    {
        for (int j = 0; j < pair.contactCount; j++)
        {
            pair.SetTargetVelocity(j, worldMovingVelocity);
        }
    }
}
