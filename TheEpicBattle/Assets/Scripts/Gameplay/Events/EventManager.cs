using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Th event manager
/// </summary>
public static class EventManager {

    #region Fields
    static List<Character> nextTurnInvokers = new List<Character>();
    static List<UnityAction> nextTurnListeners = new List<UnityAction>();

    static List<Manager> firstTurnInvokers = new List<Manager>();
    static List<UnityAction> firstTurnListeners = new List<UnityAction>();

    static List<Player> playerActionInvokers = new List<Player>();
    static List<UnityAction<int, Actions>> playerActionListeners = new List<UnityAction<int, Actions>>();

    static List<Player> playerSelectInvokers = new List<Player>();
    static List<UnityAction<CharacterName>> playerSelectListeners = new List<UnityAction<CharacterName>>();

    static List<Enemy> enemyActionInvokers = new List<Enemy>();
    static List<UnityAction<int, Actions, CharacterName>> enemyActionListeners = new List<UnityAction<int, Actions, CharacterName>>();

    static List<Enemy> enemySelectInvokers = new List<Enemy>();
    static List<UnityAction<CharacterName>> enemySelectListeners = new List<UnityAction<CharacterName>>();
    #endregion

    #region Methods
    /// <summary>
    /// Adds the parameter as a NextTurn event invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddNextTurnInvoker(Character invoker) {
        nextTurnInvokers.Add(invoker);
        foreach (UnityAction listener in nextTurnListeners) {
            invoker.AddNextTurnListener(listener);
        }
    }

    /// <summary>
    /// Adds the parameter as a NextTurn event listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddNextTurnListener(UnityAction listener) {
        nextTurnListeners.Add(listener);
        foreach (Character invoker in nextTurnInvokers) {
            invoker.AddNextTurnListener(listener);
        }
    }

    /// <summary>
    /// Adds the parameter as a FirstTurn event invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddFirstTurnInvoker(Manager invoker) {
        firstTurnInvokers.Add(invoker);
        foreach (UnityAction listener in firstTurnListeners) {
            invoker.AddFirstTurnListener(listener);
        }
    }

    /// <summary>
    /// Adds the parameter as a FirstTurn event listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddFirstTurnListener(UnityAction listener) {
        firstTurnListeners.Add(listener);
        foreach (Manager invoker in firstTurnInvokers) {
            invoker.AddFirstTurnListener(listener);
        }
    }

    ///////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////

    /// PLAYER 

    /// <summary>
    /// Adds the parameter as a PlayerAction event invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddPlayerActionInvoker(Player invoker) {
        playerActionInvokers.Add(invoker);
        foreach (UnityAction<int, Actions> listener in playerActionListeners) {
            invoker.AddPlayerActionListener(listener);
        }
    }

    /// <summary>
    /// Adds the parameter as a PlayerAction event listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddPlayerActionListener(UnityAction<int, Actions> listener) {
        playerActionListeners.Add(listener);
        foreach (Player invoker in playerActionInvokers) {
            invoker.AddPlayerActionListener(listener);
        }
    }

    /// <summary>
    /// Adds the parameter as a PlayerSelect event invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddPlayerSelectInvoker(Player invoker) {
        playerSelectInvokers.Add(invoker);
        foreach (UnityAction<CharacterName> listener in playerSelectListeners) {
            invoker.AddPlayerSelectListener(listener);
        }
    }

    /// <summary>
    /// Adds the parameter as a PlayerSelect event listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddPlayerSelectListener(UnityAction<CharacterName> listener) {
        playerSelectListeners.Add(listener);
        foreach (Player invoker in playerSelectInvokers) {
            invoker.AddPlayerSelectListener(listener);
        }
    }

    ///////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////

    /// ENEMY 

    /// <summary>
    /// Adds the parameter as a EnemyAction event invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddEnemyActionInvoker(Enemy invoker) {
        enemyActionInvokers.Add(invoker);
        foreach (UnityAction<int, Actions, CharacterName> listener in enemyActionListeners) {
            invoker.AddEnemyActionListener(listener);
        }
    }

    /// <summary>
    /// Adds the parameter as a EnemyAction event listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddEnemyActionListener(UnityAction<int, Actions, CharacterName> listener) {
        enemyActionListeners.Add(listener);
        foreach (Enemy invoker in enemyActionInvokers) {
            invoker.AddEnemyActionListener(listener);
        }
    }

    /// <summary>
    /// Adds the parameter as a EnemySelect event invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddEnemySelectInvoker(Enemy invoker) {
        enemySelectInvokers.Add(invoker);
        foreach (UnityAction<CharacterName> listener in enemySelectListeners) {
            invoker.AddEnemySelectListener(listener);
        }
    }

    /// <summary>
    /// Adds the parameter as a EnemySelect event listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddEnemySelectListener(UnityAction<CharacterName> listener) {
        enemySelectListeners.Add(listener);
        foreach (Enemy invoker in enemySelectInvokers) {
            invoker.AddEnemySelectListener(listener);
        }
    }

    #endregion
}

