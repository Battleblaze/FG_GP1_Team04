using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class oskButtonScript : MonoBehaviour
{
	public void Click()
	{
		string letter = (GetComponentInChildren(typeof(TMP_Text)) as TMP_Text).text;
		this.gameObject.transform.parent.parent.parent.gameObject.SendMessage("Click", letter);
	}
}
