using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugCollectables : MonoBehaviour {

    private Collectables collectables;

    private void Start()
    {
        collectables = FindObjectOfType<Collectables>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            collectables.CollectObject(transform.parent.gameObject);
        }
    }
}
