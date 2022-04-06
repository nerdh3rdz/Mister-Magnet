using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMP : Obstacle
{
    private bool IsExplode = false;
    private Animator glow;
    private CircleCollider2D emp;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        glow = transform.GetChild(0).GetComponent<Animator>();
        emp = GetComponent<CircleCollider2D>();
    }

    protected override void Update()
    {
        base.Update();

        if(!IsOff)
            glow.SetBool("IsExplode", IsExplode);

        if(IsOff && transform.childCount >= 1)   //stop the glow animation if emp is deactivated
            Destroy(transform.GetChild(0).gameObject);

        emp.enabled = !IsOff;   //Disable collider when emp is deactivated
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsOff && collision.gameObject.tag == "Player")
        {
            transform.GetChild(1).gameObject.SetActive(true);
            StartCoroutine(IsExploding());  //Play exploding animation once
        }
    }

    private IEnumerator IsExploding()
    {
        yield return new WaitForSeconds(0.45f);
        transform.GetChild(1).gameObject.SetActive(false);
    }
}
