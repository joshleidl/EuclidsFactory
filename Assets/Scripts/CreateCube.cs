/* Programmer: Josh Leidl
 * Desc: Creates a cube of size one cubic unit of the specified resolution using the supplied component.
 * 
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    public GameObject component;
    public GameObject intersection;
    public int res = 3;
    public float size = 1f;
    public bool add_verticies = true;

    // Upon loading
    public void Start()
    {
        //int required_components = res * res * res;
        int half_res = res / 2;
        float increment = size / res;

        // Iterate through the required resolution for each dimension
        // Currently only works with odd resolutions
        for (int width = -half_res; width <= half_res; width++)
        {
            for (int height = -half_res; height <= half_res; height++)
            {
                for (int depth = -half_res; depth <= half_res; depth++)
                {
                    GameObject block = (GameObject)Instantiate(component, transform.position, transform.rotation);
                    // Make the block a child of the object this script is attached to
                    block.transform.parent = transform;
                    block.transform.localPosition = new Vector3(width * increment, height * increment, depth * increment);
                    block.transform.localScale = new Vector3(increment, increment, increment);
                }
            }
        }

        if (add_verticies)
        {
            for (float width = -size / 2f; width <= size / 2f; width += size / res)
            {
                for (float height = -size / 2f; height <= size / 2f; height += size / res)
                {
                    for (float depth = -size / 2f; depth <= size / 2f; depth += size / res)
                    {
                        GameObject vertex = (GameObject)Instantiate(intersection, transform.position, transform.rotation);

                        vertex.transform.parent = transform;
                        vertex.transform.localPosition = new Vector3(width, height, depth);
                        vertex.transform.localScale = new Vector3(size / (3f * res), size / (3f * res), size / (3f * res));
                    }
                }
            }
        }
    }
}
