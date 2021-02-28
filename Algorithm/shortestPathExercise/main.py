import sys
import heapq


class Vertex:

    def __init__(self, vertex_id):
        self.vertex_id = vertex_id
        self.distance = float('inf')
        self.visited = False
        self.parent = None
        self.edge_list = list()

    def __lt__(self, other):
        return self.distance<other.distance

    def add_neighbor(self, edge):
        self.edge_list.append(edge)

class Edge:

    def __init__(self, to_ver, weight):
        self.to_ver = to_ver
        self.weight = weight

def find_the_parent(adj_list, route, end_ver):
    route.append(end_ver)
    parent = end_ver.parent
    if parent is None:
        return
    else:
        find_the_parent(adj_list, route, parent)


def diykstra(answer_list, adj_list, start_vertex, end_vertex):
    queue = []
    start_vertex.distance = 0
    heapq.heappush(queue, start_vertex)
    while queue:
        current = heapq.heappop(queue)
        if current.visited:
            continue
        else:
            current.visited = True
        for edge in current.edge_list:
            total_weight = current.distance + edge.weight
            if total_weight < edge.to_ver.distance:
                edge.to_ver.distance = total_weight
                edge.to_ver.parent = current
                heapq.heappush(queue, edge.to_ver)

    route = list()
    find_the_parent(adj_list, route, end_vertex)
    line = ""
    route.reverse()
    for one_route in route:
        line += str(one_route.vertex_id)+" "
    line = line[:-1]
    answer_list.append(line)

def main():
    answer_list = list()
    adj_list = list()
    ver_num = int(sys.stdin.readline())
    for v_num in range(ver_num):
        vertex = Vertex(v_num)
        adj_list.append(vertex)
    start_ver, end_ver = map(int, sys.stdin.readline().split())
    start_vertex = adj_list[start_ver]
    end_vertex = adj_list[end_ver]
    line = sys.stdin.readline().strip()
    while line!="":
        start, end, weight = map(int, line.split())
        edge = Edge(adj_list[end], weight)
        adj_list[start].add_neighbor(edge)
        line = sys.stdin.readline().strip()

    diykstra(answer_list, adj_list, start_vertex, end_vertex)

    for answer in answer_list:
        print(answer)



if __name__ =="__main__":
    main()
