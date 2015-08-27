using UnityEngine;

public class GenerateObject : MonoBehaviour
{
	public GameObject item;
	public float position = 0.35f;
	public float var = 0.1f;
	public float StartTime = 1;
	public float RepeatTime = 1;
	public float difUnit = 1f;

	private Score _score;
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateItems", StartTime, RepeatTime);
		//_score = GameObject.FindGameObjectWithTag ("Score").GetComponent<Score> ();
	}
	
	void CreateItems()
	{
		float pos = ((Random.value >= 0.5f) ? position : -position);
		GameObject bomb = gameObject.GetComponent<GetRandomObject>().GetRandomThreatObject ();
		int r = Random.Range (1, 10);
		switch (r) { // [min, max[
		case (1): // 1 bomb
			Instantiate(bomb, transform.position + ( Vector3.right * pos ), transform.rotation);
			break;
		case (2): // 1 Item
			Instantiate(item, transform.position + ( Vector3.right * pos ), transform.rotation);
			break;
		case (3): // 1 center bomb
			Instantiate(bomb, transform.position, transform.rotation);
			break;
		case (4): // 1 center Item
			Instantiate(item, transform.position, transform.rotation);
			break;
		case (5): // 1 bomb, 1 Item, 1 bomb
			Instantiate(bomb, transform.position + ( Vector3.right * pos ), transform.rotation);
			Instantiate(item, transform.position + ( Vector3.right * pos ) + ( Vector3.up * 3 * difUnit ), transform.rotation);
			Instantiate(bomb, transform.position + ( Vector3.right * pos ) + ( Vector3.up * 6 * difUnit ), transform.rotation);
			break;
		case (6): // 1 Item, 1 bomb
			Instantiate(item, transform.position + ( Vector3.right * pos ), transform.rotation);
			Instantiate(bomb, transform.position - ( Vector3.right * pos ), transform.rotation);
			break;
		case (7): // 1 Item, 1 (Other side) bomb
			Instantiate(item, transform.position + ( Vector3.right * pos ), transform.rotation);
			Instantiate(bomb, transform.position - ( Vector3.right * pos ) + ( Vector3.up * 5 * difUnit ), transform.rotation);
			break;
		case (8): // 1 bomb, 1 item (Other side), 1 bomb (Other side)
			Instantiate(bomb, transform.position + ( Vector3.right * pos ), transform.rotation);
			Instantiate(item, transform.position - ( Vector3.right * pos ) + ( Vector3.up * 3.5f * difUnit ), transform.rotation);
			Instantiate(bomb, transform.position - ( Vector3.right * pos ) + ( Vector3.up * 7 * difUnit ), transform.rotation);
			break;
		case (9): // 1 bomb lines, item (other side)
			Instantiate(bomb, transform.position + ( Vector3.right * pos ), transform.rotation);
			Instantiate(bomb, transform.position + ( Vector3.right * pos/2 ) + ( Vector3.up * 1 * difUnit ), transform.rotation);
			Instantiate(bomb, transform.position + ( Vector3.up * 2 * difUnit ), transform.rotation);
			Instantiate(bomb, transform.position - ( Vector3.right * pos/2 ) + ( Vector3.up * 3 * difUnit ), transform.rotation);
			Instantiate(item, transform.position - ( Vector3.right * pos ) + ( Vector3.up * 4 * difUnit ), transform.rotation);
			break;
/*
		case (10): // many bombs center, item sides
			Instantiate(bomb, transform.position, transform.rotation);
			Instantiate(bomb, transform.position +  ( Vector3.up * 1 * difUnit ), transform.rotation );
			Instantiate(bomb, transform.position +  ( Vector3.up * 2 * difUnit ), transform.rotation );
			Instantiate(bomb, transform.position +  ( Vector3.up * 3 * difUnit ), transform.rotation );
			Instantiate(bomb, transform.position +  ( Vector3.up * 4 * difUnit ), transform.rotation );
			Instantiate(bomb, transform.position +  ( Vector3.up * 5 * difUnit ), transform.rotation );
			Instantiate(item, transform.position - ( Vector3.right * pos ) + ( Vector3.up * 5 * difUnit ), transform.rotation);
			Instantiate(item, transform.position + ( Vector3.right * pos ) + ( Vector3.up * 5 * difUnit ), transform.rotation);
			break;
            */
		}
	
		//_score.UpScore ();
	}
}