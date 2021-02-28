from __future__ import print_function
from vertex import Vertex
import sys
import re

class ShortestPath:

    @staticmethod
    def find_the_shortest_path(vertex_list):

        group_list= list()

        queue = list()
        for xxx in range(0, len(vertex_list)):
            read = vertex_list[xxx]
            if read.status  != 1:
                queue = [vertex_list[xxx]]
            while len(queue) > 0:
                current = queue.pop(0)
                if current.is_undiscovered():
                    vertex_list[current.vertex_id].set_discovered()
                    if vertex_list[current.vertex_id].adj_list:
                        one_list = list()
                        one_list.append(current)
                        for neighbor in vertex_list[current.vertex_id].adj_list:
                            if neighbor.is_undiscovered:
                                neighbor.set_discovered()
                                queue.append(neighbor)
                                one_list.append(neighbor)

                        group_list.append(one_list)


        count =0
        for one in group_list:
            count = count + 1
            print(count, ": ", end="")
            for xx in one:
                print()





if __name__ == '__main__':

    from_vertex = None
    to_vertex = None
    vertex_list = list()

    read_line = sys.stdin.readline()
    vertex_number = int(read_line)
    for x in range(0, vertex_number):
        vertex = Vertex(x)
        vertex_list.append(vertex)

    edge_number = sys.stdin.readline()
    edge_number = edge_number.rstrip('\n')

    while edge_number != '':
        edge_number = edge_number.split(' ')
        from_vertex = int(edge_number[0])
        to_vertex = int(edge_number[1])
        vertex_list[from_vertex].add_neighbor(vertex_list[to_vertex])
        vertex_list[to_vertex].add_neighbor(vertex_list[from_vertex])
        edge_number = sys.stdin.readline()
        edge_number = edge_number.rstrip('\n')
        #edge_number = re.split("\s+", edge_number)


    shortest_path = ShortestPath()
    shortest_path.find_the_shortest_path(vertex_list)





#     read from the file
#     vertex_list = list()
#
#     read_file = open("test.txt", "r")
#     lines_from_texts = read_file.readlines()
#     vertex_number = lines_from_texts[0]
#     # get the number and make a list of vertices
#     num = int(vertex_number[0])
#     for x in range(0, num):
#         vertex = Vertex(x)
#         vertex_list.append(vertex)
#
#     for x in range(1, len(lines_from_texts)):
#         two_vertices = lines_from_texts[x].split(' ')
#         a = int(two_vertices[0])
#         b = int(two_vertices[1])
#         vertex_list[a].add_neighbor(vertex_list[b])
#         vertex_list[b].add_neighbor(vertex_list[a])
#     # if finished send the relevant information to the
#     shortest_path = ShortestPath()
#     shortest_path.find_the_shortest_path(vertex_list)

