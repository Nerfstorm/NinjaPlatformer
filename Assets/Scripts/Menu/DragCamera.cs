using UnityEngine;
using System.Collections;

public class DragCamera : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    public bool cameraDragging = true;

    public float outerLeft = -10f;
    public float outerRight = 10f;
    public float outerUp = 10f;
    public float outerDown = -10f;


    void Update()
    {



        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        float left = Screen.width * 0.2f;
        float right = Screen.width - (Screen.width * 0.2f);
        float down = Screen.height * 0.2f;
        float up = Screen.height - (Screen.height *0.2f);

        if (mousePosition.x < left)
        {
            cameraDragging = true;
        }
        else if (mousePosition.x > right)
        {
            cameraDragging = true;
        }

        if (mousePosition.y < up)
        {
            cameraDragging = true;
        }
        else if (mousePosition.y > down)
        {
            cameraDragging = true;
        }



        if (cameraDragging)
        {

            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                return;
            }

            if (!Input.GetMouseButton(0)) return;


            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 moveHor = new Vector3(pos.x * dragSpeed,0, 0);
            Vector3 moveVer = new Vector3(0, pos.y * dragSpeed, 0);


            if (moveHor.x > 0f)
            {
                if (this.transform.position.x < outerRight)
                {
                    transform.Translate(moveHor, Space.World);
                }
            }
            else
            {
                if (this.transform.position.x > outerLeft)
                {
                    transform.Translate(moveHor, Space.World);
                }
            }
            


            if (moveVer.y > 0f)
            {
                if (this.transform.position.y < outerUp)
                {
                    transform.Translate(moveVer, Space.World);
                }
            }
            else
            {
                if (this.transform.position.y > outerDown)
                {
                    transform.Translate(moveVer, Space.World);
                }
            }
        }
    }


}
