using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gameBoardManager : MonoBehaviour
{
    public GameObject player;
    private shipScript playerScript;
    
    public TextMeshProUGUI textmeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<shipScript>();
        // textmeshPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerScript.hasLanded())
            Debug.Log("\nSCORE: " + playerScript.getScore() + "\tFUEL: " + playerScript.getFuel());
            textmeshProUGUI.SetText("\nSCORE: " + playerScript.getScore() + "\nFUEL: " + playerScript.getFuel());
    }

            
        
        // The text displayed will be:
        // The first number is 4 and the 2nd is 6.35 and the 3rd is 4.
}
