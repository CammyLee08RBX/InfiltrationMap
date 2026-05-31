using UnityEngine;

public class ButtonSetUp : MonoBehaviour
{
    private string buttonNumber;
    public string buttonState;
    public Material standardMaterial;
    public Material groupMaterial;
    public Material fuseMaterial;
    public Material pressedMaterial;
    public Material inactiveMaterial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonNumber = transform.name.Substring(7);
        buttonState.ToLower();
        int btnNum = int.Parse(buttonNumber);
        int mapChildren = transform.parent.childCount;
        int index = 1;
        if (buttonState != "group")
        {
            //GameObject.Find("Light").GetComponent<Light>().color = new Color(0, 255, 91, 255);
            GameObject.Find("Light").GetComponent<Renderer>().material = standardMaterial;
        }
        else
        {
            //GameObject.Find("Light").GetComponent<Light>().color = new Color(0, 175, 255, 255);
            GameObject.Find("Light").GetComponent<Renderer>().material = groupMaterial;
        }
        for (int i = 0; i < mapChildren; i++)
        {
            int newBtnNum = btnNum + index;
            if (transform.parent.GetChild(i).name == "_Button" + newBtnNum)
            {
                transform.parent.GetChild(i).Find("Light").GetComponent<Renderer>().material = inactiveMaterial;
                transform.parent.GetChild(i).Find("Hitbox").GetComponent<ButtonBehavior>().enabled = false;
                index++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
