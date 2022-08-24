using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _mouseX;
    private float _mouseY;

    public float sensitivityMouse = 200f;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * sensitivityMouse * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * sensitivityMouse * Time.deltaTime;

        player.Rotate(_mouseX * new Vector3(0, 1, 0));

        transform.Rotate(-_mouseY * new Vector3(1, 0, 0));
    }
}
