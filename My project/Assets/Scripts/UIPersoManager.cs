using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPersoManager : MonoBehaviour
{
    [SerializeField]  private List<Sprite> playerCorps;
    [SerializeField] private Level corpsLevel;
    [SerializeField]  private List<Sprite> playerTete;
    [SerializeField] private Level teteLevel;
    [SerializeField]  private List<Sprite> playerLeg;
    [SerializeField] private Level legLevel;
    [Header("Renderer")]
    [SerializeField]  private SpriteRenderer tete;
    [SerializeField]  private SpriteRenderer body;
    [SerializeField]  private SpriteRenderer legs;
    [SerializeField]  private PlayerScript playerScript;

    public enum Level
    {
        Level0,
        Level1,
        Level2, 
        Level3,
    }
    void Start()
    {
        corpsLevel = Level.Level0;
        teteLevel = Level.Level0;
        legLevel = Level.Level0;
    }

    // Update is called once per frame
    public void UpgradeBody()
    {
        if (corpsLevel == Level.Level0)
        {
            corpsLevel = Level.Level1;
            body.sprite = playerCorps[1];
            body.transform.localPosition =new Vector3(-0.281f,-0.095f,0);
        }
        else if (corpsLevel == Level.Level1)
        {
            corpsLevel = Level.Level2;
            body.sprite = playerCorps[2];
            body.transform.localPosition = new Vector3(-0.5f,0.095f,0);
        } 
    }
    
    public void UpgradeTete()
    {
        if (teteLevel == Level.Level0)
        {
            teteLevel = Level.Level1;
            tete.sprite = playerTete[1];
        }
        else if (teteLevel == Level.Level1)
        {
            teteLevel = Level.Level2;
            tete.sprite = playerTete[2];
        } 
        else if (teteLevel == Level.Level2)
        {
            teteLevel = Level.Level3;
            tete.sprite = playerTete[3];
        }
    }
    public void UpgradeLeg()
    {
        if (legLevel == Level.Level0)
        {
            legLevel = Level.Level1;
            legs.sprite = playerLeg[1];
            legs.transform.localPosition = new Vector3(-0.5f,-0.968f,0);
            playerScript.ChangeSpeed(6f);
            
        }
        else if (legLevel == Level.Level1)
        {
            legLevel = Level.Level2;
            legs.sprite = playerLeg[2];
            legs.transform.localPosition = new Vector3(0,-0.9689f,0);
            playerScript.ChangeSpeed(8f);
        } 
    }

  
}
