using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScript : MonoBehaviour {

    Player player;
    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    /// <summary>
    /// Attack
    /// </summary>
    public void Attack() {
        AudioManager.Play(AudioName.Menu);
        player.AttackEnemy();
    }

    /// <summary>
    /// Magic
    /// </summary>
    public void Magic() {
        AudioManager.Play(AudioName.Menu);
        player.MagicEnemy();
    }

    /// <summary>
    /// Cure
    /// </summary>
    public void Cure() {
        AudioManager.Play(AudioName.Menu);
        player.SelfHeal();
    }
}
