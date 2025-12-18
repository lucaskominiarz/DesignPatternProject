using System;
using UnityEngine;

public class Pool : MonoBehaviour
{

    
    [SerializeField] private Transform poolParent;
    [SerializeField] private GameObject objectInPool;
    [SerializeField] private int poolSize = 50;
    [SerializeField] private Transform playerTransform;

    private GameObject[] _pool;
    private int _currentPoolIndex = 0;

    private void Awake()
    {
        _pool = new GameObject[poolSize];
        
        for (int i = 0; i < poolSize; i++)
        {
            _pool[i] = Instantiate(objectInPool, poolParent);
            _pool[i].SetActive(false);
        }
    }

    public void SpawnObject()
    {
        _pool[_currentPoolIndex].SetActive(true);
        _pool[_currentPoolIndex].transform.position = playerTransform.position;

        if (_currentPoolIndex >= poolSize - 1)
        {
            _currentPoolIndex = 0;
        }
        else
        {
            _currentPoolIndex ++;
        }
    }
}
