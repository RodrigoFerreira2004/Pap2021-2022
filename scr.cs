using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class scr : MonoBehaviour
{

    
    public Text p_s;//quatidade de batatas por segundo
    public Text v_s;//quantidade de batatas que vende por segundo
    public Text CoinsA;//quantidade de batatas moedas
    public Text PotatoA;//quantidade de batatas armazendas
//
    public Button reb;
    public int potatos;
    
    public int coins;
    
    public bool reds;
    public int RebirthCoin;
    public int multiplier;
    public int pc;
    public float HowManyTime ;
    public int HMR;

    public float rebirthcost;
    //public int 
    void Start()
    {
        multiplier=PlayerPrefs.GetInt("multiplier",1);//salva a variavel mulpilier
        potatos=PlayerPrefs.GetInt("potatos",0);//salva a variavel potatos
        coins=PlayerPrefs.GetInt("coins",0);//salva a variavel coins
        pc=PlayerPrefs.GetInt("pc",1);//salva a variavel pc
        RebirthCoin=PlayerPrefs.GetInt("RebirthCoin",0);
        rebirthcost=1000000;
    }

    // Update is called once per frame
    void Update()
    {
        PotatoA.text=""+potatos; //atualiza o contador de batatas 
        CoinsA.text=""+coins; //atualiza o contador de coins
        p_s.text="Potato/S: "+pc; //atualiza o texto que informa a quantdade de batatas que o jogador ganha por click
        //Inicia a função que a cada segundo transforma uma batata em uma moeda
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
      }
       
    

    //Função para o jogador resetar o seu progresso
       public void reset  (){
           if(coins>=rebirthcost){
           // PlayerPrefs.DeleteAll();
           // SceneManager.LoadScene("SampleScene");
            HMR=HMR+1;
            RebirthCoin+=1;
            coins-=rebirthcost;
            rebirthcost=rebirthcost*2;
            PlayerPrefs.SetInt("HMR",HMR);
            PlayerPrefs.SetFloat("rebirthcost",rebirthcost);
            PlayerPrefs.DeleteKey(potatos);   
            }
            else
            {
            reb.interactable=false;
            }

        }

    //quando clica na batata ganha 1 batata
    public void Click()
    {
        potatos +=multiplier;
        PlayerPrefs.SetInt("potatos",potatos);
    }

    //loja
    public void buy(int num){
        //upgrade que aumenta a quatidade de coins por batata
        if (num == 1 && coins>=100){
            multiplier +=1;
            coins-=100; 
            PlayerPrefs.SetInt("coins",coins);
            PlayerPrefs.SetInt("multiplier",multiplier);
            //upgrade para vendr mais batatas por segundo
        if(num==2 && coins>=100){
            pc +=1;
            coins-=100;
            PlayerPrefs.SetInt("coins",coins);
            PlayerPrefs.SetInt("multiplier",pc);
        }
        }
    }
    public void rebirthshop(int rebi){
            
        if (rebi==1 && RebirthCoin>=3){
            multiplier +=10;
            RebirthCoin-=3;

        }
    }
    public void hb(){
        
    }
}