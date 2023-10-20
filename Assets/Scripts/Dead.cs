using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : FSMState
{
    public List<GameObject> items;
    private bool deadAlready;
    protected override void Initialize()
    {
        base.Initialize();
        state = State.Dead;
        deadAlready = false;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        //Animation
        if (!deadAlready)
        {
            Destroy(agent);
            Destroy(transform.Find("Life_Bar").gameObject);
            gameObject.AddComponent<Rigidbody>().useGravity = true;
            StartCoroutine(DropItems());
            deadAlready = true;
        }
    }

    private IEnumerator DropItems()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject item = items[Random.Range(0, items.Count)];
        Instantiate(item, transform.position, Quaternion.identity);
    }
}
