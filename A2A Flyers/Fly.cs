using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fly : MonoBehaviour
{
    

     float forwardSpeed = 500;
    float speedBoostFactor = 6f;
    VisualEffect trailEffect;
    float trailLifeTime;
    private float blend = 0;
    Animator animator;
    Shader shader1;
    Renderer rend;
    [SerializeField] Text text;
    [SerializeField] int numberOfCheckpoints=20;

    [SerializeField] InGameUi ingameui;
    private void Start()
    {
        
        rend = GetComponentInChildren<Renderer>();
        shader1 = Shader.Find("Shader Graphs/dissolve");
        
        animator = GetComponent<Animator>();
        trailEffect = GetComponentInChildren<VisualEffect>();
        trailLifeTime = trailEffect.GetFloat("LifeTime");
        trailEffect.SetFloat("LifeTime", 0);
        text.text = numberOfCheckpoints + " Left";
    }



    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * forwardSpeed;
        if(forwardSpeed>=50 && forwardSpeed<=180)
        transform.Rotate(-Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), -Input.GetAxis("Horizontal2"));

        if (forwardSpeed == 500)
        {
            if (transform.position.y < 400)
            {
                forwardSpeed = 50;
            }
        }

        if (Input.GetAxisRaw("Vertical") != 0)
        {
            if (blend < 0.8)
            {
                blend += 10f * Time.deltaTime;
            }
        }
        else if (blend > 0.1)
        {
            blend -= 2f * Time.deltaTime;
        }

        animator.SetFloat("Blend", blend);
    }


    public void StopBoost()
    {
        trailEffect.SetFloat("LifeTime", 0);
    }

    public void SpeedUp()
    {
        trailEffect.SetFloat("LifeTime", trailLifeTime);
        forwardSpeed += speedBoostFactor;
        animator.SetTrigger("Curl");
        numberOfCheckpoints -= 1;
        text.text = numberOfCheckpoints + " Left";

        if(numberOfCheckpoints==0)
        {
            forwardSpeed = 0;
            rend.material.shader = shader1;
            ingameui.Gamewon();
        }
    }
    public void OnTriggerEnter(Collider collider)
    {
        if ((collider.gameObject.CompareTag("Finish")))
        {
            forwardSpeed = 0;
            rend.material.shader = shader1;
            StartCoroutine(Spawn());
        }
        
    }
        IEnumerator Spawn()
        {
            while (true)
            { 
            yield return new WaitForSeconds(4);
            ingameui.GameOver();
            } 
        }

}