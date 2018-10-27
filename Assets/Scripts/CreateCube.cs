/* Programmer: Josh Leidl
 * Desc: Creates a cube of size one cubic unit of the specified resolution using the supplied component.
 * 
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    public Rigidbody component;
    public static int res = 3;

    // Upon loading
    public void Start()
    {
        //int required_components = res * res * res;
        int half_res = res / 2;
        float increment = 1f / res;

        // Iterate through the required resolution for each dimension
        for (int width = -half_res; width <= half_res; width++)
        {
            for (int height = -half_res; height <= half_res; height++)
            {
                for (int depth = -half_res; depth <= half_res; depth++)
                {
                    Rigidbody block = (Rigidbody)Instantiate(component, transform.position, transform.rotation);
                    // Make the block a child of the object this script is attached to
                    block.transform.parent = transform;
                    block.transform.localPosition = new Vector3(width * increment, height * increment, depth * increment);
                    block.transform.localScale = new Vector3(increment, increment, increment);
                }
            }
        }
    }
}
