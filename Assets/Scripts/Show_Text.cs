using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public Move_Player script;
    public string textValue;
    public Text textElement;

    // Start is called before the first frame update
    void Start()
    {
        textElement.text = script.moveSpeed.ToString() + " MPH";

    }

    // Update is called once per frame
    void Update()
    {
        int scriptInt = (int)script.moveSpeed;
        textElement.text = scriptInt.ToString() + " MPH";

        if(script.moveSpeed > 100){
            Time.timeScale = 0;
        }
    }
}
