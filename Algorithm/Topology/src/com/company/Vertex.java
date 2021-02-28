package com.company;

import java.lang.reflect.Array;
import java.util.*;


public class Vertex implements Comparable<Vertex> {
    public int _id;
    int incoming;
    String desc;
    ArrayList<Vertex> adj;

    @Override
    public int compareTo(Vertex o) {
        return this.GetId() - o.GetId();
    }

    Vertex(int id) {
        this._id = id;
        adj = new ArrayList<>();
    }

    public Integer GetId() {
        return this._id;
    }

    public void SetName(String name) {
        this.desc = name;
    }

    public String getName() {
        return this.desc;
    }

    public ArrayList<Vertex> GetList() {
        return this.adj;
    }

    void addNeighbor(Vertex v) {

        adj.add(v);
    }
}


