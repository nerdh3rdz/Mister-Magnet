using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1.50f);
        gameObject.SetActive(false);
    }
}
