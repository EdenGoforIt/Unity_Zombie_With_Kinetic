import heapq
import sys
from copy import copy


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


def find_the_parent(vertex_list, route, end_ver):
    route.append(end_ver)
    parent = end_ver.parent

    if parent is None:
        return
    else:
        find_the_parent(vertex_list, route, parent)


def dijkstra(vertex_list):
    queue = []
    vertex_list[0].distance = 0
    heapq.heappush(queue, vertex_list[0])

    while queue:
        current = heapq.heappop(queue)
        if current.visited:
            continue
        else:
            current.visited = True
        for edge in current.edge_list:
            if not edge.to_vertex.visited:
                total_weight = current.distance + edge.weight
                if total_weight < edge.to_vertex.distance:
                    edge.to_vertex.distance = total_weight
                    edge.to_vertex.parent = current
                    heapq.heappush(queue, edge.to_vertex)

    route = list()
    end_ver = vertex_list[42]
    find_the_parent(vertex_list, route,end_ver)
    #route.reverse()
    sys.stdout.write("{0} tokens\n".format(vertex_list[42].distance))
    #print(vertex_list[42].distance + " tokens")
    route.reverse()
    count = 0
    for x in route:
        sys.stdout.write("{0}".format(x.vertex_id))
        if count < len(route)-1:
            sys.stdout.write("->")
        count = count+1
    print()



def main():
    answer_list = list()
    first_line = int(sys.stdin.readline())
    while first_line != 0:
        edge_num = first_line
        vertex_list = list()
        for x in range(0, 43):
            vertex = Vertex(x)
            vertex_list.append(vertex)
        for e_num in range(0, edge_num):
            from_ver_num, to_ver_num, weight = map(int, sys.stdin.readline().split())
            edge = Edge(vertex_list[to_ver_num], weight)
            vertex_list[from_ver_num].add_neighbor(edge)
        answer_list.append(dijkstra(vertex_list))
        first_line = int(sys.stdin.readline())




if __name__ == "__main__":
    main()