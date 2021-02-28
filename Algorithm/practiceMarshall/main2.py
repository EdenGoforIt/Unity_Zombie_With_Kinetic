import sys
from math import ceil

class Vertex:

    def __init__(self, vertex_id):
        self.vertex_id = vertex_id
        self.edge_list = list()
        self.parent = None
        self.visited = False
        self.distance = float('inf')

    def add_neighbor(self, edge):
        self.edge_list.append(edge)

    def __lt__(self, other):
        return self.distance < other.distance


class Edge:

    def __init__(self, to_vertex, weight):
        self.to_vertex = to_vertex
        self.weight = weight


if __name__ =="__name__":
    city_num, road_num = map(int, sys.stdin.readline().split())
    adj_list = list()
    for x in city_num:
        vertex = Vertex(x)
        adj_list.append(vertex)

    while city_num != 0 and road_num != 0:
        from_city, to_city, weight = map(int, sys.stdin.readline().split())
        for r_num in range(0, len(road_num)):
            start_city, end_city, weight = map(int, sys.stdin.readline().split())
            edge = Edge(end_city, weight)
            otherEdge = Edge(start_city, weight)
            adj_list[start_city].add_neighbor(edge)
            adj_list[end_city].add_neighbor(otherEdge)









