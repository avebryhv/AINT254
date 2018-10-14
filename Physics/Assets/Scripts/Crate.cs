using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace physic
{
    public class Crate : MonoBehaviour
    {
        public Camera cam;
        public GameObject dotPrefab;
        [Range(0,1000)]
        public float force = 10;
        public float forceMultiplier = 1;
        public float gravity = -9.81f;
        private Vector3 direction;
        [SerializeField]
        private GameObject[] dots;
        // Use this for initialization
        void Start()
        {
            dots = new GameObject[10];
            for (int i = 0; i < dots.Length; i++)
            {
                GameObject tempObject = Instantiate(dotPrefab);
                dots[i] = tempObject;
                dots[i].SetActive(false);

            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 screenPosition = cam.WorldToScreenPoint(gameObject.transform.position);
                screenPosition.z = 0;

                direction = -(Input.mousePosition - screenPosition).normalized;
                Aim();
            }

            if (Input.GetMouseButtonUp(0))
            {
                GetComponent<Rigidbody>().AddForce(direction * force * forceMultiplier);
                for (int i = 0; i < dots.Length; i++)
                {                    
                    dots[i].SetActive(false);

                }
            }
            
        }

        void Aim()
        {
            float Sx = direction.x * force;
            float Sy = direction.y * force;

            for (int i = 0; i < dots.Length; i++)
            {
                float t = i * 0.05f;
                float Dx = transform.position.x + (Sx * t);
                float Dy = (transform.position.y + Sy * t) + (0.5f * gravity * t * t);
                dots[i].transform.position = new Vector3(Dx, Dy, 0);
                dots[i].SetActive(true);
            }
        }
    }
}
