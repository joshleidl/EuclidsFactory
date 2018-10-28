/* Programmer: Josh Leidl
 * Desc: This script enables the rotation of objects based on mouse clicks 90 degres at a time.
 * Use: Left click rotates upon x axis, right click rotates upon y axis
 */

using UnityEngine;
using System.Collections;

public class TouchRotatable : MonoBehaviour
{
    bool can_rotate = true;
    // Possible degrees: 
    int goal_side_x = 0;
    int angle_remaining = 0;
    int delta_angle = 0;
    bool rotate_on_x = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // On LMB downpress
        if (Input.GetMouseButtonDown(0) && can_rotate)
        {
            can_rotate = false;
            rotate_on_x = true;
            goal_side_x = goal_side_x > 3 ? goal_side_x + 1 : 0;

            angle_remaining = 90;
            delta_angle = 3;
        }

        // On RMB downpress
        if (Input.GetMouseButtonDown(1) && can_rotate)
        {
            can_rotate = false;
            rotate_on_x = false;

            angle_remaining = 90;
            delta_angle = 3;
        }

        if (!can_rotate)
        {
            if (rotate_on_x)
                transform.Rotate(0, delta_angle, 0, Space.World);
            else
                transform.Rotate(delta_angle, 0, 0, Space.World);

            angle_remaining -= delta_angle;
            if (angle_remaining == 0)
            {
                can_rotate = true;
                delta_angle = 0;
            }
        }
    }
}