using UnityEngine;

public class ButtonSelector : MonoBehaviour
{
    public GameObject[] buttons; 
    private int selectedIndex = 0; 

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SelectButton(selectedIndex - 1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SelectButton(selectedIndex + 1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SelectButton(selectedIndex - 1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SelectButton(selectedIndex + 1);
        }
    }

    private void SelectButton(int index)
    {
        if (index < 0)
        {
            index = buttons.Length - 1; 
        }
        else if (index >= buttons.Length)
        {
            index = 0;
        }
        selectedIndex = index;
    }
}