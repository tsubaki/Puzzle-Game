using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public enum BallColorType
	{
		Red = 0,
		Yello = 1,
		Blue = 2,
		Green = 3,
		White = 4,
		Gray = 5
	}

	BallColorType m_color;

	public BallColorType BallColor {
		get{	return m_color; }
		set{	ChangeColor(value); }
	}

	void ChangeColor(BallColorType color)
	{
		switch( color)
		{
		case BallColorType.Blue:	renderer.material.color = Color.blue; 	break;
		case BallColorType.Red:		renderer.material.color = Color.red;	break;
		case BallColorType.Yello:	renderer.material.color = Color.yellow;	break;
		case BallColorType.Green:	renderer.material.color = Color.green;	break;
		case BallColorType.White:	renderer.material.color = Color.white;	break;
		case BallColorType.Gray:	renderer.material.color = Color.gray;	break;
		}
		m_color = color;
	}

	void Start()
	{
		ChangeRandomColor();
	}

	public void ChangeRandomColor()
	{
		BallColor = (BallColorType)Random.Range(0, 4);
	}
}
