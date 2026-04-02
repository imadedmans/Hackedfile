using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptReference : MonoBehaviour {}

//WELCOME TO THE SCRIPT REFERENCE, INCLUDES THE MORE FUNDMENTAL FUNCTIONS FOR GENERAL AND SPECIFIC PURPOSES

//Getting a component within an object - COMPONENTNAME cn = GetComponent<COMPONENTNAME>();
//Getting a component within the parent of an object - COMPONENTNAME cn = GetComponentInParent<COMPONENTNAME>();
//Getting a component within the children of an object (singular function) - COMPONENTNAME cn = GetComponentInChildren<COMPONENTNAME>();
//Getting components within an object - COMPONENTNAME[] cn = GetComponents<COMPONENTNAME>();
//Getting components within an object's parent - COMPONENTNAME[] cn = GetComponentsInParent<COMPONENTNAME>();
//Getting a component within an object children (array fucntion) - COMPONENTNAME[] cn = GetComponentsInChildren<COMPONENTNAME>();

//Finding an single object by name - GameObject gm = GameObject.Find("OBJECTNAME")
//Finding an single object by tag - GameObject gm = GameObject.FindWithTag("OBJECTTAG")
//Finding multiple objects by tag - GameObject[] gm = GameObject.FindGameObjectsWithTag("OBJECTTAG")

//Getting a component from another object - COMPONENTNAME cn = FindObjectOfType<COMPONENTNAME>();
//Getting a component from other objects (array function) - COMPONENTNAME[] cns = FindObjectsOfType<COMPONENTNAME>();
//Creating an object based on preexisting prefab - Instantiate(OBJECTHERE, PLACESPAWNINGOBJECT.position, PLACESPAWNINGOBJECT.rotation);
//Destroying an object based on preexisting prefab - Destroy(OBJECTNAME);

//Variable to see if object if active in scene - OBJECTNAME.activeInHierarchy (property)
//Variable to see tag of object - OBJECTNAME.tag (property)

//Moving an object with Transform(vector) - Transform.Translate(new Vector2(x * Time.deltaTime, y * Time.deltaTime))
//Moving an object with Transform(specific direction) - Transform.Translate(Vector2.direction * Time.deltaTime)
//Moving an object with Rigidbody(vector) - Rigidbody2D.velocity = new Vector2(x * Time.deltaTime, y * Time.deltaTime)
//Moving an object with Rigidbody(specific direction) - Rigidbody2D.velocity = Vector2.direction * Time.deltaTime

//Variable for refering to the the object itself - this.gameObject

//Infering to collision upon first frame - void OnCollisionEnter2D(Collision2D col)
//Infering to collision upon lingering for multiple frames - void OnCollisionStay2D(Collision2D col)
//Infering to collision exiting - void OnCollisionExitD(Collision2D col)
//Infering to trigger collision upon first frame - void OnTriggerEnter2D(Collider2D col)
//Infering to trigger collision upon lingering for multiple frames - void OnTriggerStay2D(Collider2D col)
//Infering to trigger collision exiting - void OnTriggerExitD(Collider2D col)

//Simple timer variable (in Enumerator methods) - yield return new WaitForSeconds(TIMEVARIABLE);
