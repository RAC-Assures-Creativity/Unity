using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
   public Animator animator;
   public Rigidbody2D rigidbody;
   public Collider2D collider;
    
   public int totalHealth = 3;
   public RectTransform heartUI;

   private int health;
   private float heartSize = 16f;

   private SpriteRenderer _renderer;

   private void Awake()
   {
        _renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }
   void Start()
   {
   	health = totalHealth;

   }
   public void AddDamage(int amount)
   {
   		health = health - amount;
   		//visual feefback
   		StartCoroutine("VisualFeedback");
   		//Game over
   		if (health <= 0){
   		    health = 0;
            animator.SetTrigger("Muerte");
            Destroy(GetComponent<MovimientoPersonaje>());
            Destroy(GetComponent<Arma>());
            gameObject.layer = 11;
            rigidbody.velocity = new Vector2(0, 1);
            Destroy(this.gameObject, 10f);
        }

   		heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);

   		Debug.Log("Player got demaged. His current health is " + health);
   }
   public void AddHealth (int amount)
   {
   		health = health + amount;

   		//Max healrth 
   		if(health > totalHealth){
   			health = totalHealth;
   		}
   		heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);

   		Debug.Log("Player got some life. His current health is " + health);
   }

   private IEnumerator VisualFeedback()
   {
   	_renderer.color = Color.red;
   	yield return new WaitForSeconds(0.1f);
   	_renderer.color = Color.white;
   }
}
