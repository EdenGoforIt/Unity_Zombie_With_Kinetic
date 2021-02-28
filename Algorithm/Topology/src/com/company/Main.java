package com.company;


import java.io.FileInputStream;
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.Scanner;

public class Main {
    public static ArrayList<Vertex> verticesList = new ArrayList<>();
    public static ArrayList<Vertex> searchList = new ArrayList<>();
    public static ArrayList<Vertex> resultList = new ArrayList<>();
    public static Integer verticesNumber;

    public static void redirectFromFile(String filename) {
        try {
            String userdir = System.getProperty("user.dir");
            System.setIn(new FileInputStream(userdir + "/" + filename));
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void main(String[] args) {
        redirectFromFile("146103.txt");


        Scanner reader = new Scanner(System.in);

        String numberOfVertices = reader.nextLine();

        //read one line of the number of vertices

        int vertexNum = Integer.parseInt(numberOfVertices);
        verticesNumber=vertexNum;
        for (int i = 0; i < vertexNum; i++) {
            Vertex v = new Vertex(i);
            verticesList.add(v);
        }

        //read the line and set the name according to the number provided above
        for (int i = 0; i < vertexNum; i++) {
            String name = reader.nextLine();
            verticesList.get(i).SetName(name);

        }

// 3
// go
// ready
// set
// 1 2
// 2 0
        //get the number
        while (reader.hasNextLine()) {
            String s = reader.nextLine();
            if (s.equals("-1 -1")) {
                //if -1 -1, then print topological sort and print out
                //topologicalSortAndPrintOut();
                break;

            } else {
                //if not, get the number and increase the incoming number
                String[] vertices = s.split(" ");
                int v1 = Integer.parseInt(vertices[0]);
                int v2 = Integer.parseInt(vertices[1]);
                //putIntheList(Integer.parseInt(vertices[0]), Integer.parseInt(vertices[1]));
                verticesList.get(v1).addNeighbor(verticesList.get(v2));
                verticesList.get(v2).incoming++;

            }
        }
        topologicalSortAndPrintOut();


    }
 

    private static void topologicalSortAndPrintOut() {
        //1. first search if the incoming number is zero.
        for (Vertex v1 : verticesList) {
            if (v1.incoming == 0) {
                searchList.add(v1);
            }
        }
        //2.take first vertex out  from search list and put in the result list

        while (!searchList.isEmpty()){
            Vertex vtx = searchList.remove(0);
            resultList.add(vtx);
            for (Vertex nb : vtx.adj){
                nb.incoming--;
                if (nb.incoming == 0){
                    searchList.add(nb);
                }
            }
        }


        for (Vertex v : resultList) {
            System.out.println(v.getName());
        }


    }
}
