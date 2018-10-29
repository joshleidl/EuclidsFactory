/* Programmer: Josh Leidl
 * Desc: This script goes on the vertex spheres in order to respond to clicks.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePoint : MonoBehaviour {

    public Material unselected;
    public Material selected;

    LinePointHelper helper; 

    private void Start()
    {
        helper = GameObject.FindGameObjectWithTag("Spawner").GetComponent<LinePointHelper>();
    }

    // Called when collider of object is clicked on
    void OnMouseDown()
    {
        if (helper.anchor == null)
        {
            GetComponent<Renderer>().material = selected;
            helper.anchor = this.gameObject;
        }
    }
}
