using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScript : MonoBehaviour {

    Player player;

    [SerializeField]
    GameObject btn1;

    [SerializeField]
    GameObject btn2;

    [SerializeField]
    GameObject btn3;

    /// <summary>
    /// On Enable
    /// </summary>
    void OnEnable() {
        if (Options.PlayerDifficult == Difficult.Easy) {
            btn2.active = false;
            btn3.active = false;

        } 
        else if (Options.PlayerDifficult == Difficult.Normal) { 
            btn3.active = false;
            Enemy enemy1 = GameObject.FindGameObjectWithTag("Enemy1").GetComponent<Enemy>();
            Enemy enemy2 = GameObject.FindGameObjectWithTag("Enemy2").GetComponent<Enemy>();
            
            if (enemy1.HP == 0)
                btn1.active = false;
            if (enemy2.HP == 0)
                btn2.active = false;
        }
        else {
            Enemy enemy1 = GameObject.FindGameObjectWithTag("Enemy1").GetComponent<Enemy>();
            Enemy enemy2 = GameObject.FindGameObjectWithTag("Enemy2").GetComponent<Enemy>();
            Enemy enemy3 = GameObject.FindGameObjectWithTag("Enemy3").GetComponent<Enemy>();

            if (enemy1.HP == 0)
                btn1.active = false;
            if (enemy2.HP == 0)
                btn2.active = false;
            if (enemy3.HP == 0)
                btn3.active = false;
        }
    }


    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    /// <summary>
    /// Enemy 1 Action
    /// </summary>
    public void Enemy1Action() {
        AudioManager.Play(AudioName.Menu);
        player.Enemy1();
    }

    /// <summary>
    /// Enemy 2 Action
    /// </summary>
    public void Enemy2Action() {
        AudioManager.Play(AudioName.Menu);
        player.Enemy2();
    }

    /// <summary>
    /// Enemy 3 Action
    /// </summary>
    public void Enemy3Action() {
        AudioManager.Play(AudioName.Menu);
        player.Enemy3();
    }
}
