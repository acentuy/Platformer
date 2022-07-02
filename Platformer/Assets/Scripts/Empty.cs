using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty : MonoBehaviour
{
    public static Empty Instance { get; set; }
    private void Awake()
    {        
        Instance = this;
    }
    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
