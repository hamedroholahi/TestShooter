using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseWeapon : MonoBehaviour
{
   [SerializeField] protected Transform firePoint , weapon; 
   [SerializeField] protected TMP_Text numberOfBulletText;
   [SerializeField] protected Slider cooldownSlider;

   protected float damage, fireRate, cooldown, coolingRate;
   protected Observer<float> cooldownPercent = new ();
   protected float cooldownTime;
   private int totalBullet;
   protected Observer<int> bulletNum = new();
   

   protected float time;

   protected WeaponType weaponType;


   public virtual void Init(WeaponType weaponType , float damage , float fireRate , float cooldown , float coolingRate , int totalBullet , int defaultBulletNum)
   {
      bulletNum.OnChange += UpdateTextView;
      cooldownPercent.OnChange += UpdateSliderView;
      
      this.weaponType = weaponType;
      
      this.damage = damage;
      this.fireRate = fireRate;
      this.cooldown = cooldown;
      this.coolingRate = coolingRate;
      this.totalBullet = totalBullet;
      this.bulletNum.Value = defaultBulletNum;

      
   }

      private void Update()
      {
         time += Time.deltaTime;
         
         if (cooldown == 0)
            return;
        
         cooldownTime += Time.deltaTime;
         if (cooldownTime > 1)
         {
            cooldownTime = 0;
            SetCooldown();
         }
         
      }

      public void SetActive(bool isActive)
      {
         weapon.gameObject.SetActive(isActive);
      }

      public abstract void Fire();

      public bool CanFire()
      {
         return bulletNum.Value >0 && FireRateReady() && IsFireCooldown();
      }
      public abstract bool IsFireCooldown();

      public void SetCooldown()
      {
         if (cooldownPercent.Value<= 0)
            return;
         cooldownPercent.Value -= coolingRate;
      }

      protected bool FireRateReady()
      {
         if (time >= fireRate)
         {
            time = 0;
            return true;
         }

         return false;
      }

      protected void UpdateTextView()
      {
         numberOfBulletText.SetText(bulletNum.Value + "/" + totalBullet);
      }

      protected void UpdateSliderView()
      {
         cooldownSlider.value = cooldownPercent.Value;
      }

      public void FullAmmo()
      {
         bulletNum.Value = totalBullet;
      }
}
