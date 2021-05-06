using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacking : MonoBehaviour
{
    [SerializeField] private MeleeWeapon _meleeWeapon;

    public void Start()
    {
        InputController.Instance.Input.Player.Attacking.performed += Attack;
    }

    private void OnDestroy()
    {
        InputController.Instance.Input.Player.Attacking.performed -= Attack;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        _meleeWeapon.Attack();
    }

}
