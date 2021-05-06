using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour {

	enum FIELD_STATE
		{
		EMPTY,
		SEEDED,
		PLANT,
		RIPE,
		}


	public bool isTree;
	public GameObject IconHarvest;
	public GameObject Seed;
	public GameObject Plant;
	public GameObject Plant_Grown;
	public GameObject ParticlesGO;

	public GameObject ParticleRipe;
	public GameObject ParticleCollect;
	public GameObject ParticleGrown;

	private FIELD_STATE fieldState;
	private CircleCollider2D colliderField;

	public float MinTimeToPlant;
	public float MaxTimeToPlant;

	public float MinTimeToGrow;
	public float MaxTimeToGrow;

	public AudioClip AudioRipe;
	public AudioClip AudioHarvest;
	public AudioClip AudioSeed;

	private GameObject ParticleEffect;



	// Use this for initialization
	void Start () {
	
	fieldState = FIELD_STATE.EMPTY;
	colliderField = (CircleCollider2D) this.gameObject.GetComponent ("CircleCollider2D");

	}


	// Update is called once per frame
	void Update () {


		if(isTree && fieldState == FIELD_STATE.EMPTY)
		{
			Seed.SetActive (true);
			fieldState = FIELD_STATE.SEEDED;
			StartCoroutine(WaitUntilPlant(Random.Range(MinTimeToPlant,MaxTimeToPlant)));
		}


			if(Input.GetMouseButtonDown(0)){
				Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				
				if(colliderField.OverlapPoint(mousePosition))
				{
			
					switch (fieldState) {

					case FIELD_STATE.EMPTY :
					{
						GetComponent<AudioSource>().PlayOneShot(AudioSeed);
						Seed.SetActive (true);
						fieldState = FIELD_STATE.SEEDED;
						StartCoroutine(WaitUntilPlant(Random.Range(MinTimeToPlant,MaxTimeToPlant)));
						Debug.Log("lol");
					}
					break;
					case FIELD_STATE.RIPE :
					{
						Plant_Grown.SetActive (false);
						fieldState = FIELD_STATE.EMPTY;
//						Destroy(ParticleEffect);
						GetComponent<AudioSource>().PlayOneShot(AudioHarvest);
						
						GameObject EffectCollect = Instantiate(ParticleCollect) as GameObject;
						EffectCollect.transform.parent = ParticlesGO.transform;
						EffectCollect.transform.rotation = new Quaternion(0,0,0,0);
						EffectCollect.transform.localPosition = Vector3.zero;

						IconHarvest.SetActive(true);
						Animation anim = (Animation) IconHarvest.GetComponent("Animation");
						anim.Play();
						
						StartCoroutine(DisableIcon(1.0f));

					}
					break;
					default:
						break;
					}

				}
				
			}

		}

	IEnumerator DisableIcon (float time)
	{	
		yield return new WaitForSeconds(time);
		IconHarvest.SetActive(false);
	}

	IEnumerator WaitUntilPlant (float time)
	{
	
			yield return new WaitForSeconds(time);
			Seed.SetActive (false);
			Plant.SetActive (true);
			fieldState = FIELD_STATE.PLANT;
			StartCoroutine(WaitUntilGrown(Random.Range(MinTimeToGrow,MaxTimeToGrow)));

	}

	IEnumerator WaitUntilGrown (float time)
	{
			yield return new WaitForSeconds(time);
			Debug.Log(time);
			Plant.SetActive (false);
			Plant_Grown.SetActive (true);

			GetComponent<AudioSource>().PlayOneShot(AudioRipe);

			GameObject EffectCollect = Instantiate(ParticleGrown) as GameObject;
			EffectCollect.transform.parent = ParticlesGO.transform;
			EffectCollect.transform.rotation = new Quaternion(0,0,0,0);
			EffectCollect.transform.localPosition = Vector3.zero;
//
//			ParticleEffect = Instantiate(ParticleRipe) as GameObject;
//			ParticleEffect.transform.parent = ParticlesGO.transform;
//			ParticleEffect.transform.rotation = new Quaternion(0,0,0,0);
//			ParticleEffect.transform.localPosition = Vector3.zero;

			fieldState = FIELD_STATE.RIPE;
	}

}
