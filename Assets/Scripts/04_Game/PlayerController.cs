using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using GarbageType = GarbageController.GarbageType;

public class PlayerController : MonoBehaviour {
	public Achievement achievement;
	const float MAX_VELOCITY = 100;
	const float MAX_DRAG_DISTANCE = 50;

	public GameObject arrow;

	private Vector2 FirstPos;

	private Rigidbody2D rigid;
	private Vector2 dragStartPos;
	private bool isSnap = false;

	// Use this for initialization
	void Start()
	{
		//イベント登録
		EventTrigger trigger = GetComponent<EventTrigger>();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.BeginDrag;
		entry.callback.AddListener((data) => { OnBeginDrag((PointerEventData)data); });
		trigger.triggers.Add( entry );

		entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.Drag;
		entry.callback.AddListener((data) => { OnDrag((PointerEventData)data); });
		trigger.triggers.Add( entry );

		entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.EndDrag;
		entry.callback.AddListener((data) => { OnEndDrag((PointerEventData)data); });
		trigger.triggers.Add( entry );

		//リジッドボディ登録
		rigid = GetComponent<Rigidbody2D>();

		//初期値登録（以後書き換えない）
		FirstPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (isSnap) {
			if (Mathf.Abs(Vector2.Distance(rigid.velocity, Vector2.zero)) < 50) {
				rigid.velocity = Vector2.zero;
				GameManager.instance.playCount++;
				if (GameManager.instance.CheckEndPlayCount()) {
					//ゲームエンド

					Debug.Log("EndPlay");
				}
				else {
					isSnap = false;
					Debug.Log("NextPlay");
				}
			}
		}
	}

	public void OnCollisionEnter2D(Collision2D c)
	{
		CASoundManager.instance.playSe(CASoundManager.SE.REFLECT);
	}

	public void OnTriggerEnter2D(Collider2D c)
	{
		if (c.tag == "Garbage") {
			var g = c.GetComponent<GarbageController>();
			if (g.type == GarbageType.B) {
				Reflection();
			}
			else if (g.type == GarbageType.C && g.hp > 1) {
				Reflection();
			}
			else if (g.type == GarbageType.D) {
				rigid.velocity = Vector2.zero;
				gameObject.transform.position = FirstPos;
				return;
			}
			else {
				CASoundManager.instance.playSe(CASoundManager.SE.GARBAGE);
			}

			g.hp--;
			if (g.hp <= 0) {
				//ポイント追加して削除
				GameManager.instance.point += g.point;
				GameManager.instance.AddBusgerGarbages(g.gameObject);
				Destroy(g.gameObject);
			}
		}
		else {
			CASoundManager.instance.playSe(CASoundManager.SE.REFLECT);
		}
	}

	public void OnBeginDrag(PointerEventData data)
	{
		if (!IsPlaying()) return;
		dragStartPos = data.position;
	}

	public void OnDrag(PointerEventData data)
	{
		if (!IsPlaying()) return;
		if (!arrow.activeSelf) {
			arrow.SetActive(true);
		}
		var vel = dragStartPos - data.position;
		arrow.transform.rotation = Quaternion.AngleAxis((Mathf.Atan(vel.y / vel.x) / Mathf.PI * 180) + ((vel.x < 0) ? 180 : 0), Vector3.forward);
	}

	public void OnEndDrag(PointerEventData data)
	{
		if (!IsPlaying()) return;
		isSnap = true;
		arrow.SetActive(false);

		float diff = Vector2.Distance(dragStartPos, data.position);
		float rate = diff / MAX_DRAG_DISTANCE;
		var vel = dragStartPos - data.position;

		rigid.velocity = vel * rate;

		Debug.Log(vel.ToString());
	}

	protected bool IsPlaying()
	{
		return !(isSnap || GameManager.instance.gameState != GameManager.State.Playing);
	}

	protected void Reflection()
	{
		Debug.Log("Reflection");
		CASoundManager.instance.playSe(CASoundManager.SE.REFLECT);
		var tmp = rigid.velocity;
		if ((Mathf.Abs(tmp.x) - Mathf.Abs(tmp.y)) > 0) {
			tmp.x *= -1;
		}
		else {
			tmp.y *= -1;
		}
		rigid.velocity = tmp;
	}
}
