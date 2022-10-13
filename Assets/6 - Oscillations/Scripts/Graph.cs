using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private GameObject m_CirclePrefab;
    [SerializeField] private int m_totalPoints = 10;
    [SerializeField] private float m_Separation = 0.5f;
    GameObject[] m_Points;

    private void Start()
    {
        m_Points = new GameObject[m_totalPoints];
        for (int i = 0; i < m_totalPoints; i++)
        {
            m_Points[i] = Instantiate(m_CirclePrefab, transform);
        }
    }

    private void Update()
    {
        for (int i = 0; i < m_Points.Length; i++)
        {
            GameObject NewPoint = m_Points[i];

            float x = i * m_Separation;
            float y = Mathf.Sin(x + Time.time);

            NewPoint.transform.position = new Vector3(x, y);
        }
    }
}
