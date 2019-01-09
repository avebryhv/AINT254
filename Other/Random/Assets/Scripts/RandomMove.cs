using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour {
    [SerializeField]
    private AnimationCurve animCurve;


    int randomResult;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Step();
        //StepArray();
        //FloatStep();
        //StepCurve();
        StepVector();
    }

    void Step()
    {
        randomResult = Random.Range(0, 4);

        switch (randomResult)
        {
            case 0:
                transform.position += new Vector3(0.1f, 0, 0);
                break;
            case 1:
                transform.position += new Vector3(-.1f, 0, 0);
                break;
            case 2:
                transform.position += new Vector3(0, 0, .1f);
                break;
            case 3:
                transform.position += new Vector3(0, 0, -.1f);
                break;

            default:
                break;
        }
    }

    void StepArray()
    {
        int[] elements = new int[5];

        elements[0] = 0;
        elements[1] = 1;
        elements[2] = 2;
        elements[3] = 3;
        elements[4] = 0;

        int randomIndex = Random.Range(0, 5);

        switch (elements[randomIndex])
        {
            case 0:
                transform.position += new Vector3(0.1f, 0, 0);
                break;
            case 1:
                transform.position += new Vector3(-.1f, 0, 0);
                break;
            case 2:
                transform.position += new Vector3(0, 0, .1f);
                break;
            case 3:
                transform.position += new Vector3(0, 0, -.1f);
                break;

            default:
                break;
        }
    }

    void FloatStep()
    {
        float result = Random.Range(0f,1f);
        if (result < 0.25)
        {
            transform.position += new Vector3(0.1f, 0, 0);
        }
        else if (result < 0.50)
        {
            transform.position += new Vector3(-.1f, 0, 0);
        }
        else if (result < 0.75)
        {
            transform.position += new Vector3(0, 0, .1f);
        }
        else
        {
            transform.position += new Vector3(0, 0, -.1f);
        }

    }

    void StepCurve()
    {
        float randomCurveValue = Random.Range(0.0f, 1.0f);

        float result = animCurve.Evaluate(randomCurveValue);

        if (result < 0.25)
        {
            transform.position += new Vector3(0.1f, 0, 0);
        }
        else if (result < 0.50)
        {
            transform.position += new Vector3(-.1f, 0, 0);
        }
        else if (result < 0.75)
        {
            transform.position += new Vector3(0, 0, .1f);
        }
        else
        {
            transform.position += new Vector3(0, 0, -.1f);
        }
    }

    void StepVector()
    {
        float randomX = Random.Range(-0.1f, 0.1f);
        float randomZ = Random.Range(-0.1f, 0.1f);

        transform.position += new Vector3(randomX, 0, randomZ);
    }
}
