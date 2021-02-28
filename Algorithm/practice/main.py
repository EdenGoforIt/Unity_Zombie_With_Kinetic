import sys

class Vertex:

    def __init__(self, vertex_id):
        self.vertex_id = vertex_id
        self.edge_list = list()
        self.visited = False
        self.parent = None
        self.distance = float('inf')

    def add_neighbor(self, edge):
        self.edge_list.append(edge)
        self.edge_list.sort(key= lambda x:x.to_vertex, reverse=True)
        #self.edge_list = sorted(key=lambda x:x.to_vertex, reverse=True)
    def __lt__(self, other):
        return self.distance < other.distance

class Edge:

    def __init__(self, to_vertex, weight):
        self.to_vertex = to_vertex
        self.weight = weight


def wormhole(adj_list, number):
    current = adj_list[0]
    current.distance=0
    for i in range(number-1):
        if

#https://ratsgo.github.io/data%20structure&algorithm/2017/11/27/bellmanford/
def main():
    case_num = int(sys.stdin.readline())
    answer_list = list()
    for c_num in range(case_num):
        adj_list = list()
        star_num, worm_num = map(int, sys.stdin.readline().split())
        for s_num in range(star_num):
            vertex = Vertex(s_num)
            adj_list.append(vertex)
        for w_num in range(worm_num):
            from_ver, to_ver, weight = map(int, sys.stdin.readline().split())
            start_ver= adj_list[from_ver]
            to_ver = adj_list[to_ver]
            start_ver.add_neighbor(Edge(to_ver, weight))
        answer = wormhole(adj_list, star_num)

    for answer in answer_list:
        print(answer)





if __name__ == "__main__":
    main()