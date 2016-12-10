using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour {

    private Rigidbody m_RB;

    void Start()
    {
        m_RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        AddTorqueToLeg();
    }

    public void AddTorqueToLeg()
    {
        float h = Input.GetAxis("Horizontal") * 50f * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * 50f * Time.deltaTime;


        m_RB.AddTorque((Vector3.up * h), ForceMode.Impulse);
        m_RB.AddTorque((Vector3.forward * v), ForceMode.Impulse);
    }

}
