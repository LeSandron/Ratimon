using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{
    public Transform Playermodel;
    public GameObject ControlTarget;
    float MouseY;
    float MouseX;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MouseY -= Input.GetAxis("Mouse Y") * Time.deltaTime * 1200;
        MouseY = Mathf.Clamp(MouseY, -90, 90);
        MouseX -= Input.GetAxis("Mouse X") * Time.deltaTime * 1200;
        transform.localEulerAngles = new Vector3(MouseY, 0, 0);

        Playermodel.transform.localEulerAngles = new Vector3(0, -MouseX, 0);
    }
}
