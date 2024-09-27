using UnityEngine;

namespace Winch.Components;

[UsedInUnityProject]
[RequireComponent(typeof(Joint))]
public class DynamicJoint : MonoBehaviour
{
    [SerializeField]
    public Joint joint;

    public void Awake()
    {
        joint.connectedBody = transform.parent.GetComponentInParent<Rigidbody>();
    }

    public void OnValidate()
    {
        joint = GetComponent<Joint>();
    }
}
