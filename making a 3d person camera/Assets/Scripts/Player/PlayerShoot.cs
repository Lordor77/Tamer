using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {

    // Variables
    [SerializeField]
    GameObject Bullet;
    private float attackCoolDown_1;
    private float energyCost_1;
    private float attackCoolDown_2;
    private float energyCost_2;


    // Use this for initialization
    void Start () 
    {
        attackCoolDown_1 = 0f;//1.5f
        energyCost_1 = 5;
        attackCoolDown_2 = 0f;//2f
        energyCost_2 = 10;
    }

    // Update is called once per frame
    void Update()
    {
        // CoolDown Timers
        if (attackCoolDown_1 > 0)
        {
            attackCoolDown_1 -= Time.deltaTime;
            //GameObject.FindGameObjectWithTag("Attack_1").GetComponent<BarScript>().valueText.text = attackCoolDown_1.ToString();//Mathf.RoundToInt(
            GameObject.FindGameObjectWithTag("att_1_LoadingBar").GetComponent<Image>().fillAmount = 1 - (attackCoolDown_1 / 1.5f);
        }

        if (attackCoolDown_2 > 0)
        {
            attackCoolDown_2 -= Time.deltaTime;
            //GameObject.FindGameObjectWithTag("Attack_2").GetComponent<BarScript>().valueText.text = attackCoolDown_2.ToString();//Mathf.RoundToInt(
            GameObject.FindGameObjectWithTag("att_2_LoadingBar").GetComponent<Image>().fillAmount = 1 - (attackCoolDown_2 / 2f);
        }
        

        // Attack 1 = HeadButt
        if (this.gameObject.GetComponent<Player>().energy.CurrentVal >= energyCost_1 && Input.GetKeyDown(KeyCode.Q) && attackCoolDown_1 <= 0f)
        {
            // Jumps forward, dealing damage to whatever this object hits
            this.GetComponent<Rigidbody>().AddForce(transform.forward * 16, ForceMode.Impulse);//.AddExplosionForce(500f, this.transform.position, 500f);

            // Reducing the energy value
            this.gameObject.GetComponent<Player>().energy.CurrentVal -= energyCost_1;

            // Resets this attack's cool down
            attackCoolDown_1 = 1.5f;
        }


        // Attack 2 = Fire Ball
        if (this.gameObject.GetComponent<Player>().energy.CurrentVal >= energyCost_2 && Input.GetKeyDown(KeyCode.E) && attackCoolDown_2 <= 0f) {
            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(Bullet, this.transform.position, this.transform.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 30;

            // Reducing the energy value
            this.gameObject.GetComponent<Player>().energy.CurrentVal -= energyCost_2;

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 20.0f);

            // Resets this attack's cool down
            attackCoolDown_2 = 2f;
        }
    }
}
