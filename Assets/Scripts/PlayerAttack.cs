using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private MeleeWeapon _meleeWeapon;

    public void Start()
    {
        InputController.Instance.Input.Player.Attacking.performed += Attack;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        _meleeWeapon.Attack();
    }

}
