import heapq
import sys

class Vertex(object):

    def __init__(self, vertex_id):
        self.vertex_id = vertex_id
        self.edge_list = list()
        self.parent = None
        self.distance = float('inf')
        self.visited = False

    def add_neighbor(self, edge):
        self.edge_list.append(edge)

    def __lt__(self, other):
        return self.distance < other.distance


class Edge(object):

    def __init__(self, to_vertex, weight):
        self.to_vertex = to_vertex
        self.weight = weight


def find_the_parent(vertex_list, route, end_vertex):
    route.append(end_vertex)
    parent = end_vertex.parent
    if parent is None:
        return
    else:
        find_the_parent(vertex_list, route, parent)


def dijkstra(vertex_list, start_vertex, end_vertex):
    queue = []
    current_ver = start_vertex
    current_ver.distance = 0
    heapq.heappush(queue, current_ver)
    while queue:
        current = heapq.heappop(queue)
        if not current.visited:
            current.visited = True
        else:
            continue
        for edge in current.edge_list:
            total_weight = current.distance + edge.weight
            if total_weight < edge.to_vertex.distance:
                edge.to_vertex.distance = total_weight
                heapq.heappush(queue, edge.to_vertex)
                edge.to_vertex.parent = current

    route = list()
    find_the_parent(vertex_list, route, end_vertex)
    route.reverse()

    for x in route:
        print(x.vertex_id, end=' ')



def main():
    vertex_list = list()
    ver_num = int(sys.stdin.readline())
    for v_num in range(0, ver_num):
        vertex = Vertex(v_num)
        vertex_list.append(vertex)

    start_ver, end_ver = map(int, sys.stdin.readline().split())
    start_vertex = vertex_list[start_ver]
    end_vertex = vertex_list[end_ver]
    line = sys.stdin.readline().strip()
    while line !="":
        from_ver, to_ver, weight = map(int, line.split())
        edge = Edge(vertex_list[to_ver], weight)
        vertex_list[from_ver].add_neighbor(edge)
        line = sys.stdin.readline().strip()

    dijkstra(vertex_list, start_vertex, end_vertex)






if __name__ == "__main__":
    main()
