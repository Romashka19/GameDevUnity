using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text Name;
    public Text Distance;
    public Transform Player;


    // Start is called before the first frame update
    void Start()
    {
        Name.text = "Name: " + Menu.PlayerName.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Distance.text = "Distance: " +Player.position.x.ToString("0");
    }
}
