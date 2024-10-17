using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


    public class EX02 : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int spawnCount;
        private int spawnCounter;

        private void Update()
        {
            if (spawnCount >= spawnCounter)
            {
                GeneratePrefab();
                spawnCounter++;
            }   
        }

        private void GeneratePrefab()
        {
            Instantiate(prefab, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
        }



    }



