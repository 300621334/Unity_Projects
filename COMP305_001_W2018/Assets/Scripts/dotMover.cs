using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.EventSystems;


public class dotMover : MonoBehaviour{



	Vector3 target, targetOnBtnClk;
	public GameObject point, btnMoveDotonPts;
	public float speed, speedOnBtnClk, waitAftEaMove;
	bool move, isMouseOverUIelement;
	List<Vector3> coordsList, copyList;
	Rigidbody rb;


	// Use this for initialization
	void Start () {
		coordsList = new List<Vector3> ();
		copyList = new List<Vector3> ();
		rb = GetComponent<Rigidbody> ();
		btnMoveDotonPts.SetActive (false);
		transform.position = Vector3.zero;
		target = transform.position;
	}

	//add to script for btns: chk if mouse over a btn or not: 
//	void OnMouseEnter()
//	{
//		isMouseOverUIelement = true;
//	}
//	void OnMouseExit()
//	{
//		isMouseOverUIelement = false;
//	}
	
	// Update is called once per frame
	void Update () {
		copyList = coordsList;
		//https://www.youtube.com/watch?v=26qF22kg9MA
		//MUST use "UP" or else MANY clks registered
		//https://forum.unity.com/threads/preventing-ugui-mouse-click-from-passing-through-gui-controls.272114/
		if(Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject()/*clk passing thru btn so 2 clks register!!! && !ChkForMouseOver.isMouseOverUIelement*/ /*&& (Camera.main.WorldToScreenPoint(Input.mousePosition) != GameObject.FindGameObjectWithTag("btn").transform.position)*/)
		{
			//ignore duoble-clk on same spot
			//if(target != Camera.main.ScreenToWorldPoint (Input.mousePosition))
			//{
				Debug.Log("Mouse Click At"+ Input.mousePosition);
				target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				target.z = transform.position.z;

				//move= move?false:true;
				move = true;
				Instantiate (point , target , Quaternion.identity);
				coordsList.Add (target);
				Debug.Log ("Target coords" + target);
			//}

		}

		/*Bcoz same clk causes Lict<> to add an item while btnClk_moveDot uses same List<> at the same clk, hence error:
		 * InvalidOperationException: Collection was modified; enumeration operation may not execute.
		https://forum.unity.com/threads/invalidoperationexception-collection-was-modified-enumeration-operation-may-not-execute.252443/*/

		//spontaneously move inclk direction
		//if(move)
		//{
			//transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		//}



		//make btn visible after 3 dots placed
		var clones = GameObject.FindGameObjectsWithTag ("yellowPoint");
		if(clones.Length >= 3)
		{
			btnMoveDotonPts.SetActive (true);
		}

	}


	public void btnClk_moveDot()
	{
		
		StartCoroutine(moveDot());

		Debug.Log ("ALL coords" + coordsList.ToString());
		//var clones = GameObject.FindGameObjectsWithTag ("yellowPoint");
		//foreach (var point in clones) 

	}

	IEnumerator moveDot()
	{
		
		foreach (var pos in copyList.GetRange(0, copyList.Count))//create a copy of list
		{
			//targetOnBtnClk = point.transform.position;
			Debug.Log ("Move coords" + pos);
			while(transform.position != pos)
			{
				yield return new WaitForSeconds (waitAftEaMove);//slow down move
				transform.position = Vector3.MoveTowards(transform.position, pos, speedOnBtnClk * Time.deltaTime);//moves only for some distance
			}
			//transform.position = Vector3.Lerp(transform.position, pos, speedOnBtnClk);
			//transform.position = pos;//works
			//yield return new WaitForSeconds (waitAftEaMove);
		}
	}

	public void btnClk_deleteAllPoints()
	{
		var clones = GameObject.FindGameObjectsWithTag ("yellowPoint");
		foreach (var point in clones) 
		{
			Destroy (point);
		}

		//Thread.Sleep (500);//should be in dotMover script
		GameObject.FindGameObjectWithTag ("dot").transform.position = Vector3.zero;
		coordsList.Clear ();
		copyList.Clear ();
	}



}
