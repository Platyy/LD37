using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour {

    private Rigidbody m_RB;

    void Start()
    {
        m_RB = GetComponent<Rigidbody>();
    }

    public void AddTorqueToLeg(float _torque)
    {
        m_RB.AddTorque(Vector3.forward * (-_torque * 100), ForceMode.Impulse);
    }

}
