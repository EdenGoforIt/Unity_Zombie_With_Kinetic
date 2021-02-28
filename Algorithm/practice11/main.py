import heapq
import sys

class Vertex:

    def __init__(self, vertex_id):
        self.vertex_id = vertex_id
        self.edge_list = list()
        self.key = float('inf')
        self.visited = False
        self.parent = None


    def is_not_visited(self):
        if self.visited is False:
            return True
        return False

    def add_neighbor(self,edge):
        self.edge_list.append(edge)

    def __lt__(self, other):
        return self.key < other.key

class Edge:

    def __init__(self, to_vertex, weight):
        self.to_vertex = to_vertex
        self.weight = weight

def main():
    case_list= list()
    case_num = int(sys.stdin.readline())
    for c_num in range(0, case_num, 1):
        vertices_list = list()
        first_line = sys.stdin.readline().split(" ")
        vertex_num = int(first_line[0])
        edge_num = int(first_line[1])
        for x in range(0, vertex_num):
            vertex = Vertex(x)
            vertices_list.append(vertex)
        for xx in range(0, edge_num):
            second_line = sys.stdin.readline().split(" ")
            from_ver = int(second_line[0]) - 1
            to_ver = int(second_line[1]) - 1
            weight = int(second_line[2])
            edge = Edge(vertices_list[to_ver], weight)
            vertices_list[from_ver].add_neighbor(edge)
        third_line = sys.stdin.readline().split(' ')
        source_ver = int(third_line[0])
        des_ver = int(third_line[1])
        save_list = SaveList(vertices_list, vertices_list[source_ver - 1], vertices_list[des_ver - 1])
        case_list.append(save_list)

    for c in case_list:
        daikstra(c.list, c.source, c.des)



def daikstra(vertices_list, source, dest):

    visited_list = list()
    star_ver = source
    star_ver.key = 0
    heapq.heapify(vertices_list)
    while vertices_list:
        current = vertices_list.pop(0)
        for edge in current.edge_list:
            if edge.to_vertex.is_not_visited():
                total_weight = current.key + edge.weight
                if total_weight < edge.to_vertex.key:
                    edge.to_vertex.key = total_weight
                    edge.to_vertex.parent = current
        current.visited = True
        visited_list.append(current)
        heapq.heapify(vertices_list)
        if current.vertex_id == dest.vertex_id:
            break

    t_weight = 0
    for we in visited_list:
        if we.vertex_id == dest.vertex_id:
            t_weight = we.key

    if t_weight == 0 or t_weight == float('inf'):
        sys.stdout.write("\n{0}".format("NO"))
    else:
        sys.stdout.write("\n{0}".format(t_weight))







class SaveList:

    def __init__(self, list, source ,des):
        self.list = list
        self.source = source
        self.des = des

if __name__ == "__main__":
   main()


