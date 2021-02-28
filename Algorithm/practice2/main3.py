import heapq
import sys

class Vertex:

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

class Edge:

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
    current = start_vertex
    current.distance = 0
    heapq.heappush(queue, current)
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
                    heapq.heappush(queue, edge.to_vertex)
                    edge.to_vertex.distance = total_weight
                    queue.append(edge.to_vertex)
                    edge.to_vertex.parent = current

    if end_vertex.distance < 500000:
        return end_vertex.distance
    else:
        return "NO"


def main():
    answer_list = list()

    case_num = int(sys.stdin.readline())
    for c_num in range(0, case_num):
        vertex_list = list()
        vertex_num, edge_num = map(int, sys.stdin.readline().strip().split())
        for v_num in range(0, vertex_num):
            vertex = Vertex(v_num)
            vertex_list.append(vertex)
        for e_num in range(0, edge_num):
            from_ver, to_ver, weight = map(int, sys.stdin.readline().split())
            edge = Edge(vertex_list[to_ver-1], weight)
            vertex_list[from_ver-1].add_neighbor(edge)
        start_ver_num, end_vertex_num = map(int, sys.stdin.readline().split())
        start_vertex = vertex_list[start_ver_num-1]
        end_vertex = vertex_list[end_vertex_num-1]
        answer_list.append(dijkstra(vertex_list, start_vertex, end_vertex))

    for an in answer_list:
        print(an)




if __name__ == "__main__":
    main()