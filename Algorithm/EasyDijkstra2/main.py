import heapq
import sys

class Vertex:

    def __init__(self, vertex_id):
        self.vertex_id = vertex_id
        self.parent = None
        self.visited = False
        self.edge_list = list()
        self.distance = float('inf')

    def __lt__(self, other):
        return self.distance < other.distance

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
        find_the_parent(adj_list ,route, parent)


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
            if not edge.to_ver.visited:
                total_weight = current.distance+edge.weight
                if total_weight < edge.to_ver.distance:
                    edge.to_ver.distance = total_weight
                    edge.to_ver.parent = current
                    heapq.heappush(queue, edge.to_ver)


    if end_ver.distance < 50000:
        answer_list.append(end_ver.distance)
    else:
        answer_list.append("NO")


def main():
    answer_list=list()
    case_num = int(sys.stdin.readline())
    for c_num in range(case_num):
        adj_list = list()
        ver_num, edge_num = map(int, sys.stdin.readline().split())
        for v_num in range(ver_num):
            vertex = Vertex(v_num)
            adj_list.append(vertex)
        for e_num in range(edge_num):
            from_ver, to_ver, weight = map(int, sys.stdin.readline().split())
            edge = Edge(adj_list[to_ver-1], weight)
            adj_list[from_ver-1].add_neighbor(edge)
        start_ver, end_ver = map(int, sys.stdin.readline().split())
        dijkstra(answer_list, adj_list, adj_list[start_ver - 1], adj_list[end_ver-1])

    for answer in answer_list:
        print(answer)





if __name__ =="__main__":
    main()