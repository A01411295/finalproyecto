﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma : MonoBehaviour {
    public Transform[] points;
         // put the points from unity interface
 
     public int currentWayPoint = 0; 
     Transform targetWayPoint;
    
     public float speed = 4f;
        float speed1;
     // Use this for initialization
     void Start () {
        speed1 = speed;
     }
     
     // Update is called once per frame
     void Update () {
        speed = (float)(speed1 * Maze.iteration);
         // check if we have somewere to walk
         if(currentWayPoint < this.points.Length)
         {
             if(targetWayPoint == null)
                 targetWayPoint = points[currentWayPoint];
             walk();
         }
     }
 
     void walk(){
         // rotate towards the target
         //transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed*Time.deltaTime, 0.0f);
 
         // move towards the target
         transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   speed*Time.deltaTime);
 
         if(transform.position == targetWayPoint.position)
         {
             currentWayPoint ++ ;
            if(currentWayPoint>=this.points.Length){
                currentWayPoint=0;
            }
             targetWayPoint = points[currentWayPoint];
         }
     } 
}
