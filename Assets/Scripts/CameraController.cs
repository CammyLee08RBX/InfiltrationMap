using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;   // the player object
    public float mouseSensitivity = 200f;
    public GameObject map;
    private AudioClip bgm;

    float xRotation = 0f;

    private void Start()
    {
        bgm = map.GetComponent<MapSettings>().bgm;
        transform.GetComponent<AudioSource>().generator = bgm;
        transform.GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            player.Rotate(Vector3.up * mouseX);
        }
    }
}
