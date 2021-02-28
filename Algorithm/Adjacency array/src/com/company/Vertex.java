package com.company;

import java.lang.reflect.Array;
import java.util.*;


public class Vertex implements Comparable<Vertex> {
    public int _id;
    int incoming;
    String desc;
    ArrayList<Vertex> adj ;

    //@Override
    public int compareTo(Vertex o) {
        return this.GetId()- o.GetId();
    }

    Vertex(int id) {
        this._id = id;
        adj= new ArrayList<>();
    }

    public Integer GetId() {
        return this._id;
    }

    public void SetName(String name) {
        this.desc = name;
    }

    public ArrayList<Vertex> GetList() {
        return this.adj;
    }

    void addVertex(int vertex) {
        for (int i = 0; i < vertex; i++) {
            Vertex v = new Vertex(i);
        }

    }

    void addNeighbor(Vertex v) {

        adj.add(v);

        //need to add Vertex to the list..

    }

    void printVertices() {
        Collections.sort(adj);
        System.out.printf("%d:",this._id);
        for (Vertex ver : adj) {
            System.out.print(" " + ver._id);
        }
        System.out.println();
    }
}


