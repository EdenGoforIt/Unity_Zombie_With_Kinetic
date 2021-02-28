package com.company;


import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        ArrayList<Vertex> list = new ArrayList<>();
        Scanner reader = new Scanner(System.in);

        String numberOfVertices = reader.nextLine();

        int vertexNum = Integer.parseInt(numberOfVertices);
        //3
        //make index
        for(int i=0 ; i<vertexNum; i++)
        {
           Vertex v = new Vertex(i);
           list.add(v);
        }


        //depending on the number, add the string to the list.
       // for (int i = 0; i < vertexNum; i++) {
        //    g.addString(reader.nextLine(),i);
        //}
        //read the line until -1 -1

        while(reader.hasNextLine())
        {
            String s = reader.nextLine();
            if(s.equals("-1 -1"))
            {
                for(Vertex v : list)
                {
                    v.printVertices();
                }
   		break;

            }else
            {
                String[] vertices = s.split(" ");
                Vertex v1 = new Vertex(Integer.parseInt(vertices[1]));
                for(Vertex v: list)
                {
                    if(v._id == Integer.parseInt(vertices[0]))
                    {
                        v.addNeighbor(v1);
                    }
                }
               // v1.adj.add(v2);
            }
        }



    }
}
