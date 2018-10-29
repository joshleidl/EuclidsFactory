/* Programmer: Josh Leidl
 * Desc: This script enables the rotation of objects based on arrow key inputs 90 degrees
 *       at a time
 */

using UnityEngine;
using System.Collections;

public class TouchRotatable : MonoBehaviour
{
    bool can_rotate = true;
    int angle_remaining = 0;
    int delta_angle = 0;
    bool rotate_on_x = false;

    // Update is called once per frame
    void Update()
    {
        // On left arrowkey
        if (Input.GetKey("left") && can_rotate)
        {
            can_rotate = false;
            rotate_on_x = true;

            angle_remaining = 90;
            delta_angle = 3;
        }

        // On right arrowkey
        if (Input.GetKey("right") && can_rotate)
        {
            can_rotate = false;
            rotate_on_x = true;

            angle_remaining = 90;
            delta_angle = -3;
        }

        // On up arrowkey
        if (Input.GetKey("up") && can_rotate)
        {
            can_rotate = false;
            rotate_on_x = false;

            angle_remaining = 90;
            delta_angle = 3;
        }

        // On down arrowkey
        if (Input.GetKey("down") && can_rotate)
        {
            can_rotate = false;
            rotate_on_x = false;

            angle_remaining = 90;
            delta_angle = -3;
        }

        if (!can_rotate)
        {
            if (rotate_on_x)
                transform.Rotate(0, delta_angle, 0, Space.World);
            else
                transform.Rotate(delta_angle, 0, 0, Space.World);

            angle_remaining -= Mathf.Abs(delta_angle);
            if (angle_remaining == 0)
            {
                can_rotate = true;
                delta_angle = 0;
            }
        }
    }
}