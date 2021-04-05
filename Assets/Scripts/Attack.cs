using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] int damagePower;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Status _status;
        if (collision.transform.TryGetComponent(out _status))
        {
            _status.Damaged(damagePower);
        }
    }
}
