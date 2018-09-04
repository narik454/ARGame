using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float Damage = 20f; // Очки урона
    public SceletScript sceletScript; // Подключение другого скрипта
    //public TowerScript towerScript;
    GameObject ball; // Объект снаряд
    bool touchScelet = false; // Проверка попадания во врага

	void Start ()
    {
        //enemy = GameObject.Find("Sceleton");

    }

	void Update ()
    {
        
	}

    private void OnTriggerEnter(Collider other) // Метод, выполняемый при соприкосновении с определённым объектом
    {
        if (other.CompareTag("Sceleton"))
        {
            sceletScript = other.GetComponent<SceletScript>();
            touchScelet = true;
            sceletScript.sceletHealth -= Damage; // Вычитание очков жизни врага
            gameObject.SetActive(false); // Скрытие объекта
            Debug.Log("Touch Sceleton!!!!");
        }
    }
}
