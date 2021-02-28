import sys
import heapq
from builtins import list
from copy import copy, deepcopy


class Vertex:

    def __init__(self, vertex_id):
        self.vertex_id = vertex_id
        self.parent = None
        self.visited = False
        self.distance = float('inf')
        self.edge_list = list()

    def __lt__(self, other):
        return self.distance < other.distance

    def add_neighbor(self, edge):
        self.edge_list.append(edge)


class Edge:

    def __init__(self, to_vertex, weight):
        self.to_vertex = to_vertex
        self.weight = weight


def find_the_parent(adj_list, route, end_ver):
    route.append(end_ver)
    parent = end_ver.parent
    if parent is None:
        return
    else:
        find_the_parent(adj_list, route, parent)


def dijkstra(answer_list, adj_list, start_ver, end_ver):
    queue = []
    start_ver.distance = 0
    heapq.heappush(queue, start_ver)
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
    find_the_parent(adj_list, route, end_ver)
    route.reverse()
    answer = ""

    for x in route:
        answer += str(x.vertex_id)+" "

    #answer = answer[:-1]

    answer_list.append(answer)


def main():
    answer_list = list()
    adj_list = list()

    vertex_num = int(sys.stdin.readline())
    for v in range(vertex_num):
        vertex = Vertex(v)
        adj_list.append(vertex)
    start_ver, end_ver = map(int, sys.stdin.readline().split())

    line = sys.stdin.readline().strip()
    while line != "":
        from_ver, to_ver, weight = map(int, line.split())
        if from_ver is None:
            break
        edge = Edge(adj_list[to_ver], weight)
        adj_list[from_ver].add_neighbor(edge)
        line = sys.stdin.readline().strip()

    dijkstra(answer_list, adj_list, adj_list[start_ver], adj_list[end_ver])
    for an in answer_list:
        sys.stdout.write(an)
        #print(an)

if __name__ == "__main__":
    main()
