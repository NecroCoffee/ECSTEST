using System.Collections;
using System.Collections.Generic;
using Unity.Transforms;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

namespace EX
{
    public class EX01 : MonoBehaviour
    {

        [SerializeField]private float generateTime = 0.2f;
        [SerializeField] private GameObject prefab;

        public float speed = 1.0f; // —†ù‚Ì‘¬“x
        public float radius = 0.1f; // —†ù‚Ì”¼Œa‘‰Á—Ê
        public float angleIncrement = 0.1f; // —†ù‚ÌŠp“x‘‰Á—Ê

        public float minRadius = 60f;
        public float maxRadius = 120f;

        [SerializeField]private float angle = 0.0f; // Œ»İ‚ÌŠp“x
        [SerializeField]private float currentRadius = 0.0f; // Œ»İ‚Ì”¼Œa

        private float currentHeight = 0f;
        private int count = 0;

        private bool returnFlag = false;
        private bool endFlag = false;

        private Coroutine coroutine;

        private void Start()
        {
            //currentRadius = (minRadius+maxRadius)/2;

            coroutine=StartCoroutine(WaitForSecond());
        }

        private void Update()
        {
            if (Input.anyKeyDown&&endFlag==false)
            {
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                    coroutine = null;
                }
                endFlag = true;

                foreach(Transform child in this.gameObject.transform)
                {
                    Rigidbody rig = child.gameObject.AddComponent<Rigidbody>();
                    BoxCollider collider=child.gameObject.AddComponent<BoxCollider>();
                }
            }
        }

        IEnumerator WaitForSecond()
        {
            while (true)
            {
                float x = currentRadius * Mathf.Cos(angle);
                float z = currentRadius * Mathf.Sin(angle);

                GameObject child=Instantiate(prefab, new Vector3(x, currentHeight/10, z), Quaternion.identity);
                child.transform.parent = this.gameObject.transform;

                
                    currentRadius += radius * Time.deltaTime;
                    angle += angleIncrement;
                
                


                count++;

                if (count > 10)
                {
                    currentHeight++;
                    count = 0;
                }

                yield return new WaitForSeconds(generateTime);
            }
        }

    }
}

