using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChkForMouseOver : MonoBehaviour {

	public static bool isMouseOverUIelement;

	//chk if mouse over a btn or not: https://answers.unity.com/questions/205631/detect-mouse-clicks-anywhere-on-the-screen-except.html
		void OnMouseEnter()
		{
			isMouseOverUIelement = true;
		}
		void OnMouseExit()
		{
			isMouseOverUIelement = false;
		}


}
