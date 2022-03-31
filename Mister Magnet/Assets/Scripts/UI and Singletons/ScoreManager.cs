using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int score;

    private static ScoreManager instance = null;
    public static ScoreManager Instance
    {
        get
        {
            //there is still no instance in our game
            if (instance == null)
            {
                //Check if there is an existing game object in the scene that has the component
                instance = FindObjectOfType<ScoreManager>();
                //did not find any gameobject with the instance in the heirarchy
                if (instance == null)
                {
                    //generate our own instance by creating a new gameobject
                    GameObject go = new GameObject();
                    //change the default name
                    go.name = "ScoreManager";
                    //add component and set it as the instance
                    instance = go.AddComponent<ScoreManager>();
                    //make sure the object persists
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        //set the instance if no copy in the heirarchy
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
            //if there is copy, destroy
        else
            Destroy(gameObject);
    }

    public void AddScore(int value) => score += value;

    public int GetScore() { return score; }
}