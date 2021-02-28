import sys


class Vertex:

    def __init__(self, vertex_id):
        self.vertex_id = vertex_id
        self.edge_list = list()
        self.parent = None
        self.status = None

    def is_discovered(self):
        if self.status == 1:
            return True
        return False

    def add_neighbor(self, destination, coming_weight):
        edge = Edge(destination, coming_weight)
        self.edge_list.append(edge)
        self.sort_list()

    def sort_list(self):
        self.edge_list = sorted(self.edge_list, key=lambda x: x.destination.vertex_id)

class Edge:

    def __init__(self, destination, coming_weight):
        self.destination = destination
        self.weight = coming_weight



def shortest_path_weighted(vertices_list):

        for x in vertices_list:
            sys.stdout.write("{0}:".format(x.vertex_id))
            for xx in x.edge_list:
                sys.stdout.write(" {0}".format(xx.destination.vertex_id))
                sys.stdout.write("({0})".format(xx.weight))
            if x.vertex_id < len(vertices_list) - 1:
                sys.stdout.write("\n")







if __name__ == "__main__":

    vertices_list = list()

    vertex_number = sys.stdin.readline()
    vertex_number = int(vertex_number)

    for x in range(0, vertex_number):
        vertex = Vertex(x)
        vertices_list.append(vertex)

    edge_numbers = sys.stdin.readline()
    edge_numbers = edge_numbers.rstrip('\n')

    while edge_numbers!="#":
        edge_numbers = edge_numbers.split(' ')
        from_vertex = int(edge_numbers[0])
        to_vertex = int(edge_numbers[1])
        weight = int(edge_numbers[2])
        vertices_list[from_vertex].add_neighbor(vertices_list[to_vertex],weight)
        edge_numbers = sys.stdin.readline()
        edge_numbers = edge_numbers.rstrip('\n')


    shortest_path_weighted(vertices_list)

