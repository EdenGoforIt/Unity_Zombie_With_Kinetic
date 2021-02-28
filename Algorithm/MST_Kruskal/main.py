import sys

class Edge:

    def __init__(self, start_ver, to_vertex, weight):
        self.start_ver = start_ver
        self.to_vertex = to_vertex
        self.weight = weight
        self.spanning_tree = False

    # def __lt__(self, other):
    #     return self.weight < other.weight


class UnionFind:

    def __init__(self, ver_num):
        self.parent = None
        self.create_set(ver_num)

    def create_set(self, ver_num):
        self.parent = list(range(ver_num))
        ##parent[0]=0, parent[1]=0,,,,,,5

    def find_set(self, ver_num):
        if self.parent[ver_num] != ver_num:
            self.parent[ver_num] = self.find_set(self.parent[ver_num])
        return self.parent[ver_num]

    def merge_set(self, one_ver, two_ver):
        self.parent[self.find_set(one_ver)] = self.find_set(two_ver)

def MST_Kruskal(ver_num, edge_list):

    union_find = UnionFind(ver_num)
    mst_tree = list()
    edge_list.sort(key=lambda vertex: vertex.weight)
    for edge in edge_list:
        if not edge.spanning_tree:
            if union_find.find_set(edge.start_ver) != union_find.find_set(edge.to_vertex):
                mst_tree.append(edge)
                if len(mst_tree) == ver_num - 1:
                    edge.spanning_tree = True
                union_find.merge_set(edge.start_ver, edge.to_vertex)
            edge_list.sort(key=lambda vertex: vertex.weight)
        else:
            return
    total = 0
    for x in mst_tree:
        total += x.weight
    print(total)




def main():
    edge_list = list()
    vertex_num, edge_num = map(int, (sys.stdin.readline().split()))
    for e in range(edge_num):
        start, end, weight = map(int, sys.stdin.readline().split())
        edge = Edge(start-1, end-1, weight)
        edge_list.append(edge)

    MST_Kruskal(vertex_num, edge_list)

if __name__== "__main__":
    main()
