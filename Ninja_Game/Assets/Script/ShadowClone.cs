using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowClone : MonoBehaviour
{
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private float spawnOffset = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnClone();
    }

    private void SpawnClone()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Vector3 spawnPos = transform.position + transform.right * spawnOffset;
            Instantiate(clonePrefab, spawnPos, transform.rotation);

        }
        
    }
}
