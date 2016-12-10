using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCoral : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Hurt me, daddy.
            other.GetComponentInParent<PlayerHealth>().Hurt();
        }
    }

}
