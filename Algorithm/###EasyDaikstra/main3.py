import heapq
import sys


class Vertex:

    def __init__(self, vertex_id):
        self.vertex_id = vertex_id
        self.parent = None
        self.edge_list = list()
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



def dijkstra(answer_list, vertex_list, start, end):
    queue = []
    start.distance = 0
    heapq.heappush(queue, start)

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
    find_the_parent(vertex_list, route, end)
    if end.distance == float('inf') or end.distance > 500000:
        answer_list.append("NO")
    else:
        answer_list.append(end.distance)




def main():
    answer_list = list()

    case_num = int(sys.stdin.readline())

    for c_num in range(case_num):
        vertex_list = list()
        vertex_num, edge_num = map(int, sys.stdin.readline().split())
        for x in range(vertex_num):
            vertex = Vertex(x)
            vertex_list.append(vertex)
        for e_num in range(edge_num):
            start, end, weight = map(int,sys.stdin.readline().split())
            edge = Edge(vertex_list[end-1], weight)
            vertex_list[start-1].add_neighbor(edge)
        start_ver, end_ver = map(int, sys.stdin.readline().split())
        dijkstra(answer_list, vertex_list, vertex_list[start_ver-1], vertex_list[end_ver-1])
        

    for an in answer_list:
        print(an)





if __name__=="__main__":
    main()