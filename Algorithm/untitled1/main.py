import heapq
import sys
from copy import copy, deepcopy


class Vertex:

    def __init__(self,vertex_id):
        self.vertex_id= vertex_id
        self.edge_list = list()
        self.parent = None
        self.distance = float('inf')
        self.visited = False

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



def dijkstra(answer_list, vertex_list):
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
                    heapq.heappush(queue, edge.to_vertex)
                    edge.to_vertex.parent = current

    route = list()
    end_ver = vertex_list[42]
    find_the_parent(vertex_list, route, end_ver)
    answer_one = str(vertex_list[42].distance)+" tokens"
    answer_list.append(answer_one)

    route.reverse()
    answer_two = ""
    for ver in route:
        answer_two += str(ver.vertex_id) + "->"

    answer_two = answer_two[:-2]
    answer_list.append(answer_two)




def main():
    answer_list = list()
    first_line = int(sys.stdin.readline())
    vertex_list = list()
    for x in range(0, 43):
        vertex = Vertex(x)
        vertex_list.append(vertex)

    while first_line != 0:
        vertex_list2 = deepcopy(vertex_list)
        for e_num in range(0, first_line):
            from_ver, to_ver, weight = map(int, sys.stdin.readline().split())
            edge = Edge(vertex_list2[to_ver], weight)
            vertex_list2[from_ver].add_neighbor(edge)
        dijkstra(answer_list, vertex_list2)
        first_line = int(sys.stdin.readline())

    for answer in answer_list:
        print(answer)




if __name__ =="__main__":
    main()