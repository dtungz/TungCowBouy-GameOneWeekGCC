using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayingUI : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private PlayerAmountManager _playerAmountManager;
    [SerializeField] private Image Health;
    [SerializeField] private Image Bullet;
    [SerializeField] private Image Reload;
    [SerializeField] private List<GunSO> currWeapon = new List<GunSO>();
    [SerializeField] private List<Image> weapon = new List<Image>();
    [SerializeField] private List<TMP_Text> Mags = new List<TMP_Text>();
    [SerializeField] private PlayerAmountManager playerAmountManager;
    GunStatic currentWeapon;

    private void Start()
    {
        currentWeapon = ChoiceGun.currGun;
        Reload.gameObject.SetActive(false);
        weapon[0].transform.localScale = Vector3.one * 1.5f;
    }

    private void Update()
    {
        SetHealth();
        SetBullets();
        SetReload();
        SetOption();
        SetMags();
    }
    private void SetHealth()
    {
        Health.fillAmount = (float)_playerManager.hp / 200;
    }

    private void SetBullets()
    {
        Bullet.fillAmount = (float)_playerAmountManager.currBullets / currWeapon[(int)ChoiceGun.currGun].bullet;
    }

    private void SetReload()
    {
        if(PlayerShootingState.state == PlayerState.Reload)
        {
            Reload.gameObject.SetActive(true);
        }
        else
        {
            Reload.gameObject.SetActive(false);
        }
    }

    private void SetOption()
    {
        if (currentWeapon != ChoiceGun.currGun)
        {
            for(int i = 0; i < 3; i++)
            {
                if(i == (int)ChoiceGun.currGun)
                {
                    weapon[i].transform.localScale = Vector3.one * 1.5f;
                }
                else
                {
                    weapon[i].transform.localScale = Vector3.one;
                }
            }
            currentWeapon = ChoiceGun.currGun;
        }
    }

    private void SetMags()
    {
        for(int i = 0; i < Mags.Count; i++)
        {
            Mags[i].text = $"{_playerAmountManager.Inventory[i].y}";
        }
    }
}
