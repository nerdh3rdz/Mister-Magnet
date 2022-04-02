using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreText : MonoBehaviour
{
    private Text text;
    private void Awake() => text = GetComponent<Text>();
    void Update() => text.text = ScoreManager.Instance.GetScore().ToString();
}