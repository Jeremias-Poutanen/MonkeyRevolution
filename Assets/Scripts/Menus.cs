using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour
{
    public GameObject GameOverMenu;
    public GameObject StartMenu;

    // Start is called before the first frame update
    void Start()
    {
        GameOverMenu.SetActive(false);
        StartMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
