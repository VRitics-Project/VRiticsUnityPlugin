using UnityEngine;
using VRitics;

public class OculusSample_Input : MonoBehaviour
{
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            VRiticsSetup.Input();
        }
    }
}
