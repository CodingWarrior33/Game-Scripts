using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class conversation : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] all_sentences;
    public int pos;
    public GameObject next;
    public GameObject finish;
    public TMP_InputField input;


    private string textinp;
    public GameObject player1;
    public GameObject player2;
    bool done = false;
    public ParticleSystem ps2;

    /*public ParticleSystem b1_p;
    public ParticleSystem b2_p;
    public ParticleSystem b3_p;
    public ParticleSystem b4_p;
    */

    public SpriteRenderer b1;
    public SpriteRenderer b2;
    public SpriteRenderer b3;
    public SpriteRenderer b4;


    Scene sc;
    private void Awake()
    {
        sc = SceneManager.GetActiveScene();
    }
    public void Start()
    {
       
        StartCoroutine(Print());
        input.enabled = false;
        input.gameObject.SetActive(false);
    }
    public void ReadInp(string str)
    {
        textinp = str;
        textinp=textinp.ToUpper();
        if(textinp=="ALONE")
        {
            Destroy(input.gameObject);
            done = true;            
        }
    }

   public IEnumerator Print()
    {
        foreach(char e in all_sentences[pos].ToCharArray())
        {
            text.text += e;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void Update()
    {
        
        if (!done)
        {
            if (sc.name == "SampleScene1")
            {
                if (pos == 1)
                {
                    next.SetActive(false);
                    input.gameObject.SetActive(true);
                    input.enabled = true;
                    player1.GetComponent<player_movement>().enabled = false;
                    player2.GetComponent<player_movement>().enabled = false;
                }
            }
        }
        if(text.text==all_sentences[pos])
        {
            
            if (sc.name=="SampleScene")
            {
                next.SetActive(true);
            }
            if (sc.name == "SampleScene1")
            {
                if (pos != 1)
                {
                    next.SetActive(true);
                }
                if (pos == 3)
                {
                    next.SetActive(false);
                }
                if (pos == 1 && done == true)
                {
                    next.SetActive(true);
                }
                if (pos == 3 && ps2.isPlaying)
                {
                    next.SetActive(true);
                }

                if (pos >= 5)
                {
                    b1.gameObject.SetActive(true);
                    b2.gameObject.SetActive(true);
                    b3.gameObject.SetActive(true);
                    b4.gameObject.SetActive(true);

                }
                else
                {
                    b1.gameObject.SetActive(false);
                    b2.gameObject.SetActive(false);
                    b3.gameObject.SetActive(false);
                    b4.gameObject.SetActive(false);
                }

                /*if(b1_p.isPlaying && b2_p.isPlaying && b3_p.isPlaying && b4_p.isPlaying)
                {
                    SceneManager.LoadScene("final_menu");
                }*/
            }
            
            /*if(pos==1)
            {
                next.SetActive(false);
            }
            else
            {
                next.SetActive(true);
            }*/
        }
    }
    public void sentence()
     {
        next.SetActive(false);
        
         if(pos<all_sentences.Length-1)
         {
             pos++;
             text.text = "";
             StartCoroutine(Print());
         }
         else
         {
             text.text = "";
            Destroy(finish);
         }
     }
   
    
    


}


