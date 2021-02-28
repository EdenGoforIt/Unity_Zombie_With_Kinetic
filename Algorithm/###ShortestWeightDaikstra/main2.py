import heapq
import sys

class Vertex(object):

    def __init__(self, vertex_id):
        self.vertex_id = vertex_id
        self.distance = float('inf')
        self.parent = None
        self.visited = False
        self.edge_list = list()

    def is_not_visited(self):
        if self.visited is False:
            return True
        return False

    def is_visited(self):
        if self.visited is True:
            return True
        return False

    def add_neighbor(self, edge):
        self.edge_list.append(edge)

    def __lt__(self, other):
        return self.distance < other.distance

class Edge(object):

    def __init__(self, to_vertex, weight):
        self.to_vertex = to_vertex
        self.weight = weight


def backtrack(vertices_list, route, destination):
    route.append(destination.vertex_id)
    parent = destination.parent
    if parent is None:
        return
    else:
        backtrack(vertices_list, route,  parent)


def daikstra(vertices_list, source_vertex, destination_vertex):
    queue = []
    start_ver = source_vertex
    start_ver.distance = 0
    heapq.heappush(queue, start_ver)

    """ start by setting the starting vertex key as 0 and other keys to infinite"""
    while queue:
        """ find the node having the shortest key    """
        current = heapq.heappop(queue)
        current_weight = current.distance
        if current.visited: continue
        for edge in current.edge_list:
            if edge.to_vertex.is_not_visited():
                total_weight = current_weight + edge.weight
                if total_weight < edge.to_vertex.distance:
                    heapq.heappush(queue, edge.to_vertex)
                    edge.to_vertex.distance = total_weight
                    edge.to_vertex.parent = current

        current.visited = True

    route = list()
    backtrack(vertices_list, route , destination_vertex)
    #
    # route = list()
    # que = list()
    # que.append(destination_vertex)
    # route.insert(0, destination_vertex)
    # while que:
    #     ver = que.pop(0)
    #     if ver.parent:
    #         parent = ver.parent
    #         que.append(parent)
    #         route.insert(0, parent)
    #
    #
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

    while line != "":
        from_ver, to_ver, weight = map(int, line.split())
        if from_ver is None:
            break
        edge = Edge(vertex_list[to_ver], weight)
        vertex_list[from_ver].add_neighbor(edge)
        line = sys.stdin.readline().strip()


    daikstra(vertex_list, vertex_list[start_ver], vertex_list[end_ver])



if __name__ == "__main__":
    main()