using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class scr : MonoBehaviour
{
    public Text p_s;
    public Text CoinsA;
    public Text PotatoA;
    public int potatos;
    
    public int coins;
    
    public bool reds;

    public int multiplier;
    public int pc;

    void Start()
    {
        multiplier=PlayerPrefs.GetInt("multiplier",1);
        potatos=PlayerPrefs.GetInt("potatos",0);
        coins=PlayerPrefs.GetInt("coins",0);
        pc=PlayerPrefs.GetInt("pc",1);
        
    }

    // Update is called once per frame
    void Update()
    {
        PotatoA.text=""+potatos;
        CoinsA.text=""+coins;
        p_s.text="Potato/S: "+pc;

         if(potatos<=0){
        StopCoroutine("ptoc");
       }else  StartCoroutine("ptoc"); 
    }

     

    //transforma batatas em moedas
      IEnumerator ptoc() {
         while(potatos>0){
         yield return new WaitForSeconds(1.0f); 
         potatos-=multiplier;
         coins+=multiplier; 
        PlayerPrefs.SetInt("potatos",potatos);
        PlayerPrefs.SetInt("coins",coins);
        PlayerPrefs.SetInt("pc",pc);
       }
       if(potatos<=0){
           StopCoroutine("ptoc");
       }
     }
 

    


       public void reset  (){
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("SampleScene");
        }

    //transforma batatas em moedas
      
     

    //quando clica na batata ganha 1 batata
    public void Click()
    {
        potatos +=multiplier;
        PlayerPrefs.SetInt("potatos",potatos);
    }

  
    //loja
    public void buy(int num){
        //aumenta a quatidade de coins pot batata
        if (num == 1 && coins>=100){
            multiplier +=1;
            coins-=100;
            PlayerPrefs.SetInt("coins",coins);
            PlayerPrefs.SetInt("multiplier",multiplier);
        if(num==2 && coins>=100){
            pc +=1;
            coins-=100;
            PlayerPrefs.SetInt("coins",coins);
            PlayerPrefs.SetInt("multiplier",pc);
        }
        }
    }
}

