using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Character : MonoBehaviour, IComparable {

    [SerializeField]
    Text scoreboard;

    static int minRand = 1;
    static int maxRand = 7;

    public int MAXHP;
    public int HP;
    public int MP;
    public int STR;
    public int INT;
    public int DEF;
    public int MDEF;
    public int SPD;
    public int ActualSPD;

    Animator animation;

    public Vector3 initialPosition;
    public Vector3 destination;

    public float movementSpeed = 2f;

    protected Timer timer;

    public NextTurnEvent nextTurn = new NextTurnEvent();

    /// <summary>
    /// Awake is called before Start
    /// </summary>
    protected virtual void Awake() {
        // Player initial position
        initialPosition = transform.position;
        destination = initialPosition;

        timer = gameObject.AddComponent<Timer>();
        animation = GetComponent<Animator>();
        EventManager.AddNextTurnInvoker(this);
    }

    /// <summary>
    /// Update HP and MP UI
    /// </summary>
    protected virtual void Update() {
        scoreboard.text = "HP: " + HP + "\nMP: " + MP;
    }

    /// <summary>
    /// Attack Command
    /// </summary>
    /// <param name="enemy"></param>
    public int Attack() {
        int randParameter = UnityEngine.Random.Range(minRand, maxRand);
        int damage = (STR + randParameter);
        return damage;
    }

    /// <summary>
    /// Magic Command
    /// </summary>
    /// <param name="enemy"></param>
    /// <returns></returns>
    public int Magic() {
        if (MP < 20)
            return -1;

        int randParameter = UnityEngine.Random.Range(minRand, maxRand);
        int damage = (INT + randParameter);

        return damage;
    }

    /// <summary>
    /// Heal Command
    /// </summary>
    /// <returns></returns>
    public int Heal() {
        if (MP < 10 || HP == MAXHP)
            return -1;

        int randParameter = UnityEngine.Random.Range(minRand, maxRand);
        int value = (randParameter + INT);

        return value;
    }

    /// <summary>
    /// Attack Speed
    /// </summary>
    /// <returns></returns>
    public void AttackSpeed() {
        int randParameter = UnityEngine.Random.Range(minRand, maxRand);
        int value = (randParameter + SPD);

        ActualSPD = value;
    }

    /// <summary>
    /// Take Damage
    /// </summary>
    public void TakeDamage(int damage) {
        HP = HP - damage;
        
        if (HP <= 0) {
            HP = 0;
        }

        ChangeAnimation(Animations.Damage);
    }

    /// <summary>
    /// Reduce Mana
    /// </summary>
    public void ReduceMana(int ammount) {
        MP = MP - ammount;
    }

    /// <summary>
    /// Reduce Mana
    /// </summary>
    public void CureCharacter(int ammount) {
        HP = HP + ammount;

        if (HP > MAXHP)
            HP = MAXHP;

    }

    /// <summary>
    /// Event function implemented in Enemy and Player
    /// </summary>
    public virtual void ChooseOption() { }

    public void NextTurnTimer() {
        nextTurn.Invoke();
    }

    /// <summary>
    /// Listener
    /// </summary>
    /// <param name="listener"></param>
    public void AddNextTurnListener(UnityAction listener) {
        nextTurn.AddListener(listener);
    }

    /// <summary>
    /// Start Player Animation
    /// </summary>
    /// <param name="newAnim"></param>
    public virtual void ChangeAnimation(Animations newAnim) {
        // Start Animation Attack
        if (newAnim == Animations.Attack) {
            animation.SetBool("isMoveIn", false);
            animation.SetBool("isAttack", true);
        }
        // Start Animation Magic 
        else if (newAnim == Animations.Magic) {
            animation.SetBool("isMoveIn", false);
            animation.SetBool("isMagic", true);
        }
        // Start Animation Cure
        else if (newAnim == Animations.Cure) {
            animation.SetBool("isIdle", false);
            animation.SetBool("isCure", true);
        }
        // Start Animation Idle
        else if (newAnim == Animations.Idle) {
            animation.SetBool("isDamage", false);
            animation.SetBool("isCure", false);
            animation.SetBool("isMoveOut", false);
            animation.SetBool("isIdle", true);
        }
        // Start Animation Move In
        else if (newAnim == Animations.MoveIn) {
            animation.SetBool("isIdle", false);
            animation.SetBool("isMoveIn", true);
        }
        // Start Animation Move Out
        else if (newAnim == Animations.MoveOut) {
            destination = initialPosition;
            animation.SetBool("isAttack", false);
            animation.SetBool("isMagic", false);
            animation.SetBool("isMoveOut", true);
        }
        // Start Animation Damage
        else if (newAnim == Animations.Damage) {
            animation.SetBool("isIdle", false);
            animation.SetBool("isDamage", true);
        }
        // Start Animation Die
        else if (newAnim == Animations.Die) {
            animation.SetBool("isDamage", false);
            animation.SetBool("isDie", true);
        }
    }

    /// <summary>
    /// Check if dead animation
    /// </summary>
    public virtual void CheckIfDead() {
        if (HP == 0)
            ChangeAnimation(Animations.Die);
        else
            ChangeAnimation(Animations.Idle);
    }

    /// <summary>
    /// Attack Sound
    /// </summary>
    public virtual void AttackSound() {

    }

    /// <summary>
    /// Magic Sound
    /// </summary>
    public virtual void MagicSound() {
        AudioManager.Play(AudioName.Magic);
    }

    /// <summary>
    /// Heal Sound
    /// </summary>
    public virtual void HealSound() {
        AudioManager.Play(AudioName.Heal);
    }

    public int CompareTo(object obj) {
        if (obj == null) return 1;

        Character charac = obj as Character;
        if (charac != null) {
            if (ActualSPD < charac.ActualSPD)
                return 1;
            else if (ActualSPD == charac.ActualSPD)
                return 0;
            else
                return -1;
        }

        return -1;
    }
}
