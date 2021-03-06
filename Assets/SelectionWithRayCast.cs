﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionWithRayCast : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Button clicked");
            RaycastHit hit;


            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);  // Construct a ray from the current mouse coordinates
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider.gameObject != null)
                {
                    GameObject obj = hit.collider.gameObject;
                    Color x = obj.GetComponent<Renderer>().material.color;
                    if (x != Color.red)
                        obj.GetComponent<Renderer>().material.color = Color.red;
                    else
                        obj.GetComponent<Renderer>().material.color = Color.blue;
                }
            }
        }
    }
}
