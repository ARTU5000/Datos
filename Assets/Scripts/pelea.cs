using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pelea : MonoBehaviour
{
    public LevelData player;
    public LevelData Enemy;
    public Potion Busted;
    public HP Php;
    public HP Ehp;
    int totalP;
    bool IsBusted;
    public float enemylife;
    public float playerlife;
    bool defending;
    bool Hturn;
    public int counter;
    int maxcounter;


    public Button pocion;
    public Button ataque;
    public Button defensa;
    public Animator clone;
    // Start is called before the first frame update
    void Start()
    {
        player = new LevelData(1);
        Debug.Log("tu vida " + player.Vida);
        Debug.Log("tu nivel " + player.Nivel);
        Debug.Log("tu fuerza " + player.Fuerza);
        Debug.Log("tu defensa " + player.Defensa);
        Php = new HP(player.Vida);
        Enemy = new LevelData(1);
        Ehp = new HP(Enemy.Vida);
        totalP = 10;
        IsBusted = false;
        defending = false;
        Hturn = true;
        counter = 0;
        maxcounter = 10;
        pTurn();
    }

    // Update is called once per frame
    void Update()
    {
        pTurn();
        Eturn();
        life();

        if(counter >= maxcounter)
        {
            player.LevelUp();
            counter = 0;
            maxcounter *= 2;
        }
        enemylife = Ehp.Vida;
        playerlife = Php.Vida;
    }

    public void life()
    {
        if (Php.Vida <= 0)
        {
            Debug.Log("Estas Morido");
            Respawn();
        }

        if (Ehp.Vida <= 0)
        {
            Debug.Log("enemigo cayo");
            counter ++;
            Debug.Log("Haz derrotado a " + counter + "enemigos");
            NewEnemy();
        }
    }

    public void Respawn()
    {
        Php = new HP(player.Vida);

        Debug.Log("Haz volvido a la vida");
    }

    public void NewEnemy()
    {
        Random.Range(1, 6);
        Enemy = new LevelData(1);
        Ehp = new HP(Enemy.Vida);

        Debug.Log("Nuevo Enemigo Amigable");
    }

    public void Eturn()
    {
        if (Hturn == false)
        {
            Debug.Log("Turno enemigo");
            if (IsBusted == true)
            {Debug.Log("busted");
                if (defending == true)
                {Debug.Log("defending");
                    Debug.Log("te hizo " + Enemy.Fuerza/2 + "de daño");
                    Debug.Log("tu vida base " + player.Vida);
                    Debug.Log("tu vida actual" + Php.Vida);
                    IsBusted = false;
                    defending = false;
                }
                else
                {
                    Php.Vida -= Enemy.Fuerza/2;
                        Debug.Log("te hizo " + Enemy.Fuerza + "de daño");
                    Debug.Log("tu vida base " + player.Vida);
                    Debug.Log("tu vida actual" + Php.Vida);
                }
            }
            else
            {Debug.Log("not busted");

                if (defending == true)
                {Debug.Log("defending");
                    Php.Vida -= Enemy.Fuerza/2;
                    defending = false;
                    
                        Debug.Log("te hizo " + Enemy.Fuerza/2 + "de daño");
                        Debug.Log("tu vida base " + player.Vida);
                        Debug.Log("tu vida actual" + Php.Vida);
                }
                else
                {
                    Php.Vida -= Enemy.Fuerza;
                        Debug.Log("te hizo " + Enemy.Fuerza + "de daño");
                        Debug.Log("tu vida base " + player.Vida);
                        Debug.Log("tu vida actual" + Php.Vida);
                }
            }

            Hturn = true;
        }
    }

    public void pTurn()
    {
        if (Hturn == true)
        {
            Debug.Log("tu Turno");

            if(totalP > 0)
            {
                pocion.interactable = true;
            }
            else 
            {
                pocion.interactable = false;
            }
            ataque.interactable = true;
            defensa.interactable = true;
        }
        else 
        {
            pocion.interactable = false;
            ataque.interactable = false;
            defensa.interactable = false;
        }
    }

    public void Drink()
    {
        Debug.Log("Fondo fondo fondo!");
        totalP--;
        Busted = new Potion(player.Fuerza, player.Defensa);
        Debug.Log("tu fuerza " + player.Fuerza);
        Debug.Log("tu defensa " + player.Defensa);
        Debug.Log("tu superfuerza " + Busted.Fuerza);
        Debug.Log("tu superdefensa " + Busted.Defensa);
        IsBusted = true;
        
        Hturn = false;
    }

    public void Attack()
    {
        Debug.Log("Atacaste");
        if (IsBusted == true)
        {
            int a = Random.Range(0,10);
            if (a==1)
            {
                IsBusted = false;
        Debug.Log("te esquivaron");
            }
            else
            {
                Ehp.Vida -= Busted.Fuerza;
                IsBusted = false;
        Debug.Log("al enemigo le queda " + Ehp.Vida + " de vida");
            }
        }
        else
        {
            int a = Random.Range(0,5);
            if (a==1)
            {
                
        Debug.Log("te esquivaron");
            }
            else
            {
                Ehp.Vida -= player.Fuerza;
        Debug.Log("al enemigo le queda " + Ehp.Vida + " de vida");
            }
        }

        Hturn = false;
    }
    
    public void Defense()
    {
        Debug.Log("defendiendo");
        defending = true;

        Hturn = false;
    }

    public class LevelData
    {
        public int Vida;
        public int Fuerza;
        public int Defensa;
        public int Nivel;

        public LevelData(int Nivel) 
        { 
            Vida = Nivel * 10;
            Fuerza = Nivel;
            Defensa = Nivel;
            this.Nivel = Nivel;
        }

        public void LevelUp()
        {
            Nivel ++;
            Vida = Nivel * 10;
            Fuerza = Nivel;
            Defensa = Nivel;
        }
    }
    
    public struct HP
    {
        public int Vida;

        public HP(int Vida) 
        { 
            this.Vida = Vida;
        }
    }

    public struct Potion
    {
        public int Fuerza;
        public int Defensa;

        public Potion(int Fuerza, int Defensa) 
        { 
            this.Fuerza = Fuerza * 2;
            this.Defensa = Defensa * 2;
        }
    }
}