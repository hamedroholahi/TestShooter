using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform weaponPoint;
    [SerializeField] private float moveSpeed;

    
    private List<BaseWeapon> weapons = new();
    private BaseWeapon currentWeapon;
    private int currentWeaponIndex;

    private IInputHandler inputHandler;
    
    private float minX;
    private float maxX;

    public void Init()
    {
        List<WeaponData> weaponDatas = AppData.Instance.WeaponDatas;
        foreach (var data in weaponDatas)
        {
            BaseWeapon weapon = Instantiate(data.weaponPrefab, weaponPoint.position, Quaternion.identity, transform);
            weapon.Init(data.weaponType , data.damage , data.fireRate , data.coolDown , data.coolingRate , data.totalBullet , data.defaultBulletNum);
            weapon.SetActive(false);
            weapons.Add(weapon);
        }

        currentWeaponIndex = 0;
        currentWeapon = weapons[currentWeaponIndex];
        currentWeapon.SetActive(true);
        
        GameSettings.LoadSetting();
        SetControlStrategy();
        CalculateCameraBounds();
        
    }
    void SetControlStrategy()
    {
        switch (GameSettings.controlType)
        {
            case ControlType.Keyboard:
                inputHandler = new KeyboardInput();
                break;
            case ControlType.Touch:
                inputHandler = new TouchInput();
                break;
        }
    }
    private void Update()
    {
        HandleMovement();
        HandleShooting();
        HandleChangeGun();
    }
    
    void HandleMovement()
    {
        Vector2 move = inputHandler.GetMoveInput();
        Vector3 pos = transform.position;
        pos.x += move.x * moveSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }

    void HandleShooting()
    {
        if (inputHandler.IsShooting() && currentWeapon != null)
            Shoot();
    }

    void HandleChangeGun()
    {
        if (inputHandler.IsChangeGun())
        {
            ChangeGun();
        }
    }

    public void Shoot()
    {
        currentWeapon.Fire();
    }

    public void ChangeGun()
    {
        currentWeapon.SetActive(false);
            
        currentWeaponIndex = currentWeaponIndex < weapons.Count - 1 ? currentWeaponIndex+1 : 0;
        currentWeapon = weapons[currentWeaponIndex];
        currentWeapon.SetActive(true);
    }

    void CalculateCameraBounds()
    {
        Camera cam = Camera.main;
        float distance = Mathf.Abs(cam.transform.position.z - transform.position.z);

        Vector3 leftEdge = cam.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightEdge = cam.ViewportToWorldPoint(new Vector3(1, 0, distance));

        float halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        
        minX = leftEdge.x + halfWidth;
        maxX = rightEdge.x - halfWidth;
    }

    public void FullAmmoAllWapon()
    {
        foreach (var weapon in weapons)
        {
            weapon.FullAmmo();
        }
    }
}
