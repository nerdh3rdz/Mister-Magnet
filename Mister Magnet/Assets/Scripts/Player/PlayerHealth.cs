using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlayerHealth : MonoBehaviour
{
    private Image playerHealthBar;
    private void Awake() => playerHealthBar = GetComponent<Image>();
    void Update() => playerHealthBar.fillAmount = HealthManager.Instance.GetHealth();
}
