using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2D;
	public float speed;
	public Text countText;
	private int count;
	void Start()
	{
		this.rb2D = GetComponent<Rigidbody2D>();
		this.count = 0;
		SetCountText();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(moveHorizontal,moveVertical);
		this.rb2D.AddForce(movement * this.speed); 
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("PickUp")){
			other.gameObject.SetActive(false);
			this.count +=1;
			SetCountText();
		}
	}
	void SetCountText(){
		this.countText.text = count.ToString();
	}
}
