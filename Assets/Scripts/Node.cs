using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color startColor;
    public Color enoughMoney;
    public GameObject turret;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    
    private void OnMouseDown()
    {
        
        if(turret != null)
        {
            BuildManager.instance.SelectNode(this); // nếu click chuột vào ô mà có tháp thì sẽ trả về ô có tháp đó
            return;
        }
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!BuildManager.instance.canBuild)
        {
            return;
        }
        BuildManager.instance.BuildTurretOn(this);
    }
    private void OnMouseEnter() // khi chuot di chuyyen tren node thì sẽ thực hiện hành động như controller
    {
        if(turret != null)
        {
            rend.material.color = Color.blue;
            return;
        }
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!BuildManager.instance.canBuild)
        {
            return;
        }
        if (BuildManager.instance.hasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
            rend.material.color = enoughMoney;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    public void SellTurret()
    {
        PlayerStart.money += 50;
        Destroy(turret);
    }
}
