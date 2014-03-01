using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchControll : MonoBehaviour
{

	public Camera m_targetCamera;
	public LineRenderer m_lineRenderer;

	private BallController.BallColorType m_currentBallColor;
	private List<BallController> m_ballList = new List<BallController> ();
	private BallController m_currentTouchBall;

	void Start()
	{
		m_targetCamera = Camera.main;
	}

	void Update ()
	{
		DrawLine();

		if (Input.GetMouseButtonUp (0)) {
			RemoveBalls ();
		}

		if (Input.GetMouseButton (0)) {
			var position = m_targetCamera.ScreenToWorldPoint (Input.mousePosition);
			var hit = Physics2D.OverlapCircle (position, 0.1f);

			if (hit == null)
				return;

			var ball = hit.GetComponent<BallController> ();

			if (Input.GetMouseButtonDown (0) && hit.CompareTag ("Ball")) {
				m_currentBallColor = ball.BallColor;
				m_currentTouchBall = ball;
				m_ballList.Add (ball);
			} else {
				if (m_currentTouchBall == ball) {
					return;
				}

				if (hit.CompareTag ("Ball") && !m_ballList.Exists ((item) => item == ball) && ball.BallColor == m_currentBallColor) {
					m_ballList.Add (ball);
					m_currentTouchBall = ball;
				} else {
					RemoveBalls ();
				}
			}
		}
	}

	void DrawLine()
	{	
		m_lineRenderer.SetVertexCount (m_ballList.Count);
		int i = 0;
		foreach (var item in m_ballList) {
			m_lineRenderer.SetPosition (i, item.transform.position + m_targetCamera.transform.forward * -4);
			i++;
		}
	}

	void RemoveBalls ()
	{
		if (m_ballList.Count > 2) {
			foreach (var item in m_ballList) {
				item.transform.position += Vector3.up * 20;
				item.ChangeRandomColor ();
			}
		}
		m_ballList.Clear ();

		m_lineRenderer.SetVertexCount (0);
	}
}
