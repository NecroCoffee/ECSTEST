using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace EX
{
    public class EX01Cube : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private GameObject circle;

        public int sizeX;
        public int sizeY;
        public int sizeZ;

        public float diff;

        private int currentPosX = 0;
        private int currentPosY = 0;
        private int currentPosZ = 0;

        private Coroutine coroutine;

        private bool endFlag = false;

        private Vector3 thisObjPos;

        void Start()
        {
            thisObjPos = this.transform.position;
            coroutine = StartCoroutine(Generate());
        }

        private void Update()
        {
            if (Input.anyKeyDown && endFlag == false)
            {
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                    coroutine = null;
                }
                endFlag = true;

                foreach (Transform child in this.gameObject.transform)
                {
                    Rigidbody rig = child.gameObject.AddComponent<Rigidbody>();
                    BoxCollider collider = child.gameObject.AddComponent<BoxCollider>();
                }
            }
        }

        IEnumerator Generate()
        {
            while (true)
            {

                GameObject childObject = 
                    Instantiate(
                        prefab,
                        new Vector3(thisObjPos.x + currentPosX + diff, thisObjPos.y + currentPosY + diff, thisObjPos.z + currentPosZ + diff),
                        Quaternion.identity);

                childObject.transform.parent = this.gameObject.transform;

                currentPosX++;

                if (currentPosX > sizeX)
                {
                    currentPosX = 0;
                    currentPosZ++;
                }

                if (currentPosZ > sizeZ)
                {
                    currentPosZ = 0;
                    currentPosY++;
                }

                if (currentPosY > sizeY)
                {
                    currentPosY = 0;
                    StopCoroutine(coroutine);

                    childObject = Instantiate(
                        circle,
                        new Vector3(thisObjPos.x, thisObjPos.y * 1.5f, thisObjPos.z),
                        Quaternion.identity);

                    childObject.transform.parent = this.gameObject.transform;
                    childObject.transform.localScale = new Vector3(sizeX, (sizeX+sizeZ)/2, sizeZ);

                    childObject.AddComponent<Rigidbody>();
                    childObject.AddComponent<SphereCollider>();

                    foreach (Transform child in this.gameObject.transform)
                    {
                        Rigidbody rig = child.gameObject.AddComponent<Rigidbody>();
                        BoxCollider collider = child.gameObject.AddComponent<BoxCollider>();
                    }
                }

                yield return new WaitForSeconds(0);

            }


        }

    }
}
