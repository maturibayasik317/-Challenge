using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int hp;
    public int attack;
    public float moveSpeed;
    public Sprite icon;

    public void Initialize(EnemyData data)
    {
        enemyName = data.enemyName;
        hp = data.baseHP;
        attack = data.baseAttack;
        moveSpeed = data.moveSpeed;
        icon = data.icon;
        // 必要に応じて他のパラメータもセット
    }
}