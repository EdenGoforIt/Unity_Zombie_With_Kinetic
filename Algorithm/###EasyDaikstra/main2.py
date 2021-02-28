import sys


class Vertex:

    def __init__(self, vertex_id):
        self.vertex_id = vertex_id
        self.edge_list = list()
        self.distance = sys.maxsize
        self.visited = False
        self.parent = None

    def add_neighbor(self, to_vertex, weight):
        edge = Edge(to_vertex, weight)
        self.edge_list.append(edge)

    def sort_edge_list(self):
        self.edge_list = sorted(self.edge_list, key=lambda x: x.edge_list.to_vertex)

    def is_not_visited(self):
        if self.visited is None:
            return True
        return False

    def is_visited(self):
        if self.visited is True:
            return True
        return False


class Edge:

    def __init__(self, to_vertex, weight):
        self.to_vertex = to_vertex
        self.distance = weight


class Graph(object):

    def daikstra(self, adj_list, source, destination):
        queue = adj_list
        visited = list()
        adj_list[source].distance = 0
        current = adj_list[source]
        




            minimum_node = None
            ##update the vertex distance
            ##find the vertex having shortest distance
            for edge in current.edge_list:
                if edge.to_vertex.weight > edge.weight:
                    edge.to_vertex.weight = edge.weight
                if minimum_node is None:
                    minimum_node = edge.to_vertex
                if edge.to_vertex.weight < adj_list[minimum_node.vertex_id].distance:
                    minimum_node = edge.to_vertex

            queue.append(minimum_node)
            ##append to the queue.
            ##find the

    def shortest_path(self, adj_list, source, destination):
        result = self.daikstra(adj_list, source, destination)
        ## result might be a list and make a stack for that going back to the desitnation

        weight = 0
        que = list()
        result_list = list()
        que.append(adj_list[destination])
        while len(que) > 0:
            cur = que.pop(0)
            if adj_list[cur.vertex_id].parent:
                parent = adj_list[cur.vertex_id].parent
                que.append(parent)
                result_list.insert(0, parent)
                weight = weight + parent.edge_list[cur.vertex_id].distance
                if parent == adj_list[source]:
                    sys.stdout.write("{0}\n", weight)
                if adj_list[cur.vertex_id].parent is None:
                    sys.stdout.write("{0}\n", "NO")


def main():
    number_of_cases = sys.stdin.readline()
    number_of_cases = number_of_cases.rstrip('\n')
    for case_num in (0, number_of_cases):
        adj_list = list()
        line_two = sys.stdin.readline()
        line_two = line_two.rstrip('\n')
        line_two = line_two.split(" ")
        vertex_num = int(line_two[0])
        edge_num = int(line_two[1])
        for x in range(0, vertex_num):
            vertex = Vertex(x)
            adj_list.append(vertex)

        for xx in range(0, edge_num):
            line_three = sys.stdin.readline()
            line_three = line_three.rstrip('\n')
            line_three = line_three.split(" ")
            from_vertex = int(line_three[0])
            to_vertex = int(line_three[1])
            distance = int(line_three[2])
            adj_list[from_vertex].add_neighbor(to_vertex, distance)

        line_four = sys.stdin.readline()
        line_four = line_four.rstrip('\n')
        line_four = line_four.split(" ")
        source = int(line_four[0])
        destination = int(line_four[1])
        graph = Graph()
        graph.shortest_path(adj_list, source, destination)


if __name__ == "__main__":
    main()

