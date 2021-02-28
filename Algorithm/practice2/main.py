import heapq
import sys

class Vertex(object):

    def __init__(self,vertex_id):
        self.vertex_id = vertex_id
        self.distance = float('inf')
        self.parent = None
        self.visited = False
        self.edge_list = list()

    def add_neighbor(self, edge):
        self.edge_list.append(edge)

    def __lt__(self, other):
        return self.distance < other.distance


class Edge(object):

    def __init__(self, to_vertex, weight):
        self.to_vertex = to_vertex
        self.weight = weight


def find_the_parent(verteices_list, route, end_ver):
    route.append(end_ver)
    parent = end_ver.parent
    if parent is None:
        return
    else:
        find_the_parent(verteices_list, route, parent)


def dijkstra(verteices_list, start_ver, end_ver):
    queue = []
    current = start_ver
    current.key = 0
    heapq.heappush(queue, current)
    while queue:
        current = heapq.heappop(queue)
        if current.visited: continue
        for edge in current.edge_list:
            if not edge.visited:
                if current.key + edge.weight < edge.to_vertex.key:
                    edge.to_vertex.key = current.key + edge.weight
                    heapq.heappush(queue, edge.to_vertex)
                    edge.to_vertex.parent = current
        current.visited = True

    route = list()
    find_the_parent(verteices_list, route, end_ver)

    route.reverse()
    for x in route:
        sys.stdout.write("{0} ".format(x))



def main():
    ver_num = int(sys.stdin.readline())
    vertex_list = list()

    for v_num in range(0, ver_num):
        vertex = Vertex(v_num)
        vertex_list.append(vertex)

    start_ver, end_ver = map(int, sys.stdin.readline().split())
    line = sys.stdin.readline().strip()
    while line !="":
        from_ver, to_ver, weight = map(int, line.split())
        edge = Edge(vertex_list[to_ver], weight)
        vertex_list[from_ver].add_neighbor(edge)
        line = sys.stdin.readline().strip()

    dijkstra(vertex_list, vertex_list[start_ver], vertex_list[end_ver])


if __name__ == "__main__":
    main()
