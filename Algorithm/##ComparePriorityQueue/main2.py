import heapq
import sys

class Vertex:

    def __init__(self, vertex_id):
        self.vertex_id = vertex_id
        self.key = float('inf')
        self.edge_list = list()
        self.visited = False

    def is_not_visited(self):
        if self.visited is False:
            return True
        return False

    def __lt__(self, other):
        return self.vertex_id < other.vertex_id

class Edge:

    def __init__(self, to_vertex, weight):
        self.to_vertex = to_vertex
        self.weight = weight


def find_the_smallest_vertex(queue):
    pass


def linear_daikstra(c_num, start_vertex, end_vertex, vertices_list):
    queue = vertices_list
    visited_list = list()
    current_ver = start_vertex
    current_ver.key = 0

    while queue:
        current_ver = find_the_smallest_vertex(queue)
        for edge in current_ver.edge_list:
            if edge.to_vertex.is_not_visited():
                total_weight = current_ver.key + edge.weight
                if total_weight < edge.to_vertex.key:
                    edge.to_vertex.key = total_weight
                    edge.to_vertex.parent = current_ver
        current_ver.visited = True
        visited_list.append(current_ver)

    for x in visited_list:
        if x.vertex_id == end_vertex.vertex_id:
            print()

def load_num_case():
    return int(sys.stdin.readline().strip())

def main():
    case_list = list()
    n_case = load_num_case()
    for c_num in range(n_case):
        vertices_list = list()
        num_ver_edge = sys.stdin.readline()
        num_ver_edge = (num_ver_edge.rstrip('\n')).split(" ")
        vertex_num = int(num_ver_edge[0])
        edge_num = int(num_ver_edge[1])
        for v_num in range(vertex_num):
            vertex = Vertex(v_num)
            vertices_list.append(vertex)
        start_end = sys.stdin.readline().rstrip('\n')
        start_end = start_end.split(" ")
        start_vertex = int(start_end[0])
        end_vertex = int(start_end[1])

        for edge_num in range(edge_num):
            from_to_weight = sys.stdin.readline().rstrip('\n')
            from_to_weight = from_to_weight.split(" ")
            from_vertex = int(from_to_weight[0])
            to_vertex = int(from_to_weight[1])
            weight = int(from_to_weight[2])
            edge = Edge(vertices_list[to_vertex], weight)
            vertices_list[from_vertex].edge_list.append(edge)

        # heap_daikstra(c_num, vertices_list[start_vertex], vertices_list[end_vertex], vertices_list)
        # sort_daikstra(c_num, vertices_list[start_vertex], vertices_list[end_vertex], vertices_list)

        linear_daikstra(c_num, vertices_list[start_vertex], vertices_list[end_vertex], vertices_list)


if __name__ == "__main__":
    main()


