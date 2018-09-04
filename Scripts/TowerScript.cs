using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public float towerHealth = 100f; //Очки жизни башни
    public GameObject ball; // Снаряд
    public float AttackTime = 3; // Перезарядка орудия
    float t; // Вспомогатеельная переменная
    GameObject enemy; // Объект враг
    GameObject tower_Top; // Верхняя крутящаяся часть башни
    public GameObject gunPoint; // Точка фиксации вылета снаряда

	// Use this for initialization
	void Start ()
    {
        enemy = GameObject.Find("Skeleton"); // Поиск врага на сцене
        tower_Top = GameObject.Find("Tower_Top"); // Поиск верхней части башни
        gunPoint = GameObject.Find("Gunpoint"); // Поиск точки фиксации снаряда
        ball.transform.position = gunPoint.transform.position; // Фиксация снаряда в точке фиксации
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 dir = enemy.transform.position; // Позиция врага
        Vector3 balltDir = transform.TransformDirection(dir); 
        tower_Top.transform.rotation = Quaternion.LookRotation(dir);
        Debug.Log("Ball pos: " + ball.transform.position);
        Debug.Log("gunPoint pos: " + gunPoint.transform.position);
        if (Time.time - t > AttackTime)
        {
            ball.GetComponent<Rigidbody>().AddForce(balltDir * 7f, ForceMode.Force);
        }
        else
        {
            ball.transform.position = gunPoint.transform.position;
        }
    }
}
