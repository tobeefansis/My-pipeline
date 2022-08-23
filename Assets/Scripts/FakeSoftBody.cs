
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[BurstCompile]
public class FakeSoftBody : MonoBehaviour
{
    [SerializeField] private float maxImpulse = 2.0f;

    private int bodyInstanceId;
    private void Start()
    {
        foreach (var componetsInChild in GetComponentsInChildren<Collider>())
        {
            componetsInChild.hasModifiableContacts = true;
        }
        bodyInstanceId = GetComponent<Rigidbody>().GetInstanceID();
        Physics.ContactModifyEvent += PhysicsOnContactModifyEvent;
    }

    private unsafe void PhysicsOnContactModifyEvent(PhysicsScene scene, Unity.Collections.NativeArray<ModifiableContactPair> pairs)
    {
        PhysicsOnContactModifyEventBurs(scene, (ModifiableContactPair*)pairs.GetUnsafeReadOnlyPtr(),
            pairs.Length, bodyInstanceId, maxImpulse);
    }

    [BurstCompile]
    private static unsafe void PhysicsOnContactModifyEventBurs(PhysicsScene scene, ModifiableContactPair* contactPairs,
        int count, int bodyInstanceId,float maxImpulse) 
    {
        for (int i = 0; i < count; i++)
     
        {
            var pair = contactPairs[i];
            if (pair.bodyInstanceID != bodyInstanceId && pair.otherBodyInstanceID != bodyInstanceId) continue;
            for (int j = 0; j < pair.contactCount; j++)
            {
                var separetionRate = -pair.GetSeparation(j);
                if (separetionRate < 0) separetionRate = 0;
                pair.SetMaxImpulse(j, maxImpulse*separetionRate);
            }
        }
    }
}
