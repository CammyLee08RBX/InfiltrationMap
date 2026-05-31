using Unity.VisualScripting;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public Material standardMaterial;
    public Material groupMaterial;
    public Material fuseMaterial;
    public Material pressedMaterial;
    public Material inactiveMaterial;
    public GameObject explosionRadius;
    private string buttonNumber;
    private string buttonState;
    private Material buttonMaterial;
    private Transform map;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonNumber = transform.parent.name.Substring(7);
        buttonState = transform.parent.GetComponent<ButtonSetUp>().buttonState;
        map = transform.parent.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Begins processing the button's abilities
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("pressedButton", 0f);
        }
    }

    private void pressedButton()
    {
        buttonMaterial = transform.parent.Find("Light").GetComponent<Renderer>().material;
        if (buttonNumber != null)
        {
            int btnNum = int.Parse(buttonNumber);

            if (!buttonMaterial.name.Contains(inactiveMaterial.name) && buttonState != "pressed")
            {
                int mapChildren = map.childCount;
                for (int i = 0; i < mapChildren; i++)
                {
                    if (map.GetChild(i).name == "_Appear" + buttonNumber)
                    {
                        var renderer = map.GetChild(i).GetComponent<Renderer>();
                        if (renderer != null)
                        {
                            renderer.enabled = true;
                        }
                        var collider = map.GetChild(i).GetComponent<Collider>();
                        if (collider != null)
                        {
                            collider.enabled = true;
                        }
                        else
                        {
                            collider = map.GetChild(i).AddComponent<MeshCollider>();
                            collider.enabled = true;
                        }
                        if (map.GetChild(i).GetComponent<AudioSource>() != null)
                        {
                            map.GetChild(i).GetComponent<AudioSource>().Play();
                        }
                    }
                    if (map.GetChild(i).name == "_Fade" + buttonNumber)
                    {
                        var renderer = map.GetChild(i).GetComponent<Renderer>();
                        if (renderer != null)
                        {
                            renderer.enabled = false;
                        }
                            var collider = map.GetChild(i).GetComponent<Collider>();
                        if (collider != null)
                        {
                            collider.enabled = false;
                        }
                        else
                        {
                            collider = map.GetChild(i).AddComponent<MeshCollider>();
                            collider.enabled = false;
                        }
                        if (map.GetChild(i).GetComponent<AudioSource>() != null)
                        {
                            map.GetChild(i).GetComponent<AudioSource>().Play();
                        }
                    }
                    if (map.GetChild(i).name == "_Fall" + buttonNumber)
                    {
                        var rb = map.GetChild(i).GetComponent<Rigidbody>();
                        if (rb == null)
                        {
                            rb = map.GetChild(i).AddComponent<Rigidbody>();
                        }
                        rb.useGravity = true;
                        var collider = map.GetChild(i).GetComponent<Collider>();
                        if (collider != null)
                        {
                            collider.enabled = false;
                        }
                        else
                        {
                            collider = map.GetChild(i).AddComponent<MeshCollider>();
                            collider.enabled = false;
                        }
                        if (map.GetChild(i).GetComponent<AudioSource>() != null)
                        {
                            map.GetChild(i).GetComponent<AudioSource>().Play();
                        }
                        if (map.GetChild(i).GetComponent<DestroyObject>() != null)
                        {
                            map.GetChild(i).GetComponent<DestroyObject>().enabled = true;
                        }
                    }
                    if (map.GetChild(i).name == "_Unanchor" + buttonNumber)
                    {
                        var rb = map.GetChild(i).GetComponent<Rigidbody>();
                        if (rb == null)
                        {
                            rb = map.GetChild(i).AddComponent<Rigidbody>();
                        }
                        rb.useGravity = true;
                        if (map.GetChild(i).GetComponent<AudioSource>() != null)
                        {
                            map.GetChild(i).GetComponent<AudioSource>().Play();
                        }
                        if (map.GetChild(i).GetComponent<DestroyObject>() != null)
                        {
                            map.GetChild(i).GetComponent<DestroyObject>().enabled = true;
                        }
                    }
                }
                if (transform.parent.GetComponent<AudioSource>() != null)
                {
                    transform.parent.GetComponent<AudioSource>().Play();
                }
                if (buttonState == "fuse")
                {
                    //GameObject.Find("Light").GetComponent<Light>().color = new Color(255, 0, 0, 255);
                    transform.parent.Find("Light").GetComponent<Renderer>().material = fuseMaterial;
                    Instantiate(explosionRadius, transform.parent.Find("Hitbox").position, transform.parent.Find("Hitbox").rotation);
                    buttonState = "pressed";
                    Debug.Log("exploision!");
                }
                else
                {
                    buttonState = "pressed";
                    //GameObject.Find("Light").GetComponent<Light>().enabled = false;
                    transform.parent.Find("Light").GetComponent<Renderer>().material = pressedMaterial;

                    int nextBtn = btnNum + 1;
                    if (transform.parent.parent.Find("_Button" + nextBtn))
                    {
                        transform.parent.parent.Find("_Button" + nextBtn).Find("Light").GetComponent<Renderer>().material = standardMaterial;
                        transform.parent.parent.Find("_Button" + nextBtn).Find("Hitbox").GetComponent<ButtonBehavior>().enabled = true;
                    }
                }
            }
        }
    }
}
