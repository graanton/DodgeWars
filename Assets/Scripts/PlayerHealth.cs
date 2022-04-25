using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int baseMaxHealth { private set; get; }
    [SerializeField] private int _maxHealth = 3200;
    [SerializeField] private Image _hpBar;
    [SerializeField] private float _regenerationRate = 1f;
    [SerializeField] [Range(0, 1)] private float _regenerationPower;
    private int HP;

    private IEnumerator _regeneration;

    private void Awake()
    {
        _regeneration = PassiveRegeneretion();
        HP = _maxHealth;
        baseMaxHealth = _maxHealth;
        
    }

    public void Hit(int damage)
    {
        if (damage < 0)
        {
            throw new Exception("damage is not heal");
        }
        HP -= damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        UpdateHpBar();
        StopCoroutine(_regeneration);
        _regeneration = PassiveRegeneretion();
        StartCoroutine(_regeneration);
    }

    public void AddMaxHealth(int maxHp)
    {
        _maxHealth += maxHp;
        UpdateHpBar();
    }

    public void Heal(int hp)
    {
        if (hp < 0)
        {
            throw new Exception("heal is not damage");
        }
        if (hp + HP > _maxHealth)
        {
            HP = _maxHealth;
        }
        else
        {
            HP += hp;
        }
        

        UpdateHpBar();
    }

    public virtual void UpdateHpBar()
    {
        _hpBar.fillAmount = 1f / ((_maxHealth * 1f) / HP);

    }

    private IEnumerator PassiveRegeneretion()
    {
        
        while (HP < _maxHealth)
        {
            yield return new WaitForSeconds(_regenerationRate);
            Heal(Convert.ToInt32(_maxHealth * _regenerationPower));
        }
    }


    public virtual void OnDestroy()
    {
        SceneManager.LoadScene(0);
    }
}
