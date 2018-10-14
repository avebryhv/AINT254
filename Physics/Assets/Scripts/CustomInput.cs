using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace physic
{
    public class CustomInput : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnGUI()
        {
            GUI.Label(new Rect(5, 5, 200, 30), "Horizontal Axis: ");
            GUI.Label(new Rect(200, 5, 200, 30), Input.GetAxis("Horizontal").ToString());

            GUI.Label(new Rect(5, 30, 200, 30), "Vertical Axis: ");
            GUI.Label(new Rect(200, 30, 200, 30), Input.GetAxis("Vertical").ToString());
        }
    }
}
