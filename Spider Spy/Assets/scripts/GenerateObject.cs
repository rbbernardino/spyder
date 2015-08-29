using UnityEngine;

public class GenerateObject : MonoBehaviour
{
	public GameObject item;
	public float position = 0.35f;
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
		int r = Random.Range (1, 15);
		Debug.Log (r);
		switch (r) { // [min, max[
		case (1): // 1 bomb // easy
			pos = ((Random.value >= 0.3f) ? pos : 0);
			Instantiate(bomb, transform.position + ( Vector3.right * pos ), transform.rotation);
			break;
		case (2): // 1 Item // easy
			pos = ((Random.value >= 0.3f) ? pos : 0);
			Instantiate(item, transform.position + ( Vector3.right * pos ), transform.rotation);
			break;
		case (3): // 1 bomb, 1 Item, 1 bomb  // med
			pos = ((Random.value >= 0.3f) ? pos : 0);
			Instantiate(bomb, transform.position + ( Vector3.right * pos ), transform.rotation);
			Instantiate(item, transform.position + ( Vector3.right * pos ) + ( Vector3.up * 2.5f * difUnit ), transform.rotation);
			Instantiate(bomb, transform.position + ( Vector3.right * pos ) + ( Vector3.up * 5 * difUnit ), transform.rotation);
			break;
		case (4): // 1 Item, 1 bomb  // easy
			Instantiate(item, transform.position + ( Vector3.right * pos ), transform.rotation);
			Instantiate(bomb, transform.position - ( Vector3.right * pos ), transform.rotation);
			break;
		case (5): // 1 Item, 1 (Other side) bomb //easy
			Instantiate(item, transform.position + ( Vector3.right * pos ), transform.rotation);
			Instantiate(bomb, transform.position - ( Vector3.right * pos ) + ( Vector3.up * 3.5f * difUnit ), transform.rotation);
			break;
		case (6): // 1 bomb, 1 item (Other side), 1 bomb (Other side) // med
			Instantiate(bomb, transform.position + ( Vector3.right * pos ), transform.rotation);
			Instantiate(item, transform.position - ( Vector3.right * pos ) + ( Vector3.up * 2.25f * difUnit ), transform.rotation);
			Instantiate(bomb, transform.position - ( Vector3.right * pos ) + ( Vector3.up * 3.5f * difUnit ), transform.rotation);
			break;
		case (7): // 1 bomb lines, item (other side) // easy
			Instantiate(bomb, transform.position + ( Vector3.right * pos ), transform.rotation);
			Instantiate(bomb, transform.position + ( Vector3.right * pos/2 ) + ( Vector3.up * 1 * difUnit ), transform.rotation);
			Instantiate(bomb, transform.position + ( Vector3.up * 2 * difUnit ), transform.rotation);
			Instantiate(bomb, transform.position - ( Vector3.right * pos/2 ) + ( Vector3.up * 3 * difUnit ), transform.rotation);
			Instantiate(item, transform.position - ( Vector3.right * pos ) + ( Vector3.up * 4 * difUnit ), transform.rotation);
			break;
		case (8): // many bombs center, item sides // hard
			Instantiate(bomb, transform.position, transform.rotation);
			Instantiate(bomb, transform.position +  ( Vector3.up * 1.5f * difUnit ), transform.rotation );
			Instantiate(bomb, transform.position +  ( Vector3.up * 3 * difUnit ), transform.rotation );
			Instantiate(bomb, transform.position +  ( Vector3.up * 4.5f * difUnit ), transform.rotation );
			Instantiate(item, transform.position - ( Vector3.right * pos ) + ( Vector3.up * 5 * difUnit ), transform.rotation);
			Instantiate(item, transform.position + ( Vector3.right * pos ) + ( Vector3.up * 5 * difUnit ), transform.rotation);
			break;
		case (9): // 1 item, bomb lines // med
			Instantiate(item, transform.position + ( Vector3.right * pos ), transform.rotation);
			Instantiate(bomb, transform.position + ( Vector3.right * pos/3 ) + ( Vector3.up * 1 * difUnit ), transform.rotation);
			Instantiate(bomb, transform.position - ( Vector3.right * pos/3 ) + ( Vector3.up * 2.5f * difUnit ), transform.rotation);
			break;
		case (10): // 1 bomb lines, items // hard
			Instantiate(bomb, transform.position + ( Vector3.right * pos ), transform.rotation);
			Instantiate(item, transform.position + ( Vector3.right * pos/2 ) + ( Vector3.up * 1.25f * difUnit ), transform.rotation);
			Instantiate(bomb, transform.position + ( Vector3.up * 2.5f * difUnit ), transform.rotation);
			Instantiate(item, transform.position - ( Vector3.right * pos/2 ) + ( Vector3.up * 3.75f * difUnit ), transform.rotation);
			Instantiate(bomb, transform.position - ( Vector3.right * pos ) + ( Vector3.up * 5 * difUnit ), transform.rotation);
			break;
		case (11): // 1 bomb lines, items // hard
			Instantiate(bomb, transform.position + ( Vector3.right * pos ), transform.rotation);
			Instantiate(bomb, transform.position - ( Vector3.right * pos/2 ) + ( Vector3.up * 1.5f * difUnit ), transform.rotation);
			Instantiate(bomb, transform.position + ( Vector3.up * 3 * difUnit ), transform.rotation);
			Instantiate(item, transform.position - ( Vector3.right * pos/3 ) + ( Vector3.up * 4.5f * difUnit ), transform.rotation);
			break;
		case (12): // 1 bomb lines, items // hard
			Instantiate(bomb, transform.position + ( Vector3.right * pos ), transform.rotation);
			Instantiate(bomb, transform.position + ( Vector3.right * pos/2 ) + ( Vector3.up * 1.5f * difUnit ), transform.rotation);
			Instantiate(bomb, transform.position + ( Vector3.up * 3 * difUnit ), transform.rotation);
			Instantiate(item, transform.position + ( Vector3.right * pos/2 ) + ( Vector3.up * 4.5f * difUnit ), transform.rotation);
			break;
		case (13): // triangle // hard
			Instantiate(bomb, transform.position, transform.rotation);
			Instantiate(bomb, transform.position + ( Vector3.right * pos/2 ) + ( Vector3.up * 1.5f * difUnit ), transform.rotation);
			Instantiate(bomb, transform.position - ( Vector3.right * pos/2 ) + ( Vector3.up * 1.5f * difUnit ), transform.rotation);
			Instantiate(item, transform.position + ( Vector3.up * 3 * difUnit ), transform.rotation);
			Instantiate(bomb, transform.position + ( Vector3.right * pos ) + ( Vector3.up * 4.5f * difUnit ), transform.rotation);
			break;
		case (14): // 1 bomb, 1 item (Other side), 1 bomb (Other side) // med
			Instantiate(bomb, transform.position + ( Vector3.right * pos ), transform.rotation);
			Instantiate(bomb, transform.position - ( Vector3.right * pos ) + ( Vector3.up * 4.4f * difUnit ), transform.rotation);
			pos = ((Random.value >= 0.5f) ? pos : -pos);
			Instantiate(bomb, transform.position + ( Vector3.right * pos ) + ( Vector3.up * 2.2f * difUnit ), transform.rotation);
			Instantiate(item, transform.position - ( Vector3.right * pos ) + ( Vector3.up * 2.2f * difUnit ), transform.rotation);
			break;
		}
		
		//_score.UpScore ();
	}
}