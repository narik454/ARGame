using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceletScript : MonoBehaviour
{
    public float sceletHealth = 40f; // Очки жизни скелетона
    public TowerScript towerScript; // Подключение другого скрипта
    public Collider tower; // Объект, к которому будут двигаться скелетоны
    float speed = 0.8f; // Скорость скелетона
    bool touchTower = false; // Проверка соприкосновения башни и скелетона
    bool towerDest = false; // Проверка уничтожения башни
    Animator animator; // Подключение анимации
    GameObject center;
    bool touchBall = false; // Проверка попадания снаряда

    // Use this for initialization
    void Start () // Метод, который выполняется при старте сцены
    {
        animator = GetComponent<Animator>();
        center = GameObject.Find("Tower"); // Поиск на сцене объекта с именем Tower
    }

    // Update is called once per frame
    void Update() // Метод, который вызывается один раз за кадр
    {
        if (touchTower == false && towerDest == false)
        {
            animator.Play("Walk"); // Проигрывание анимации движения
            Vector3 dir = center.transform.position; // Получение координат башни
            transform.LookAt(dir); // Направление взгляда скелетона в сторону башни
            transform.position += (tower.transform.position - transform.position).normalized * speed * Time.deltaTime; // Движение скелетона в сторону башни
        }

        if (touchTower) // При соприкосновении с башней
        {
            animator.Play("Attack"); // Проигрывание анимации атаки
            towerScript.towerHealth -= 3f * Time.deltaTime; // Отнимаем очки жизни башни
            if (towerScript.towerHealth <= 0) // Если очки жизни башни <= 0
            {
                towerScript.gameObject.SetActive(false);
                towerDest = true;
                touchTower = false;
                animator.Play("Stand"); // Проигрывание анимации покоя
                Debug.Log("Tower destroyed");
            }
            Debug.Log(towerScript.towerHealth);
        }

        if (sceletHealth <= 0) // Если очки жизни скелетона <= 0
        {
            Debug.Log("Scelet dead");
            gameObject.SetActive(false); // Скрываем объект скелетон
        }
    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.gameObject.name == "Ball")
    //    {
    //        touchBall = true;
    //        Debug.Log("Touch Ball!!!!!!!!!!!!!!!!");
    //    }
    //}

    private void OnTriggerEnter(Collider other) // Метод, который выполняется при соприкосновении башни и скелетона
    {
        if (other.gameObject.name == "Tower")
        {
            touchTower = true;
            Debug.Log("Touch Tower");
        }
    }
}
