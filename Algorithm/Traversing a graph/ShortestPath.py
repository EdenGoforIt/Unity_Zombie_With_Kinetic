from __future__ import print_function

import sys

from vertex import Vertex

class ShortestPath:
     @staticmethod
     def find_the_shortest_path(_vertex_list, _from_vertex, _to_vertex):

        queue = [_vertex_list[_from_vertex]]
        while queue:
            current = queue.pop()
            _vertex_list[current.vertex_id].set_discovered()
            for neighbor in _vertex_list[current.vertex_id].adj_list:
                if neighbor.is_undiscovered():
                    queue.append(neighbor)
                    neighbor.set_discovered()
                    neighbor.parent = current
            current.set_processed()

        result = list()
        que = list()
        que.append(_vertex_list[_to_vertex])
        result.append(_vertex_list[_to_vertex])
        while que:
            ver = que.pop()
            if _vertex_list[ver.vertex_id].parent:
                parent = _vertex_list[ver.vertex_id].parent
                que.append(parent)
                result.insert(0, parent)

        for xx in result:
            print(xx.vertex_id, end =" ")


if __name__ == '__main__':
    from_vertex = None
    to_vertex = None
    vertex_list = list()

    read_line = sys.stdin.readline()
    vertex_number = int(read_line[0])
    for x in range(0, vertex_number):
        vertex = Vertex(x)
        vertex_list.append(vertex)

    # now read edges
    start_end = sys.stdin.readline()
    start_end = start_end.split(' ')
    start = int(start_end[0])
    end = int(start_end[1])
    edge_numbers = sys.stdin.readline()
    while edge_numbers != '':
        edge_numbers = edge_numbers.split(' ')
        from_vertex = int(edge_numbers[0])
        to_vertex = int(edge_numbers[1])
        vertex_list[from_vertex].add_neighbor(vertex_list[to_vertex])
        edge_numbers = sys.stdin.readline()

    shortest_path = ShortestPath()
    shortest_path.find_the_shortest_path(vertex_list, start, end)


# from_vertex = None
    # to_vertex = None
    # vertex_list = list()
    #
    # read_line = input()
    # vertex_number = int(read_line[0])
    # for x in range(0, vertex_number):
    #     vertex = Vertex(x)
    #     vertex_list.append(vertex)
    #
    # # now read edges
    # start_end = input()
    # start_end = start_end.split(' ')
    # start = int(start_end[0])
    # end = int(start_end[1])
    # edge_numbers = input()
    # while edge_numbers != '':
    #     edge_numbers = edge_numbers.split(' ')
    #     from_vertex = int(edge_numbers[0])
    #     to_vertex = int(edge_numbers[1])
    #     vertex_list[from_vertex].add_neighbor(vertex_list[to_vertex])
    #     edge_numbers = input()
    #
    #
    # shortest_path = ShortestPath()
    # shortest_path.find_the_shortest_path(vertex_list, start, end)

    # read_file = open("test.txt", "r")
    # lines_from_texts = read_file.readlines()
    # vertex_number = lines_from_texts[0]
    # # get the number and make a list of vertices
    # num = int(vertex_number[0])
    # for x in range(0, num):
    #     vertex = Vertex(x)
    #     vertex_list.append(vertex)
    # # get the line and assign from to end
    # fromTo = read_file.readlines()
    # from_to_split = lines_from_texts[1].split(' ')
    # from_vertex = int(from_to_split[0])
    # to_vertex = int(from_to_split[1])
    #
    #
    # # get two vertices until the end
    # for x in range(2, len(lines_from_texts)):
    #     two_vertices = lines_from_texts[x].split(' ')
    #     a = int(two_vertices[0])
    #     b = int(two_vertices[1])
    #     vertex_list[a].add_neighbor(vertex_list[b])
    # # if finished send the relevant information to the
    # shortest_path = ShortestPath()
    # shortest_path.find_the_shortest_path(vertex_list, from_vertex, to_vertex)

