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
        self.edge_list = sorted(self.edge_list, key=lambda x:x.to_ver.vertex_id)

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
            if not edge.to_ver.visited:
                total_weight = current.distance+edge.weight
                if total_weight < edge.to_ver.distance:
                    edge.to_ver.distance = total_weight
                    edge.to_ver.parent = current
                    heapq.heappush(queue, edge.to_ver)
    route = list()
    find_the_parent(adj_list, route, end_vertex)
    route.reverse()

    answer= ""
    for a in adj_list:

        # answer += vertex_id
        # answer +="("+str(a.parent)+":"+str(a.distance)+"): "
        if a.vertex_id==start_vertex.vertex_id:
            sys.stdout.write("{0} (-:{1}): ".format(a.vertex_id, a.distance))
        else:
            sys.stdout.write("{0} ({1}:{2}): ".format(a.vertex_id, a.parent.vertex_id, a.distance))
        #answer += "%i (%i:%i): "%(a.vertex_id, a.parent, a.distance)
        for b in a.edge_list:
            sys.stdout.write("{0}({1}) ".format(b.to_ver.vertex_id, b.weight))
        print()

    print(str(end_vertex.distance)+" seconds")

    line = ""
    for x in route:
        line+=str(x.vertex_id)+" "
    #sys.stdin.readline("{0}".format(line))
    print(line)


def main():
    vertex_num, edge_num = map(int, sys.stdin.readline().split())
    adj_list = list()
    answer_list = list()
    for v_num in range(vertex_num):
        vertex = Vertex(v_num)
        adj_list.append(vertex)
    for e_num in range(edge_num):
        start, end, weight = map(int, sys.stdin.readline().split())
        edge = Edge(adj_list[end], weight)
        edge2 = Edge(adj_list[start], weight)
        adj_list[start].add_neighbor(edge)
        adj_list[end].add_neighbor(edge2)
    start_ver, end_ver = map(int, sys.stdin.readline().split())
    start_vertex = adj_list[start_ver]
    end_vertex = adj_list[end_ver]
    diykstra(answer_list, adj_list, start_vertex, end_vertex)








if __name__=="__main__":
    main()