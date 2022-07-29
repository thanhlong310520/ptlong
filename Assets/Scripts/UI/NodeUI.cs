using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    Node nodeTarget;
    public GameObject ui;
    public void SetTarget(Node node)
    {
        nodeTarget = node;
        transform.position = nodeTarget.transform.position;
        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Sell()
    {
        nodeTarget.SellTurret();
        Hide();
    }
}
