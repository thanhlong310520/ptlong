    using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panspeed = 50f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 10f;
    public float minScroll = 30f;
    public float maxScroll = 110f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * panspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * panspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * panspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * panspeed * Time.deltaTime);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y = pos.y - scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minScroll, maxScroll);
        transform.position = pos;
    }
}
