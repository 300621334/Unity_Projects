using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyLab5 : MonoBehaviour {

    public void MakeThisIndestructible()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
