﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    // [SerializeField] Animator spriteAnimator;
    // [SerializeField] Image heroSprite;
    //[SerializeField] GameObject heroObject;
    [SerializeField] GameObject warriorObject;
    [SerializeField] GameObject thiefObject;
    [SerializeField] GameObject paladinObject;
    [SerializeField] Text heroNameText;
    [SerializeField] Text heroClassText;
    [SerializeField] Text heroAttackText;
    [SerializeField] Text heroDefenseText;
    [SerializeField] Text heroLuckText;

    // [SerializeField] Text heroSpellText;

    //  [SerializeField] Image heroWeaponImage;
    // [SerializeField] Image heroDefenseImage;
    // [SerializeField] Image heroLuckImage;
    //[SerializeField] Image heroSpellImage;

    #region Singleton
    private static InventoryManager _instance = null;

    public static InventoryManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<InventoryManager>();
            }
            return _instance;
        }
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerManager.Instance != null)
        {
            InitInventoryUI();
        }
    }


    public void InitInventoryUI()
    {
        var myHero = PlayerManager.Instance.ownerPlayer.hero;
        heroNameText.text = PlayerManager.Instance.ownerPlayer.displayName;
        heroClassText.text = myHero.classText;
        UpdateSprite(myHero.classText);
        heroAttackText.text = myHero.attackPoint.ToString();
        heroDefenseText.text = myHero.defencePoint.ToString();
        heroLuckText.text = myHero.luck.ToString();
        //spellcard name?
    }


    private void UpdateSprite(string classText)
    {
        if (classText == "Thief")
        {
            thiefObject.SetActive(true);
            Debug.Log("switch to thief");
        }
        else if (classText == "Warrior")
        {
            warriorObject.SetActive(true);
            Debug.Log("switch to " + classText);
        }
        else
        {
            paladinObject.SetActive(true);
            Debug.Log("switch to paladin");
        }
    }
}