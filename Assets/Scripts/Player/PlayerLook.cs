using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xrotation = 0f;

    public float xsensitivity = 15f;
    public float ysensitivity = 15f;

    public Transform bulletSpawnPoint;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Processlook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        xrotation -= (mouseY * Time.deltaTime) * ysensitivity;
        xrotation = Mathf.Clamp(xrotation, -80f, 80f);
        // apply this to the cam transform
        cam.transform.localRotation = Quaternion.Euler(xrotation, 0, 0);
        // rotate for left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xsensitivity);
    }

    public Vector3 GetAimingDirection()
    {
        if (cam != null)
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                return (hit.point - bulletSpawnPoint.position).normalized;
            }
        }

        // Return a default direction if camera not found or raycast fails
        return Vector3.forward; // Or any other default direction
    }
}

