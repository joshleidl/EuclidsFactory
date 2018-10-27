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
    private enum Direction {x, y, z, rx, ry, rz};
    Direction x_dir = Direction.x;
    Direction y_dir = Direction.y;

    // Use this for initialization
    void Start()
    {

    }

    void apply_rotation(Direction dir, int degrees)
    {
        switch (dir)
        {
            case Direction.x:
                transform.Rotate(0, degrees, 0);
                break;
            case Direction.y:
                transform.Rotate(degrees, 0, 0);
                break;
            case Direction.z:
                transform.Rotate(0, 0, degrees);
                break;
            case Direction.rx:
                transform.Rotate(0, -degrees, 0);
                break;
            case Direction.ry:
                transform.Rotate(-degrees, 0, 0);
                break;
            case Direction.rz:
                transform.Rotate(0, 0, -degrees);
                break;
        }
    }

    /*
    Direction update_x ()
    {
    }

    Direction update_y ()
    {

    }
    */
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
                apply_rotation(x_dir, delta_angle);
            else
                apply_rotation(y_dir, delta_angle);

            angle_remaining -= delta_angle;
            if (angle_remaining == 0)
            {
                can_rotate = true;
                delta_angle = 0;
            }
        }
    }
}