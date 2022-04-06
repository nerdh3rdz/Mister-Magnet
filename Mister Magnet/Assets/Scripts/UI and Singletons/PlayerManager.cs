using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance = null;
    public static PlayerManager Instance
    {
        get
        {
            //there is still no instance in our game
            if (instance == null)
            {
                //Check if there is an existing game object in the scene that has the component
                instance = FindObjectOfType<PlayerManager>();
                //did not find any gameobject with the instance in the heirarchy
                if (instance == null)
                {
                    //generate our own instance by creating a new gameobject
                    GameObject go = new GameObject();
                    //change the default name
                    go.name = "PlayerManager";
                    //add component and set it as the instance
                    instance = go.AddComponent<PlayerManager>();
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
            DontDestroyOnLoad(gameObject);
        }
        //if there is copy, destroy
        else
            Destroy(gameObject);
    }

    public void ShiftGravity()
    {
        GravityScale *= -1;
        Scale = new Vector3(Scale.x, -Scale.y, Scale.z);
    }

    public float GravityScale { get; set; }

    public Vector3 Scale { get; set; }

    public void Reset()
    {
        GravityScale = 1;
        Scale = new Vector3(Scale.x, Math.Abs(Scale.y), Scale.z);
    }
}
