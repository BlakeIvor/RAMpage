using UnityEngine;

public class PlayerBaseController : MonoBehaviour
{
    [Header("Spawn Slots")]
    public Transform ramSlot;
    public Transform wheelSlot;
    public Transform frontSlot;

    [Header("Spawned Parts")]
    public GameObject ramPart;
    public GameObject wheelPart;
    public GameObject frontPart;

    public void SetParts(GameObject ram, GameObject wheel, GameObject front)
    {
        ramPart = ram;
        wheelPart = wheel;
        frontPart = front;

        if (ramSlot != null) ram.transform.SetParent(ramSlot, false);
        if (wheelSlot != null) wheel.transform.SetParent(wheelSlot, false);
        if (frontSlot != null) front.transform.SetParent(frontSlot, false);
    }

}
