using UnityEngine;

public class Dimmer2 : MonoBehaviour
{
    public Light Target_Light;

    public void DimLight(float rate)
    {
        Debug.Log("function called");

        float intensity = Target_Light.intensity;

        intensity = rate;

        Target_Light.intensity = intensity;
       
    }

}
