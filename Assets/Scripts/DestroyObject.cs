using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float delayTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("clearObj", delayTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void clearObj()
    {
        Destroy(transform.gameObject);
    }
}
