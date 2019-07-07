using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAverage
{
    private int computeRange; //N digits to compute
    private int count = 0; //Current queue size
    private Queue<float> values = new Queue<float>(); //queue of values
    private float currentSum; //Current sum of values
    private float currentAverage; //Current average of values

    //Constructor accepts size of window
    public MovingAverage(int N){
        computeRange = N;
    }
    //Appends value and returns new average
    public float GetNewMovingAverage(float value){
        AddValue(value);
        return GetAverage();
    }
    //Returns the current average of the window
    public float GetAverage(){
        float average;
        if(count == computeRange){
            average = currentSum / computeRange;
        }else{
            average = currentSum / count;
        }
        return average;
    }
    //Adds a value to the values for the average
    public void AddValue(float value){
        if(values.Count < computeRange){
        AddToQueue(value);
        count++;
        }else{
        AddToQueue(value);
        RemoveFromQueue();
        }
    }
    //Adds a value to the queue and updates sum of window
    private void AddToQueue(float value){
        values.Enqueue(value);
        currentSum += value;
    }
    //Removes value from the queue and updates sum of window
    private void RemoveFromQueue(){
        currentSum -= values.Peek();
        values.Dequeue();
    }
}
