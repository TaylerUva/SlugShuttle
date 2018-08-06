using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_ResetPlayerPrefs : MonoBehaviour {

    public void Delete() {
        PlayerPrefs.DeleteAll();
    }
}
