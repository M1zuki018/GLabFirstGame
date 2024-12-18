using UnityEngine;
using Cinemachine;

public class DamageCamera : MonoBehaviour
{
    CinemachineImpulseSource _impulse;
    private void Start()
    {
        _impulse = GetComponent<CinemachineImpulseSource>();
    }

    /// <summary>
    /// カメラを揺らす
    /// </summary>
    public void Shake()
    {
        _impulse.GenerateImpulse();
    }
}
