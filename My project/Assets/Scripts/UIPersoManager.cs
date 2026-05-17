using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPersoManager : MonoBehaviour
{
    [SerializeField]  private List<GameObject> playerCorps;
    [SerializeField] public Level corpsLevel;
    [SerializeField]  private List<Sprite> playerTete;
    [SerializeField] public Level teteLevel;
    [SerializeField]  private List<GameObject> playerLeg;
    [SerializeField] public Level legLevel;
    [Header("Renderer")]
    [SerializeField]  private SpriteRenderer tete;
    [SerializeField]  private GameObject body;
    [SerializeField]  public GameObject legs;
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
        playerCorps[0].SetActive(true);
        playerCorps[1].SetActive(false);
        playerCorps[2].SetActive(false);
        teteLevel = Level.Level0;
        legLevel = Level.Level0;
        playerLeg[0].SetActive(true);
        playerLeg[1].SetActive(false);
        playerLeg[2].SetActive(false);
    }

    // Update is called once per frame
    public void UpgradeBody()
    {
        if (corpsLevel == Level.Level0)
        {
            corpsLevel = Level.Level1;
            playerCorps[0].SetActive(false);
            body = playerCorps[1];
            body.SetActive(true);
            playerScript.UpgradeAttack();   
        }
        else if (corpsLevel == Level.Level1)
        {
            corpsLevel = Level.Level2;
            playerCorps[1].SetActive(false);
            body = playerCorps[2];
            body.SetActive(true);
            playerScript.UpgradeAttack();
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
            playerLeg[0].SetActive(false);
            legs = playerLeg[1];
            legs.SetActive(true);
            playerScript.ChangeSpeed(6f);
            
        }
        else if (legLevel == Level.Level1)
        {
            legLevel = Level.Level2;
            playerLeg[1].SetActive(false);
            legs = playerLeg[2];
            legs.SetActive(true);
            playerScript.ChangeSpeed(8f);
            playerScript.legAnimator= legs.GetComponent<Animator>();
        } 
    }

  
}
