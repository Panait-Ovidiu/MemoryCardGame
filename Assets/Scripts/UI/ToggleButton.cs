using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public Toggle button;

    // Start is called before the first frame update
    void Start()
    {
        button.SetIsOnWithoutNotify(Menu.isHideMatches());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
