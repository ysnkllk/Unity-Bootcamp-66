using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = System.Numerics.Vector3;


public class playerController : MonoBehaviour{
Rigidbody2D rb;
public Vector2 haraketYonu;
private Animator charAnimator;
public bool sagaDonuk = true;

void Start(){
rb = GetComponent<Rigidbody2D>();
charAnimator = GetComponent<Animator>();}

void Update(){
if(gameObject.GetComponent<stats>().stunned==false)
GirdileriIsle();}

private void FixedUpdate(){
HaraketEt();
}

void GirdileriIsle(){
float moveX = Input.GetAxisRaw("Horizontal");
float moveY = Input.GetAxisRaw("Vertical");
haraketYonu = new Vector2(moveX, moveY).normalized;}

void HaraketEt(){
rb.velocity = new Vector2(haraketYonu.x * gameObject.GetComponent<stats>().speed, haraketYonu.y * gameObject.GetComponent<stats>().speed);charAnimator.SetFloat("playerSpeed", Mathf.Abs(rb.velocity.x));
if (rb.velocity.x < 0 && sagaDonuk && gameObject.GetComponent<stats>().stunned==false){
YuzuCevir();}
else if (rb.velocity.x > 0 && !sagaDonuk && gameObject.GetComponent<stats>().stunned==false){
YuzuCevir();}}
    
void YuzuCevir(){
sagaDonuk = !sagaDonuk;
UnityEngine.Vector3 geciciBoyutlan = transform.localScale;
geciciBoyutlan.x *= -1;
transform.localScale =  geciciBoyutlan;}

}
