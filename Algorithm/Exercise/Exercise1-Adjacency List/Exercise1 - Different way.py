class Vertex:
    def __init__(self, id=None, list=None):
        self._id = id
        self._list=list()

    def add_vertex(self):
        self._list.append(self._id)


class Graph:

    def __init__(self, graph_dic=None, neighbor_list=None):
        if graph_dic is None:
            graph_dic = dict()
            neighbor_list = list()
        self._graph_dict = graph_dic
        self._neighbor_list = neighbor_list


    def add_vertex(self, number_of_vertices):
        self._graph_dict = {new_list: [] for new_list in range(number_of_vertices)}

    def add_edge(self, start, end):
        if start in self._graph_dict.keys():
            self._graph_dict[start].append(end)
            """needs to be sorted"""

    def return_graph(self):
        for key, value in self._graph_dict.items():
            if value:
                list_values = ' '.join("{0}".format(n) for n in value)
                print("{vertex}: {neighbor}".format(vertex=key, neighbor=list_values))



if __name__ == "__main__":
    g = Graph()

    how_many_vertices = input()
    g.add_vertex(int(how_many_vertices))

    while True:
        a, b = input().split()

        if int(a) == -1 and int(b) == -1:
            g.return_graph()
            break
        g.add_edge(int(a), int(b))
