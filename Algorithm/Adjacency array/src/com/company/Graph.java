package com.company;

import java.util.*;


public class Graph {
    public ArrayList<Vertex> graphList;



    void addVertex(int vertex) {
        for(int i=0 ; i<vertex; i++)
        {
            Vertex v = new Vertex(i);
        }

    }


    //add all to the list first
    //for loop and if the each list is zero then add that to the result list
    //get the result list from index 0, print out the value of 0
    //

    //0, 1
    void addEdge(int a, int b) {

        Vertex v1 =new Vertex(a);
        Vertex v2 = new Vertex(b);
        v1.adj.set(a,v2);

        //need to add Vertex to the list..

    }

    void addString(String name, int id)
    {
        Vertex v = new Vertex(id);
        v.desc=name;
        //add string to the Vertex according to id

    }

    void printVertices(int num) {

        for(int i =0; i<num; i++ )
        {
            Vertex v = new Vertex(i);
            int id = v.GetId();
            if(id==i)
            {
                graphList=v.GetList();
            }

            System.out.printf("%d:",i);
            for (Vertex v2 :graphList) {
                System.out.print(" " + v2._id);
            }
            System.out.println();

        }


    }
}
