using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class World : MonoBehaviour
{

    public Transform agentPrefab;
    public int nAgents ;
    public List<Agent> agents;
    public float bound;
    public float spawnR;
    public bool debugWonder = false;
    public Text text;

    //In fact are player variables
    public float hightPlayer;
    public float radiousPlayer;
    public float minimunHight;

    void Start ()
	{
        agents = new List<Agent>();
	    spawn(agentPrefab, nAgents);
	    text.text = nAgents.ToString();
        agents.AddRange(FindObjectsOfType<Agent>());
    }

	void Update () {
		
	}

    void spawn(Transform prefab, int n)
    {
        for (int i = 0; i < n; ++i)
        {
            var obj = Instantiate(prefab, new Vector3(Random.Range(-spawnR, spawnR), 10, Random.Range(-spawnR, spawnR)),
                Quaternion.identity);

        }
    }

    public List<Agent> getNeightbours(Agent agent, float radious)
    {

        List<Agent> neightbours = new List<Agent>();
        foreach (var otherAgent in agents)
        {
            if (otherAgent != agent)
            {
                if (Vector3.Distance(agent.x, otherAgent.x) <= radious)
                {
                    neightbours.Add(otherAgent);
                }
            }

        }

        return neightbours;
    }
}
