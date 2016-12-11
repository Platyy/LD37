using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public GameObject[] m_CollectableObjects;

    private int m_CollectableCount;
    private int m_Collected;

    private void Start()
    {
        m_Collected = 0;
    }

    public void CollectObject(GameObject collected)
    {
        for (int i = 0; i < m_CollectableObjects.Length; ++i)
        {
            if (m_CollectableObjects[i] == collected)
            {
                m_Collected++;
                m_CollectableObjects[i].SetActive(false);
            }
        }

        Debug.Log("Successfully collected: " + collected.name + ". New Collected count: " + m_Collected);
    }


}
