using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roundUI : MonoBehaviour
{
    public Text round;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        round.text = GameManager.round.ToString() + "/" + GameManager.roundOnLevel.ToString();
    }
}
