using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorePopUp : MonoBehaviour
{

    public Text myText;

    public void changeText(string Ctext)
    {
        myText.text = Ctext;
    }

    public void _destroyMe()
    {
        Destroy(gameObject);
    }
}
