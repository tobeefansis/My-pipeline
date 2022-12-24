using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public static class ContactsListener 
{
    private static Dictionary<int, Action<int, int, ModifiableContactPair>> modifiers = new();

    public static void RegisterModifier(int bodyId, Action<int, int, ModifiableContactPair> modifier)
    {
        if (!modifiers.TryAdd(bodyId, modifier) || modifiers.Count>1) return;
        Physics.ContactModifyEvent += PhysicsOnContactModyfyEvent;
    }
    public static void UnregisterModifier(int bodyId)
    {
        if (!modifiers.Remove(bodyId) || modifiers.Count > 0) return;
        Physics.ContactModifyEvent -= PhysicsOnContactModyfyEvent;
        {

        }
    }
    private static void PhysicsOnContactModyfyEvent(PhysicsScene scene, NativeArray<ModifiableContactPair> pairs)
    {
        foreach (var modifiableContactPair in pairs)
        {
            if (modifiers.TryGetValue(modifiableContactPair.bodyInstanceID, out var m))
            {
                m(modifiableContactPair.bodyInstanceID, modifiableContactPair.otherBodyInstanceID, modifiableContactPair);
            }
            else if(modifiers.TryGetValue(modifiableContactPair.otherBodyInstanceID, out m))
            {
                m(modifiableContactPair.otherBodyInstanceID, modifiableContactPair.bodyInstanceID, modifiableContactPair);
            }
        }
    }
}
