using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	const float MAX_VELOCITY = 100;
	const float MAX_DRAG_DISTANCE = 50;

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

	public void OnTriggerEnter2D(Collider2D c)
	{
		if (c.tag == "Garbage") {
			var g = c.GetComponent<GarbageController>();
			g.hp--;
			if (g.hp <= 0) {
				//ポイント追加して削除
				GameManager.instance.point += g.point;
				GameManager.instance.AddBusgerGarbages(g.gameObject);
				Destroy(g.gameObject);
			}
		}
	}

	public void OnBeginDrag(PointerEventData data)
	{
		if (isSnap) return;
		dragStartPos = data.position;
	}

	public void OnDrag(PointerEventData data)
	{
	}

	public void OnEndDrag(PointerEventData data)
	{
		if (isSnap) return;
		isSnap = true;

		float diff = Vector2.Distance(dragStartPos, data.position);
		float rate = diff / MAX_DRAG_DISTANCE;
		var vel = dragStartPos - data.position;

		rigid.velocity = vel * rate;

		Debug.Log(vel.ToString());
	}
}
