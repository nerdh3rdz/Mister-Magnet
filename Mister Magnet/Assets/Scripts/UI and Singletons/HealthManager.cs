using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100.0f,
                    currentHealth = 100.0f;

    private static HealthManager instance = null;
    public static HealthManager Instance
    {
        get
        {
            //there is still no instance in our game
            if (instance == null)
            {
                //Check if there is an existing game object in the scene that has the component
                instance = FindObjectOfType<HealthManager>();
                //did not find any gameobject with the instance in the heirarchy
                if (instance == null)
                {
                    //generate our own instance by creating a new gameobject
                    GameObject go = new GameObject();
                    //change the default name
                    go.name = "HealthManager";
                    //add component and set it as the instance
                    instance = go.AddComponent<HealthManager>();
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

    public void TakeDamage(float value) => currentHealth -= value;

    public float GetHealth() { return currentHealth / maxHealth; }
    public float GetCurrentHealth() { return currentHealth; }
}
