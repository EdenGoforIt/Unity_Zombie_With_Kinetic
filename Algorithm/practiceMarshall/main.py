import sys
import heapq


class Vertex:

    def __init__(self, vertex_id):
        self.vertex_id = vertex_id
        self.parent = None
        self.visited = False
        self.edge_list = list()
        self.distance = float('inf')


    def add_neighbor(self, edge):
        self.edge_list.append(edge)

    def __lt__(self, other):
        return self.distance < other.distance

class Edge:

    def __init__(self, to_vertex, weight):
        self.to_vertex = to_vertex
        self.weight = weight


def main():
    vertex_list = list()
    vertex_num, edge_num = map(int, sys.stdin.readline())
    for v_num in vertex_num:
        vertex = Vertex(v_num)
        vertex_list.append(vertex)
    for e_num in edge_num:
        from_ver, to_ver, weight =




if __name__=="__main__":
    main()